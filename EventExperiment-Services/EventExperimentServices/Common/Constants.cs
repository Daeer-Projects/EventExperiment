using System;
using System.Collections.Generic;
using System.Text;

namespace EventExperimentServices.Common
{
    public class Constants
    {
        public static List<string> MovementItems = new List<string>
        {
            "N",
            "North",
            "NE",
            "North-East",
            "E",
            "East",
            "SE",
            "South-East",
            "S",
            "South",
            "SW",
            "South-West",
            "W",
            "West",
            "NW",
            "North-West",
            "U",
            "Up",
            "D",
            "Down"
        };

        public static List<string> ActionItems = new List<string>
        {
            "Hit",
            "Attack",
            "Open",
            "Close",
            "Lock",
            "Unlock",
            "Examine",
            "Search",
            "Talk",
            "Say",
            "Wait"
        };

        public static List<string> ReActionItems = new List<string>
        {
            "Defend",
            "Duck",
            "Counter",
            "Hide",
            "Jump"
        };
    }
}
