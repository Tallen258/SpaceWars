using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars.Logic.Exceptions;

[Serializable]
public class TooManyPlayersException : Exception
{
    public TooManyPlayersException()
    {
    }

    public TooManyPlayersException(string? message) : base(message)
    {
    }

    public TooManyPlayersException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected TooManyPlayersException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
