using System.Collections.Generic;
using SignificantTrade.Models;

namespace SigTrade.Interfaces
{
    public interface ISPRepository
    {
        IList<MeetingLibSP> execute_spMeetingLib(int ID);
    }
}