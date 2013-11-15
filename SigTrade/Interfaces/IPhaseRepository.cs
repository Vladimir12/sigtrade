using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignificantTradeSSRepository;

namespace SigTrade.Interfaces
{
    public interface IPhaseRepository
    {
        IList<Phase> getAll();
        Phase getPhase(int id);    
        int save(Phase p);
        void delete(Phase p);
    }
}
