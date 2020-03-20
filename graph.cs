using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafgry
{
    class Graph
    {
        private List<Node> Nodes;
        private List<Edge> Edges;
        private List<int> AvailableTokens;
        private String StartingPlayer;
        

        public Graph (List<Node> nodes, List<Edge> edges, List<int> tokens, String startingPlayer)
        {
            Nodes = nodes;
            Edges = edges;
            AvailableTokens = tokens;
            StartingPlayer = startingPlayer;

        }

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
        public void GenerateGraph(string firstPlayer)
        {
            Edges.Clear();
            Nodes.Clear();

            Node first = new Node(firstPlayer, 0);
            Nodes.Add(first);

            generateChildren(first, AvailableTokens, firstPlayer, 0);
        }
        public void generateChildren(Node node, List<int> tokens, string player1, int value)
        {
            String player;
            player = player1=="P" ? "A" : "P";

            foreach (int token in tokens)
            {
                int nodeValue = value + token;
                if (nodeValue==21)
                {
                    Node lastNode = new Node("Remis", 2);
                    Edge edge = new Edge(node, lastNode, token);
                    Nodes.Add(lastNode);
                    Edges.Add(edge);
                }
                if (nodeValue>21 && player == "P")
                {
                    Node lastNode = new Node("Wygrana", 3);
                    Edge edge = new Edge(node, lastNode, token);
                    Nodes.Add(lastNode);
                    Edges.Add(edge);
                }
                if (nodeValue>21 && player == "A")
                {
                    Node lastNode = new Node("Przegrana", 1);
                    Edge edge = new Edge(node, lastNode, token);
                    Nodes.Add(lastNode);
                    Edges.Add(edge);
                }
                if (nodeValue < 21) {
                Node targetNode = new Node(player, nodeValue);
                    Nodes.Add(targetNode);
                Edge edge = new Edge(node, targetNode, token);
                    Edges.Add(edge);
                    generateChildren(targetNode, tokens, player, nodeValue);
                }
            }

           
        }
             

    }
}
