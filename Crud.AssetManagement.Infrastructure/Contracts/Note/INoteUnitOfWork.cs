namespace Crud.AssetManagement.Infrastructure.Contracts.Note
{
    public interface INoteUnitOfWork : IUnitOfWork
    {
        INoteRepository NoteRepository { get; }
    }
}
