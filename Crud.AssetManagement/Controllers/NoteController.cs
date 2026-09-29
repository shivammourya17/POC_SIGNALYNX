using System.Threading.Tasks;
using AutoMapper;
using Signalynx;
using Microsoft.AspNetCore.Mvc;
using Crud.AssetManagement.Commands.Extensions;
using Crud.AssetManagement.Commands.Note;
using Crud.AssetManagement.DTOs.Note;
using Crud.AssetManagement.Utils;

namespace Crud.AssetManagement.Controllers
{
    // Signalynx pipeline: PreNoteDecorator -> PostNoteDecorator -> AddNoteCommandHandler.
    public class NoteController : BaseController
    {
        private readonly ISignalynx _signalynx;
        private readonly IMapper _mapper;

        public NoteController(ISignalynx signalynx, IMapper mapper)
        {
            _signalynx = signalynx;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddNoteAsync([FromBody] NoteDto dto)
        {
            var result = await _signalynx.CommandDispatchAsync<AddNoteCommand, string>(_mapper, dto);
            return FromResult(result);
        }
    }
}
