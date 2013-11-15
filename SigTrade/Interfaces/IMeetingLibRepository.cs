using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignificantTradeSSRepository;

namespace SigTrade.Interfaces
{
    public interface IMeetingLibRepository
    {
        int Save(MeetingLib m);
        IList<MeetingLib> getAllMeetingLibs();
        MeetingLib getMeetingLibByID(int ID);
        void Delete(MeetingLib m);
    }
}
