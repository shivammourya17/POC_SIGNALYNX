using System;

namespace Crud.AssetManagement.Infrastructure.Models.Note
{
    public class NoteModel
    {
        public virtual int NoteId { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime? PreProcessedDate { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? PostProcessedDate { get; set; }
    }
}
