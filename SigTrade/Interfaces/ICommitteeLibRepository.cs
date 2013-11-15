using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignificantTradeSSRepository;

namespace SigTrade.Interfaces
{
    public interface ICommitteeLibRepository
    {
        IList<CommitteeLib> getAll();
        CommitteeLib getCommittee(int id);    
        int save(CommitteeLib c);
        void delete(CommitteeLib c);
    }
}
