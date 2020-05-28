using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourthirtysix
{
    public class Item
    {
        /// <summary>
        /// The ID of this Item.
        /// </summary>
        public string ID;
        /// <summary>
        /// The Friendly Name of this Item.
        /// </summary>
        public string FriendlyName;
        /// <summary>
        /// The description of this Item.
        /// </summary>
        public string Description;

        private List<GameAction> Actions = new List<GameAction>();

        /// <summary>
        /// Describes an Item.
        /// </summary>
        /// <param name="id">The ID of this Item (like sample_house)</param>
        /// <param name="name">The friendly name of this Item (like Sample House)</param>
        /// <param name="description">The descriptor of this Item</param>
        public Item(string id, string name, string description)
        {
            ID = id;
            FriendlyName = name;
            Description = description;
        }

        /// <summary>
        /// Describes an Item.
        /// </summary>
        /// <param name="id">The ID of this Item (like sample_house)</param>
        /// <param name="name">The friendly name of this Item (like Sample House)</param>
        public Item(string id, string name)
        {
            ID = id;
            FriendlyName = name;
        }

        /// <summary>
        /// Describes an Item.
        /// </summary>
        /// <param name="id">The ID of this Item (like sample_house)</param>
        public Item(string id)
        {
            ID = id;
        }

        /// <summary>
        /// Describes an Item.
        /// </summary>
        public Item() { }

        public void AddAction(GameAction a)
        {
            Actions.Add(a);
        }

        public bool DoAction(string action, out GameAction game)
        {
            foreach(GameAction a in Actions)
            {
                if(a.TryAction(action)) { game = a; return true; }
            }
            game = null;
            return false;
        }
    }
    public class Inventory
    {
        public Dictionary<Item, int> Collection = new Dictionary<Item, int>();

        public Inventory() { }

        public void Add(Item i, int quantity)
        {
            if(Collection.Keys.Contains(i))
            {
                Collection[i] += quantity;
            }
            else
            {
                Collection.Add(i, quantity);
            }
        }

        public void Remove(Item i, int quantity)
        {
            if (Collection.Keys.Contains(i))
            {
                if (Collection[i] - quantity <= 0) { Collection.Remove(i); }
                else { Collection[i] -= quantity; }
            }
        }

        public bool Has(Item i)
        {
            return Collection.Keys.Contains(i);
        }

        public int GetQuantity(Item i)
        {
            try { return Collection[i]; } catch { return 0; }
        }

        public void Erase()
        {
            Collection = new Dictionary<Item, int>();
        }
    }
    public static class Items
    {
        public static Inventory Current;

        #region Custom Items

        #region Hardcoded

        public static Item BagOfSprite = 
            new Item("bag_of_sprite", "Bag of Sprite", "A seven-eleven bag filled with what you determine to be Sprite.");

        public static Item DamagedFence =
            new Item("fence_with_hole", "damaged fence", "a fence with a person-sized hole in it.");

        #endregion

        #endregion

        #region Custom Item Actions

        public static void DoDrinkBagOfSprite(object sender, GameActionEventArgs e) { Current.Remove(BagOfSprite, 1); }
        public static void DoGoThruHole(object sender, GameActionEventArgs e) { Locations.Set(Locations.Narnia); }

        #endregion

        public static void InitializeItems()
        {
            Current = new Inventory();

            #region Bag of Sprite
            GameAction DrinkBagOfSprite = new GameAction("drink bag of sprite", "disgusting, but ok");
            DrinkBagOfSprite.Trigger.Add("chug sprite");
            DrinkBagOfSprite.Trigger.Add("drink bag sprite");
            DrinkBagOfSprite.GameActionTriggered += DoDrinkBagOfSprite;
            BagOfSprite.AddAction(DrinkBagOfSprite);
            #endregion

            #region Go Thru Hole
            GameAction GoThruHole = new GameAction("go through hole in fence", "you manage to get through");
            GoThruHole.Trigger.Add("go thru hole");
            GoThruHole.Trigger.Add("go through hole");
            GoThruHole.Trigger.Add("go thru hole in fence");
            GoThruHole.Trigger.Add("go hole");
            GoThruHole.GameActionTriggered += DoGoThruHole;
            DamagedFence.AddAction(GoThruHole);
            #endregion
        }

    }
}
