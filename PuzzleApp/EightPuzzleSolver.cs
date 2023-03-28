using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleApp
{
    public class EightPuzzleSolver
    {
        static public bool solutionFound = true;
        static public List<Node> solutionPath = new List<Node>();
        public static void Solve(State initialState)
        {
            Queue<Node> frontier = new Queue<Node>(); // a queue to store the nodes to be expanded
            HashSet<State> explored = new HashSet<State>(); // a set to store the explored states
            Node initialNode = new Node(initialState, null, 0); // create the initial node
            frontier.Enqueue(initialNode); // add the initial node to the frontier

            while (frontier.Count > 0)
            {
                Node currentNode = frontier.Dequeue(); // remove the first node from the frontier
                explored.Add(currentNode.State); // add the state of the current node to the explored set

                if (currentNode.State.IsGoalState()) // check if the current state is the goal state
                {
                    
                //    Console.WriteLine("Solution found:");
                    PrintSolution(currentNode); // print the solution
                    return;
                }

                // generate the successor nodes
                foreach (int value in GetPossibleActions(currentNode.State))
                {
                    State nextState = currentNode.State.GetNextState(value);
                    if (!explored.Contains(nextState))
                    {
                        Node nextNode = new Node(nextState, currentNode, currentNode.Cost + 1);
                        frontier.Enqueue(nextNode); // add the next node to the frontier
                    }
                }
            }

            solutionFound = false;
        }

        // Returns a list of possible actions that can be taken from the given state
        private static List<int> GetPossibleActions(State state)
        {
            List<int> possibleActions = new List<int>();
            Tuple<int, int> blankIndices = state.GetIndicesOf(0); // get the indices of the blank tile
           
            if (blankIndices.Item1 > 0) possibleActions.Add(state.GetValueAt(blankIndices.Item1 - 1, blankIndices.Item2)); // move up
            if (blankIndices.Item1 < 2) possibleActions.Add(state.GetValueAt(blankIndices.Item1 + 1, blankIndices.Item2)); // move down
            if (blankIndices.Item2 > 0) possibleActions.Add(state.GetValueAt(blankIndices.Item1, blankIndices.Item2 - 1)); // move left
            if (blankIndices.Item2 < 2) possibleActions.Add(state.GetValueAt(blankIndices.Item1, blankIndices.Item2 + 1)); // move right
            return possibleActions;
        }

        // Prints the solution path from the initial node to the current node
        public static void PrintSolution(Node currentNode)
        {

            
            while (currentNode != null)
            {
                solutionPath.Add(currentNode);
                currentNode = currentNode.Parent;
            }
            solutionPath.Reverse(); // reverse the solution path
           // foreach (Node node in solutionPath)
            //{
           //     node.State.Print(); // print the state of the node
            //    Console.WriteLine();
              //  Console.WriteLine("Cost: " + node.Cost);
              //  Console.WriteLine();
            //}
        }
    }
}
