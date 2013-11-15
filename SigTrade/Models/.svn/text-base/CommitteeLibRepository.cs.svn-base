using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;

namespace SigTrade.Models
{
    public class CommitteeLibRepository : ICommitteeLibRepository
    {
        public int save(CommitteeLib c)
        {
            return DB.Save(c);
        }

        public IList<CommitteeLib> getAll()
        {
            return DB.Select().From<CommitteeLib>().Where("Deleted").IsNotEqualTo(true).ExecuteTypedList<CommitteeLib>();
        }

        public CommitteeLib getCommittee(int id)
        {
            return DB.Get<CommitteeLib>(id); 
        }

        public void delete(CommitteeLib c)
        {
            DB.Delete(c);
        }

    }
}
