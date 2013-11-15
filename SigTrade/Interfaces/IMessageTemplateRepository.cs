using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignificantTradeSSRepository;

namespace SigTrade.Interfaces
{
    interface IMessageTemplateRepository
    {
        int save(MessageTemplate m);
        void delete(MessageTemplate m);
        IList<MessageTemplate> getAll();
        MessageTemplate getById(int id);
    }
}

