using System;
using CSharpFunctionalExtensions;
using Signalynx;

namespace Crud.AssetManagement.Commands.Note
{
    public class AddNoteCommand : ICommand<Result<string>>
    {
        public string Text { get; set; }

        // Set by PreNoteDecorator before the handler runs; the handler persists it.
        public DateTime? PreProcessedDate { get; set; }
    }
}
