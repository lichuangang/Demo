using Dao.Demo;
using Entity.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    public class MeetingRoomData
    {
        private static IList<MeetingRoom> list = new List<MeetingRoom>();

        private static DateTime lastLoadTime = DateTime.Now;//上次加载时间
        private static int flushHours = 1;//一小时过期

        private static void Init()
        {
            lastLoadTime = DateTime.Now;
            list = new MeetingRoomDao().ToList();
        }

        public static IList<MeetingRoom> List
        {
            get
            {
                if (list == null || list.Count == 0 || (DateTime.Now - lastLoadTime).TotalHours > flushHours)
                {
                    Init();
                }

                return list;
            }
        }

        public static void Clear()
        {
            list.Clear();
        }

        public static MeetingRoom GetById(int id)
        {
            return List.FirstOrDefault(m => m.ID == id);
        }

        public static string GetRoomNameById(int id)
        {
            var room = GetById(id);
            if (room != null)
            {
                return room.Name;
            }
            else
            {
                return "未知会议室";
            }
        }
    }
}
