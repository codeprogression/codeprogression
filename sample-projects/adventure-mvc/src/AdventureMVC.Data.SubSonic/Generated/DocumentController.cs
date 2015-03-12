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
namespace AdventureWorks
{
    /// <summary>
    /// Controller class for Document
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DocumentController
    {
        // Preload our schema..
        Document thisSchemaLoad = new Document();
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
        public DocumentCollection FetchAll()
        {
            DocumentCollection coll = new DocumentCollection();
            Query qry = new Query(Document.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DocumentCollection FetchByID(object DocumentID)
        {
            DocumentCollection coll = new DocumentCollection().Where("DocumentID", DocumentID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DocumentCollection FetchByQuery(Query qry)
        {
            DocumentCollection coll = new DocumentCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object DocumentID)
        {
            return (Document.Delete(DocumentID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object DocumentID)
        {
            return (Document.Destroy(DocumentID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Title,string FileName,string FileExtension,string Revision,int ChangeNumber,byte Status,string DocumentSummary,byte[] DocumentX,DateTime ModifiedDate)
	    {
		    Document item = new Document();
		    
            item.Title = Title;
            
            item.FileName = FileName;
            
            item.FileExtension = FileExtension;
            
            item.Revision = Revision;
            
            item.ChangeNumber = ChangeNumber;
            
            item.Status = Status;
            
            item.DocumentSummary = DocumentSummary;
            
            item.DocumentX = DocumentX;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int DocumentID,string Title,string FileName,string FileExtension,string Revision,int ChangeNumber,byte Status,string DocumentSummary,byte[] DocumentX,DateTime ModifiedDate)
	    {
		    Document item = new Document();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.DocumentID = DocumentID;
				
			item.Title = Title;
				
			item.FileName = FileName;
				
			item.FileExtension = FileExtension;
				
			item.Revision = Revision;
				
			item.ChangeNumber = ChangeNumber;
				
			item.Status = Status;
				
			item.DocumentSummary = DocumentSummary;
				
			item.DocumentX = DocumentX;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
