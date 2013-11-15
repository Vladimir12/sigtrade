using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;

namespace SigTrade.Models
{
    public class PhaseRepository : IPhaseRepository
    {
        public int save(Phase p)
        {
            return DB.Save(p);
        }

        public IList<Phase> getAll()
        {
            return DB.Select().From<Phase>().Where("Deleted").IsNotEqualTo(true).ExecuteTypedList<Phase>();
        }


        public Phase getPhase(int id)
        {
            return DB.Get<Phase>(id); 
        }  

        public void delete(Phase p)
        {
            DB.Delete(p);
        }

    }
}
