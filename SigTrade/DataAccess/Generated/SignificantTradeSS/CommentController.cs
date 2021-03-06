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
    /// Controller class for Comments
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CommentController
    {
        // Preload our schema..
        Comment thisSchemaLoad = new Comment();
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
        public CommentCollection FetchAll()
        {
            CommentCollection coll = new CommentCollection();
            Query qry = new Query(Comment.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CommentCollection FetchByID(object Id)
        {
            CommentCollection coll = new CommentCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CommentCollection FetchByQuery(Query qry)
        {
            CommentCollection coll = new CommentCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Comment.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Comment.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? CommentType,string Comments,DateTime? DateAdded,string RoleAccess,string UserID,int? SourceType,int? SourceID,bool Deleted,DateTime? DateModified,DateTime? DeletedDate)
	    {
		    Comment item = new Comment();
		    
            item.CommentType = CommentType;
            
            item.Comments = Comments;
            
            item.DateAdded = DateAdded;
            
            item.RoleAccess = RoleAccess;
            
            item.UserID = UserID;
            
            item.SourceType = SourceType;
            
            item.SourceID = SourceID;
            
            item.Deleted = Deleted;
            
            item.DateModified = DateModified;
            
            item.DeletedDate = DeletedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? CommentType,string Comments,DateTime? DateAdded,string RoleAccess,string UserID,int? SourceType,int? SourceID,bool Deleted,DateTime? DateModified,DateTime? DeletedDate)
	    {
		    Comment item = new Comment();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.CommentType = CommentType;
				
			item.Comments = Comments;
				
			item.DateAdded = DateAdded;
				
			item.RoleAccess = RoleAccess;
				
			item.UserID = UserID;
				
			item.SourceType = SourceType;
				
			item.SourceID = SourceID;
				
			item.Deleted = Deleted;
				
			item.DateModified = DateModified;
				
			item.DeletedDate = DeletedDate;
				
	        item.Save(UserName);
	    }
    }
}
