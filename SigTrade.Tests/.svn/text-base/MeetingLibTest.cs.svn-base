using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignificantTrade.Models;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;
using SigTrade.Models;
using SigTrade.Paging;
using SubSonic;
using DB=SignificantTradeSSRepository.DB;

namespace SigTrade.Tests
{
    /// <summary>
    /// Summary description for MeetingLibTest
    /// </summary>
    [TestClass]
    public class MeetingLibTest
    {
        public MeetingLibTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

       
       [TestMethod]
        public void getAllMeetingLibs()
        {
            //
            // TODO: Add test logic	here
            //
        }

        [TestMethod]
        public void MeetingLibs_Get_By_ID()
        {
            IMeetingLibRepository MeetingLibRep = new MeetingLibRepository();

            MeetingLib m = MeetingLibRep.getMeetingLibByID(1);
         
            Assert.AreEqual(m.MeetingLibDesc,"Animal");

        }

        [TestMethod]
        public void Adding_MeetingLib()
        {
            IMeetingLibRepository MeetingLibRep = new MeetingLibRepository();

            MeetingLib m = new MeetingLib();

            IList<SelectItems> allItems = new List<SelectItems>();
            allItems.ToPagedList(0, 10);
           
           m.MeetingLibDesc = "Plants";
            m.MeetingLibNumber = "PL01";
            m.MeetingLibDate = DateTime.Parse("02/02/2009");
            m.DateAdded = DateTime.Now;
            m.DateModified = DateTime.Now;

            int saved = MeetingLibRep.Save(m);
            Assert.AreEqual(saved, 3);

        }

        [TestMethod]
        public void Modify_MeetingLib()
        {
            IMeetingLibRepository MeetingLibRep = new MeetingLibRepository();

            MeetingLib m = MeetingLibRep.getMeetingLibByID(2);

            m.MeetingLibDesc = "PLants Committee";
            m.DateModified = DateTime.Now;

            int saved = MeetingLibRep.Save(m);
            Assert.AreEqual(saved, 1);

        }

        [TestMethod]
        public void Delete_MeetingLib()
        {
            IMeetingLibRepository MeetingLibRep = new MeetingLibRepository();

            MeetingLib m = MeetingLibRep.getMeetingLibByID(2);

            MeetingLibRep.Delete(m);

            m = MeetingLibRep.getMeetingLibByID(2);

            Assert.IsTrue(m.Deleted == true);
        }

        [TestMethod]
        public void Update_Meeting_Lib()
        {
            IMeetingLibRepository MeetingLibRep = new MeetingLibRepository();

            MeetingLib m = MeetingLibRep.getMeetingLibByID(2);
            FormCollection form = new FormCollection();
            form["MeetingLibNumber"] = "x";
            form["MeetingLibDesc"] = "xy";
            form["MeetingLibDate"] = "01/01/2009";

            m.MeetingLibDesc = form["MeetingLibDesc"];
            m.MeetingLibNumber = form["MeetingLibNumber"];
            m.MeetingLibDate = DateTime.Parse(form["MeetingLibDate"]);


            MeetingLibRep.Save(m);

           Assert.AreEqual(MeetingLibRep.Save(m),0);
        }

        [TestMethod]
        public void Test_SP_MeetingLib()
        {
            //List<MeetingLibSP> meetings =
            //    SignificantTradeSSRepository.SPs.SpMeetingLibTest(1).ExecuteTypedList<MeetingLibSP>();
            ISPRepository sps = new SPRepository();
             IList<MeetingLibSP> meetings = sps.execute_spMeetingLib(1);

            Assert.AreEqual(meetings.First().MeetingLibDesc,"Animals Committee");
        }

        [TestMethod]
        public void Testing_views()
        {

            IList<AnimalsTaxa>  at = SignificantTradeSSRepository.DB.Select().From<AnimalsTaxa>().ExecuteTypedList<AnimalsTaxa>();

        }


        [TestMethod]
        public void getTaxonLevelID()
        {

            ITaxonRepository taxon = new TaxonRepository();

            int i = taxon.getTaxonLevelID("SPECIES");

            Assert.AreEqual(i, 10);

        }

        [TestMethod]
        public void test_Sp_getTaxonSelected()
        {

            ITaxonRepository taxon = new TaxonRepository();

            string test = taxon.getReviewTaxonName(25, UpdateUtils.PHYLUM, UpdateUtils.ANIMALS);

            Assert.AreEqual(test, "test");

        }


        [TestMethod]
        public void testGetExternalRef()
        {

            IGenericRepository gen = new GenericRepository();

            int i = gen.getExternalRef(UpdateUtils.RECOMMENDATIONS,UpdateUtils.REVIEWSTATUS);

            Assert.AreEqual(i, 10);

        }


        [TestMethod]
        public void testAllCommittees()
        {

            IGenericRepository generic = new GenericRepository();
            IMeetingLibRepository mlib = new MeetingLibRepository();
           // IList<TblMeetingLib> coms = generic.getAllMeetings();

            //IList<SelectItems> items = generic.getAllCommitteesSelect();

            IList<SelectItems> items = generic.getAllMeetingsSelect();

            IList<MeetingLib> itemsm = mlib.getAllMeetingLibs();
            SelectList sl = new SelectList(itemsm, "MeetingLibID", "MeetingLibDesc");

            Assert.AreEqual(sl.First().Text,"hello");


        }

        [TestMethod]
        public void testSpPALIbExtra()
        {

            IReviewRepository gen = new ReviewRepository();

            IList<PALibExtra> libs = gen.getAllPALibExtra(7);

            Assert.AreEqual(libs[0].Paragraph, "hello");

        }

        [TestMethod]
        public void testForRoles()
        {

            IMembershipRepository m = new MembershipRepository();
            string[] roles = m.getAllRoles();

            string role = roles[1];
            
            
            Assert.AreEqual(role, "hello");
        }

        [TestMethod]
        public void TestSelect() {

            IList<SelectItems> si =
                DB.Query().ExecuteTypedList<SelectItems>("select MeetingLibNumber, MeetingLibDesc from tblMeetingLib");
                
            Assert.AreEqual(si.Count, 2);
        }


        [TestMethod]
        public void TestAllDecisions() {

            IDecisionsRepository decs = new DecisionsRepository();

            IRecommendationsRepository recs = new RecommendationsRepository();

            int i = decs.GetAllDecisionsPerParagraph(12).Count;

         //   int j = recs.getAllRecommendationsByParagraph(12).Count;
          
            Assert.AreEqual(i, 2);
        }


        [TestMethod]
        public void TestDescriptionGeneral() {

            IGenericRepository gens = new GenericRepository();
            
            string test = gens.GetDescriptionByType(1, UpdateUtils.TYPE_DECISION);

            
            //   int j = recs.getAllRecommendationsByParagraph(12).Count;

            Assert.AreEqual(test, "hello");
        }

        [TestMethod]
        public void TestDecisionDetails() {
            IGenericRepository gens = new GenericRepository();

            IDecisionsRepository decisions = new DecisionsRepository();
            IList<Decision> decs = decisions.GetAllDecisionsPerParagraph(12);

            IList<DecisionDetails> details = UpdateUtils.GetDecisionDetails(decs);

           //   int j = recs.getAllRecommendationsByParagraph(12).Count;

            Assert.AreEqual(details.Count,decs.Count);
        }

        [TestMethod]
        public void Testing_Pagination() {

            //Query q = new Query("select * from tblreview where deleted=0");
            //Query q = new Query("tblReview");

            Query q = new Query("tblreview").WHERE("deleted=false");

            q.PageSize = 10;
            q.PageIndex = 3;
            DataRowCollection rows = q.ExecuteDataSet().Tables[0].Rows;


            //IList<AnimalsTaxa> at = SignificantTradeSSRepository.DB.Select().From<AnimalsTaxa>().ExecuteTypedList<AnimalsTaxa>();
            Assert.AreEqual(rows[0][0].ToString(),"hello");
        }

        [TestMethod]
        public void testPaging2()
        {

           // SqlQuery q = Select.AllColumnsFrom<MeetingLib>().Paged(1, 5);
            ITaxonRepository taxons = new TaxonRepository();

            //int count = taxons.GetAllReviewsPaged(1, 5).Count;

            SqlQuery q = Select.AllColumnsFrom<VwAllReview>().Paged(1, 6);
            int records = q.GetRecordCount();

            Assert.AreEqual(records,10);
        }

    }
}
