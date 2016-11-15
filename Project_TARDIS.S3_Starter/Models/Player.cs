﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Player : Character
    {
        #region FIELDS

        private List<Item> _playersItems;
        private List<Treasure> _playersTreasures;

        #endregion

        public List<Item> PlayersItems
        {
            get { return _playersItems; }
            set { _playersItems = value; }
        }

        public List<Treasure> PlayersTreasures
        {
            get { return _playersTreasures; }
            set { _playersTreasures = value; }
        }

        #region PROPERTIES



        #endregion


        #region CONSTRUCTORS

        public Player()
        {
            _playersItems = new List<Item>();
            _playersTreasures = new List<Treasure>();
        }

        public Player(string name, RaceType race, int shipLocationID) : base(name, race, shipLocationID)
        {

        }

        #endregion


        #region METHODS



        #endregion
    }
}
