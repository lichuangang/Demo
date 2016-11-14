using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MeetingDto
    {
        public int roomid { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public string title { get; set; }

        public int peopleCount { get; set; }

        [Required]
        public string other { get; set; }

        public int min { get; set; }

        public int max { get; set; }
    }


    public class MeetingInfoDto
    {
        public DateTime UseDate { get; set; }
        public long ID { get; set; }
        public string MeetingRoomID { get; set; }
        public int PeopleCount { get; set; }
        public string Title { get; set; }
        public string CreateUser { get; set; }
    }
}
