using Entity.Demo;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{	

	public partial class MeetingRoomQuery : QueryPage<MeetingRoom>
    {
		
		/// <summary>
		/// ID
		/// </summary>		
		public int ID { get; set; }
		
		/// <summary>
		/// Name
		/// </summary>		
		public string Name { get; set; }
		
		/// <summary>
		/// Address
		/// </summary>		
		public string Address { get; set; }
		
		/// <summary>
		/// PeopleCount
		/// </summary>		
		public int PeopleCount { get; set; }
		
		/// <summary>
		/// AdminInfo
		/// </summary>		
		public string AdminInfo { get; set; }
		 
    }
}
		