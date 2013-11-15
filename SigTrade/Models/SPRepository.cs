using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SignificantTrade.Models;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;

namespace SigTrade.Models
{
    public class SPRepository : ISPRepository
    {
        public SPRepository()
        {
        }

        public IList<MeetingLibSP> execute_spMeetingLib(int ID)
        {
            return SignificantTradeSSRepository.SPs.SpMeetingLibTest(1).ExecuteTypedList<MeetingLibSP>();
        }

        public IList<AGeneralTaxon> searchByTaxon(string search)
        {
            var taxons = SPs.SpGetCurrentSigtradeTaxons(search).ExecuteTypedList<AGeneralTaxon>();
             if (taxons != null && taxons.Count > 0)
             {
                 return taxons;
             }
                 
           // return  rows.CopyTo(string [] Taxons,0)
            return null;
        }

    }
}