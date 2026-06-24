namespace Rovy.Assignment11._2.Models
{
    // ListNode represents one node in a singly linked list.
    //
    // A linked list is made of nodes connected in a sequence.
    // Each node stores:
    //   1. A value
    //   2. A reference to the next node
    //
    // Example of a list:
    //   1 2 3 4 5
    //
    // This class is used by ReverseList and PrintList in Program.cs.
    public class ListNode
    {
        // The number stored in this node
        public int Value { get; set; }

        // Points to the next node in the list
        // If this is the last node, Next will be null
        public ListNode Next { get; set; }

        // Constructor creates a new node with a value
        // Optionally you can pass the next node
        public ListNode(int value, ListNode next = null)
        {
            Value = value;
            Next = next;
        }
    }
}
