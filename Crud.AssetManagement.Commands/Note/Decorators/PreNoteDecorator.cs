using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using Signalynx;

namespace Crud.AssetManagement.Commands.Note.Decorators
{
    // PRE decorator: does its work before next(). Rejects an empty note without
    // calling the handler; otherwise stamps PreProcessedDate on the command.
    public class PreNoteDecorator : IPipelineBehavior<AddNoteCommand, Result<string>>
    {
        private readonly ILogger<PreNoteDecorator> _logger;

        public PreNoteDecorator(ILogger<PreNoteDecorator> logger)
        {
            _logger = logger;
        }

        public async ValueTask<Result<string>> HandleAsync(AddNoteCommand request, RequestHandlerDelegate<Result<string>> next, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(request.Text))
            {
                _logger.LogWarning("PRE: rejected, handler not called");
                return Result.Failure<string>("Text is required.");
            }

            request.PreProcessedDate = DateTime.UtcNow;
            _logger.LogInformation("PRE: validated, calling handler");

            return await next();
        }
    }
}
