using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;

namespace SigTrade.Models
{
    public class CountryRepository : ICountryRepository
    {
    
        public IList<VwCountry> getAll()
        {
            return DB.Select().From<VwCountry>().OrderAsc("CtyShort").ExecuteTypedList<VwCountry>();
        }

        public VwCountry getCountry(int id)
        {
            return DB.Select().From<VwCountry>().Where("CtyRecID").IsEqualTo(id).ExecuteSingle<VwCountry>();
        }

    }
}
