using NHibernate;
using Crud.AssetManagement.Infrastructure.Contracts.Note;
using Crud.AssetManagement.Infrastructure.Utils;

namespace Crud.AssetManagement.Infrastructure.Repositories.Note
{
    public class NoteUnitOfWork : UnitOfWork, INoteUnitOfWork
    {
        public INoteRepository NoteRepository { get; }

        public NoteUnitOfWork(ISession session, INoteRepository noteRepository)
            : base(session)
        {
            NoteRepository = noteRepository;
        }
    }
}
