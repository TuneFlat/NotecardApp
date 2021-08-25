using NotecardApp.Models;
using System.Collections.Generic;

namespace NotecardApp.Services
{
    public interface INotecardService
    {
        List<Notecard> SearchNotecards(int? id = null, string question = null, string answer = null,
            string hint = null);

        void AddNotecard(Notecard notecard);

        void AddNotecards(List<Notecard> notecards);

        void UpdateNotecard(Notecard notecard);

        void UpdateNotecards(List<Notecard> notecards);

        void DeleteNotecard(Notecard notecard);

        void DeleteNotecards(List<Notecard> notecards);
    }
}
