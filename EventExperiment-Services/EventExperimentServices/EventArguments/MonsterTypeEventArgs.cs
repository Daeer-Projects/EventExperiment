using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EventExperimentServices.EventArguments
{
    public class MonsterTypeEventArgs : AsyncCompletedEventArgs
    {
        public MonsterTypeEventArgs(Exception error, bool cancelled, object userState, IList<string> monsters)
            : base(error, cancelled, userState)
        {
            Monsters = monsters;
        }

        public IList<string> Monsters { get; }
    }
}