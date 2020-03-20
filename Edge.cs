using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafgry
{
    class Edge
    {
        private Node SourceNode;
        private Node TargetNode;
        private int Value;

        public Edge(Node source, Node target, int value)
        {
            SourceNode = source;
            TargetNode = target;
            Value = value;
        }

        public override string ToString()
        {
            return $"\t\"{SourceNode.Player};\\n{SourceNode.Value}\" -> \"{TargetNode.Player};\\n{TargetNode.Value}\" [label = \"{Value}\"];" ;
        }

    }
}
