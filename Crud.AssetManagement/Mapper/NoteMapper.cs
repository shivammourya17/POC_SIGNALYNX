using AutoMapper;
using Crud.AssetManagement.Commands.Note;
using Crud.AssetManagement.DTOs.Note;

namespace Crud.AssetManagement.Mapper
{
    public class NoteMapper : Profile
    {
        public NoteMapper()
        {
            CreateMap<NoteDto, AddNoteCommand>()
                .ForMember(dest => dest.PreProcessedDate, opt => opt.Ignore());
        }
    }
}
