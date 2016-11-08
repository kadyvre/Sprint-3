using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Knights : Character
    {
        public string _talk;
        public string _description;
        private int _characterID;
        public int CharacterID
        {
            get { return _characterID; }
            set { _characterID = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Talk
        {
            get { return _talk; }
            set { _talk = value; }
        }
        public Knights()
        {
        }

        public Knights(string name, string description, string talk, RaceType race, int spaceTimeLocationID, int characterID) : base(name, race, spaceTimeLocationID)
        {

        }
    }
}
