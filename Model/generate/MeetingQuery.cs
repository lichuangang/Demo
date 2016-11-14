using Entity.Demo;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{	

	public partial class MeetingQuery : QueryPage<Meeting>
    {
		
		/// <summary>
		/// ID
		/// </summary>		
		public long ID { get; set; }
		
		/// <summary>
		/// MeetingRoomID
		/// </summary>		
		public int MeetingRoomID { get; set; }
		
		/// <summary>
		/// Title
		/// </summary>		
		public string Title { get; set; }
		
		/// <summary>
		/// UseDate
		/// </summary>		
		public DateTime UseDate { get; set; }
		
		/// <summary>
		/// CreateUser
		/// </summary>		
		public string CreateUser { get; set; }
		
		/// <summary>
		/// PeopleCount
		/// </summary>		
		public int PeopleCount { get; set; }
		
		/// <summary>
		/// Other
		/// </summary>		
		public string Other { get; set; }
		
		/// <summary>
		/// Begin
		/// </summary>		
		public int Begin { get; set; }
		
		/// <summary>
		/// End
		/// </summary>		
		public int End { get; set; }
		 
    }
}
		