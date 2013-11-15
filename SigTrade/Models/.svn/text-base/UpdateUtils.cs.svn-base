using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;
using MailMessage = System.Net.Mail.MailMessage;
using System.Text;
using System.Net.Mail;

namespace SigTrade.Models
{
    public class UpdateUtils
    {

        public const string ANIMALS = "animals";
        public const string PLANTS = "plants";

        public const string PHYLUM = "phylum";
        public const string CLASS = "class";
        public const string ORDER = "order";
        public const string FAMILY = "family";
        public const string GENUS = "genus";
        public const string SPECIES = "species";

        public const string SELECTION = "Selection Stage";
        public const string CATEGORIZATION = "Categorization";
        public const string RECOMMENDATIONS = "Recommendations";
        public const string DECISIONS = "Decisions";
        public const string REVIEWSTATUS = "status";

        public const string TYPE_KINGDOM = "kingdom";
        public const string TYPE_REVIEW = "reviewtype";
        public const string TYPE_TAXONLEVEL = "taxonlevel";
        public const string TYPE_CONCERN = "concern";

        public const int URGENT_CONCERN_ID = 1;
        public const int POSSIBLE_CONCERN_ID = 2;
        public const int LEAST_CONCERN_ID = 3;
        public const int NOT_CLASSIFIED_ID = 4;


        public const string URGENT_CONCERN = "Urgent Concern";
        public const string POSSIBLE_CONCERN = "Possible Concern";
        public const string LEAST_CONCERN = "Least Concern";
        public const string NOT_CLASSIFIED = "Not Classified";

        public const int PARAGRAPH_SOURCE = 1;
        public const int DECISION_SOURCE = 3;
        public const int RECOMMENDATION_SOURCE = 2;

        public const string DOCPATH = @"\\wcmc-data-01.internal.wcmc\Programs\PROGRAMMES\CPS\SPECIES\06 IT & library\AJTest";
        public const int DOC_HYPERLINK = 1;
        public const int DOC_UPLOADED = 2;

        public const string REVIEW_NORMAL = "normal";
        public const string REVIEW_ADHOC = "adhoc";

        public const string SELECT_ALL = "-2";

        public const string SEARCH_FREE = "freesearch";
        public const string SEARCH_COUNTRY = "countrysearch";
        public const string SEARCH_ALL = "searchall";

        public const string ALL_KINGDOM = "all";

        public const string TYPE_DECISION = "decisiontype";
        public const string TYPE_TRADETERMS = "tradeterms";

        public const string NO_PARAGRAPH = "Not Started Yet";
        public const string ROLE_ADMINISTRATOR = "Administrator";
        public const string ROLE_DATA_MANAGER = "Data Manager";
        public const string ROLE_DATA_CONTRIBUTOR = "Data Contributor";
        public const string ROLE_FULL_VIEWER= "Full Viewer";
        public const string ROLE_INTERMEDIATE_VIEWER = "Intermediate Viewer";
        public const string ROLE_PUBLIC_VIEWER = "Public Viewer";
        public const string ROLE_ALL = "ALL";

        public const string SMTP_RELAY_SERVER = "email-filter.unep-wcmc.org";

        public const int DEFAULT_PAGE_SIZE = 15;


        //Locale Information
        public const string ENGLISH_EN = "";
        public const string FRENCH_FR = "fr-FR";
        public const string SPANISH_ES = "es-ES";

        public static DateTime getDateUK(string date)
        {
            CultureInfo cultEnGb = new CultureInfo("en-GB");
            CultureInfo cultEnUs = new CultureInfo("en-US");
            DateTime dtGb = Convert.ToDateTime(date, cultEnGb.DateTimeFormat);
            return dtGb;
        }

        public static void InsertMeetingLib(FormCollection collection)
        {
            IMeetingLibRepository MeetingLibRep = new MeetingLibRepository();

            MeetingLib m = new MeetingLib();
            
            m.MeetingLibDesc = collection["MeetingLibDesc"];
            m.MeetingLibNumber = collection["MeetingLibNumber"];
            m.MeetingLibDate = DateTime.Parse(collection["meeting_date"]);
            m.DateAdded = DateTime.Now;
            m.DateModified = DateTime.Now;
            
            MeetingLibRep.Save(m);
            return;
        }

        public static void UpdateMeetingLib(MeetingLib m, FormCollection collection)
        {
            IMeetingLibRepository MeetingLibRep = new MeetingLibRepository();

            m.MeetingLibDesc = collection["MeetingLibDesc"];
            m.MeetingLibNumber = collection["MeetingLibNumber"];
            m.MeetingLibDate = DateTime.Parse(collection["meeting_date"]);
            m.DateModified = DateTime.Now;
            

            MeetingLibRep.Save(m);
            return;
        }

        public static int InsertParagraphActionForm(FormCollection collection)
        {
            IReviewRepository reviews = new ReviewRepository();
            IGenericRepository generics = new GenericRepository();

            ParagraphAction pa = new ParagraphAction();

            int palibid = int.Parse(collection["PALibID"]);
            int reviewid = int.Parse(collection["ReviewID"]);
            pa.PALibID = palibid;
            pa.DateStarted = DateTime.Parse(collection["pda_started_date"].ToString());
            pa.DeadlineDate = DateTime.Parse(collection["pda_deadline_date"].ToString());
            pa.MeetingID = int.Parse(collection["meetings"]);
            pa.ReviewID = reviewid;         
            //string concern = collection["concerns"].ToString();)

            if (collection["concerns"] != null)
            {
                string concern = collection["concerns"].ToString();
                switch(concern)
                {
                    case UpdateUtils.URGENT_CONCERN:
                        pa.ConcernID = UpdateUtils.URGENT_CONCERN_ID;
                        
                        break;
                    case UpdateUtils.POSSIBLE_CONCERN:
                        pa.ConcernID = UpdateUtils.POSSIBLE_CONCERN_ID;
                        break;
                    case UpdateUtils.LEAST_CONCERN:
                        pa.ConcernID = UpdateUtils.LEAST_CONCERN_ID;
                        break;
                    case UpdateUtils.NOT_CLASSIFIED:
                        pa.ConcernID = UpdateUtils.NOT_CLASSIFIED_ID;
                        break;
                }
                TblReview review = reviews.getSingleReviewEdit(reviewid);
                review.ConcernID = pa.ConcernID;
                DB.Save(review);
                generics.resetCurrentConcernForReview(reviewid);
                pa.CurrentConcern = true;
            }
            else
            {
                pa.ConcernID = UpdateUtils.NOT_CLASSIFIED_ID;
                pa.CurrentConcern = true;
            }
            
            string completed = collection["completed"];
           
            if ((completed!=null) && (completed.Equals("on")))
            {
                DateTime dateCompleted = DateTime.Now;
                if (collection["pda_completed_date"] != null && collection["pda_completed_date"].Length > 0) {
                    dateCompleted = DateTime.Parse(collection["pda_completed_date"]);
                    pa.CompletedDate = dateCompleted;
                }
                else {
                    pa.CompletedDate = dateCompleted;
                }             
                pa.Completed = true;
            }

            pa.DateAdded = DateTime.Now;
            return reviews.SavePA(pa);
        }

        public static int InsertComments(FormCollection collection, int SourceID, int SourceType)
        {
            ICommentsRepository comments = new CommentsRepository();

            Comment c = new Comment();

            c.Comments = collection["S1"];
            c.DateAdded = DateTime.Now;
            c.RoleAccess = collection["ddCommentType"];
            //c.UserID = collection["UserID"];
            c.UserID = Membership.GetUser().ToString();
            c.SourceID = SourceID;
            c.SourceType = SourceType;

            return comments.Save(c);

        }

        //function to save users for a paragraph
        public static void InsertUsersPerParagraph(FormCollection collection, int SourceID, int SourceType)
        {
            IGenericRepository generics = new GenericRepository();


            string selectedusers = collection["users"];

            string[] allusers = selectedusers.Split(',');
            int count = allusers.Length;

            if (count > 0)
                generics.DeleteUser(null, SourceID, SourceType);

                
            for (int i = 0; i < count; i++)
            {
                UsersParagraphLink user = new UsersParagraphLink();

                user.DateAdded = DateTime.Now;
                user.UserID = Membership.GetUser(allusers[i]).ProviderUserKey.ToString();
                user.SourceID = SourceID;
                user.SourceType = SourceType;
                generics.SaveUser(user);
                
            }
        }

        public static string[] getViewersList()
        {
            string[] list = {UpdateUtils.ROLE_FULL_VIEWER, UpdateUtils.ROLE_INTERMEDIATE_VIEWER,UpdateUtils.ROLE_PUBLIC_VIEWER};
            return list;
        }

        public void DeleteUsers(string[] users, int SourceID, int SourceType)
        {
            IGenericRepository generics = new GenericRepository();
            int count = users.Length;
            for (int i=0;i<count;i++)
            {
                generics.DeleteUser(users[i],SourceID,SourceType);

            }

        }

        public static int InsertDocuments(FormCollection collection, int SourceID, int SourceType)
        {
            IDocumentsRepository documents = new DocumentsRepository();

            Document d = new Document();

            d.DateAdded = DateTime.Now;
            d.DocName = collection["DocName"];
            d.DocPath = collection["DocPath"];
            d.RoleAccess = collection["DocAccess"];
            d.DocLegend = collection["txtDocLegend"];

            string docType = collection["docfiletype"];

            if (docType.Equals("upload"))
                d.DocumentType = UpdateUtils.DOC_UPLOADED;
            else if (docType.Equals("hyperlink"))
            {
                d.DocumentType = UpdateUtils.DOC_HYPERLINK;
            }
            d.SourceID = SourceID;
            d.SourceType = SourceType;
            //d.UserID = collection["UserID"];
            d.UserID = Membership.GetUser().ToString();
            
            return documents.Save(d);

        }


        //Method to retrieve the current user
        public static MembershipUser getCurrentMembershipUser()
        {
            
            MembershipUser u = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            return u;
        }

        public static IList<DecisionDetails> GetDecisionDetails (IList<Decision> decisions)
        {
            IList<DecisionDetails> decDetails = new List<DecisionDetails>();
           // IList<DecisionDetails> decDetails;
            IGenericRepository gens = new GenericRepository();
            Decision decision;


            int decCount = decisions.Count;
            for (int i = 0; i < decCount;i++ ) {

                decision = decisions[i];
                DecisionDetails decDetail = new DecisionDetails();

               
                decDetail.DecisionId = decision.Id;
                decDetail.DecisionType =
                gens.GetDescriptionByType(decision.DecisionType, UpdateUtils.TYPE_DECISION);
                decDetail.TradeTerms =
                    gens.GetDescriptionByType(decision.TradeTerms, UpdateUtils.TYPE_TRADETERMS);
                decDetail.DecisionDate = DateTime.Parse(decision.SuspensionDate.ToString());
                if (decision.SuspensionLiftDate != null)
                 decDetail.LiftingDate = DateTime.Parse(decision.SuspensionLiftDate.ToString());
                

                decDetails.Insert(i,decDetail);
                                    
            }


                return decDetails;

        }

        internal static void SendPasswordResetNotification(MembershipUser emailRecipient, String emailDetails)
        {
            MessageTemplate message_to_send = DB.Select()
                        .From(MessageTemplate.Schema)
                        .Where("Deleted").IsNotEqualTo(true)
                        .And("MessageType").IsEqualTo('R')
                        .ExecuteSingle<MessageTemplate>();
            if (message_to_send.Disabled)
                return;
            List<MembershipUser> recipient = new List<MembershipUser>();
            recipient.Add(emailRecipient);
            build_send_and_log_notification(recipient, message_to_send, emailDetails);
        }

        internal static void SendDocumentUploadNotification(string username, int documentid)
        {
            MessageTemplate message_to_send = DB.Select()
                                    .From(MessageTemplate.Schema)
                                    .Where("Deleted").IsNotEqualTo(true)
                                    .And("MessageType").IsEqualTo('D')
                                    .ExecuteSingle<MessageTemplate>();
            if (message_to_send != null && message_to_send.Disabled)
                return;

            MembershipUser submitter = Membership.GetUser(username);
            List<MembershipUser> recipient = new List<MembershipUser>();
            String[] administrators = Roles.GetUsersInRole("Administrator");
            foreach (String user in administrators)
                recipient.Add(Membership.GetUser(user));

            Document d = DB.Select().From(Document.Schema).Where("ID").IsEqualTo(documentid).ExecuteSingle<Document>();
            StringBuilder emailDetails = new StringBuilder();
            emailDetails.AppendLine("Document Title: " + d.DocName);
            emailDetails.AppendLine("Date:" + ((DateTime) d.DateAdded).ToShortDateString());
            emailDetails.Append("Submitted By: " + submitter.UserName + "\n\n");
            build_send_and_log_notification(recipient, message_to_send, emailDetails.ToString());
        }

        private static void build_send_and_log_notification(List<MembershipUser> recipients, MessageTemplate template, String emailDetails)
        {
            //MODIFY TO SEND EMAIL TO ONLY ONE SPECIFIC ADMINISTRATOR
            foreach (MembershipUser recipient in recipients) {
                try {
                    MailMessage mail = new MailMessage();
                    ///mail.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["Email_Sender"]);
                    mail.From = new MailAddress("ackbar.joolia@unep-wcmc.org", "SigTrade System");
                    if (recipient.Email != null && recipient.Email.Length > 0)
                    {
                        mail.To.Add(recipient.Email);
                    }
                    else
                    {
                        break;
                    }
                    mail.Subject = template.Title;

                    StringBuilder emailBody = new StringBuilder();
                    emailBody.Append(template.Body + "\n\n");
                    emailBody.Append(emailDetails);
                    mail.Body = emailBody.ToString();

                    //send the message
                    SmtpClient smtp = new SmtpClient(UpdateUtils.SMTP_RELAY_SERVER, 25);
                    smtp.Send(mail);
                }
                catch (Exception e) {
                    throw new Exception("Error sending message: " + e.Message);
                }
            }

            //try
            //{
            //    MailMessage mail = new MailMessage();
            //    ///mail.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["Email_Sender"]);
            //    mail.From = new MailAddress("ackbar.joolia@unep-wcmc.org", "SigTrade System");
            //    mail.To.Add("ackbar.joolia@unep-wcmc.org");
            //    mail.Subject = template.Title;

            //    StringBuilder emailBody = new StringBuilder();
            //    emailBody.Append(template.Body + "\n\n");
            //    emailBody.Append(emailDetails);
            //    mail.Body = emailBody.ToString();

            //    //send the message
            //    SmtpClient smtp = new SmtpClient(UpdateUtils.SMTP_RELAY_SERVER, 25);
            //    smtp.Send(mail);
            //}
            //catch
            //   (Exception e) {
            //    throw new Exception("Error creating log: " + e.Message);
            //}
        }
    }
}
