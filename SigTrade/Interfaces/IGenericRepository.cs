using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SignificantTradeSSRepository;
using SigTrade.Models;

namespace SigTrade.Interfaces
{
    public interface IGenericRepository
    {
        IList<Phase> getAllPhase();
        int getExternalRef(string description, string type);

        string GetDescriptionByType(int? externalRef, string type);

        IList<CommitteeLib> getAllCommittees();
        IList<MeetingLib> getAllMeetings();

        //Function to get the latest paragraph action for that review
        ParagraphAction getParagraphActionPerReview(int reviewid);

        IList<SelectItems> getAllCommitteesSelect();
        IList<SelectItems> getAllMeetingsSelect();

        IList<VwCountry> getAllCountries();
        string getConcernForParagraphAction(int paction_id);
        void SaveUser(UsersParagraphLink user);
        void DeleteUser(string key, int SourceID, int SourceType);
        UsersParagraphLink getUserByKey(string key);
        IList<UsersParagraphLink> getUserBySource(int SourceID, int SourceType);

        IList<UsersParagraphLink> getAllUsersBySource();

        IList<SelectItems> getAllLevelofConcerns();
        IList<SelectItems> GetAllDecisionTypes();
        IList<SelectItems> GetAllTradeTerms();

        DataSet getReportData(int country, int phase, int palibid, int concern, string actors, int kingdom, int taxonId);

        ParagraphActionLib getPActionLib(int ID);

        void resetCurrentConcernForReview(int ReviewID);

        bool getOldDataImportedStatus(int ReviewID);

    }

   
}
