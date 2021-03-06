﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    /// <summary>
    /// Console class for the MVC pattern
    /// </summary>
    public class ConsoleView
    {
        #region FIELDS

        //
        // declare a Ship and Player object for the ConsoleView object to use
        //
        Ship _gameUniverse;
        Player _gameTraveler;
        Knights _gameKnights;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Player gameTraveler, Ship gameUniverse, Knights gameKnights)
        {
            _gameTraveler = gameTraveler;
            _gameUniverse = gameUniverse;
            _gameKnights = gameKnights;

            InitializeConsole();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize all console settings
        /// </summary>
        private void InitializeConsole()
        {
            ConsoleUtil.WindowTitle = "The TARDIS Project";
            ConsoleUtil.HeaderText = "The TARDIS Project";
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.HeaderText = "Exit";
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            ConsoleUtil.DisplayMessage("Thank you for playing The TARDIS Project. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }

        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("The TARDIS Project");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Written by John Velis, Co-Written by Mitchell Holm");
            ConsoleUtil.DisplayMessage("Northwestern Michigan College");
            Console.WriteLine();

            //
            // TODO update opening screen
            //

            sb.Clear();
            sb.AppendFormat("You have been hired by the Norlon Corporation to participate ");
            sb.AppendFormat("in its latest endeavor, the TARDIS Project. Your mission is to ");
            sb.AppendFormat("test the limits of the new TARDIS Machine and report back to ");
            sb.AppendFormat("the Norlon Corporation.");
            ConsoleUtil.DisplayMessage(sb.ToString());
            Console.WriteLine();

            sb.Clear();
            sb.AppendFormat("Your first task will be to set up the initial parameters of your mission.");
            ConsoleUtil.DisplayMessage(sb.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// setup the new Player object
        /// </summary>
        public void DisplayMissionSetupIntro()
        {
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Mission Setup";
            ConsoleUtil.DisplayReset();

            //
            // display intro
            //
            ConsoleUtil.DisplayMessage("You will now be prompted to enter the starting parameters of your mission.");
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a message confirming mission setup
        /// </summary>
        public void DisplayMissionSetupConfirmation()
        {
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Mission Setup";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.HeaderText = "Mission Setup";
            ConsoleUtil.DisplayReset();

            //
            // display confirmation
            //
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Your mission setup is complete.");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("To view your TARDIS traveler information use the Main Menu.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get player's name
        /// </summary>
        /// <returns>name as a string</returns>
        public string DisplayGetTravelersName()
        {
            string travelersName;
            bool usingMenu = true;
            bool no = false;
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Player's Name";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayPromptMessage("Enter your name: ");
            travelersName = Console.ReadLine();

            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage($"You have indicated {travelersName} as your name.");
            ConsoleUtil.DisplayMessage("Is this correct? ('y' for yes, 'n' for no)");

            TravelerAction travelerActionChoice = TravelerAction.None;

            while (usingMenu == true)
            {
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case 'Y':
                    case 'y':
                        travelerActionChoice = TravelerAction.Yes;
                        usingMenu = false;
                        no = false;
                        break;
                    case 'N':
                    case 'n':
                        travelerActionChoice = TravelerAction.No;
                        no = true;
                        usingMenu = false;                    
                        break;
                }
            }
            
            while (no == true)
            {

                ConsoleUtil.DisplayReset();
                ConsoleUtil.DisplayMessage("Please Re-enter your name:");
                travelersName = Console.ReadLine();
                ConsoleUtil.DisplayReset();
                ConsoleUtil.DisplayMessage($"You have indicated {travelersName} as your name.");
                ConsoleUtil.DisplayMessage("Is this correct? ('y' for yes, 'n' for no)");

                no = false;
                usingMenu = true;

                while (usingMenu == true)
                {
                    ConsoleKeyInfo userResponse = Console.ReadKey(true);
                    switch (userResponse.KeyChar)
                    {
                        case 'Y':
                        case 'y':
                            travelerActionChoice = TravelerAction.Yes;
                            usingMenu = false;
                            no = false;
                            break;
                        case 'N':
                        case 'n':
                            travelerActionChoice = TravelerAction.No;
                            no = true;
                            usingMenu = false;
                            break;
                    }
                }
            }


            DisplayContinuePrompt();

            return travelersName;
        }

        /// <summary>
        /// get and validate the player's race
        /// </summary>
        /// <returns>race as a RaceType</returns>
        public Player.RaceType DisplayGetTravelersRace()
        {
            bool validResponse = false;
            Player.RaceType travelersRace = Player.RaceType.None;

            while (!validResponse)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "Player's Race";
                ConsoleUtil.DisplayReset();

                //
                // display all race types on a line
                //
                ConsoleUtil.DisplayMessage("Races");
                StringBuilder sb = new StringBuilder();
                foreach (Character.RaceType raceType in Enum.GetValues(typeof(Character.RaceType)))
                {
                    if (raceType != Character.RaceType.None)
                    {
                        sb.Append($" [{raceType}] ");
                    }

                }
                ConsoleUtil.DisplayMessage(sb.ToString());

                ConsoleUtil.DisplayPromptMessage("Enter your race: ");

                //
                // validate user response for race
                //
                if (Enum.TryParse<Character.RaceType>(Console.ReadLine(), out travelersRace))
                {
                    validResponse = true;
                    ConsoleUtil.DisplayReset();
                    ConsoleUtil.DisplayMessage($"You have indicated {travelersRace} as your race type.");
                }
                else
                {
                    ConsoleUtil.DisplayMessage("You must limit your race to the list above.");
                    ConsoleUtil.DisplayMessage("Please reenter your race.");
                }

                DisplayContinuePrompt();
            }

            return travelersRace;
        }

        /// <summary>
        /// get and validate the player's TARDIS destination
        /// </summary>
        /// <returns>space-time location</returns>
        public ShipLocation DisplayGetTravelersNewDestination()
        {
            bool validResponse = false;
            int locationID;
            ShipLocation nextSpaceTimeLocation = new ShipLocation();

            while (!validResponse)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "TARDIS Destination";
                ConsoleUtil.DisplayReset();

                //
                // display a table of space-time locations
                //
                DisplayTARDISDestinationsTable();

                //
                // get and validate user's response for a space-time location
                //
                ConsoleUtil.DisplayPromptMessage("Choose the TARDIS destination by entering the ID: ");

                //
                // user's response is an integer
                //
                if (int.TryParse(Console.ReadLine(), out locationID))
                {
                    ConsoleUtil.DisplayMessage("");

                    try
                    {
                        nextSpaceTimeLocation = _gameUniverse.GetShipLocationByID(locationID);

                        ConsoleUtil.DisplayReset();
                        ConsoleUtil.DisplayMessage($"You have indicated {nextSpaceTimeLocation.Name} as your TARDIS destination.");
                        ConsoleUtil.DisplayMessage("");

                        if (nextSpaceTimeLocation.Accessable == true)
                        {
                            validResponse = true;
                            ConsoleUtil.DisplayMessage("You will be transported immediately.");
                        }
                        else
                        {
                            ConsoleUtil.DisplayMessage("It appears this destination is not available to you at this time.");
                            ConsoleUtil.DisplayMessage("Please make another choice.");
                        }
                    }
                    //
                    // user's response was not in the correct range
                    //
                    catch (ArgumentOutOfRangeException ex)
                    {
                        ConsoleUtil.DisplayMessage("It appears you entered an invalid location ID.");
                        ConsoleUtil.DisplayMessage(ex.Message);
                        ConsoleUtil.DisplayMessage("Please try again.");
                    }
                }
                //
                // user's response was not an integer
                //
                else
                {
                    ConsoleUtil.DisplayMessage("It appears you did not enter a number for the location ID.");
                    ConsoleUtil.DisplayMessage("Please try again.");
                }

                DisplayContinuePrompt();
            }

            return nextSpaceTimeLocation;
        }

        /// <summary>
        /// generate a table of space-time location names and ids
        /// </summary>
        public void DisplayTARDISDestinationsTable()
        {
            //
            // table headings
            //
            ConsoleUtil.DisplayMessage("ID".PadRight(10) + "Name".PadRight(20));
            ConsoleUtil.DisplayMessage("---".PadRight(10) + "-------------".PadRight(20));

            //
            // location name and id
            //
            foreach (ShipLocation location in _gameUniverse.ShipLocations)
            {
                ConsoleUtil.DisplayMessage(location.ShipLocationID.ToString().PadRight(10) + location.Name.PadRight(20));
            }
        }

        /// <summary>
        /// generate a table of item names and ids
        /// </summary>
        public void DisplayItemTable(List<Item> items)
        {
            //
            // table headings
            //
            ConsoleUtil.DisplayMessage("ID".PadRight(10) + "Name".PadRight(20));
            ConsoleUtil.DisplayMessage("---".PadRight(10) + "-------------".PadRight(20));

            //
            // item name and id
            //
            foreach (Item item in items)
            {
                ConsoleUtil.DisplayMessage(item.GameObjectID.ToString().PadRight(10) + item.Name.PadRight(20));
            }
        }

        public void DisplayKnightTable(List<Knights> knights)
        {
            //
            // table headings
            //
            ConsoleUtil.DisplayMessage("ID".PadRight(10) + "Name".PadRight(20));
            ConsoleUtil.DisplayMessage("---".PadRight(10) + "-------------".PadRight(20));

            //
            // item name and id
            //
            foreach (Knights knight in knights)
            {
                ConsoleUtil.DisplayMessage(knight.CharacterID.ToString().PadRight(10) + knight.Name.PadRight(20));
            }
        }
        /// <summary>
        /// generate a table of treasure names and ids
        /// </summary>
        public void DisplayTreasureTable(List<Treasure> treasures)
        {
            //
            // table headings
            //
            ConsoleUtil.DisplayMessage("ID".PadRight(10) + "Name".PadRight(20));
            ConsoleUtil.DisplayMessage("---".PadRight(10) + "-------------".PadRight(20));

            //
            // treasure name and id
            //
            foreach (Treasure treasure in treasures)
            {
                ConsoleUtil.DisplayMessage(treasure.GameObjectID.ToString().PadRight(10) + treasure.Name.PadRight(20));
            }
        }

        /// <summary>
        /// get the action choice from the user
        /// </summary>
        public TravelerAction DisplayGetTravelerActionChoice()
        {
            TravelerAction travelerActionChoice = TravelerAction.None;
            bool usingMenu = true;

            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.HeaderText = "Player Action Choice";
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("What would you like to do (Type Letter).");
                Console.WriteLine();
                Console.WriteLine(
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Player Actions" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "A. Look Around" + Environment.NewLine +
                    "\t" + "B. Look At" + Environment.NewLine +
                    "\t" + "C. Pick Up Item" + Environment.NewLine +
                    "\t" + "D. Pick Up Treasure" + Environment.NewLine +
                    "\t" + "E. Put Down Item" + Environment.NewLine +
                    "\t" + "F. Put Down Treasure" + Environment.NewLine +
                    "\t" + "G. Travel" + Environment.NewLine +
                    "\t" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Player Information" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "H. Display General Player Info" + Environment.NewLine +
                    "\t" + "I. Display Player Inventory" + Environment.NewLine +
                    "\t" + "J. Display Player Treasure" + Environment.NewLine +
                    "\t" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Game Information" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "K. Display All TARDIS Destinations" + Environment.NewLine +
                    "\t" + "L. Display All Game Items" + Environment.NewLine +
                    "\t" + "M. Display All Game Treasures" + Environment.NewLine +
                    "\t" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Q. Quit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case 'A':
                    case 'a':
                        travelerActionChoice = TravelerAction.LookAround;
                        if (_gameTraveler.ShipLocationID == _gameKnights.ShipLocationID)
                        {
                            travelerActionChoice = TravelerAction.TalkTo;
                        }
                        usingMenu = false;
                        break;
                    case 'B':
                    case 'b':
                        travelerActionChoice = TravelerAction.LookAt;
                        usingMenu = false;
                        break;
                    case 'C':
                    case 'c':
                        travelerActionChoice = TravelerAction.PickUpItem;
                        usingMenu = false;
                        break;
                    case 'D':
                    case 'd':
                        travelerActionChoice = TravelerAction.PickUpTreasure;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        travelerActionChoice = TravelerAction.PutDownItem;
                        usingMenu = false;
                        break;
                    case 'F':
                    case 'f':
                        travelerActionChoice = TravelerAction.PutDownTreasure;
                        usingMenu = false;
                        break;
                    case 'G':
                    case 'g':
                        travelerActionChoice = TravelerAction.Travel;
                        usingMenu = false;
                        break;
                    case 'H':
                    case 'h':
                        travelerActionChoice = TravelerAction.TravelerInfo;
                        usingMenu = false;
                        break;
                    case 'I':
                    case 'i':
                        travelerActionChoice = TravelerAction.TravelerInventory;
                        usingMenu = false;
                        break;
                    case 'J':
                    case 'j':
                        travelerActionChoice = TravelerAction.TravelerTreasure;
                        usingMenu = false;
                        break;
                    case 'K':
                    case 'k':
                        travelerActionChoice = TravelerAction.ListTARDISDestinations;
                        usingMenu = false;
                        break;
                    case 'L':
                    case 'l':
                        travelerActionChoice = TravelerAction.ListItems;
                        usingMenu = false;
                        break;
                    case 'M':
                    case 'm':
                        travelerActionChoice = TravelerAction.ListTreasures;
                        usingMenu = false;
                        break;
                    case 'Q':
                    case 'q':
                        travelerActionChoice = TravelerAction.Exit;
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine(
                            "It appears you have selected an incorrect choice." + Environment.NewLine +
                            "Press any key to continue or the ESC key to quit the application.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
            }
            Console.CursorVisible = true;

            return travelerActionChoice;
        }

        /// <summary>
        /// display information about the current space-time location
        /// </summary>
        public void DisplayLookAround()
        {
            ConsoleUtil.HeaderText = "Current Space-Time Location Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage(_gameUniverse.GetShipLocationByID(_gameTraveler.ShipLocationID).Description);

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items in current location.");
            foreach (Item item in _gameUniverse.GetItemtsByShipLocationID(_gameTraveler.ShipLocationID))
            {
                ConsoleUtil.DisplayMessage(item.Name + " - " + item.Description);
            }

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Treasures in current location.");
            foreach (Treasure treasure in _gameUniverse.GetTreasuresByShipLocationID(_gameTraveler.ShipLocationID))
            {
                ConsoleUtil.DisplayMessage(treasure.Name + " - " + treasure.Description);
            }

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Characters in current location.");
            foreach (Knights knight in _gameUniverse.GetKnightsByShipLocationID(_gameTraveler.ShipLocationID))
            {
                ConsoleUtil.DisplayMessage(knight.Name + " - " + knight.Description);
            }
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display information about items and treasures in the current space-time location
        /// </summary>
        public void DisplayLookAt()
        {
            bool usingMenu = false;
            bool yes = false;

            int currentSptID = _gameTraveler.ShipLocationID;
            List<Item> itemsInSpt = new List<Item>();
            List<Treasure> treasuresInSpt = new List<Treasure>();
            List<Knights> knightsInSpt = new List<Knights>();
            Item itemToLookAt = new Item();
            Treasure treasureToLookAt = new Treasure();
            Knights knightToLookAt = new Knights();

            itemsInSpt = _gameUniverse.GetItemtsByShipLocationID(currentSptID);
            treasuresInSpt = _gameUniverse.GetTreasuresByShipLocationID(currentSptID);
            knightsInSpt = _gameUniverse.GetKnightsByShipLocationID(currentSptID);

            ConsoleUtil.HeaderText = "Look at a Game Item in Current Location";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage(_gameUniverse.GetShipLocationByID(currentSptID).Name);

            if (itemsInSpt != null)
            {
                ConsoleUtil.DisplayMessage("");
                ConsoleUtil.DisplayMessage("Items in current location.");
                DisplayItemTable(itemsInSpt);

                ConsoleUtil.DisplayPromptMessage("Enter the item number to view or press the Enter key to move on. ");
                Console.WriteLine("");
                int itemIDChoice;

                if (int.TryParse(Console.ReadLine(), out itemIDChoice))
                {
                    itemToLookAt = _gameUniverse.GetItemtByID(itemIDChoice);
                    ConsoleUtil.DisplayMessage(itemToLookAt.Description);

                    DisplayContinuePrompt();
                }
            }

            if (treasuresInSpt != null)
            {
                ConsoleUtil.HeaderText = "Look at a treasure in current location";
                ConsoleUtil.DisplayReset();

                ConsoleUtil.DisplayMessage("");
                ConsoleUtil.DisplayMessage("Treasures in current location.");
                DisplayTreasureTable(treasuresInSpt);

                ConsoleUtil.DisplayPromptMessage(
                    "Enter the treasure number to view or press the Enter key to move on. "
                    ); // TODO code in validation
                Console.WriteLine();
                int treasureIDChoice;

                if (int.TryParse(Console.ReadLine(), out treasureIDChoice))
                {
                    treasureToLookAt = _gameUniverse.GetTreasureByID(treasureIDChoice);
                    ConsoleUtil.DisplayMessage(treasureToLookAt.Description);

                    DisplayContinuePrompt();
                }

                if (knightsInSpt != null)
                {
                    ConsoleUtil.HeaderText = "Look at a Character in current location";
                    ConsoleUtil.DisplayReset();

                    ConsoleUtil.DisplayMessage("");
                    ConsoleUtil.DisplayMessage("Characters in current location.");
                    DisplayKnightTable(knightsInSpt);

                    TravelerAction travelerActionChoice = TravelerAction.None;

                    ConsoleUtil.DisplayMessage("Would you like to speak to him? ('y' for yes, 'n' for no)");
                    usingMenu = true;

                    while (usingMenu == true)
                    {
                        ConsoleKeyInfo userResponse = Console.ReadKey(true);
                        switch (userResponse.KeyChar)
                        {
                            case 'Y':
                            case 'y':
                                travelerActionChoice = TravelerAction.Yes;
                                usingMenu = false;
                                yes = true;
                                break;
                            case 'N':
                            case 'n':
                                travelerActionChoice = TravelerAction.No;
                                yes = false;
                                usingMenu = false;
                                break;
                        }
                    }

                    while (yes == true)
                    {
                        ConsoleUtil.DisplayPromptMessage("Enter the character ID to talk to, or press the Enter key to move on. ");
                        Console.WriteLine("");
                        ConsoleUtil.DisplayPromptMessage("Character ID:");
                        int itemIDChoice;

                        if (int.TryParse(Console.ReadLine(), out itemIDChoice))
                        {
                            knightToLookAt = _gameUniverse.GetKnightByID(itemIDChoice);
                            ConsoleUtil.DisplayMessage(knightToLookAt.Talk);                           
                        }
                        yes = false;
                    }
                    DisplayContinuePrompt();
                }
            }
        }

        public void DisplayTalkTo()
        {
            int currentSptID = _gameTraveler.ShipLocationID;
            List<Knights> knightsInSpt = new List<Knights>();
            Knights knightToLookAt = new Knights();

            knightsInSpt = _gameUniverse.GetKnightsByShipLocationID(currentSptID);

            ConsoleUtil.HeaderText = "Talk to a Character in Current Location";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage(_gameUniverse.GetShipLocationByID(currentSptID).Name);

            if (knightsInSpt != null)
            {
                ConsoleUtil.DisplayMessage("");
                ConsoleUtil.DisplayMessage("Characters in current location.");
                DisplayKnightTable(knightsInSpt);

                ConsoleUtil.DisplayPromptMessage("Enter the character ID to talk to, or press the Enter key to move on. ");
                Console.WriteLine("");
                int itemIDChoice;

                if (int.TryParse(Console.ReadLine(), out itemIDChoice))
                {
                    knightToLookAt = _gameUniverse.GetKnightByID(itemIDChoice);
                    ConsoleUtil.DisplayMessage(knightToLookAt.Talk);

                    DisplayContinuePrompt();
                }
            }
        }

        /// <summary>
        /// display a list of all TARDIS destinations
        /// <summary>
        public void DisplayListAllTARDISDestinations()
        {
            ConsoleUtil.HeaderText = "Space-Time Locations";
            ConsoleUtil.DisplayReset();

            foreach (ShipLocation location in _gameUniverse.ShipLocations)
            {
                ConsoleUtil.DisplayMessage("ID: " + location.ShipLocationID);
                ConsoleUtil.DisplayMessage("Name: " + location.Name);
                ConsoleUtil.DisplayMessage("Description: " + location.Description);
                ConsoleUtil.DisplayMessage("Accessible: " + location.Accessable);
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all game items
        /// <summary>
        public void DisplayListAllGameItems()
        {
            ConsoleUtil.HeaderText = "Game Items";
            ConsoleUtil.DisplayReset();

            foreach (Item item in _gameUniverse.Items)
            {
                ConsoleUtil.DisplayMessage("ID: " + item.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + item.Name);
                ConsoleUtil.DisplayMessage("Description: " + item.Description);

                //
                // all treasure in the traveler's inventory have a ShipLocationID of 0
                //
                if (item.ShipLocationID != 0)
                {
                    ConsoleUtil.DisplayMessage("Location: " + _gameUniverse.GetShipLocationByID(item.ShipLocationID).Name);
                }
                else
                {
                    ConsoleUtil.DisplayMessage("Location: Player's Inventory");
                }


                ConsoleUtil.DisplayMessage("Value: " + item.Value);
                ConsoleUtil.DisplayMessage("Can Add to Inventory: " + item.CanAddToInventory.ToString().ToUpper());
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all game treasures
        /// <summary>
        public void DisplayListAllGameTreasures()
        {
            ConsoleUtil.HeaderText = "Game Treasures";
            ConsoleUtil.DisplayReset();

            foreach (Treasure treasure in _gameUniverse.Treasures)
            {
                ConsoleUtil.DisplayMessage("ID: " + treasure.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + treasure.Name);
                ConsoleUtil.DisplayMessage("Description: " + treasure.Description);

                //
                // all treasure in the traveler's inventory have a ShipLocationID of 0
                //
                if (treasure.ShipLocationID != 0)
                {
                    ConsoleUtil.DisplayMessage("Location: " + _gameUniverse.GetShipLocationByID(treasure.ShipLocationID).Name);
                }
                else
                {
                    ConsoleUtil.DisplayMessage("Location: Player's Inventory");
                }

                ConsoleUtil.DisplayMessage("Value: " + treasure.Value);
                ConsoleUtil.DisplayMessage("Can Add to Inventory: " + treasure.CanAddToInventory.ToString().ToUpper());
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current traveler information
        /// </summary>
        public void DisplayTravelerInfo()
        {
            ConsoleUtil.HeaderText = "Player Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage($"Player's Name: {_gameTraveler.Name}");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage($"Player's Race: {_gameTraveler.Race}");
            ConsoleUtil.DisplayMessage("");
            string shipLocationName = _gameUniverse.GetShipLocationByID(_gameTraveler.ShipLocationID).Name;
            ConsoleUtil.DisplayMessage($"Player's Current Location: {shipLocationName}");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current traveler inventory
        /// </summary>
        public void DisplayTravelerItems()
        {
            ConsoleUtil.HeaderText = "Player Inventory";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Player Items");
            ConsoleUtil.DisplayMessage("");

            foreach (Item item in _gameTraveler.PlayersItems)
            {
                ConsoleUtil.DisplayMessage("ID: " + item.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + item.Name);
                ConsoleUtil.DisplayMessage("Description: " + item.Description);
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current traveler's treasure
        /// </summary>
        public void DisplayTravelerTreasure()
        {
            ConsoleUtil.HeaderText = "Player Inventory";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Player Treasure");
            ConsoleUtil.DisplayMessage("");

            foreach (Treasure treasure in _gameTraveler.PlayersTreasures)
            {
                ConsoleUtil.DisplayMessage("ID: " + treasure.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + treasure.Name);
                ConsoleUtil.DisplayMessage("Description: " + treasure.Description);
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the id of an item to add to inventory
        /// </summary>
        /// <returns>id of desired item</returns>
        public int DisplayPickUpItem()
        {
            ConsoleUtil.HeaderText = "Pick Up Item";
            ConsoleUtil.DisplayReset();

            int itemID = 0;

            int locationID;
            locationID = _gameTraveler.ShipLocationID;

            List<Item> itemsInCurrentLocation = new List<Item>();
            itemsInCurrentLocation = _gameUniverse.GetItemtsByShipLocationID(locationID);

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items in current Location");
            ConsoleUtil.DisplayMessage("");

            DisplayItemTable(itemsInCurrentLocation);

            ConsoleUtil.DisplayPromptMessage("Enter Item Number:");
            itemID = int.Parse(Console.ReadLine()); // TODO validate ID

            DisplayContinuePrompt();

            return itemID;
        }

        /// <summary>
        /// get the id of an item to remove from inventory
        /// </summary>
        /// <returns>id of desired item</returns>
        public int DisplayPutDownItem()
        {
            ConsoleUtil.HeaderText = "Put Down Item";
            ConsoleUtil.DisplayReset();

            int itemID = 0;

            int locationID;
            locationID = _gameTraveler.ShipLocationID;

            List<Item> itemsInInventory = new List<Item>();
            itemsInInventory = _gameTraveler.PlayersItems;

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items in Your Inventory");
            ConsoleUtil.DisplayMessage("");

            DisplayItemTable(itemsInInventory);

            ConsoleUtil.DisplayPromptMessage("Enter Item Number:");
            itemID = int.Parse(Console.ReadLine()); // TODO validate ID

            DisplayContinuePrompt();

            return itemID;
        }

        /// <summary>
        /// get the id of a treasure to add to inventory
        /// </summary>
        /// <returns>id of desired treasure</returns>
        public int DisplayPickUpTreasure()
        {
            ConsoleUtil.HeaderText = "Pick Up Treasure";
            ConsoleUtil.DisplayReset();

            int treasureID = 0;

            int locationID;
            locationID = _gameTraveler.ShipLocationID;

            List<Treasure> treasuresInCurrentLocation = new List<Treasure>();
            treasuresInCurrentLocation = _gameUniverse.GetTreasuresByShipLocationID(locationID);

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items in current Location");
            ConsoleUtil.DisplayMessage("");

            DisplayTreasureTable(treasuresInCurrentLocation);

            ConsoleUtil.DisplayPromptMessage("Enter Treasure Number:");
            treasureID = int.Parse(Console.ReadLine()); // TODO validate ID

            DisplayContinuePrompt();

            return treasureID;
        }

        /// <summary>
        /// get the id of a treasure to remove from inventory
        /// </summary>
        /// <returns>id of desired treasure</returns>
        public int DisplayPutDownTreasure()
        {
            ConsoleUtil.HeaderText = "Put Down Treasure";
            ConsoleUtil.DisplayReset();

            int treasureID = 0;

            int locationID;
            locationID = _gameTraveler.ShipLocationID;

            List<Treasure> treasuresInInventory = new List<Treasure>();
            treasuresInInventory = _gameTraveler.PlayersTreasures;

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Treasures in Your Inventory");
            ConsoleUtil.DisplayMessage("");

            DisplayTreasureTable(treasuresInInventory);

            ConsoleUtil.DisplayPromptMessage("Enter Treasure Number:");
            treasureID = int.Parse(Console.ReadLine()); // TODO validate ID

            DisplayContinuePrompt();

            return treasureID;
        }
        #endregion
    }
}
