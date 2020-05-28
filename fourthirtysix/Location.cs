using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourthirtysix
{
    /// <summary>
    /// Describes a location.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// The ID of this location.
        /// </summary>
        public string ID;
        /// <summary>
        /// The Friendly Name of this location.
        /// </summary>
        public string FriendlyName;
        /// <summary>
        /// The description of this location.
        /// </summary>
        public string Description;
        public bool NoBack = false;

        public Location ToNorth;
        public Location ToSouth;
        public Location ToWest;
        public Location ToEast;
        public Location Up;
        public Location Down;

        public Inventory LocationInventory = new Inventory();

        /// <summary>
        /// Describes a location.
        /// </summary>
        /// <param name="id">The ID of this location (like sample_house)</param>
        /// <param name="name">The friendly name of this location (like Sample House)</param>
        /// <param name="description">The descriptor of this location</param>
        public Location(string id, string name, string description)
        {
            ID = id;
            FriendlyName = name;
            Description = description;
        }

        /// <summary>
        /// Describes a location.
        /// </summary>
        /// <param name="id">The ID of this location (like sample_house)</param>
        /// <param name="name">The friendly name of this location (like Sample House)</param>
        public Location(string id, string name)
        {
            ID = id;
            FriendlyName = name;
        }

        /// <summary>
        /// Describes a location.
        /// </summary>
        /// <param name="id">The ID of this location (like sample_house)</param>
        public Location(string id)
        {
            ID = id;
        }

        /// <summary>
        /// Describes a location.
        /// </summary>
        public Location() { }
    }

    public static class Locations
    {
        private static Location Current;
        private static Location Previous;

        #region Regions

        #region Hardcoded
        // do NOT modify; used in code to represent a location that is undefined right now
        public static Location Narnia = new Location("narnia", "Undefined Location", "How did you get here?");
        // do NOT modify; used in code to prevent user from travelling any more in a certain direction
        public static Location Wall = new Location("wall", "Undefined Location", "How did you get here?");
        // do NOT modify; used in code to prepresent a location that you cannot leave
        public static Location LostSource = new Location("lost_source", "Middle of Nowhere", "How did you get here? You've become disoriented and don't know the directions.");
        // do NOT modify; used in code to prepresent a location that you cannot leave
        public static Location Lost = new Location("lost", "Middle of Nowhere", "How did you get here? You've become disoriented and don't know the directions.");
        #endregion

        // sample location, copy-paste this for new ones
        public static Location CoolHouse = 
            new Location("cool_house", "Cool House", "You are right outside the Cool House, you vaguely see something to the East, and West of you.");

        public static Location NCoolHouse =
            new Location("n_cool_house", "North of Cool House", "You see a window leading inside the Cool House, " +
                "it's closed, and appears to be locked. To the north, you see a thick forest you don't think you can get through.");

        public static Location SCoolHouse =
            new Location("s_cool_house", "South of Cool House", "There is an extremely tall tree with something faintly glistening at the top.");

        public static Location Frontyard =
            new Location("frontyard", "Frontyard", 
                "There is a small mailbox here. Beyond that there is only a thick forest.");

        public static Location Backyard =
            new Location("backyard", "Backyard", "You see a swingset too small for you to sit in. " +
                "There is a fence to the North, West, and South; but the South fence " +
                "is missing some planks where it looks like you might be able to fit through.");

        public static Location NECoolHouse =
            new Location("ne_cool_house", "North East of Cool House", "You are standing in an open field.");

        public static Location NWCoolHouse =
            new Location("nw_cool_house", "North West of Cool House", "You are standing in an open field.");

        public static Location SECoolHouse =
            new Location("se_cool_house", "South East of Cool House", "You are standing in an open field.");

        public static Location SWCoolHouse =
            new Location("sw_cool_house", "South West of Cool House", "You are standing in an open field. To the south of you there is an open cave enterance.");

        #endregion

        public enum Direction
        {
            North = 0,
            East = 1,
            South = 2,
            West = 3,
            Up = 4,
            Down = 5,
            // internal use only
            Back = 6
        }

        // run this ONCE on startup!!!!!! IMPORTANT!
        // set all directionals here
        /// <summary>
        /// Initialize the map.
        /// </summary>
        public static void InitializeMap()
        {
            // Set whatever you want the initial room to be
            Locations.Current = CoolHouse;
            Locations.Previous = Wall;

            // Starting tile, Cool House
            #region Cool House (cool_house)
            CoolHouse.ToNorth = NCoolHouse;
            CoolHouse.ToSouth = SCoolHouse;
            CoolHouse.ToWest = Backyard;
            CoolHouse.ToEast = Frontyard;
            CoolHouse.Up = Wall;
            CoolHouse.Down = Wall;
            #endregion

            // East of Cool House
            #region Frontyard (frontyard)
            Frontyard.ToNorth = Wall;
            Frontyard.ToSouth = Wall;
            Frontyard.ToWest = CoolHouse;
            Frontyard.ToEast = Wall;
            Frontyard.Up = Wall;
            Frontyard.Down = Wall;
            #endregion

            // West of Cool House
            #region Backyard (backyard)
            Backyard.ToNorth = Wall;
            Backyard.ToSouth = SWCoolHouse;
            Backyard.ToWest = Wall;
            Backyard.ToEast = CoolHouse;
            Backyard.Up = Wall;
            Backyard.Down = Wall;
            Backyard.LocationInventory.Add(Items.DamagedFence, 1);
            #endregion

            // North of Cool House
            #region North of Cool House (n_cool_house)
            NCoolHouse.ToNorth = LostSource;
            NCoolHouse.ToSouth = CoolHouse;
            NCoolHouse.ToWest = Wall;
            NCoolHouse.ToEast = Wall;
            NCoolHouse.Up = Wall;
            NCoolHouse.Down = Wall;
            #endregion

            // South of Cool House
            #region South of Cool House (s_cool_house)
            SCoolHouse.ToNorth = CoolHouse;
            SCoolHouse.ToSouth = LostSource;
            SCoolHouse.ToWest = SWCoolHouse;
            SCoolHouse.ToEast = SECoolHouse;
            SCoolHouse.Up = Wall;
            SCoolHouse.Down = Wall;
            #endregion

            #region AllLost
            // If you are lost this is where you will be first
            #region Lost Source (lost_source)
            LostSource.ToNorth = Lost;
            LostSource.ToSouth = Lost;
            LostSource.ToWest = Lost;
            LostSource.ToEast = Lost;
            LostSource.Up = Lost;
            LostSource.Down = Lost;
            #endregion

            // If you are lost you are fucked. Restart time
            #region Lost
            Lost.ToNorth = Lost;
            Lost.ToSouth = Lost;
            Lost.ToWest = Lost;
            Lost.ToEast = Lost;
            Lost.Up = Lost;
            Lost.Down = Lost;
            Lost.NoBack = true;
            #endregion

            #endregion Lost
        }

        /// <summary>
        /// Force a location change.
        /// </summary>
        /// <param name="loc">The location to set to.</param>
        public static void Set(Location loc)
        {
            Previous = Current;
            Current = loc;
        }

        /// <summary>
        /// Get's the user's current location
        /// </summary>
        public static Location Get()
        {
            return Current;
        }

        /// <summary>
        /// Attempt to travel in a direction.
        /// </summary>
        /// <param name="dir">The direction to travel in.</param>
        /// <returns>True if the travel is possible, otherwise false.</returns>
        public static bool TryTravel(Direction dir)
        {
            Location tp = Previous;
            Previous = Current;
            if(dir == Direction.North && Current.ToNorth.ID != "wall") { Current = Current.ToNorth; return true; }
            else if (dir == Direction.South && Current.ToSouth.ID != "wall") { Current = Current.ToSouth; return true; }
            else if (dir == Direction.West && Current.ToWest.ID != "wall") { Current = Current.ToWest; return true; }
            else if (dir == Direction.East && Current.ToEast.ID != "wall") { Current = Current.ToEast; return true; }
            else if (dir == Direction.Up && Current.Up.ID != "wall") { Current = Current.Up; return true; }
            else if (dir == Direction.Down && Current.Down.ID != "wall") { Current = Current.Down; return true; }
            else if (dir == Direction.Back && Previous.ID != "wall") { Current = Previous; return true; }
            Previous = tp;
            return false;
        }

        public static bool TryTravel(string dir)
        {
            if(dir.ToUpper() == "N" || dir.ToUpper() == "NORTH" || dir.ToUpper() == "GO NORTH")
            {
                return TryTravel(Direction.North);
            }
            else if (dir.ToUpper() == "S" || dir.ToUpper() == "SOUTH" || dir.ToUpper() == "GO SOUTH")
            {
                return TryTravel(Direction.South);
            }
            else if (dir.ToUpper() == "E" || dir.ToUpper() == "EAST" || dir.ToUpper() == "GO EAST")
            {
                return TryTravel(Direction.East);
            }
            else if (dir.ToUpper() == "W" || dir.ToUpper() == "WEST" || dir.ToUpper() == "GO WEST")
            {
                return TryTravel(Direction.West);
            }
            else if (dir.ToUpper() == "U" || dir.ToUpper() == "UP" || dir.ToUpper() == "GO UP")
            {
                return TryTravel(Direction.Up);
            }
            else if (dir.ToUpper() == "D" || dir.ToUpper() == "DOWN" || dir.ToUpper() == "GO DOWN")
            {
                return TryTravel(Direction.Down);
            }
            else if(dir.ToUpper() == "B" || dir.ToUpper() == "BACK" || dir.ToUpper() == "GO BACK")
            {
                if (Locations.Current.NoBack) { return false; }
                else { return TryTravel(Direction.Back); }
            }
            else
            {
                return false;
            }
        }
    }
}