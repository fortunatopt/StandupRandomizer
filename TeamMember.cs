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
        private bool present;
        public bool Present
        {
            get { return present; }
            set { present = value; }
        }
        private bool finished;
        public bool Finished
        {
            get { return finished; }
            set { finished = value; }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

    }
}
