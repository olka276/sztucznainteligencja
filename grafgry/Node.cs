using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafgry
{
    class Node
    {
        public string Player;
        public int Value;
        public int? Score;

        public Node(string player, int value)
        {
            Player = player;
            Value = value;
            Score = null;
        }

        public Node(string player, int value, int score)
        {
            Player = player;
            Value = value;
            Score = score;
        }


    }
}
