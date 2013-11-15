
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;

namespace SigTrade.Models
{
    public class MessageLogRepository : IMessageLogRepository
    {
        public int save(MessageLog m)
        {
            return DB.Save(m);
        }

        public IList<MessageLog> getAll()
        {
            return DB.Select().From<MessageLog>().Where("Deleted").IsNotEqualTo(true).ExecuteTypedList<MessageLog>();
        }

        public MessageLog getById(int id)
        {
            return DB.Get<MessageLog>(id);
        }

        public void delete(MessageLog m)
        {
            DB.Delete(m);
        }

    }
}
