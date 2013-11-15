using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;

namespace SigTrade.Models
{
    public class MessageTemplateRepository : IMessageTemplateRepository
    {
        public int save(MessageTemplate m)
        {
            return DB.Save(m);
        }

        public IList<MessageTemplate> getAll()
        {
            return DB.Select().From<MessageTemplate>().Where("Deleted").IsNotEqualTo(true).ExecuteTypedList<MessageTemplate>();
        }

        public MessageTemplate getById(int id)
        {
            return DB.Get<MessageTemplate>(id);
        }

        public void delete(MessageTemplate m)
        {
            DB.Delete(m);
        }

    }
}
