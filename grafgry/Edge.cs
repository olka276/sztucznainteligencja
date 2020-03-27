using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafgry
{
    class Edge
    {
        public Node SourceNode;
        public Node TargetNode;
        public int Value;
        public String Color;

        public Edge(Node source, Node target, int value)
        {
            SourceNode = source;
            TargetNode = target;
            Value = value;
            Color = "black";
        }

        //overrides a method ToString, which gives a graphViz lines

        public override string ToString()
        {
            return $"\t\"{SourceNode.Player};\\n{SourceNode.Value};\\n{SourceNode.Score}\" -> \"{TargetNode.Player};\\n{TargetNode.Value};\\n{TargetNode.Score}\" [label = \"{Value}\" color = \"{Color}\"];" ;
        }

    }
}
