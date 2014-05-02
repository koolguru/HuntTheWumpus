using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpusXNAGame
{
    public class Engine
    {
        int[] keyList = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
        static public int[][] valueList = new int[][] {
            new int[] {25,26,2,7,6,30},new int[] {26,3,9,8,7,1},new int[] {27, 28, 4, 9, 2, 26},new int[] {28, 5, 11, 10, 9, 3},new int[] {92, 30, 6, 11, 4 ,28},new int[] {30, 1, 7, 12, 11, 5},
            new int[] {1,2,8,13,12,6},new int[] {2, 9, 15, 14, 13, 7},new int[] {3, 4, 10, 15, 8, 2},new int[] {4, 11, 17, 16 ,15, 9},new int[] {5, 6, 12, 17, 10, 4},new int[] {6, 7, 13, 18, 17, 11},
            new int[] {7, 8, 14, 19, 18, 12},new int[] {8, 15, 21, 20, 19, 13},new int[] {9, 10, 16, 21, 14, 8},new int[] {10, 17, 23, 22, 21, 15},new int[] {11, 12, 18, 23, 16, 10},new int[] {12, 13, 19, 24, 23, 17},
            new int[] {13,14,20, 25, 24, 18},new int[] {14, 21, 27, 26, 25, 19},new int[] {15, 16, 22, 27, 20, 14},new int[] {16, 23, 29, 28, 27, 21},new int[] {17, 18, 24, 29, 22, 16},new int[] {18, 19, 25, 30, 29, 23},
            new int[] {19, 20, 26, 1, 6, 24},new int[] {20, 27, 3, 2, 1, 25},new int[] {21, 22, 28, 3, 26, 20},new int[] {22, 29, 5, 4, 3, 27},new int[] {23, 24, 30, 5, 28, 22},new int[] {24, 25, 1, 6, 5, 29}
            };
        //int[][] valueList = new int[][] {
        //    new int[] {2,6,7,25,26,30},new int[] {1,3,7,8,9,26},new int[] {2,4,9,26,27,28},new int[] {3,5,9,10,11,28},new int[] {4,6,11,28,29,30},new int[] {1,5,7,11,12,30},
        //    new int[] {1,2,6,8,12,13},new int[] {2,7,9,13,14,15},new int[] {2,3,4,8,10,15},new int[] {4,9,11,15,16,17},new int[] {4,5,6,10,12,17},new int[] {6,7,11,13,17,18},
        //    new int[] {7,8,12,14,18,19},new int[] {8,13,15,19,20,21},new int[] {8,9,10,14,16,21},new int[] {10,15,17,21,22,23},new int[] {10,11,12,16,18,23},new int[] {12,13,17,19,23,24},
        //    new int[] {13,14,18,20,24,25},new int[] {14,19,21,25,26,27},new int[] {14,15,16,20,22,27},new int[] {16,21,23,27,28,29},new int[] {16,17,18,22,24,29},new int[] {18,19,23,25,29,30},
        //    new int[] {1,19,20,24,26,30},new int[] {1,2,3,20,25,27},new int[] {3,20,21,22,26,28},new int[] {3,4,5,22,27,29},new int[] {5,22,23,24,28,30},new int[] {1,5,6,24,25,29}
        //    };
        Dictionary<int, int[]> adjacentDict = new Dictionary<int, int[]>();

        List<int> nodeNumberList = new List<int>();
        List<Node> nodeList = new List<Node>();

        public Engine()
        {
            for (int i = 0; i < 30; i++)
            {
                adjacentDict.Add(keyList[i], valueList[i]);
            }
        }

        public bool checkConnections(List<Node> nodeList)
        {
            foreach (Node node in nodeList)
            {
                if (node.openConnections != 0)
                    return false;
            }
            return true;
        }

        public bool checkDuplicates(List<Node> nodeList)
        {
            foreach (Node node in nodeList)
            {
                if (node.connections[0].nodeNumber == node.connections[1].nodeNumber | node.connections[0].nodeNumber == node.connections[2].nodeNumber | node.connections[1].nodeNumber == node.connections[2].nodeNumber)
                    return false;
            }
            return true;
        }
        public List<Node> genMap()
        {
            bool complete = false;
            while (!complete)
            {
                for (int i = 0; i < 30; i++)
                {
                    this.nodeList.Add(new Node(i + 1, adjacentDict[i + 1]));
                }

                foreach (Node nodeA in nodeList)
                {
                    foreach (Node nodeB in nodeList)
                    {
                        if (Array.IndexOf(nodeA.adjacentNodeNumbers, nodeB.nodeNumber) != -1)
                            nodeA.possibleConnections.Add(nodeB);
                    }
                }

                foreach (Node node in nodeList)
                {
                    node.createConnections(nodeList);
                }

                List<Node> tempNodeList = new List<Node>();
                foreach (Node node in nodeList)
                {
                    tempNodeList.Add(node);
                }

                if (this.checkConnections(nodeList))
                {
                    if (checkDuplicates(nodeList))
                        return nodeList;
                    else
                    {
                        nodeList = new List<Node>();
                    }

                }

            }
            return new List<Node>();
        }

    }

    public class Node
    {
        public int nodeNumber;
        public int[] adjacentNodeNumbers;
        public int openConnections = 3;
        public List<Node> connections = new List<Node>();
        public List<Node> possibleConnections = new List<Node>();
        public NodeTest room;

        int gScore = 0;
        int fScore = 1;
        Node cameFrom = null;

        Random rnd = new Random();

        public Node(int nodeNumber, int[] adjacentNodeNumbers)
        {
            this.nodeNumber = nodeNumber;
            this.adjacentNodeNumbers = adjacentNodeNumbers;
        }
        public void clearConnections()
        {
            this.connections.Clear();
            this.openConnections = 3;
        }

        public void createConnections(List<Node> nodeList)
        {
            bool chosen = false;
            List<Node> tempPossibleConnections = new List<Node>();
            foreach (Node node in this.possibleConnections)
            {
                tempPossibleConnections.Add(node);
            }
            while (chosen == false)
            {
                if (possibleConnections.Count == 0 || this.openConnections == 0 || tempPossibleConnections.Count == 0)
                {
                    chosen = true;
                }
                else
                {
                    Node lookingAt = tempPossibleConnections[rnd.Next(0, tempPossibleConnections.Count)];
                    if (lookingAt.openConnections > 0 && this.openConnections > 0 && !(this.connections.Contains(lookingAt) && !(lookingAt.connections.Contains(this))))
                    {
                        lookingAt.connections.Add(this);
                        this.connections.Add(lookingAt);
                        lookingAt.openConnections--;
                        this.openConnections--;

                    }
                    tempPossibleConnections.Remove(lookingAt);
                }
                if (chosen)
                {
                    break;
                }
            }
        }
    }
}
