using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleApp
{
    // This class represents a node in the search tree.
    // Each node has a state, a parent node, a depth, and a cost.
    // The state is the current state of the puzzle board.
    // The parent node is the node from which this node was generated.
    // The depth is the number of moves from the initial state to this node.
    // The cost is the total cost of getting to this node from the initial state.
    public class Node
    {
        public State State { get; }    // The state of the puzzle board

        public Node Parent { get; }    // The parent node

        public int Depth { get; }      // The depth of the node

        public int Cost { get; }       // The cost of the node

        // This constructor creates a new node with the given state, parent, and cost.
        // The depth of the node is calculated as the depth of the parent plus 1.
        public Node(State state, Node parent, int cost)
        {
            State = state;                  // Set the state of the node
            Parent = parent;                // Set the parent node
            Cost = cost;                    // Set the cost of the node
            Depth = parent?.Depth + 1 ?? 0; // Set the depth of the node
        }
    }

}
