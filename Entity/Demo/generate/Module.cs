using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Demo
{	

	public partial class Module
    {
		
		/// <summary>
		/// ID
		/// </summary>		
		public int ID { get; set; }
		
		/// <summary>
		/// ParentID
		/// </summary>		
		public int ParentID { get; set; }
		
		/// <summary>
		/// Name
		/// </summary>		
		public string Name { get; set; }
		
		/// <summary>
		/// Title
		/// </summary>		
		public string Title { get; set; }
		
		/// <summary>
		/// 0 
		/// </summary>		
		public bool IsShow { get; set; }
		
		/// <summary>
		/// Url
		/// </summary>		
		public string Url { get; set; }
		
		/// <summary>
		/// IconCls
		/// </summary>		
		public string IconCls { get; set; }
		 
    }
}
		