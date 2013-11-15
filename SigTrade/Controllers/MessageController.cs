using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Security;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;
using SigTrade.Models;
using MailMessage=System.Net.Mail.MailMessage;

namespace SigTrade.Controllers
{
    public class MessageController : Controller
    {
        //
        // GET: /Message/SendAlerts
        public ActionResult SendAlerts()
        {
            //GET UNIQUE LIST OF ALL USERS WHO HAVE ACTIVE PARAGRAPHS (PARAGRAPH.COMPLETE=0)
            IList<SigtradeUser> users_with_active_paragraphs = DB.Select("UserID")
                .From(UsersParagraphLink.Schema)
                .InnerJoin(ParagraphAction.IdColumn, UsersParagraphLink.SourceIDColumn)
                .Where("Deleted")
                .IsNotEqualTo(true)
                .And("Completed")
                .IsEqualTo(false).Distinct()
                .ExecuteTypedList<SigtradeUser>();
            //GET ALL TEMPLATES
            MessageTemplateCollection messages_to_send = DB.Select()
                                                .From(MessageTemplate.Schema)
                                                .Where("Deleted").IsNotEqualTo(true)
                                                .And("MessageType").IsEqualTo('A')
                                                .ExecuteAsCollection<MessageTemplateCollection>();

            //FOR EACH TEMPLATE - WARNING - GONNA BE SLOW.
            foreach (MessageTemplate template in messages_to_send)
            {
                
                //FOR EACH USER
                foreach (SigtradeUser user in users_with_active_paragraphs)
                {
                    //GET ALL ACTIVE PARAS FOR USER
                    ParagraphActionCollection active_paragraphs = DB.Select("PALibID", "ReviewID","DeadlineDate","UserID")
                        .From(ParagraphAction.Schema)
                        .InnerJoin(UsersParagraphLink.SourceIDColumn, ParagraphAction.IdColumn)
                        .WhereExpression("UserID").IsEqualTo(user.userid)
                        .Distinct()
                        .ExecuteAsCollection<ParagraphActionCollection>();

                    //ONLY ATTEMPT EMAIL IF THE USER HAS ACTIVE PARAS
                    if (active_paragraphs.Count() > 0)
                    {
                        ParagraphActionCollection paras_for_email = new ParagraphActionCollection();

                        //STRIP OUT ALL THE PARAS THAT SHOULD BE SENT IN ALERT - MOVE UP TO SQL LATER
                        foreach (ParagraphAction action in active_paragraphs)
                        {
                            if (should_send((DateTime) action.DeadlineDate, template.DaysDelta))
                                paras_for_email.Add(action);
                        }

                        //FINALLY, IF WE SHOULD SEND AN ALERT TO THE USER, BUILD AND SEND
                        if (paras_for_email.Count() > 0)
                        {
                            build_send_and_log_message(user, template, paras_for_email);
                        }
                    }
                }
            }

            return View();
        }

        /**
         * This function should construct and send the email finally
         * 
         * NOT FINISHED!!!
         */
        private void build_send_and_log_message(SigtradeUser user, MessageTemplate template, ParagraphActionCollection paras)
        {
            //create the mail message
            MailMessage mail = new MailMessage();

            //set the addresses
            mail.From = new MailAddress("ackbar.joolia@unep-wcmc.org");

            //Finding user through membership Api 

            MembershipUser my_user = Membership.GetUser(new Guid(user.userid));
            mail.To.Add(my_user.Email);
            //mail.To.Add(user); //MUST USE MEMBERSHIP API TO FIND USER AND PROFILE SETTINGS (INCL EMAIL) NOT WORKING

            //set the content
            mail.Subject = template.Title;
            StringBuilder emailBody = new StringBuilder();

            var userProfile = Profile.GetProfile(my_user.UserName);

            mail.Body = template.Body;
            emailBody.AppendLine("Dear " + userProfile.first_name + ' ' + userProfile.last_name);
            emailBody.AppendLine(template.Body);

            //Need to get the paragraph details
            IReviewRepository reviews = new ReviewRepository();
            ITaxonRepository taxon = new TaxonRepository();

            foreach (ParagraphAction para in paras)
            {
                var review = reviews.getSingleReview(para.ReviewID);
                var paragraph = reviews.getSinglePALib(para.PALibID);
                review.TaxonName = taxon.getReviewTaxonName(review.ID, review.Taxontype, review.Kingdom);
                //mail.Body = mail.Body.Concat(para.DeadlineDate.ToString()); //SOME SORT OF WARNING HERE!
                var review_type = review.TaxonName + " [" + review.CtyShort + "]";
                emailBody.AppendLine("Review:" + review_type);
                emailBody.AppendLine("Paragraph details: " + paragraph.Action + " (" + ((DateTime)para.DeadlineDate).ToShortDateString() + ')');
                emailBody.AppendLine();
                //mail.Body = mail.Body;
            }
            emailBody.AppendLine();
            emailBody.AppendLine(Resources.SigTrade.emailFooter);
            mail.Body = emailBody.ToString();
           
            //send the message
            SmtpClient smtp = new SmtpClient(UpdateUtils.SMTP_RELAY_SERVER,25);
            try
            {
                smtp.Send(mail);   
            }
            catch(SmtpException e)
            {
                   
            }
            

            //HERE WE SHOULD WRITE TO THE LOG TABLE.
            //Prepare the MessageLog object
            MessageLog log = new MessageLog();
            log.SentTo = my_user.Email;
            log.SentAt = DateTime.Today;
            log.Title = template.Title;
            log.Body = emailBody.ToString();
            write_to_message_log(log);

        }

        /**
         * FUNCTION TO WRITE TO THE MESSAGELOG TABLE
         * 
         * 
         * */
        private void write_to_message_log(MessageLog m)
        {
            IMessageLogRepository messageLog = new MessageLogRepository();
            messageLog.save(m);
        }

        /**
         * CALCULATES IF SHOULD SEND MESSAGE OR NOT
         * 
         * DAYS DELTA EXAMPLES:
         * 
         * -10 = USER WANTS REMINDER SENT 10 DAYS BEFORE DEADLINE
         * 0 = USER WANTS REMINDER SEND ON DAY OF DEADLINE
         * 10 = USER WANTS REMINDER SENT 10 DAYS AFTER DEADLINE
         * */
        private bool should_send(DateTime deadline, int days_delta)
        {
            DateTime now = DateTime.Now.Date;
            TimeSpan difference =  now - deadline; //RETURNS negative if before deadline, and positive if on or after deadline.
            bool send_or_not = difference.Days <= days_delta ? true : false;
            return send_or_not;
           // return true;
        }

        //GET: /MessageController/SendTestEmail
        public void SendTestEmail()
        {
            MailMessage message = new MailMessage();

            message.From = new MailAddress("ackbar.joolia@unep-wcmc.org");

            message.To.Add("ackbar7@gmail.com");
            message.Subject = "Hello Test";
            message.IsBodyHtml = true;


            message.Body = "This is a test";
            SmtpClient smtp = new SmtpClient(UpdateUtils.SMTP_RELAY_SERVER,25);

            // SmtpMail.SmtpServer = "email-filter.unep-wcmc.org";
            // SmtpMail.Send(message);
            smtp.Send(message);

        }

        // POST: /MessageController/SendTestEmail

        [AcceptVerbs(HttpVerbs.Post)]
        public int SendTestEmail(FormCollection collection)
        {
           return 1;
        }

    }
}
