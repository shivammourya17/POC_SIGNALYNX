using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using Signalynx;
using Crud.AssetManagement.Infrastructure.Contracts.Note;
using Crud.AssetManagement.Infrastructure.Models.Note;

namespace Crud.AssetManagement.Commands.Note
{
    public class AddNoteCommandHandler : ICommandHandler<AddNoteCommand, Result<string>>
    {
        private readonly INoteUnitOfWork _noteUnitOfWork;
        private readonly ILogger<AddNoteCommandHandler> _logger;

        public AddNoteCommandHandler(INoteUnitOfWork noteUnitOfWork, ILogger<AddNoteCommandHandler> logger)
        {
            _noteUnitOfWork = noteUnitOfWork;
            _logger = logger;
        }

        public async ValueTask<Result<string>> HandleAsync(AddNoteCommand request, CancellationToken cancellationToken = default)
        {
            var model = new NoteModel
            {
                Text = request.Text,
                PreProcessedDate = request.PreProcessedDate,
                CreatedDate = DateTime.UtcNow
            };

            await _noteUnitOfWork.NoteRepository.SaveAsync(model);
            await _noteUnitOfWork.FlushAsync();

            _logger.LogInformation("HANDLER: note {NoteId} saved", model.NoteId);

            return Result.Success(model.NoteId.ToString());
        }
    }
}
