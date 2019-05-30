using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EventExperimentServices.EventArguments
{
    public class MovementTypeEventArgs : AsyncCompletedEventArgs
    {
        public MovementTypeEventArgs(Exception error, bool cancelled, object userState, IList<string> direction)
            : base(error, cancelled, userState)
        {
            MovementDirection = direction;
        }

        public IList<string> MovementDirection { get; }
    }
}