using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;
using SubSonic;

namespace SigTrade.Models
{
    public class GenericRepository : IGenericRepository
    {
        public IList<Phase> getAllPhase()
        {
            return DB.Select("ID", "PhaseDesc").From<Phase>().Where(Phase.DeletedColumn).IsNotEqualTo(true).ExecuteTypedList<Phase>();

        }

        //function to return the concern ID for the current paragraph action
        public string getConcernForParagraphAction(int paction_id)
        {
            int concernid = 0;
            string concern = null;

            List<ParagraphAction> paction =
                DB.Select("ConcernID").From<ParagraphAction>().Where(ParagraphAction.IdColumn).IsEqualTo(paction_id).
                    ExecuteTypedList<ParagraphAction>();
            
            switch (paction.First().ConcernID) {
                case UpdateUtils.URGENT_CONCERN_ID:
                    concern = UpdateUtils.URGENT_CONCERN;
                    break;
                case UpdateUtils.POSSIBLE_CONCERN_ID:
                    concern = UpdateUtils.POSSIBLE_CONCERN;
                    break;
                case UpdateUtils.LEAST_CONCERN_ID:
                    concern = UpdateUtils.LEAST_CONCERN;
                    break;
                case UpdateUtils.NOT_CLASSIFIED_ID:
                    concern = UpdateUtils.NOT_CLASSIFIED;
                    break;
            }
            return concern;
        }

        public int getExternalRef(string description, string type)
        {
            return
                int.Parse(DB.Select().From<GeneralLib>().Where(GeneralLib.DescriptionColumn).Like(description).And(
                    GeneralLib.TypeColumn).Like(type).And(GeneralLib.ValidColumn).IsEqualTo(true).ExecuteDataSet().
                    Tables[0].Rows[0]["ExternalRef"].ToString());

        }

        public IList<MeetingLib> getAllMeetings()
        {

            return DB.Select().From<MeetingLib>().ExecuteTypedList<MeetingLib>();
        }

        public IList<CommitteeLib> getAllCommittees()
        {

            return DB.Select().From<CommitteeLib>().ExecuteTypedList<CommitteeLib>();
        }

        public IList<SelectItems> getAllCommitteesSelect()
        {

           return DB.Select(CommitteeLib.IdColumn.DisplayName,CommitteeLib.DescriptionColumn.DisplayName).From<CommitteeLib>().ExecuteTypedList<SelectItems>();

          
        }

        public IList<SelectItems> getAllMeetingsSelect()
        {

            //return DB.Select("MeetingLibID", "MeetingLibDesc").From<MeetingLib>().ExecuteTypedList<SelectItems>();
            return
                DB.Query().ExecuteTypedList<SelectItems>(
                    "select MeetingLibID as ID, MeetingLibNumber + '-' + MeetingLibDesc + ' [' + convert(varchar(4),MeetingLibDate,100) + '' +  DATENAME(Year,MeetingLibDate) + ']' as Description  from tblMeetingLib where deleted=0 order by 2");

            
        }

        public IList<VwCountry> getAllCountries()
        {
            return DB.SelectAllColumnsFrom<VwCountry>().ExecuteTypedList<VwCountry>();
        }

         public void SaveUser(UsersParagraphLink user)
         {
             DB.Save(user);

         }

        public UsersParagraphLink getUserByKey(string key)
        {
            if ( DB.Select().From<UsersParagraphLink>().Where(UsersParagraphLink.UserIDColumn).IsEqualTo(key).ExecuteDataSet().Tables[0].Rows.Count >0)
            return
                DB.Select().From<UsersParagraphLink>().Where(UsersParagraphLink.UserIDColumn).IsEqualTo(key).ExecuteTypedList
                    <UsersParagraphLink>()[0];
            else
            {
                return null;
            }

        }

        public void DeleteUser(string key, int SourceID, int SourceType)
        {
            if (DB.Select().From<UsersParagraphLink>().Where(UsersParagraphLink.SourceIDColumn).IsEqualTo(SourceID).And(UsersParagraphLink.SourceTypeColumn).
                IsEqualTo(SourceType).GetRecordCount() > 0)
            {

               DB.Delete().From<UsersParagraphLink>().Where(UsersParagraphLink.SourceIDColumn).IsEqualTo(SourceID).And(UsersParagraphLink.SourceTypeColumn).
                        IsEqualTo(SourceType).ExecuteSingle<UsersParagraphLink>();

                          }
            

        }

        public IList<UsersParagraphLink> getUserBySource(int SourceID, int SourceType)
        {
            return
                DB.Select().From<UsersParagraphLink>().Where(UsersParagraphLink.SourceIDColumn).IsEqualTo(SourceID).And(
                    UsersParagraphLink.SourceTypeColumn).
                    IsEqualTo(SourceType).And(UsersParagraphLink.DeletedColumn).IsNotEqualTo(1).ExecuteTypedList<UsersParagraphLink>();

        }

        public IList<UsersParagraphLink> getAllUsersBySource()
        {
            return
                DB.Select(UsersParagraphLink.UserIDColumn.DisplayName).From<UsersParagraphLink>().Distinct().Where(UsersParagraphLink.DeletedColumn).IsNotEqualTo(1).ExecuteTypedList<UsersParagraphLink>();

        }

        public ParagraphAction getParagraphActionPerReview(int reviewid)
        {
           return SPs.SpGetTopParagraphActionPerReview(reviewid).ExecuteTypedList<ParagraphAction>().First();
        }

        public IList<SelectItems> getAllLevelofConcerns()
        {
            return 
                DB.Select().From
                    <GeneralLib>().Where(GeneralLib.TypeColumn).IsEqualTo(UpdateUtils.TYPE_CONCERN).ExecuteTypedList
                    <SelectItems>();

        }

        public IList<SelectItems> GetAllDecisionTypes()
        {

            return
                DB.Select("ExternalRef" , "Description").From<GeneralLib>().Where(GeneralLib.TypeColumn).IsEqualTo(UpdateUtils.TYPE_DECISION).ExecuteTypedList
                   <SelectItems>();

            //return
             //   DB.Query().ExecuteTypedList<SelectItems>(
                //   @"Select ExternalRef as ID, Description from GeneralLib where Type = 'decisiontype'");
        }

        public IList<SelectItems> GetAllTradeTerms() {

            return
                DB.Select("ExternalRef", "Description").From<GeneralLib>().Where(GeneralLib.TypeColumn).IsEqualTo(UpdateUtils.TYPE_TRADETERMS).ExecuteTypedList
                    <SelectItems>();
        }

        public DataSet getReportData(int country, int phase, int paLibId, int concern, string actors, int kingdom, int taxonId)
        {
            DataSet dataTest = null;

            dataTest = SPs.SpGetGenericReport(country, phase, paLibId, concern, actors, kingdom, taxonId).GetDataSet();

            return dataTest;
        }

        public ParagraphActionLib getPActionLib(int ID)
        {
            return DB.Get<ParagraphActionLib>(ID);
        }

        public void resetCurrentConcernForReview(int ReviewID)
        {

            SPs.SpResetCurrentConcernForReview(ReviewID).Execute();

        }

        
        public string GetDescriptionByType(int? externalRef, string type) {
            return
                DB.Select(GeneralLib.DescriptionColumn.DisplayName).From<GeneralLib>().Where(
                    GeneralLib.ExternalRefColumn).
                    IsEqualTo(externalRef).And(GeneralLib.TypeColumn).Like(type).ExecuteDataSet().Tables[0].Rows[0][0].
                    ToString();
                   

            //return DB.Select().From<GeneralLib>().Where(
              //     GeneralLib.ExternalRefColumn).
                //    IsEqualTo(externalRef).ExecuteDataSet().Tables[0].Rows.Count.ToString();

                    //.ExecuteDataSet().Tables[0].Rows[0]
                    //[GeneralLib.DescriptionColumn.DisplayName].ToString();
        }

        public bool getOldDataImportedStatus(int ReviewID) {

            ParagraphAction p =
                DB.Select().From<ParagraphAction>().Where(ParagraphAction.ReviewIDColumn.DisplayName).IsEqualTo(ReviewID)
                    .ExecuteSingle<ParagraphAction>();

            if (p !=null)
             if (p.CompletedDate != null)
                if (p.CompletedDate.Equals(DateTime.Parse("2008-01-01")))
                    return true;
            return false;
            //return p.Completed;


//               int.Parse( DB.Select(ParagraphAction.CompletedColumn.DisplayName).From(ParagraphAction.Schema).Where(
  //                  ParagraphAction.ReviewIDColumn.DisplayName).IsEqualTo(ReviewID).ExecuteScalar().ToString());

        }
    }
}
