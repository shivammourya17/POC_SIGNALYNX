using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using Signalynx;
using Crud.AssetManagement.Infrastructure.Contracts.Note;

namespace Crud.AssetManagement.Commands.Note.Decorators
{
    // POST decorator: calls next() first, then works on the handler's result.
    // Loads the saved note through NHibernate and stamps PostProcessedDate.
    public class PostNoteDecorator : IPipelineBehavior<AddNoteCommand, Result<string>>
    {
        private readonly INoteUnitOfWork _noteUnitOfWork;
        private readonly ILogger<PostNoteDecorator> _logger;

        public PostNoteDecorator(INoteUnitOfWork noteUnitOfWork, ILogger<PostNoteDecorator> logger)
        {
            _noteUnitOfWork = noteUnitOfWork;
            _logger = logger;
        }

        public async ValueTask<Result<string>> HandleAsync(AddNoteCommand request, RequestHandlerDelegate<Result<string>> next, CancellationToken cancellationToken = default)
        {
            var result = await next();

            if (result.IsFailure)
            {
                return result;
            }

            var model = await _noteUnitOfWork.NoteRepository.GetByIdAsync(int.Parse(result.Value));
            model.PostProcessedDate = DateTime.UtcNow;
            await _noteUnitOfWork.FlushAsync();

            _logger.LogInformation("POST: note {NoteId} stamped after handler", model.NoteId);

            return result;
        }
    }
}
