using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Record
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Record(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public override string ToString()
        {
            return Name + " - " + Score;
        }
    }
}
