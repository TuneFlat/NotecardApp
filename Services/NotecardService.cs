using NotecardApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace NotecardApp.Services
{
    public class NotecardService : INotecardService
    {
        private NotecardRepository _notecardRepository;

        #region Constructor

        public NotecardService()
        {
            _notecardRepository = new NotecardRepository(new NotecardModel());
        }

        #endregion


        #region Search

        public List<Notecard> SearchNotecards(int? id = null, string question = null, string answer = null,
            string hint = null)
        {
            var query = _notecardRepository.GetNotecards();
            return query.ToList();
        }

        #endregion


        #region Add

        public void AddNotecard(Notecard notecard)
        {
            _notecardRepository.InsertNotecard(notecard);
        }

        public void AddNotecards(List<Notecard> notecards)
        {
            _notecardRepository.InsertNotecards(notecards);
        }

        #endregion


        #region Update

        public void UpdateNotecard(Notecard notecard)
        {
            _notecardRepository.UpdateNotecard(notecard);
        }

        public void UpdateNotecards(List<Notecard> notecards)
        {
            _notecardRepository.UpdateNotecards(notecards);
        }

        #endregion


        #region Delete

        public void DeleteNotecard(Notecard notecard)
        {
            _notecardRepository.DeleteNotecard(notecard);
        }

        public void DeleteNotecards(List<Notecard> notecards)
        {
            _notecardRepository.DeleteNotecards(notecards);
        }

        #endregion
    }
}
