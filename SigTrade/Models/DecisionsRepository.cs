using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;

namespace SigTrade.Models {
    public class DecisionsRepository: IDecisionsRepository {

        public IList<Decision> GetAllDecisionsPerParagraph(int pactionId) {

            
                
            return
DB.Select().From<Decision>().Where(Decision.ParagraphActionIDColumn).IsEqualTo(pactionId).And(Decision.DeletedColumn).IsNull().ExecuteTypedList<Decision>();
       

          //  throw new NotImplementedException();
        }


        public int SaveDecision(Decision dec) {
            return DB.Save(dec);
       
        }

        public void DeleteDecision(int decisionId) {
            Decision dec = DB.Get<Decision>(decisionId);
            dec.DeletedDate = DateTime.Now;
            DB.Save(dec);
            DB.Delete(dec);
           
        }

      
    }
}
