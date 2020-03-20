using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafgry
{
    class Graph
    {

        //attributes of graph

        private List<Node> Nodes;
        private List<Edge> Edges;
        private List<int> AvailableTokens;
        private String StartingPlayer;
        
        //constructor for graph

        public Graph (List<Node> nodes, List<Edge> edges, List<int> tokens, String startingPlayer)
        {
            Nodes = nodes;
            Edges = edges;
            AvailableTokens = tokens;
            StartingPlayer = startingPlayer;

        }

        public void generateChildren(Node node, List<int> tokens, string player1, int value)
        {
            String player;
            player = player1 == "P" ? "A" : "P"; //check the player and change it

            foreach (int token in tokens)
            {
                int nodeValue = value + token;
                if (nodeValue == 21)
                {
                    Node lastNode = new Node("Remis", nodeValue, 2);
                    Edge edge = new Edge(node, lastNode, token);
                    Nodes.Add(lastNode);
                    Edges.Add(edge);
                }
                if (nodeValue > 21 && player == "P")
                {
                    Node lastNode = new Node("Wygrana", nodeValue, 3);
                    Edge edge = new Edge(node, lastNode, token);
                    Nodes.Add(lastNode);
                    Edges.Add(edge);
                }
                if (nodeValue > 21 && player == "A")
                {
                    Node lastNode = new Node("Przegrana", nodeValue, 1);
                    Edge edge = new Edge(node, lastNode, token);
                    Nodes.Add(lastNode);
                    Edges.Add(edge);
                }
                if (nodeValue < 21)
                {
                    Node targetNode = new Node(player, nodeValue);
                    Nodes.Add(targetNode);
                    Edge edge = new Edge(node, targetNode, token);
                    Edges.Add(edge);
                    generateChildren(targetNode, tokens, player, nodeValue);
                }
            }


        }

        //generating graph

        public void GenerateGraph(string firstPlayer)
        {
            Edges.Clear();
            Nodes.Clear();

            Node first = new Node(firstPlayer, 0);
            Nodes.Add(first);

            generateChildren(first, AvailableTokens, firstPlayer, 0);
        }

        //generating childen for each node

        

        //generowanie kodu do graphViz

        public override string ToString()
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine("strict digraph G {");

            foreach (Edge edge in Edges)
            {
                code.AppendLine(edge.ToString());
            }

            code.AppendLine("}");
            return code.ToString();
        }

        public bool hasChildren(Node node)
        {

            foreach (Edge edge in Edges)
            {
                if (edge.SourceNode == node)
                {
                    return true;
                }
            }
            return false;           
        }

        public int? maxChild (Node node)
        {
            int? value = null;
           
            foreach (Edge edge in Edges)
            {
                if (edge.SourceNode == node)
                {
                    if (edge.SourceNode.Value>value)
                    value = edge.SourceNode.Value;
                }
            }
            

            return value;
        }

        public void generateMinMax (Graph graph)

        { 
           
            foreach (Node node in Nodes)
            {
                if (hasChildren(node)==false) //it's the last node
                {

                }

                if (hasChildren(node)==true)
                {
                    foreach(Edge edge in Edges)
                    {  
                        hasChildren(edge.SourceNode);

                    }
                }
            }
        }


             

    }
}
