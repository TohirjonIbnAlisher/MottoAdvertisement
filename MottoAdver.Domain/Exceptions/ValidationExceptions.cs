﻿namespace MottoAdver.Domain.Exceptions;
public class ValidationExceptions : Exception
{
    public ValidationExceptions(string message) 
        : base(message)
    { }
}
