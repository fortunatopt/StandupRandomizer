using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandupRandomizer
{
    public class TeamMember
    {

        public bool Finished
        {
            get { return finished; }
            set { finished = value; }
        }
        private bool finished;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

    }
}
