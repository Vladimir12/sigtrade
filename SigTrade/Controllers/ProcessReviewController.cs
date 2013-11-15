using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Security;
using SignificantTrade.Models;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;
using SigTrade.Models;

namespace SigTrade.Controllers
{
    public class ProcessReviewController : Controller
    {
        //
        // GET: /ProcessReview/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /ProcessReview/Details/5

        public ActionResult Details(int id)
        {
            int ReviewID = id;

            IReviewRepository reviews = new ReviewRepository();
            ITaxonRepository taxon = new TaxonRepository();
            IGenericRepository generics = new GenericRepository();
            
            ReviewDesc review = reviews.getSingleReview(ReviewID);
            review.TaxonName = taxon.getReviewTaxonName(review.ID, review.Taxontype, review.Kingdom);
            bool completed = generics.getOldDataImportedStatus(ReviewID);

            ViewData["para31_completed"] = completed;
            ViewData["Title"] = review.TaxonName + " [" + review.CtyShort + "]";
            ViewData["Review"] = review;
            //ViewData["PAction"] = reviews.getParagraphDetails(review.)

            ViewData["NextPALibID"] = reviews.getNextParagraphForReview(ReviewID);
            var current_reviews = reviews.getAllPALibExtra(ReviewID);
            ViewData["PALibs"] = current_reviews;

            ViewData["para_contributor"] = null;
            foreach (var currentReview in current_reviews)
            {
                if ((currentReview.ReviewID > 0)  && !currentReview.Completed && (!completed))
                {
                    IList<UsersParagraphLink> users = generics.getUserBySource(currentReview.ID, UpdateUtils.PARAGRAPH_SOURCE);
                    int usercount = users.Count;
                    for (int j = 0; j < usercount; j++) {
                        users[j].UserID = Membership.GetUser(new Guid(users[j].UserID)).UserName;
                        if (User.Identity.IsAuthenticated) {
                            var current_user = User.Identity.Name;
                            if (users[j].UserID == current_user) {
                                ViewData["para_contributor"] = current_user;
                            }
                        }


                    }
                }
            }

            return View();
        }

        //
        // GET: /ProcessReview/DeleteComment
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        public ActionResult DeleteComment(int ID, int ReviewID_, int PALibID_)
        {
            ICommentsRepository comments = new CommentsRepository();
            //int ID = int.Parse(collection["ID"]);
            //int ReviewID_ = int.Parse(collection["ReviewID"]);
            //int PALibID_ = int.Parse(collection["PALibID"]);
            comments.DeleteComment(ID);

            //return PartialView("edit_comments");

            return RedirectToAction("ParagraphDetailsEdit", new { ReviewID = ReviewID_, PALibID = ReviewID_ });
            //return View();
        }


        // POST: /ProcessReview/DeleteComment
        [Authorize(Roles = UpdateUtils.ROLE_DATA_CONTRIBUTOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteComment(FormCollection collection)
        {
            ICommentsRepository comments = new CommentsRepository();
            int ID = int.Parse(collection["ID"]);
            int ReviewID_ = int.Parse(collection["ReviewID"]);
            int PALibID_ = int.Parse(collection["PALibID"]);
            int SourceID = int.Parse(collection["SourceID"]);
            int SourceType = int.Parse(collection["SourceType"]);
            string _contributor = collection["contributor"];
            comments.DeleteComment(ID);

            ViewData["Comments"] = comments.getCommentsByID(SourceID, SourceType, UpdateUtils.ROLE_ALL);
            ViewData["ReviewID"] = ReviewID_;
            ViewData["PALibID"] = PALibID_;
            ViewData["PActionID"] = SourceID;
            ViewData["contributor"] = _contributor;
          
            return PartialView("edit_comments");

            //return RedirectToAction("ParagraphDetailsEdit", new { ReviewID = ReviewID_, PALibID = PALibID_ });
            //return View();
        }

        //
        // GET: /ProcessReview/DeleteDoc
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        public ActionResult DeleteDocument(int ID, int ReviewID_, int PALibID_)
        {
            IDocumentsRepository docs = new DocumentsRepository();

            //int ID = int.Parse(collection["ID"]);
            //int ReviewID_ = int.Parse(collection["ReviewID"]);
            //int PALibID_ = int.Parse(collection["PALibID"]);
            docs.DeleteDocument(ID);


            //return PartialView("display_documents");
            return RedirectToAction("ParagraphDetailsEdit", new { ReviewID = ReviewID_, PALibID = PALibID_ });
            //return View();
        }

        // POST: /ProcessReview/DeleteDoc
        [Authorize(Roles = UpdateUtils.ROLE_DATA_CONTRIBUTOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteDocument(FormCollection collection)
        {
            IDocumentsRepository docs = new DocumentsRepository();

            int ID = int.Parse(collection["ID"]);
            int ReviewID_ = int.Parse(collection["ReviewID"]);
            int PALibID_ = int.Parse(collection["PALibID"]);
            int SourceID = int.Parse(collection["SourceID"]);
            int SourceType = int.Parse(collection["SourceType"]);
            string _contributor = collection["contributor"];
            docs.DeleteDocument(ID);

            ViewData["ReviewID"] = ReviewID_;
            ViewData["PALibID"] = PALibID_;
            ViewData["PActionID"] = SourceID;
            ViewData["contributor"] = _contributor;
            ViewData["Documents"] = docs.getDocumentsByID(SourceID, SourceType, UpdateUtils.ROLE_ALL);
            return PartialView("display_documents");
            //return RedirectToAction("ParagraphDetailsEdit", new { ReviewID = ReviewID_, PALibID = PALibID_ });
            //return View();
        }

        //

        //
        // GET: /ProcessReview/Create
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ProcessReview/Create

        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                collection["UserID"] = 1.ToString();
                int SourceID = UpdateUtils.InsertParagraphActionForm(collection);

                if (collection["S1"]!=null)
                {
                    collection["ddCommentType"] = collection["rolesc"].ToString();
                    int commentID = UpdateUtils.InsertComments(collection, SourceID, UpdateUtils.PARAGRAPH_SOURCE);
                }

                if(collection["selectedactorsadd"] !=null)
                {
                    collection["users"] = collection["selectedactorsadd"];
                    UpdateUtils.InsertUsersPerParagraph(collection, SourceID, UpdateUtils.PARAGRAPH_SOURCE);

                }

                if (collection["fileadd"] != null)
                {
                    collection["docfiletype"] = collection["fileadd"];
                    if (collection["docfiletype"].ToString().Equals("upload"))
                    {
                        foreach (string filename in Request.Files)
                        {
                            HttpPostedFileBase file = Request.Files[filename];

                            if (file.ContentLength > 0)
                            {
                                string filePath = Path.Combine(UpdateUtils.DOCPATH, Path.GetFileName(file.FileName));
                                file.SaveAs(filePath);

                                collection["DocName"] = file.FileName;
                                collection["DocPath"] = UpdateUtils.DOCPATH;
                                collection["DocAccess"] = collection["rolesd"].ToString();
                                int documentID = UpdateUtils.InsertDocuments(collection, SourceID,
                                                                             UpdateUtils.PARAGRAPH_SOURCE);
                            }
                        }
                    }
                    else if (collection["docfiletype"].ToString().Equals("hyperlink"))
                    {
                        collection["DocName"] = collection["txtHyperlink"];
                        collection["DocPath"] = null;
                        collection["DocAccess"] = collection["rolesd"];
                        int documentID = UpdateUtils.InsertDocuments(collection, SourceID,
                                                                     UpdateUtils.PARAGRAPH_SOURCE);
                    }
                }

                int ReviewID = int.Parse(collection["ReviewID"]);
                return RedirectToAction("Details", "ProcessReview", new { ID = ReviewID });
            }
            catch
            {
                return RedirectToAction("Search","SearchReview");
            }
        }

        //
        // POST: /ProcessReview/Test
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult  Test(string test)
        {
            try
            {
               
                    // TODO: Add insert logic here

                    ViewData["AJAX"] = "It worked:" + test;
               ITaxonRepository taxon = new TaxonRepository();

                IList <AGeneralTaxon> lists = taxon.getAPhylum();
            
                 return this.Json(lists.ToList());
                    
                
                //return RedirectToAction("Details");
            }
            catch
            {
                //return View();
               return null;
                
            }
        }

        // POST: /ProcessReview/SaveCompleted
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveCompleted(FormCollection collection)
        {
            try
            {
                IGenericRepository generics = new GenericRepository();
                IReviewRepository reviews = new ReviewRepository();
                int PActionID = int.Parse(collection["SourceID"].ToString());
                
                string completed = collection["ckCompleted"];

                DateTime dateCompleted = DateTime.Now;
                
                ParagraphAction PAction = reviews.getParagraphActionbyID(PActionID);
                int ReviewID = int.Parse(PAction.ReviewID.ToString());

                
                if (collection["selectedactorsedit"] != null)
                {
                    collection["users"] = collection["selectedactorsedit"];
                    UpdateUtils.InsertUsersPerParagraph(collection, PActionID, UpdateUtils.PARAGRAPH_SOURCE);
                }
               // string selected = collection["selectedactorsedit"].ToString();
              //  string[] listselected = selected.Split(',');

              //  int count = listselected.Length;
              //  for (int j = 0; j < count; j++)
              //  {
              //      string key = Membership.GetUser(listselected[j]).ProviderUserKey.ToString();
              //  }

                if (completed != null)
                {
                    PAction.Completed = true;
                    if (collection["edit_date_completed"] != null && collection["edit_date_completed"].Length > 0)
                    {
                        dateCompleted = DateTime.Parse(collection["edit_date_completed"]);
                    }
                   PAction.CompletedDate = dateCompleted;     
                }
                else
                {                   
                    PAction.Completed = false;
                    PAction.DateModified = DateTime.Now;
                }
                //Save the rest of the data
                var deadlineDate = collection["Deadline"] == null ? ((DateTime)PAction.DateStarted).AddDays(30) : DateTime.Parse(collection["Deadline"].ToString());
                var startedDate = DateTime.Parse(collection["DateStarted"]);
                PAction.DeadlineDate = deadlineDate;
                PAction.DateStarted = startedDate;
                if (collection["concerns"] != null)
                {
                    string concern = collection["concerns"];
                    switch (concern) {
                        case UpdateUtils.URGENT_CONCERN:
                            PAction.ConcernID = UpdateUtils.URGENT_CONCERN_ID;

                            break;
                        case UpdateUtils.POSSIBLE_CONCERN:
                            PAction.ConcernID = UpdateUtils.POSSIBLE_CONCERN_ID;
                            break;
                        case UpdateUtils.LEAST_CONCERN:
                            PAction.ConcernID = UpdateUtils.LEAST_CONCERN_ID;
                            break;
                        case UpdateUtils.NOT_CLASSIFIED:
                            PAction.ConcernID = UpdateUtils.NOT_CLASSIFIED_ID;
                            break;
                    }
                   
                    ParagraphAction topPA = generics.getParagraphActionPerReview(PAction.ReviewID.Value);
                    if (topPA.Id == PAction.Id)
                    {
                        TblReview review = reviews.getSingleReviewEdit(PAction.ReviewID);
                        review.ConcernID = PAction.ConcernID;
                        DB.Save(review);
                        generics.resetCurrentConcernForReview(PAction.ReviewID.Value);
                        PAction.CurrentConcern = true;   
                    }
                              
                }
                PAction.MeetingID = Int32.Parse(collection["Meetings"]);
                PAction.DateModified = DateTime.Now;

                int i= reviews.SavePA(PAction);

                return RedirectToAction("Details","ProcessReview", new {ID=ReviewID});
            }
            catch
            {
                //return View();
                return null;

            }
        }


        //
        // POST: /ProcessReview/ParagraphDetails

        [AcceptVerbs(HttpVerbs.Post)] 
        public ActionResult ParagraphDetails(int ReviewID, int PALibID, FormCollection form)
        {
            try
            {
                ITaxonRepository taxon = new TaxonRepository();
                IReviewRepository reviews = new ReviewRepository();
                IMembershipRepository members = new MembershipRepository();

                ReviewDesc review = reviews.getSingleReview(ReviewID);
                review.TaxonName = taxon.getReviewTaxonName(review.ID, review.Taxontype, review.Kingdom);

                ViewData["PATitle"] = review.TaxonName + "-" + review.Taxontype;
               
                ViewData["PALid"] = reviews.getSinglePALib(PALibID); 
                ParagraphActionDetails pad = reviews.getParagraphDetails(PALibID, ReviewID);

                ViewData["PADetails"] = pad;
                return View();
                //return RedirectToAction("Details");
            }
            catch
            {
                return null;
             }
        }

        public ActionResult ParagraphDetails(int ReviewID, int PALibID)
        {
            try
            {
                ITaxonRepository taxon = new TaxonRepository();
                IReviewRepository reviews = new ReviewRepository();
                IGenericRepository generic = new GenericRepository();
                IMeetingLibRepository mlib = new MeetingLibRepository();
                IMembershipRepository members = new MembershipRepository();
                ICommentsRepository comments = new CommentsRepository();
                IDocumentsRepository docs = new DocumentsRepository();

                ReviewDesc review = reviews.getSingleReview(ReviewID);
                review.TaxonName = taxon.getReviewTaxonName(review.ID, review.Taxontype, review.Kingdom);

                ViewData["allactorsadd"] = new SelectList(Membership.GetAllUsers());
                ViewData["selectedactorsedit"]= ViewData["allactorsedit"]=ViewData["selectedactorsadd"]=ViewData["allactors2"] = ViewData["allactorsadd"];
         
                
                ViewData["PATitle"] = review.TaxonName + "-" + review.Taxontype + "\\" + review.CtyShort;
                ViewData["Committees"] = new SelectList(generic.getAllCommitteesSelect(), "ID", "Description");
                ViewData["Meetings"] = new SelectList(mlib.getAllMeetingLibs(), "MeetingLibID", "MeetingLibDesc");
                ViewData["Roles"] = new SelectList(members.getAllRoles());
                ViewData["PALib"] = reviews.getSinglePALib(PALibID);
                ViewData["ReviewID"] = ReviewID;
                ParagraphActionDetails pad = reviews.getParagraphDetails(PALibID, ReviewID);

                if (pad != null)
                {
                    ViewData["Comments"] = comments.getCommentsByID(pad.ID, UpdateUtils.PARAGRAPH_SOURCE,UpdateUtils.ROLE_ALL);
                    ViewData["Documents"] = docs.getDocumentsByID(pad.ID, UpdateUtils.PARAGRAPH_SOURCE, UpdateUtils.ROLE_ALL);

                    IList<UsersParagraphLink> users = generic.getUserBySource(pad.ID, UpdateUtils.PARAGRAPH_SOURCE);
                    int usercount = users.Count;
                    for (int j = 0; j < usercount; j++)
                    {
                        users[j].UserID = Membership.GetUser(new Guid(users[j].UserID)).UserName;

                    }

                    ViewData["selectedactorsedit"] =
                        new SelectList(users, "UserID", "UserID");
                }
                

                ViewData["PADetails"] = pad;
                return View();
                
            }
            catch
            {
                return null;
            }
        }


        //TestModal
        [AcceptVerbs(HttpVerbs.Post)] 
        public ActionResult TestModal(FormCollection collection)
        {

            string input = collection["input"].ToString();
            return RedirectToAction("List", "AddReview");
        }

        public ActionResult ParagraphDetailsEdit(int ReviewID, int PALibID)
        {
            try
            {
                ITaxonRepository taxon = new TaxonRepository();
                IReviewRepository reviews = new ReviewRepository();
                IGenericRepository generic = new GenericRepository();
                IMeetingLibRepository mlib = new MeetingLibRepository();
                IMembershipRepository members = new MembershipRepository();
                ICommentsRepository comments = new CommentsRepository();
                IDocumentsRepository docs = new DocumentsRepository();
                IRecommendationsRepository recs = new RecommendationsRepository();
                IDecisionsRepository decisions = new DecisionsRepository();

                var review = reviews.getSingleReview(ReviewID);
                review.TaxonName = taxon.getReviewTaxonName(review.ID, review.Taxontype, review.Kingdom);

                List<Actor> userDetails = GetUserDetails();
                ViewData["allactorsadd"] = new SelectList(userDetails,"UserName","UserDetails");
                ViewData["selectedactorsedit"] =
                ViewData["allactorsedit"] =
                ViewData["selectedactorsadd"] = ViewData["allactors2"] = ViewData["allactorsadd"];

                ViewData["PATitle"] = review.TaxonName + " [" + review.CtyShort + "]";
                ViewData["MeetingsA"] = ViewData["DecMeetings"] = ViewData["LiftedMeetings"] = new SelectList(generic.getAllMeetingsSelect(), "ID", "Description");

               // ViewData["Roles"] = new SelectList(members.getAllRoles());
                ViewData["roles"] = new SelectList(UpdateUtils.getViewersList());
                ViewData["PALib"] = reviews.getSinglePALib(PALibID);
                              
                //GETTING THE PACTIONLIB TO RETRIEVE RECOMMENDATIONS/DECISIONS VALUES
                ParagraphActionLib palib = generic.getPActionLib(PALibID);
                ViewData["NeedsRecommendation"] = palib.Recommendations;
                ViewData["NeedsDecision"] = palib.Decisions;
                ViewData["NeedsConcern"] = palib.ConcernVisible;
                
                //END GETTING RECOMMENDATIONS/DECISIONS

                ViewData["ReviewID"] = ReviewID;
                ParagraphActionDetails pad = reviews.getParagraphDetails(PALibID, ReviewID);

                ViewData["Meetings"] = new SelectList(generic.getAllMeetingsSelect(), "ID", "Description",
                                                      pad.MeetingID);
                
                ViewData["DateStarted"] = pad.DateStarted.ToShortDateString();
                ViewData["Deadline"] = pad.Deadline.ToShortDateString();
                ViewData["concerns"] = new SelectList(generic.getAllLevelofConcerns(), "Description", "Description");
               // ViewData["concernlevel"]= reviews.getConcernForReview(ReviewID);
                ViewData["concernlevel"] = generic.getConcernForParagraphAction(pad.ID);
                ViewData["contributor"] = null;

                if (pad != null)
                {
                    if (Request.IsAuthenticated)
                    {
                        var user = UpdateUtils.getCurrentMembershipUser();
                        var roles = Roles.GetRolesForUser();
                        if (roles.Contains(UpdateUtils.ROLE_DATA_CONTRIBUTOR))
                        {
                            ViewData["contributor"] = User.Identity.Name;
                        }

                        if (roles.Contains(UpdateUtils.ROLE_INTERMEDIATE_VIEWER))
                        {

                            ViewData["Comments"] = comments.getCommentsByID(pad.ID, UpdateUtils.PARAGRAPH_SOURCE,UpdateUtils.ROLE_INTERMEDIATE_VIEWER );
                            ViewData["Documents"] = docs.getDocumentsByID(pad.ID, UpdateUtils.PARAGRAPH_SOURCE, UpdateUtils.ROLE_INTERMEDIATE_VIEWER);

                            //ViewData["Documents"] = ViewData["Documents"] + docs.getDocumentsByID(pad.ID, UpdateUtils.PARAGRAPH_SOURCE, UpdateUtils.ROLE_PUBLIC_VIEWER);
                        }
                         if (roles.Contains(UpdateUtils.ROLE_FULL_VIEWER))
                        {

                             ViewData["Comments"] = comments.getCommentsByID(pad.ID, UpdateUtils.PARAGRAPH_SOURCE, UpdateUtils.ROLE_ALL);
                             ViewData["Documents"] = docs.getDocumentsByID(pad.ID, UpdateUtils.PARAGRAPH_SOURCE, UpdateUtils.ROLE_ALL);
                        }
                    }
                    else
                    {
                        ViewData["Comments"] = comments.getCommentsByID(pad.ID, UpdateUtils.PARAGRAPH_SOURCE, UpdateUtils.ROLE_PUBLIC_VIEWER );
                        ViewData["Documents"] = docs.getDocumentsByID(pad.ID, UpdateUtils.PARAGRAPH_SOURCE,  UpdateUtils.ROLE_PUBLIC_VIEWER);
                    }

                    IList<UsersParagraphLink> users = generic.getUserBySource(pad.ID, UpdateUtils.PARAGRAPH_SOURCE);
                    int usercount = users.Count;
                    for (int j = 0; j < usercount; j++)
                    {
                        users[j].UserID = Membership.GetUser(new Guid(users[j].UserID)).UserName;
                        if (User.Identity.IsAuthenticated)
                    {
                        var current_user = User.Identity.Name;
                        if (users[j].UserID == current_user)
                        {
                            ViewData["contributor"] = current_user;
                        }
                    }


                    }

                    ViewData["PActionID"] = pad.ID;
                    ViewData["ReviewID"] = ReviewID;
                    ViewData["PALibID"] = PALibID;
                    ViewData["recommendations"] = recs.getAllRecommendationsByParagraph(pad.ID);

                    ViewData["editmode"] = false;
                    
                    //ViewData["decisions"] = decisions.GetAllDecisionsPerParagraph(pad.ID);
                    IList<Decision> decs = decisions.GetAllDecisionsPerParagraph(pad.ID);
                    ViewData["decisiondetails"] = UpdateUtils.GetDecisionDetails(decs);
                    ViewData["decisions"] = decs;

                    ViewData["decisiontypes"] = new SelectList(generic.GetAllDecisionTypes(), "Description",
                                                               "Description");

                    ViewData["tradeterms"] = new SelectList(generic.GetAllTradeTerms(), "Description",
                                                               "Description");

                    ViewData["selectedactorsedit"] =
                        new SelectList(users, "UserID", "UserID");
                    
                }

              
                ViewData["PADetails"] = pad;
                return View();

            }
            catch (Exception e)
            {
                return null;
            }
        }

        private List<Actor> GetUserDetails()
        {
              // Get all profile objects
              System.Web.Profile.ProfileInfoCollection profiles = System.Web.Profile.ProfileManager.GetAllProfiles(System.Web.Profile.ProfileAuthenticationOption.All);
              List<Actor> userdetails = new List<Actor>();
              CountryRepository cr = new CountryRepository();
              foreach (System.Web.Profile.ProfileInfo info in profiles)
              {
                // We need to turn a ProfileInfo into a ProfileCommon to access the properties to do the search
                  System.Web.Profile.ProfileBase userProfile = System.Web.Profile.ProfileBase.Create(info.UserName);

                  System.Text.StringBuilder userString = new System.Text.StringBuilder();
                  userString.Append(info.UserName);
                  if (userProfile.GetPropertyValue("Organization").ToString() != "")
                      userString.Append(", " + userProfile.GetPropertyValue("Organization"));
                  if (userProfile.GetPropertyValue("country_id").ToString() != "")
                  {
                      var ctyShort = cr.getCountry(Convert.ToInt32(userProfile.GetPropertyValue("country_id").ToString()));
                      if (ctyShort != null)
                          userString.Append(", " + ctyShort.CtyShort);
                  }
                  userdetails.Add(new Actor(info.UserName, userString.ToString()));
              }
              return userdetails;
        }

        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        //GET: ProcessReview/ParagraphDetailsAdd
        public ActionResult ParagraphDetailsAdd(int? ReviewID, int? PALibID)
        {
            try
            {
                ITaxonRepository taxon = new TaxonRepository();
                IReviewRepository reviews = new ReviewRepository();
                IGenericRepository generic = new GenericRepository();
                IMeetingLibRepository mlib = new MeetingLibRepository();
                IMembershipRepository members = new MembershipRepository();
                ICommentsRepository comments = new CommentsRepository();
                IDocumentsRepository docs = new DocumentsRepository();

                ReviewDesc review = reviews.getSingleReview(ReviewID);
                ViewData["concernlevel"] = reviews.getConcernForReview(ReviewID.Value);
                review.TaxonName = taxon.getReviewTaxonName(review.ID, review.Taxontype, review.Kingdom);

                List<Actor> userdetails = GetUserDetails();
                ViewData["allactorsadd"] = new SelectList(userdetails,"UserName", "UserDetails");
                //ViewData["selectedactorsedit"] = ViewData["allactorsedit"] = ViewData["selectedactorsadd"] = ViewData["allactors2"] = ViewData["allactorsadd"];

                ViewData["PATitle"] = review.TaxonName + " [" + review.CtyShort + "]";
                ViewData["committees"] = new SelectList(generic.getAllCommitteesSelect(), "ID", "Description");
                ViewData["meetings1"] = new SelectList(mlib.getAllMeetingLibs(), "MeetingLibID", "MeetingLibDesc");
                ViewData["meetings"] =new SelectList(generic.getAllMeetingsSelect(), "ID", "Description");
                ViewData["concerns"] = new SelectList(generic.getAllLevelofConcerns(), "Description", "Description");
                //ViewData["roles"] = new SelectList(members.getAllRoles());
                ViewData["rolesc"] = 
                ViewData["rolesd"]=new SelectList(UpdateUtils.getViewersList());
                ViewData["paction"] = reviews.getSinglePALib(PALibID);
                ViewData["PALib"] = PALibID;
                ViewData["ReviewID"] = ReviewID;
                ViewData["concernlevel"] = reviews.getConcernForReview(ReviewID.Value);
              
                return View();

            }
            catch
            {
                return null;
            }
        }

        // POST: /ProcessReview/AddDocument
        [Authorize(Roles = UpdateUtils.ROLE_DATA_CONTRIBUTOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddDocument(FormCollection collection)
        {
            try
            {
                IDocumentsRepository docs = new DocumentsRepository();

                string _SourceID = collection["SourceID"];
                string _SourceType = collection["SourceType"];
                string _ReviewID = collection["ReviewID"];
                string _PALibID = collection["PALibID"];
                string _contributor = collection["CONTRIBUTOR"];
                collection["UserID"] = 1.ToString();
                collection["docfiletype"] = collection["docfileadd"];
                
                if (collection["docfileadd"].ToString().Equals("upload"))
                {
                    foreach (string filename in Request.Files)
                    {
                        HttpPostedFileBase file = Request.Files[filename];
                        var document_dir = ConfigurationManager.AppSettings["@BaseDir"];

                        var file_path = Request.PhysicalApplicationPath + document_dir;

                        if (file.ContentLength > 0)
                        {
                            string filePath = Path.Combine(file_path, Path.GetFileName(file.FileName));
                            file.SaveAs(filePath);

                            collection["DocName"] = file.FileName;
                            collection["DocPath"] = file_path;
                            collection["DocAccess"] = collection["ddDocumentTypeEdit"];
                            int documentID = UpdateUtils.InsertDocuments(collection, int.Parse(_SourceID),
                                                                         int.Parse(_SourceType));
                            UpdateUtils.SendDocumentUploadNotification(Membership.GetUser().UserName, documentID);
                        }
                    }
                }
                else if (collection["docfileadd"].ToString().Equals("hyperlink"))
                {
                    collection["DocName"] = collection["txtHyperlinkAdd"];
                    collection["DocPath"] = null;
                    collection["DocAccess"] = collection["ddDocumentTypeEdit"];
                    int documentID = UpdateUtils.InsertDocuments(collection, int.Parse(_SourceID),
                                                                         int.Parse(_SourceType));
                    //NEED TO COME BACK TO THIS
                    UpdateUtils.SendDocumentUploadNotification(System.Web.HttpContext.Current.User.Identity.Name, documentID);
                }
                
                //return View();
                ViewData["Documents"] = docs.getDocumentsByID(int.Parse(_SourceID),
                                                              int.Parse(_SourceType),UpdateUtils.ROLE_ALL);

                ViewData["ReviewID"] = _ReviewID;
                ViewData["PALibID"] = _PALibID;
                ViewData["PActionID"] = _SourceID;
                ViewData["contributor"] = _contributor;

                return PartialView("display_documents");
                //return RedirectToAction("ParagraphDetails", new { ReviewID = int.Parse(_ReviewID), PALibID = int.Parse(_PALibID) });
                //return RedirectToAction("Details");
            }
            catch
            {
                return null;
            }
        }


        // POST: /ProcessReview/AddComment
        [Authorize(Roles = UpdateUtils.ROLE_DATA_CONTRIBUTOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddComment(FormCollection collection)
        {
            try
            {
                ICommentsRepository comments = new CommentsRepository();
                string comment = collection["txtNewComment"];
                collection["S1"] = comment;
                collection["ddCommentType"] = collection["ddCommentTypeEdit"];
                string _SourceID = collection["SourceID"];
                string _SourceType = collection["SourceType"];
                string _ReviewID = collection["ReviewID"];
                string _PALibID = collection["PALibID"];
                string _contributor = collection["CONTRIBUTOR"];
                collection["UserID"] = 1.ToString();

                int commentID = UpdateUtils.InsertComments(collection, int.Parse(_SourceID), int.Parse(_SourceType));

                ViewData["Comments"] = comments.getCommentsByID(int.Parse(_SourceID), int.Parse(_SourceType),UpdateUtils.ROLE_ALL);


                ViewData["ReviewID"] = _ReviewID;
                ViewData["PALibID"] = _PALibID;
                ViewData["PActionID"] = _SourceID;
                ViewData["contributor"] = _contributor;

                return PartialView("edit_comments");
                //return View();int.
                return RedirectToAction("ParagraphDetails", new { ReviewID = int.Parse(_ReviewID), PALibID = int.Parse(_PALibID) });
                //return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ProcessReview/Edit/5
        [Authorize(Roles = UpdateUtils.ROLE_DATA_CONTRIBUTOR)]
        public ActionResult EditComment(int id, int ReviewID_, int PALibID_)
        {
            ICommentsRepository comments = new CommentsRepository();
            Comment c = comments.getCommentByID(id);
            ViewData["Comment"] = c.Comments;
            ViewData["ReviewID"] = ReviewID_;
            ViewData["PALibID"] = PALibID_;

            IMembershipRepository members = new MembershipRepository();
            //ViewData["RolesAccess"] = new SelectList(members.getAllRoles(),c.RoleAccess);
            ViewData["RolesAccess"] = new SelectList(UpdateUtils.getViewersList(), c.RoleAccess);
            
            return View();
        }

        //
        // POST: /ProcessReview/Edit/5
        [Authorize(Roles = UpdateUtils.ROLE_DATA_CONTRIBUTOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditComment(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ICommentsRepository comments = new CommentsRepository();
                Comment c = comments.getCommentByID(id);
                c.Comments = collection["Comment"];
                c.RoleAccess = collection["RoleAccess"];
                c.DateModified = DateTime.Now;

                int i= comments.Save(c);
                int review = int.Parse(collection["ReviewID"]);
                int palib = int.Parse(collection["PALibID"]);


                return RedirectToAction("ParagraphDetailsEdit", new { ReviewID = review, PALibID = palib });
            }
            catch
            {
                return View();
            }
        }

        //POST CreateRecommendation
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateRecommendation(FormCollection collection) {
            try {
                // TODO: Add insert logic here


                string recommendation = collection["recommendation"].ToString();
                int meetingId = int.Parse(collection["MeetingsA"].ToString());
               
                int PActionID = int.Parse(collection["SourceID"].ToString());

                IRecommendationsRepository recs = new RecommendationsRepository();
                IGenericRepository generic = new GenericRepository();
                Recommendation r = new Recommendation();

                r.AddedDate = DateTime.Now;
                r.CommitteeID = meetingId;
               
                r.RecommendationX = recommendation;
                r.ParagraphActionID = PActionID;

                if (collection["recdeadlinedate"] != null && collection["recdeadlinedate"].Length > 0) {
                    r.DeadlineDate = DateTime.Parse(collection["recdeadlinedate"].ToString());
                }
                if (collection["recdate"] != null && collection["recdate"].Length > 0) {
                     r.RecDate = DateTime.Parse(collection["recdate"].ToString());
                }

                int i = recs.SaveRec(r);

                ViewData["MeetingsA"] = new SelectList(generic.getAllMeetingsSelect(), "ID", "Description");
                ViewData["recommendations"] = recs.getAllRecommendationsByParagraph(PActionID);
                ViewData["ReviewID"] = int.Parse(collection["ReviewID"]);
                ViewData["PALibID"] = int.Parse(collection["PALibID"]);
                ViewData["PActionID"] = PActionID;
                return PartialView("Recommendations");

                //return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }


        // POST: /ProcessReview/DeleteRecommendation
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteRecommendation(FormCollection collection) {
            //ICommentsRepository comments = new CommentsRepository();
            IRecommendationsRepository recs = new RecommendationsRepository();
            
            int ID = int.Parse(collection["ID"]);
            int ReviewID_ = int.Parse(collection["ReviewID"]);
            int PALibID_ = int.Parse(collection["PALibID"]);
            int SourceID = int.Parse(collection["SourceID"]);
            int SourceType = int.Parse(collection["SourceType"]);
            recs.DeleteRecommendation(ID);

            //SourceID is the ParagraphActionID actually
            ViewData["recommendations"] = recs.getAllRecommendationsByParagraph(SourceID);
            //ViewData["Comments"] = comments.getCommentsByID(SourceID, SourceType);
            ViewData["ReviewID"] = ReviewID_;
            ViewData["PALibID"] = PALibID_;
            ViewData["PActionID"] = SourceID;

            return PartialView("Recommendations");

            //return RedirectToAction("ParagraphDetailsEdit", new { ReviewID = ReviewID_, PALibID = PALibID_ });
            //return View();
        }

        //POST EditDecision
        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        public ActionResult EditDecision(FormCollection collection)
        {

            IDecisionsRepository decisions = new DecisionsRepository();
            IGenericRepository generics = new GenericRepository();

            int ID = int.Parse(collection["ID"]);
            int ReviewID_ = int.Parse(collection["ReviewID"]);
            int PALibID_ = int.Parse(collection["PALibID"]);
            int SourceID = int.Parse(collection["SourceID"]);
            int SourceType = int.Parse(collection["SourceType"]);
            //decisions.DeleteDecision(ID);

            Decision decision = DB.Get<Decision>(ID);

            ViewData["decision"] = decision;
            ViewData["editmode"] = true;

            //SourceID is the ParagraphActionID actually

            IList<Decision> decs = decisions.GetAllDecisionsPerParagraph(SourceID);

            ViewData["decisiondetails"] = UpdateUtils.GetDecisionDetails(decs);

            ViewData["decisions"] = decs;


            //ViewData["Comments"] = comments.getCommentsByID(SourceID, SourceType);
            ViewData["ReviewID"] = ReviewID_;
            ViewData["PALibID"] = PALibID_;
            ViewData["PActionID"] = SourceID;
            ViewData["ID"] = ID;

            ViewData["MeetingsA"] = new SelectList(generics.getAllMeetingsSelect(), "ID", "Description");
            ViewData["DecMeetings"] = new SelectList(generics.getAllMeetingsSelect(), "ID", "Description", decision.SuspensionCommitteeID);
            ViewData["LiftedMeetings"] = new SelectList(generics.getAllMeetingsSelect(), "ID", "Description", decision.LigftingCommitteeID);
            ViewData["decisiontypes"] = new SelectList(generics.GetAllDecisionTypes(), "Description",
                                                          "Description", decision.DecisionType);

            ViewData["tradeterms"] = new SelectList(generics.GetAllTradeTerms(), "Description",
                                                       "Description",decision.TradeTerms);

            return PartialView("Decisions");

        }


        //POST CreateRecommendation
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateDecision(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                IGenericRepository generics = new GenericRepository();

                string decisionnotes = collection["decision"].ToString();
                int decMeetingId = int.Parse(collection["DecMeetings"].ToString());
              
                int decisionType = generics.getExternalRef(collection["decisiontypes"].ToString(),UpdateUtils.TYPE_DECISION);
                int tradeTerms = generics.getExternalRef(collection["tradeterms"].ToString(),UpdateUtils.TYPE_TRADETERMS);

                int PActionID = int.Parse(collection["SourceID"].ToString());

                IDecisionsRepository decisions = new DecisionsRepository();
                IGenericRepository generic = new GenericRepository();
                Decision dec = new Decision();

                dec.AddedDate = DateTime.Now;
                dec.DecisionType = decisionType;
                dec.ParagraphActionID = PActionID;
                dec.Notes = decisionnotes;
                dec.TradeTerms = tradeTerms;
                dec.SuspensionCommitteeID = decMeetingId;


                if (collection["suspensiondate"] != null && collection["suspensiondate"].Length > 0)
                {
                    dec.SuspensionDate = DateTime.Parse(collection["suspensiondate"].ToString());
                }


                if (collection["lifteddate"] != null && collection["lifteddate"].Length > 0) {
                    DateTime liftedDate = DateTime.Parse(collection["lifteddate"].ToString());
                    dec.SuspensionDate = liftedDate;
                }

                if (collection["LiftedMeetings"] != null && collection["LiftedMeetings"].Length > 0) {
                    int liftedCommitteeId = int.Parse(collection["LiftedMeetings"].ToString());
                    dec.LigftingCommitteeID = liftedCommitteeId;
                }
 
                int i = decisions.SaveDecision(dec);

                ViewData["MeetingsA"] = 
                ViewData["DecMeetings"] = 
                ViewData["LiftedMeetings"] = new SelectList(generic.getAllMeetingsSelect(), "ID", "Description");

                //ViewData["DecCommittees"] = ViewData["LiftedCommittees"]= new SelectList(generic.getAllCommitteesSelect(), "ID", "Description");
                IList<Decision> decs = decisions.GetAllDecisionsPerParagraph(PActionID);

                ViewData["decisiondetails"] = UpdateUtils.GetDecisionDetails(decs);

                ViewData["decisions"] = decs;

                //ViewData["decisions"] = decisions.GetAllDecisionsPerParagraph(PActionID);
                ViewData["ReviewID"] = int.Parse(collection["ReviewID"]);
                ViewData["PALibID"] = int.Parse(collection["PALibID"]);
                ViewData["PActionID"] = PActionID;
         
                ViewData["decisiontypes"] = new SelectList(generic.GetAllDecisionTypes(), "Description",
                                                           "Description");

                ViewData["tradeterms"] = new SelectList(generic.GetAllTradeTerms(), "Description",
                                                           "Description");

                ViewData["editmode"] = false;

                return PartialView("Decisions");

                //return RedirectToAction("Index");
            }
            catch {
                return RedirectToAction("Search", "SearchReview");
            }
        }


        //POST CreateRecommendation
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveEditDecision(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                IGenericRepository generics = new GenericRepository();

                int decisionID = int.Parse(collection["ID"].ToString());
                Decision dec = DB.Get<Decision>(decisionID);


                string decisionnotes = collection["decision"].ToString();
                int decMeetingId = int.Parse(collection["DecMeetings"].ToString());
                DateTime suspensionDate = DateTime.Parse(collection["suspensiondate"].ToString());


                int decisionType = generics.getExternalRef(collection["decisiontypes"].ToString(), UpdateUtils.TYPE_DECISION);
                int tradeTerms = generics.getExternalRef(collection["tradeterms"].ToString(), UpdateUtils.TYPE_TRADETERMS);

                int PActionID = int.Parse(collection["SourceID"].ToString());

                IDecisionsRepository decisions = new DecisionsRepository();
                IGenericRepository generic = new GenericRepository();
                

                dec.ModifiedDate = DateTime.Now;
                dec.DecisionType = decisionType;
                dec.ParagraphActionID = PActionID;
                dec.Notes = decisionnotes;
                dec.TradeTerms = tradeTerms;
                dec.SuspensionCommitteeID = decMeetingId;
                dec.SuspensionDate = suspensionDate;

                if (collection["lifteddate"].ToString().Length > 0) {
                    DateTime liftedDate = DateTime.Parse(collection["lifteddate"].ToString());
                    dec.SuspensionDate = liftedDate;
                }

                if (collection["LiftedMeetings"].ToString().Length > 0) {
                    int liftedCommitteeId = int.Parse(collection["LiftedMeetings"].ToString());
                    dec.LigftingCommitteeID = liftedCommitteeId;
                }

                int i = decisions.SaveDecision(dec);

                ViewData["MeetingsA"] =
                ViewData["DecMeetings"] =
                ViewData["LiftedMeetings"] = new SelectList(generic.getAllMeetingsSelect(), "ID", "Description");

                //ViewData["DecCommittees"] = ViewData["LiftedCommittees"]= new SelectList(generic.getAllCommitteesSelect(), "ID", "Description");
                IList<Decision> decs = decisions.GetAllDecisionsPerParagraph(PActionID);

                ViewData["decisiondetails"] = UpdateUtils.GetDecisionDetails(decs);

                ViewData["decisions"] = decs;

                //ViewData["decisions"] = decisions.GetAllDecisionsPerParagraph(PActionID);
                ViewData["ReviewID"] = int.Parse(collection["ReviewID"]);
                ViewData["PALibID"] = int.Parse(collection["PALibID"]);
                ViewData["PActionID"] = PActionID;


                ViewData["decisiontypes"] = new SelectList(generic.GetAllDecisionTypes(), "Description",
                                                           "Description");

                ViewData["tradeterms"] = new SelectList(generic.GetAllTradeTerms(), "Description",
                                                           "Description");

                ViewData["editmode"] = false;

                return PartialView("Decisions");

                //return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }


        // POST: /ProcessReview/DeleteRecommendation
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteDecision(FormCollection collection) {
            //ICommentsRepository comments = new CommentsRepository();
            IDecisionsRepository decisions = new DecisionsRepository();
            IGenericRepository generics = new GenericRepository();

            int ID = int.Parse(collection["ID"]);
            int ReviewID_ = int.Parse(collection["ReviewID"]);
            int PALibID_ = int.Parse(collection["PALibID"]);
            int SourceID = int.Parse(collection["SourceID"]);
            int SourceType = int.Parse(collection["SourceType"]);
            decisions.DeleteDecision(ID);

            //SourceID is the ParagraphActionID actually

            IList<Decision> decs = decisions.GetAllDecisionsPerParagraph(SourceID);

            ViewData["decisiondetails"] = UpdateUtils.GetDecisionDetails(decs);

            ViewData["decisions"] = decs;


            //ViewData["Comments"] = comments.getCommentsByID(SourceID, SourceType);
            ViewData["ReviewID"] = ReviewID_;
            ViewData["PALibID"] = PALibID_;
            ViewData["PActionID"] = SourceID;

            ViewData["MeetingsA"] =
            ViewData["DecMeetings"] =
            ViewData["LiftedMeetings"] = new SelectList(generics.getAllMeetingsSelect(), "ID", "Description");
            ViewData["decisiontypes"] = new SelectList(generics.GetAllDecisionTypes(), "Description",
                                                          "Description");

            ViewData["tradeterms"] = new SelectList(generics.GetAllTradeTerms(), "Description",
                                                       "Description");

            ViewData["editmode"] = false;

            return PartialView("Decisions");

            //return RedirectToAction("ParagraphDetailsEdit", new { ReviewID = ReviewID_, PALibID = PALibID_ });
            //return View();
        }

        // GET: /AddReview/AddCountries

        public ActionResult GetMeetingDate(bool ajax, int meetingId) {


            MeetingLib m = DB.Get<MeetingLib>(meetingId);
                
            IList<string> dates = new List<string>();
            DateTime meeting = DateTime.Parse(m.MeetingLibDate.ToString());
            DateTime deadline = meeting.AddDays(30);

            dates.Add(meeting.ToShortDateString());
            dates.Add(deadline.ToShortDateString());
            // return Json(taxons.getCountries(3, UpdateUtils.PHYLUM, UpdateUtils.ANIMALS).ToList());
            return Json(dates);

        }


        // GET: /ProcessReview/GetDocument
        public ActionResult GetDocument(int docId)
        {
            try
            {
                string filename = null;
                IDocumentsRepository rep = new DocumentsRepository();
                var document = rep.getDocumentByID(docId);
                if (document == null)
                {
                    return null;
                }

                filename = document.DocPath + "\\" + document.DocName;
                
                string contentType = "";
                if (filename.IndexOf(".pdf") > -1)
                    contentType = "application/pdf";
                else if (filename.IndexOf(".doc") > -1)
                    contentType = "application/msword";
                else if (filename.IndexOf(".com") > -1)
                    contentType = "text/html";
                else if (filename.IndexOf(".txt") > -1)
                    contentType = "text/plain";
                if (!contentType.Equals(""))
                    return new FilePathResult(filename, contentType);
                else
                    return null;
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }
    }

    public struct Actor
    {
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string UserDetails
        {
            get { return userDetails; }
            set { userDetails = value; }
        }

        private string userName, userDetails;

        public Actor(string name, string details)
        {
            userName = name;
            userDetails = details;
        }
    }

}
