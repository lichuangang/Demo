using Cache;
using Dao.Demo;
using Entity.Demo;
using Framework;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public partial class MeetingService
    {
        public MeetingService()
        {
            searchFunc = list =>
            {
                var data = list.Data.Select(m => new MeetingInfoDto
                {
                    UseDate = m.UseDate,
                    ID = m.ID,
                    MeetingRoomID = MeetingRoomData.GetRoomNameById(m.MeetingRoomID),
                    PeopleCount = m.PeopleCount,
                    Title = m.Title,
                    CreateUser = m.CreateUser
                }).ToList();

                return list.Copy<MeetingInfoDto>(data);
            };
        }

        MeetingRoomDao meetingRoomDao = new MeetingRoomDao();

        public HxResult GetMeeting(DateTime date)
        {
            var result = new HxResult();

            var checkedList = dao.ToList(m => m.UseDate == date);
            var data = MeetingRoomData.List.Select(m =>
            {
                return new
                {
                    id = m.ID,
                    name = m.Name,
                    checkedList = checkedList.Where(m1 => m1.MeetingRoomID == m.ID).Select(s =>
                    {
                        return new { title = s.Title, min = s.Begin, max = s.End };
                    }).ToList()
                };
            });


            //var data = checkedList.GroupBy(m => m.MeetingRoomID).Select(m =>
            //{

            //    return new
            //    {
            //        id = m.Key,
            //        name = MeetingRoomData.GetRoomNameById(m.Key),
            //        checkedList = m.Select(s =>
            //        {
            //            return new { title = s.Title, min = s.Begin, max = s.End };
            //        }).ToList()
            //    };
            //}).ToList();
            result.Data = data;
            return result;
        }

        public HxResult Save(MeetingDto model)
        {
            HxResult result = new HxResult();

            //数据检测
            var checkedList = dao.ToList(m => m.UseDate == model.date && m.MeetingRoomID == model.roomid);
            if (VilidateTime(model, checkedList))
            {
                Meeting meeting = new Meeting()
                {
                    CreateUser = "管理员",
                    MeetingRoomID = model.roomid,
                    Other = model.other,
                    PeopleCount = model.peopleCount,
                    Title = model.title,
                    UseDate = model.date,
                    Begin = model.min,
                    End = model.max
                };
                dao.Add(meeting);
            }
            else
            {
                result.Msg = "该时间段与其它会议有冲突，请刷新页面。重新选择时间段。";
            }

            return result;
        }

        private bool VilidateTime(MeetingDto model, IList<Meeting> list)
        {
            if (model.max == 0) return false;

            foreach (var item in list)
            {
                if ((item.Begin > model.min && item.End < model.max)
                    || (item.End > model.min && item.End < model.max)
                    || (model.min >= item.Begin && model.max <= item.End)
                    )
                {
                    return false;
                }
            }
            return true;
        }

        public HxResult DeleteById(long id)
        {
            dao.Delete(m => m.ID == id);

            return new HxResult();
        }

    }
}
