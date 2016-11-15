using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum RaceType
        {
            None,
            Human,
            Betazoid,
            Vulcan
        }

        #endregion

        #region FIELDS
        
        private string _name;
        private int _shipLocationID;
        private RaceType _race;


        #endregion


        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public int ShipLocationID
        {
            get { return _shipLocationID; }
            set { _shipLocationID = value; }
        }

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, RaceType race, int shipLocationID)
        {
            Name = name;
            Race = race;
            ShipLocationID = shipLocationID;
        }

        #endregion


        #region METHODS



        #endregion




    }
}
