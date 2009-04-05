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
	/// Strongly-typed collection for the ProductReview class.
	/// </summary>
    [Serializable]
	public partial class ProductReviewCollection : ActiveList<ProductReview, ProductReviewCollection>
	{	   
		public ProductReviewCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ProductReviewCollection</returns>
		public ProductReviewCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ProductReview o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the ProductReview table.
	/// </summary>
	[Serializable]
	public partial class ProductReview : ActiveRecord<ProductReview>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ProductReview()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ProductReview(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ProductReview(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ProductReview(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("ProductReview", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarProductReviewID = new TableSchema.TableColumn(schema);
				colvarProductReviewID.ColumnName = "ProductReviewID";
				colvarProductReviewID.DataType = DbType.Int32;
				colvarProductReviewID.MaxLength = 0;
				colvarProductReviewID.AutoIncrement = true;
				colvarProductReviewID.IsNullable = false;
				colvarProductReviewID.IsPrimaryKey = true;
				colvarProductReviewID.IsForeignKey = false;
				colvarProductReviewID.IsReadOnly = false;
				colvarProductReviewID.DefaultSetting = @"";
				colvarProductReviewID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductReviewID);
				
				TableSchema.TableColumn colvarProductID = new TableSchema.TableColumn(schema);
				colvarProductID.ColumnName = "ProductID";
				colvarProductID.DataType = DbType.Int32;
				colvarProductID.MaxLength = 0;
				colvarProductID.AutoIncrement = false;
				colvarProductID.IsNullable = false;
				colvarProductID.IsPrimaryKey = false;
				colvarProductID.IsForeignKey = true;
				colvarProductID.IsReadOnly = false;
				colvarProductID.DefaultSetting = @"";
				
					colvarProductID.ForeignKeyTableName = "Product";
				schema.Columns.Add(colvarProductID);
				
				TableSchema.TableColumn colvarReviewerName = new TableSchema.TableColumn(schema);
				colvarReviewerName.ColumnName = "ReviewerName";
				colvarReviewerName.DataType = DbType.String;
				colvarReviewerName.MaxLength = 50;
				colvarReviewerName.AutoIncrement = false;
				colvarReviewerName.IsNullable = false;
				colvarReviewerName.IsPrimaryKey = false;
				colvarReviewerName.IsForeignKey = false;
				colvarReviewerName.IsReadOnly = false;
				colvarReviewerName.DefaultSetting = @"";
				colvarReviewerName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReviewerName);
				
				TableSchema.TableColumn colvarReviewDate = new TableSchema.TableColumn(schema);
				colvarReviewDate.ColumnName = "ReviewDate";
				colvarReviewDate.DataType = DbType.DateTime;
				colvarReviewDate.MaxLength = 0;
				colvarReviewDate.AutoIncrement = false;
				colvarReviewDate.IsNullable = false;
				colvarReviewDate.IsPrimaryKey = false;
				colvarReviewDate.IsForeignKey = false;
				colvarReviewDate.IsReadOnly = false;
				
						colvarReviewDate.DefaultSetting = @"(getdate())";
				colvarReviewDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReviewDate);
				
				TableSchema.TableColumn colvarEmailAddress = new TableSchema.TableColumn(schema);
				colvarEmailAddress.ColumnName = "EmailAddress";
				colvarEmailAddress.DataType = DbType.String;
				colvarEmailAddress.MaxLength = 50;
				colvarEmailAddress.AutoIncrement = false;
				colvarEmailAddress.IsNullable = false;
				colvarEmailAddress.IsPrimaryKey = false;
				colvarEmailAddress.IsForeignKey = false;
				colvarEmailAddress.IsReadOnly = false;
				colvarEmailAddress.DefaultSetting = @"";
				colvarEmailAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmailAddress);
				
				TableSchema.TableColumn colvarRating = new TableSchema.TableColumn(schema);
				colvarRating.ColumnName = "Rating";
				colvarRating.DataType = DbType.Int32;
				colvarRating.MaxLength = 0;
				colvarRating.AutoIncrement = false;
				colvarRating.IsNullable = false;
				colvarRating.IsPrimaryKey = false;
				colvarRating.IsForeignKey = false;
				colvarRating.IsReadOnly = false;
				colvarRating.DefaultSetting = @"";
				colvarRating.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRating);
				
				TableSchema.TableColumn colvarComments = new TableSchema.TableColumn(schema);
				colvarComments.ColumnName = "Comments";
				colvarComments.DataType = DbType.String;
				colvarComments.MaxLength = 3850;
				colvarComments.AutoIncrement = false;
				colvarComments.IsNullable = true;
				colvarComments.IsPrimaryKey = false;
				colvarComments.IsForeignKey = false;
				colvarComments.IsReadOnly = false;
				colvarComments.DefaultSetting = @"";
				colvarComments.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComments);
				
				TableSchema.TableColumn colvarModifiedDate = new TableSchema.TableColumn(schema);
				colvarModifiedDate.ColumnName = "ModifiedDate";
				colvarModifiedDate.DataType = DbType.DateTime;
				colvarModifiedDate.MaxLength = 0;
				colvarModifiedDate.AutoIncrement = false;
				colvarModifiedDate.IsNullable = false;
				colvarModifiedDate.IsPrimaryKey = false;
				colvarModifiedDate.IsForeignKey = false;
				colvarModifiedDate.IsReadOnly = false;
				
						colvarModifiedDate.DefaultSetting = @"(getdate())";
				colvarModifiedDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedDate);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["AdventureWorks"].AddSchema("ProductReview",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ProductReviewID")]
		[Bindable(true)]
		public int ProductReviewID 
		{
			get { return GetColumnValue<int>(Columns.ProductReviewID); }
			set { SetColumnValue(Columns.ProductReviewID, value); }
		}
		  
		[XmlAttribute("ProductID")]
		[Bindable(true)]
		public int ProductID 
		{
			get { return GetColumnValue<int>(Columns.ProductID); }
			set { SetColumnValue(Columns.ProductID, value); }
		}
		  
		[XmlAttribute("ReviewerName")]
		[Bindable(true)]
		public string ReviewerName 
		{
			get { return GetColumnValue<string>(Columns.ReviewerName); }
			set { SetColumnValue(Columns.ReviewerName, value); }
		}
		  
		[XmlAttribute("ReviewDate")]
		[Bindable(true)]
		public DateTime ReviewDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ReviewDate); }
			set { SetColumnValue(Columns.ReviewDate, value); }
		}
		  
		[XmlAttribute("EmailAddress")]
		[Bindable(true)]
		public string EmailAddress 
		{
			get { return GetColumnValue<string>(Columns.EmailAddress); }
			set { SetColumnValue(Columns.EmailAddress, value); }
		}
		  
		[XmlAttribute("Rating")]
		[Bindable(true)]
		public int Rating 
		{
			get { return GetColumnValue<int>(Columns.Rating); }
			set { SetColumnValue(Columns.Rating, value); }
		}
		  
		[XmlAttribute("Comments")]
		[Bindable(true)]
		public string Comments 
		{
			get { return GetColumnValue<string>(Columns.Comments); }
			set { SetColumnValue(Columns.Comments, value); }
		}
		  
		[XmlAttribute("ModifiedDate")]
		[Bindable(true)]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedDate); }
			set { SetColumnValue(Columns.ModifiedDate, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Product ActiveRecord object related to this ProductReview
		/// 
		/// </summary>
		public AdventureWorks.Product Product
		{
			get { return AdventureWorks.Product.FetchByID(this.ProductID); }
			set { SetColumnValue("ProductID", value.ProductID); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varProductID,string varReviewerName,DateTime varReviewDate,string varEmailAddress,int varRating,string varComments,DateTime varModifiedDate)
		{
			ProductReview item = new ProductReview();
			
			item.ProductID = varProductID;
			
			item.ReviewerName = varReviewerName;
			
			item.ReviewDate = varReviewDate;
			
			item.EmailAddress = varEmailAddress;
			
			item.Rating = varRating;
			
			item.Comments = varComments;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProductReviewID,int varProductID,string varReviewerName,DateTime varReviewDate,string varEmailAddress,int varRating,string varComments,DateTime varModifiedDate)
		{
			ProductReview item = new ProductReview();
			
				item.ProductReviewID = varProductReviewID;
			
				item.ProductID = varProductID;
			
				item.ReviewerName = varReviewerName;
			
				item.ReviewDate = varReviewDate;
			
				item.EmailAddress = varEmailAddress;
			
				item.Rating = varRating;
			
				item.Comments = varComments;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ProductReviewIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ReviewerNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ReviewDateColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EmailAddressColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn RatingColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CommentsColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ProductReviewID = @"ProductReviewID";
			 public static string ProductID = @"ProductID";
			 public static string ReviewerName = @"ReviewerName";
			 public static string ReviewDate = @"ReviewDate";
			 public static string EmailAddress = @"EmailAddress";
			 public static string Rating = @"Rating";
			 public static string Comments = @"Comments";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
