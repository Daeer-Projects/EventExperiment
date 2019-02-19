using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EventExperimentServices.EventArguments
{
    public class ObjectTypeEventArgs : AsyncCompletedEventArgs
    {
        public ObjectTypeEventArgs(Exception error, bool cancelled, object userState, IList<string> objects)
            : base(error, cancelled, userState)
        {
            ObjectsList = objects;
        }

        public IList<string> ObjectsList { get; }
    }
}