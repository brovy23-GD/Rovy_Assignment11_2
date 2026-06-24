using System;
using Rovy.Assignment11._2.Models;

namespace Rovy.Assignment11._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Assignment 11.2 ");

            // PROBLEM 1: Best Time to Buy and Sell Stock (LeetCode 121)


            // This array represents stock prices over several days.
            // Our goal: buy at the lowest price, sell at the highest *after* that day.
            var prices = new int[] { 7, 1, 5, 3, 6, 4 };

            // Call our MaxProfit method and store the result.
            var profit = MaxProfit(prices);

            // Print the maximum profit we found.
            Console.WriteLine($"Max Profit: {profit}");


            // PROBLEM 2: Reverse a Singly Linked List (LeetCode 206)

            // Here we manually build a linked list:
            // 1 -> 2 -> 3 -> 4 -> 5
            var head = new ListNode(1,
                        new ListNode(2,
                        new ListNode(3,
                        new ListNode(4,
                        new ListNode(5)))));

            Console.WriteLine("Original List:");
            PrintList(head);   // Show the list before reversing

            // Reverse the linked list using our method
            var reversed = ReverseList(head);

            Console.WriteLine("Reversed List:");
            PrintList(reversed);   // Show the reversed list

            Console.ReadLine(); // Keeps console open
        }

     
        // PROBLEM 1: Best Time to Buy and Sell Stock (LeetCode 121)
       
        // Goal: Find the maximum profit from ONE buy and ONE sell.
        // Strategy:
        // - Track the lowest price we've seen so far.
        // - At each price, calculate the profit if we sold today.
        // - Keep the highest profit found.
        public static int MaxProfit(int[] prices)
        {
            var minPrice = int.MaxValue; // Start with the highest possible number
            var maxProfit = 0;           // No profit yet

            // Loop through each day's price
            foreach (var price in prices)
            {
                // If today's price is lower than any we've seen, update minPrice
                if (price < minPrice)
                    minPrice = price;

                // Profit if we sold today = today's price - lowest price so far
                var profit = price - minPrice;

                // If this profit is the best we've seen, update maxProfit
                if (profit > maxProfit)
                    maxProfit = profit;
            }

            return maxProfit; // Return the best profit found
        }

        // PROBLEM 2: Reverse a Singly Linked List (LeetCode 206)
       
        // Goal: Reverse the direction of the list so the last node becomes first.
        // Strategy:
        // Use three pointers: prev, current, next

        // Walk through the list and flip each pointer one by one
        public static ListNode ReverseList(ListNode head)
        {
            ListNode prev = null; // This will become the new head
            var curr = head;      // Start at the original head

            // Loop until we reach the end of the list
            while (curr != null)
            {
                var next = curr.Next; // Save the next node before breaking the link

                curr.Next = prev;     // Reverse the pointer (flip the arrow)

                prev = curr;          // Move prev forward
                curr = next;          // Move curr forward
            }

            return prev; // prev is now the new head of the reversed list
        }

      
        // Helper Method: PrintList
      
        // Walks through the linked list and prints each value.
        public static void PrintList(ListNode head)
        {
            var curr = head; // Start at the head

            while (curr != null)
            {
                Console.Write(curr.Value + " "); // Print the value
                curr = curr.Next;                // Move to the next node
            }

            Console.WriteLine(); // New line after printing the list
        }
    }
}
