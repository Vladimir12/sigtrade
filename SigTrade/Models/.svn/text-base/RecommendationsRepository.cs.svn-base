using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;

namespace SigTrade.Models
{
    public class RecommendationsRepository: IRecommendationsRepository
    {
       public int SaveRec(Recommendation r)
       {
           return DB.Save(r);

       }

        public IList<Recommendation> getAllRecommendationsByParagraph(int PActionID)
        {
            return
                DB.Select().From<Recommendation>().Where(Recommendation.ParagraphActionIDColumn).IsEqualTo(PActionID).And(Recommendation.DeletedColumn).IsNotEqualTo(1).ExecuteTypedList<Recommendation>();

        }

        public void DeleteRecommendation(int id)
        {

            Recommendation rec = DB.Get<Recommendation>(id);
            rec.DeletedDate = DateTime.Now;
            DB.Save(rec);
            DB.Delete(rec);
          }
    }
}
