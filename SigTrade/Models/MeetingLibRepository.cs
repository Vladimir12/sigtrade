using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;

namespace SigTrade.Models
{
    public class MeetingLibRepository : IMeetingLibRepository
    {

        public int Save(MeetingLib m)
        {
            int i = 0;
            try
            {
                i=DB.Save(m);
            }catch( Exception e)
            {
                Console.Write(e.Message);
            }
            return i;
        }


        public IList<MeetingLib> getAllMeetingLibs()
        {
            return DB.Select().From<MeetingLib>().Where("Deleted").IsNotEqualTo(true).ExecuteTypedList<MeetingLib>();
        }


        public MeetingLib getMeetingLibByID(int ID)
        {
            return DB.Get<MeetingLib>(ID);
        }

        #region IMeetingLibRepository Members

        public void Delete(MeetingLib m)
        {
            DB.Delete(m);
        }

        #endregion
    }
}