using System.Threading.Tasks;
using Crud.AssetManagement.Infrastructure.Models.Note;

namespace Crud.AssetManagement.Infrastructure.Contracts.Note
{
    public interface INoteRepository
    {
        Task SaveAsync(NoteModel model);
        Task<NoteModel> GetByIdAsync(int id);
    }
}
