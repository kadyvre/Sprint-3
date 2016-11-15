using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    /// <summary>
    /// the Ship class manages all of the game elements
    /// </summary>
    public class Ship
    {
        #region ***** define all lists to be maintained by the Universe object *****

        //
        // list of all space-time locations
        //
        public List<ShipLocation> ShipLocations { get; set; }

        //
        // list of all items
        //
        public List<Item> Items { get; set; }


        //
        // list of all treasure
        //
        public List<Treasure> Treasures { get; set; }
        public List<Knights> Knight { get; set; }

        #endregion

        #region ***** constructor *****

        //
        // default Ship constructor
        //
        public Ship()
        {
            //
            // instantiate the lists of space-time locations and game objects
            //
            this.ShipLocations = new List<ShipLocation>();
            this.Items = new List<Item>();
            this.Treasures = new List<Treasure>();
            this.Knight = new List<Knights>();

            //
            // add all of the space-time locations and game objects to their lists
            // 
            IntializeUniverseShipLocations();
            IntializeUniverseItems();
            IntializeUniverseTreasures();
            InitializeUniverseKnights();
        }

        #endregion

        #region ***** define methods to get the next available ID for game elements *****

        /// <summary>
        /// return the next available ID for a ShipLocation object
        /// </summary>
        /// <returns>next SpaceTimeLocationObjectID </returns>
        private int GetNextSpaceTimeLocationID()
        {
            int MaxID = 0;

            foreach (ShipLocation STLocation in ShipLocations)
            {
                if (STLocation.ShipLocationID > MaxID)
                {
                    MaxID = STLocation.ShipLocationID;
                }
            }

            return MaxID + 1;
        }

        /// <summary>
        /// return the next available ID for an item
        /// </summary>
        /// <returns>next GameObjectID </returns>
        private int GetNextItemID()
        {
            int MaxID = 0;

            foreach (Item item in Items)
            {
                if (item.GameObjectID > MaxID)
                {
                    MaxID = item.GameObjectID;
                }
            }

            return MaxID + 1;
        }

        /// <summary>
        /// return the next available ID for a treasure
        /// </summary>
        /// <returns>next GameObjectID </returns>
        private int GetNextTreasureID()
        {
            int MaxID = 0;

            foreach (Treasure treasure in Treasures)
            {
                if (treasure.GameObjectID > MaxID)
                {
                    MaxID = treasure.GameObjectID;
                }
            }

            return MaxID + 1;
        }

        #endregion

        #region ***** define methods to return game element objects *****

        /// <summary>
        /// get a ShipLocation object using an ID
        /// </summary>
        /// <param name="ID">space-time location ID</param>
        /// <returns>requested space-time location</returns>
        public ShipLocation GetShipLocationByID(int ID)
        {
            ShipLocation spt = null;

            //
            // run through the space-time location list and grab the correct one
            //
            foreach (ShipLocation location in ShipLocations)
            {
                if (location.ShipLocationID == ID)
                {
                    spt = location;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (spt == null)
            {
                string feedbackMessage = $"The Space-Time Location ID {ID} does not exist in the current Ship.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return spt;
        }

        /// <summary>
        /// get an item using an ID
        /// </summary>
        /// <param name="ID">game object ID</param>
        /// <returns>requested item object</returns>
        public Item GetItemtByID(int ID)
        {
            Item requestedItem = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Item item in Items)
            {
                if (item.GameObjectID == ID)
                {
                    requestedItem = item;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (requestedItem == null)
            {
                string feedbackMessage = $"The item ID {ID} does not exist in the current Ship.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedItem;
        }

        public Knights GetKnightByID(int ID)
        {
            Knights requestedKnight = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Knights knight in Knight)
            {
                if (knight.CharacterID == ID)
                {
                    requestedKnight = knight;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (requestedKnight == null)
            {
                string feedbackMessage = $"The knight ID {ID} does not exist in the Ship.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedKnight;
        }
        /// <summary>
        /// get a treasure using an ID
        /// </summary>
        /// <param name="ID">game object ID</param>
        /// <returns>requested treasure object</returns>
        public Treasure GetTreasureByID(int ID)
        {
            Treasure requestedTreasure = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Treasure treasure in Treasures)
            {
                if (treasure.GameObjectID == ID)
                {
                    requestedTreasure = treasure;
                };
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (requestedTreasure == null)
            {
                string feedbackMessage = $"The treasure ID {ID} does not exist in the current Ship.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedTreasure;
        }

        #endregion

        #region ***** define methods to get lists of game elements by location *****


        /// get a list of items using a space-time location ID
        /// </summary>
        /// <param name="ID">space-time location ID</param>
        /// <returns>list of items in the specified location</returns>
        public List<Item> GetItemtsByShipLocationID(int ID)
        {
            // TODO validate ShipLocationID

            List<Item> itemsInShipLocation = new List<Item>();

            //
            // run through the item list and put all items in the current location
            // into a list
            //
            foreach (Item item in Items)
            {
                if (item.ShipLocationID == ID)
                {
                    itemsInShipLocation.Add(item);
                }
            }

            return itemsInShipLocation;
        }


        /// get a list of treasures using a space-time location ID
        /// </summary>
        /// <param name="ID">space-time location ID</param>
        /// <returns>list of treasures in the specified location</returns>
        public List<Treasure> GetTreasuresByShipLocationID(int ID)
        {
            // TODO validate ShipLocationID

            List<Treasure> treasuresInShipLocation = new List<Treasure>();

            //
            // run through the treasure list and put all items in the current location
            // into a list
            //
            foreach (Treasure treasure in Treasures)
            {
                if (treasure.ShipLocationID == ID)
                {
                    treasuresInShipLocation.Add(treasure);
                }
            }

            return treasuresInShipLocation;
        }

        public List<Knights> GetKnightsByShipLocationID(int ID)
        {
            // TODO validate ShipLocationID

            List<Knights> knightsInShipLocation = new List<Knights>();

            //
            // run through the treasure list and put all items in the current location
            // into a list
            //
            foreach (Knights knight in Knight)
            {
                if (knight.ShipLocationID == ID)
                {
                    knightsInShipLocation.Add(knight);
                }
            }

            return knightsInShipLocation;
        }
        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the universe with all of the space-time locations
        /// </summary>
        private void IntializeUniverseShipLocations()
        {
            ShipLocations.Add(new ShipLocation
            {
                Name = "Bridge",
                ShipLocationID = 1,
                Description = "USS Desires bridge, Located at the heart of the ship for maximum safety" +
                              "Captain Turk and Commander J.D. stare off into the distance seemingly lost in thought.",
                Accessable = true
            });

            ShipLocations.Add(new ShipLocation
            {
                Name = "Ten Forward",
                ShipLocationID = 2,
                Description = "Ten Forward is the ship's cafeteria " +
                              "Personell gather here for social events or just to enjoy a meal.",
                Accessable = true
            });

            ShipLocations.Add(new ShipLocation
            {
                Name = "Holodeck",
                ShipLocationID = 3,
                Description = "The Holodeck is a large holographice simulator. " +
                  "Personell come here to unwind and run simulations, it" +
                  "is capable of producing 'Hard-Light' replicas as well as physical replicas.",
                Accessable = true
            });
        }

        /// <summary>
        /// initialize the universe with all of the items
        /// </summary>
        private void IntializeUniverseItems()
        {
            Items.Add(new Item
            {
                Name = "Keycard",
                GameObjectID = 1,
                Description = "A Federation keycard, it belongs to Lieutenant Jensen.",
                ShipLocationID = 3,
                HasValue = false,
                Value = 0,
                CanAddToInventory = true
            });

            Items.Add(new Item
            {
                Name = "Mirror",
                GameObjectID = 2,
                Description = "A full sized mirror with jewels decorating the border.",
                ShipLocationID = 2,
                HasValue = false,
                Value = 0,
                CanAddToInventory = false
            });

            Items.Add(new Item
            {
                Name = "Tricorder",
                GameObjectID = 3,
                Description = "A device carried by federation personell, it is a multi-functionality scanning device.",
                ShipLocationID = 0,
                HasValue = true,
                Value = 500,
                CanAddToInventory = true
            });
        }

        /// <summary>
        /// initialize the universe with all of the treasures
        /// </summary>
        private void IntializeUniverseTreasures()
        {
            Treasures.Add(new Treasure
            {
                Name = "Trantorian Ruby",
                TreasureType = Treasure.Type.Ruby,
                GameObjectID = 1,
                Description = "A deep red ruby the size of an egg.",
                ShipLocationID = 2,
                HasValue = true,
                Value = 25,
                CanAddToInventory = true
            });

            Treasures.Add(new Treasure
            {
                Name = "Lodestone",
                TreasureType = Treasure.Type.Lodestone,
                GameObjectID = 2,
                Description = "A deep red ruby the size of an egg.",
                ShipLocationID = 3,
                HasValue = true,
                Value = 15,
                CanAddToInventory = true
            });
        }

        private void InitializeUniverseKnights()
        {
            Knight.Add(new Knights
            {
                Name = "Knight Frederic",
                CharacterID = 1,
                Description = "A tall, imposing knight. He doesn't look particularly friendly...",
                Talk = "Bring me a shrubbery or I shall say 'NI!'",
                ShipLocationID = 3,
            });
        }
        #endregion

    }
}

