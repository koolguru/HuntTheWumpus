using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusTestHighScore
{
    class Cave
    {
        public Cave()
        {
            Console.WriteLine("You just made a new Cave Object");
            Generator generator = new Generator();
        }
    }
    class Generator
    {
        public List<Node> GenerateMap()
        {
            Node node1 = new Node(1);
            List<Node> nodeList = new List<Node>();
            return nodeList;

        }
    }

    public class Node
    {
        int nodeNumber;

        public Node(int nodeNumber)
        {
            this.nodeNumber = nodeNumber;
        }
    }

    
}
