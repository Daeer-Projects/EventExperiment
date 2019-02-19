using System;
using System.Collections.Generic;
using System.Text;

namespace EventExperimentServices.Common
{
    public class Constants
    {
        public const string LogMessageTemplate = "{0} - {1} ({2}) - Details: {3}";

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
            "Wait",
            "Defend",
            "Duck",
            "Counter",
            "Hide",
            "Jump"
        };

        public static List<string> ObjectItems = new List<string>
        {
            "Door",
            "Chest",
            "Sword",
            "Axe",
            "Knife",
            "Armour",
            "Shield",
            "Table",
            "Food",
            "Drink"
        };

        public static List<string> MonsterItems = new List<string>
        {
            "Human",
            "Dwarf",
            "Elf",
            "Gnome",
            "Halfling",
            "Orc",
            "Ogre",
            "Troll",
            "Goblin"
        };
    }
}
