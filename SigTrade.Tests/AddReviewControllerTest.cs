using System.Collections.Generic;
using System.Data;
using SignificantTrade.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using SignificantTrade.Models;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;
using SigTrade.Models;


namespace SigTrade.Tests
{
    
    
    /// <summary>
    ///This is a test class for AddReviewControllerTest and is intended
    ///to contain all AddReviewControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AddReviewControllerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Index
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Personal\\dev\\SignificantTrade\\SignificantTrade", "/")]
        [UrlToTest("http://localhost:2625/")]
        public void IndexTest()
        {
        
        }

        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Personal\\dev\\SignificantTrade\\SignificantTrade", "/")]
        [UrlToTest("http://localhost:2625/")]
        public void IndexTest1()
        {
            ITaxonRepository Taxon = new TaxonRepository();
            IList<GeneralLib> am = Taxon.getKingdom();

            Assert.AreEqual(am[1].Description, "hello");
        }

        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Personal\\dev\\SignificantTrade\\SignificantTrade", "/")]
        [UrlToTest("http://localhost:2625/")]
        public void IndexTest2()
        {
            ITaxonRepository Taxon = new TaxonRepository();
            IList<AGeneralTaxon> am = Taxon.getAPhylum();

            Assert.AreEqual(am[1].TaxonName, "hello");
        }

        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Personal\\dev\\SignificantTrade\\SignificantTrade", "/")]
        [UrlToTest("http://localhost:2625/")]
        public void IndexTest3()
        {
         //   ITaxonRepository Taxon = new TaxonRepository();
            IGenericRepository gen = new GenericRepository();
            IList<Phase> am = gen.getAllPhase();

            Assert.AreEqual(am[0].PhaseDesc, "hello");
        }



         [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Personal\\dev\\SignificantTrade\\SignificantTrade", "/")]
        [UrlToTest("http://localhost:2625/")]
        public void testgetAllReviews()
        {
            ITaxonRepository Taxon = new TaxonRepository();
            IGenericRepository gen = new GenericRepository();

            // ViewData["Review"] = Taxon.getAllReviews();

             
            IList<ReviewDesc> reviews = Taxon.getAllReviews();

             int count = reviews.Count;

             if (count > 0)
             {
                 for(int i=0;i<count;i++)
                 {

                     reviews[i].TaxonName = Taxon.getReviewTaxonName(reviews[i].ID, reviews[i].Taxontype, reviews[i].Kingdom);

                 }
             }

             //ReviewDesc r = reviews[0];

             Assert.AreEqual( reviews[0].TaxonName, "test");

             //Assert.AreEqual(count,0);

        }


         [TestMethod()]
         //[HostType("ASP.NET")]
         //[AspNetDevelopmentServerHost("C:\\Personal\\dev\\SignificantTrade\\SignificantTrade", "/")]
         //[UrlToTest("http://localhost:2625/")]
         public void DeleteAReview()
         {
             ITaxonRepository Taxon = new TaxonRepository();

             TblReview r = Taxon.getReview(2);

             Taxon.deleteReview(r);

             TblReview r2 = Taxon.getReview(2);
             Assert.AreEqual(r2.Deleted,false);

             //Assert.AreEqual(count,0);

         }

         [TestMethod()]
         //[HostType("ASP.NET")]
         //[AspNetDevelopmentServerHost("C:\\Personal\\dev\\SignificantTrade\\SignificantTrade", "/")]
         //[UrlToTest("http://localhost:2625/")]
         public void testParagraphActionDetails()
         {
             IReviewRepository reviews = new ReviewRepository();

             ParagraphActionDetails pad = reviews.getParagraphDetails(1, 6);

             Assert.AreEqual(pad.CommitteeDesc, "hello");

             //Assert.IsNull(pad);
             //Assert.AreEqual(count,0);

         }

         [TestMethod()]
         //[HostType("ASP.NET")]
         //[AspNetDevelopmentServerHost("C:\\Personal\\dev\\SignificantTrade\\SignificantTrade", "/")]
         //[UrlToTest("http://localhost:2625/")]
         public void testgetSingleReview()
         {

              //ParagraphActionDetails pad = reviews.getParagraphDetails(1, 3);
            //Assert.AreEqual(SPs.SpGetSingleReview(7).GetDataSet().Tables[0].Rows.Count,8);
             //Assert.IsNotNull();
             //Assert.AreEqual(SPs.GetParagraphActionDetails(1,3).GetDataSet().Tables[0].Rows.Count,10);
             //Assert.AreEqual(count,0);
             //Assert.AreEqual(SPs.SpGetSingleReview(7).Execute(),10);
         }







    }
}
