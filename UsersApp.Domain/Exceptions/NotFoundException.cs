using System;
using System.Diagnostics;

namespace UsersApp.Domain.Exceptions;

[StackTraceHidden]
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    { }
}

