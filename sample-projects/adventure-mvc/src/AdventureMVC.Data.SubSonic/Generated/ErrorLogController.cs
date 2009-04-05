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
    /// Controller class for ErrorLog
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ErrorLogController
    {
        // Preload our schema..
        ErrorLog thisSchemaLoad = new ErrorLog();
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
        public ErrorLogCollection FetchAll()
        {
            ErrorLogCollection coll = new ErrorLogCollection();
            Query qry = new Query(ErrorLog.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ErrorLogCollection FetchByID(object ErrorLogID)
        {
            ErrorLogCollection coll = new ErrorLogCollection().Where("ErrorLogID", ErrorLogID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ErrorLogCollection FetchByQuery(Query qry)
        {
            ErrorLogCollection coll = new ErrorLogCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ErrorLogID)
        {
            return (ErrorLog.Delete(ErrorLogID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ErrorLogID)
        {
            return (ErrorLog.Destroy(ErrorLogID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(DateTime ErrorTime,string UserName,int ErrorNumber,int? ErrorSeverity,int? ErrorState,string ErrorProcedure,int? ErrorLine,string ErrorMessage)
	    {
		    ErrorLog item = new ErrorLog();
		    
            item.ErrorTime = ErrorTime;
            
            item.UserName = UserName;
            
            item.ErrorNumber = ErrorNumber;
            
            item.ErrorSeverity = ErrorSeverity;
            
            item.ErrorState = ErrorState;
            
            item.ErrorProcedure = ErrorProcedure;
            
            item.ErrorLine = ErrorLine;
            
            item.ErrorMessage = ErrorMessage;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ErrorLogID,DateTime ErrorTime,string UserName,int ErrorNumber,int? ErrorSeverity,int? ErrorState,string ErrorProcedure,int? ErrorLine,string ErrorMessage)
	    {
		    ErrorLog item = new ErrorLog();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ErrorLogID = ErrorLogID;
				
			item.ErrorTime = ErrorTime;
				
			item.UserName = UserName;
				
			item.ErrorNumber = ErrorNumber;
				
			item.ErrorSeverity = ErrorSeverity;
				
			item.ErrorState = ErrorState;
				
			item.ErrorProcedure = ErrorProcedure;
				
			item.ErrorLine = ErrorLine;
				
			item.ErrorMessage = ErrorMessage;
				
	        item.Save(UserName);
	    }
    }
}
