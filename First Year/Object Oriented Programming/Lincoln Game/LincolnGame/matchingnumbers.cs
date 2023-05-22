using System;
using System.Collections.Generic;
using System.Text;

namespace LincolnGame
{
    [Serializable]
    class MatchingNumberException : Exception
    {
        public MatchingNumberException() { }
        public MatchingNumberException(string message)
        : base(message) { }
    }
}
