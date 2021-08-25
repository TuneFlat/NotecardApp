using NotecardApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotecardApp.Models
{
    public class NotecardRepository
    {
        private NotecardModel _notecardModel;
        private bool _disposed = false;

        public NotecardRepository(NotecardModel _notecardModel)
        {
            this._notecardModel = _notecardModel;
        }

        public void DeleteNotecard(Notecard notecard)
        {
            _notecardModel.Notecards.Remove(notecard);
        }

        public void DeleteNotecards(List<Notecard> notecards)
        {
            _notecardModel.Notecards.RemoveRange(notecards);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _notecardModel.Dispose();
                }
            }
            _disposed = true;
        }

        public Notecard GetNotecardById(int notecardId)
        {
            return _notecardModel.Notecards.Find(notecardId);
        }

        public IEnumerable<Notecard> GetNotecards()
        {
            return _notecardModel.Notecards.ToList();
        }

        public void InsertNotecard(Notecard notecard)
        {
            _notecardModel.Notecards.Add(notecard);
        }

        public void InsertNotecards(List<Notecard> notecards)
        {

            _notecardModel.Notecards.AddRange(notecards);
        }

        public void Save()
        {
            _notecardModel.SaveChanges();
        }

        public void UpdateNotecard(Notecard notecard)
        {
            _notecardModel.Entry(notecard).State = EntityState.Modified;
        }

        public void UpdateNotecards(List<Notecard> notecards)
        {
            _notecardModel.Entry(notecards).State = EntityState.Modified;
        }
    }
}
