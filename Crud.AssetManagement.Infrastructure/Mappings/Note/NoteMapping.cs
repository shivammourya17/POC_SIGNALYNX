using FluentNHibernate.Mapping;
using Crud.AssetManagement.Infrastructure.Models.Note;

namespace Crud.AssetManagement.Infrastructure.Mappings.Note
{
    public class NoteMapping : ClassMap<NoteModel>
    {
        public NoteMapping()
        {
            Table("Note");
            Schema("Note");

            Id(x => x.NoteId).Column("NoteId").GeneratedBy.Identity();
            Map(x => x.Text);
            Map(x => x.PreProcessedDate);
            Map(x => x.CreatedDate);
            Map(x => x.PostProcessedDate);
        }
    }
}
