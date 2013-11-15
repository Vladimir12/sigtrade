using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace SignificantTradeSS
{
    /// <summary>
    /// Controller class for tblReview
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TblReviewController
    {
        // Preload our schema..
        TblReview thisSchemaLoad = new TblReview();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public TblReviewCollection FetchAll()
        {
            TblReviewCollection coll = new TblReviewCollection();
            Query qry = new Query(TblReview.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TblReviewCollection FetchByID(object Id)
        {
            TblReviewCollection coll = new TblReviewCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TblReviewCollection FetchByQuery(Query qry)
        {
            TblReviewCollection coll = new TblReviewCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (TblReview.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (TblReview.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? PhaseID,int? CountryID,int? TaxonID,int? TaxonLevel,DateTime? DateAdded,int? AddedBy,int? KingdomID,bool Deleted,DateTime? DeletedDate,int? CommitteeID,DateTime? ReviewDate,int? ReviewType,int? ConcernID,int? OldSigMainID)
	    {
		    TblReview item = new TblReview();
		    
            item.PhaseID = PhaseID;
            
            item.CountryID = CountryID;
            
            item.TaxonID = TaxonID;
            
            item.TaxonLevel = TaxonLevel;
            
            item.DateAdded = DateAdded;
            
            item.AddedBy = AddedBy;
            
            item.KingdomID = KingdomID;
            
            item.Deleted = Deleted;
            
            item.DeletedDate = DeletedDate;
            
            item.CommitteeID = CommitteeID;
            
            item.ReviewDate = ReviewDate;
            
            item.ReviewType = ReviewType;
            
            item.ConcernID = ConcernID;
            
            item.OldSigMainID = OldSigMainID;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? PhaseID,int? CountryID,int? TaxonID,int? TaxonLevel,DateTime? DateAdded,int? AddedBy,int? KingdomID,bool Deleted,DateTime? DeletedDate,int? CommitteeID,DateTime? ReviewDate,int? ReviewType,int? ConcernID,int? OldSigMainID)
	    {
		    TblReview item = new TblReview();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.PhaseID = PhaseID;
				
			item.CountryID = CountryID;
				
			item.TaxonID = TaxonID;
				
			item.TaxonLevel = TaxonLevel;
				
			item.DateAdded = DateAdded;
				
			item.AddedBy = AddedBy;
				
			item.KingdomID = KingdomID;
				
			item.Deleted = Deleted;
				
			item.DeletedDate = DeletedDate;
				
			item.CommitteeID = CommitteeID;
				
			item.ReviewDate = ReviewDate;
				
			item.ReviewType = ReviewType;
				
			item.ConcernID = ConcernID;
				
			item.OldSigMainID = OldSigMainID;
				
	        item.Save(UserName);
	    }
    }
}