using System;
using Microsoft.CodeAnalysis;

namespace Forge.UI
{
    public class CompilationError : Exception
    {
        public CompilationError(Diagnostic diagnostic, string message)
        {
            Diagnostic = diagnostic;
            Message = message;
        }

        public override string Message { get; }

        public Diagnostic Diagnostic { get; }
    }
}