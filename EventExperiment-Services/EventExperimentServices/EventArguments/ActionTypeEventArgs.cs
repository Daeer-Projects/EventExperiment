using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EventExperimentServices.EventArguments
{
    public class ActionTypeEventArgs : AsyncCompletedEventArgs
    {
        public ActionTypeEventArgs(Exception error, bool cancelled, object userState, IList<string> actions)
            : base(error, cancelled, userState)
        {
            Actions = actions;
        }

        public IList<string> Actions { get; }
    }
}