using System.Threading.Tasks;
using NHibernate;
using Crud.AssetManagement.Infrastructure.Contracts.Note;
using Crud.AssetManagement.Infrastructure.Models.Note;
using Crud.AssetManagement.Infrastructure.Utils;

namespace Crud.AssetManagement.Infrastructure.Repositories.Note
{
    public class NoteRepository : BaseRepository<NoteModel>, INoteRepository
    {
        public NoteRepository(ISession session)
            : base(session)
        {
        }

        public async Task SaveAsync(NoteModel model)
        {
            await AddAsync(model);
        }

        public async Task<NoteModel> GetByIdAsync(int id)
        {
            return await FindByIdAsync(id);
        }
    }
}
