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
    /// Controller class for JobCandidate
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class JobCandidateController
    {
        // Preload our schema..
        JobCandidate thisSchemaLoad = new JobCandidate();
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
        public JobCandidateCollection FetchAll()
        {
            JobCandidateCollection coll = new JobCandidateCollection();
            Query qry = new Query(JobCandidate.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public JobCandidateCollection FetchByID(object JobCandidateID)
        {
            JobCandidateCollection coll = new JobCandidateCollection().Where("JobCandidateID", JobCandidateID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public JobCandidateCollection FetchByQuery(Query qry)
        {
            JobCandidateCollection coll = new JobCandidateCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object JobCandidateID)
        {
            return (JobCandidate.Delete(JobCandidateID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object JobCandidateID)
        {
            return (JobCandidate.Destroy(JobCandidateID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? EmployeeID,string ResumeX,DateTime ModifiedDate)
	    {
		    JobCandidate item = new JobCandidate();
		    
            item.EmployeeID = EmployeeID;
            
            item.ResumeX = ResumeX;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int JobCandidateID,int? EmployeeID,string ResumeX,DateTime ModifiedDate)
	    {
		    JobCandidate item = new JobCandidate();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.JobCandidateID = JobCandidateID;
				
			item.EmployeeID = EmployeeID;
				
			item.ResumeX = ResumeX;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
