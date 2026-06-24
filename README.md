![Assignment 11.2 Banner](assets/assignment11_2_banner.png)

# 🚀 Assignment 11.2 — Algorithms & Data Structures

![Language](https://img.shields.io/badge/Language-C%23-178600?style=for-the-badge)
![Framework](https://img.shields.io/badge/.NET-10.0-purple?style=for-the-badge)
![Algorithms](https://img.shields.io/badge/Algorithms-LeetCode-blue?style=for-the-badge)
![Data Structures](https://img.shields.io/badge/Data%20Structures-Linked%20Lists-green?style=for-the-badge)

---

## 📖 Executive Summary

Assignment 11.2 demonstrates two classic software engineering interview problems using C# and .NET 10.

This project focuses on algorithmic problem-solving, clean code, Big-O analysis, linked list manipulation, one-pass optimization, and whiteboard-style technical explanation.

---

## 🎯 Problems Solved

| # | Problem | Category | Time | Space |
|---|---------|----------|------|-------|
| 1 | Best Time to Buy and Sell Stock | Arrays / One-Pass Optimization | **O(n)** | **O(1)** |
| 2 | Reverse a Singly Linked List | Linked Lists / Pointer Manipulation | **O(n)** | **O(1)** |

---

## 🏗 Project Architecture

```mermaid
flowchart TD
    A[Program Starts] --> B[Run Stock Profit Problem]
    B --> C[Calculate Max Profit]
    C --> D[Print Profit]
    D --> E[Build Linked List]
    E --> F[Print Original List]
    F --> G[Reverse Linked List]
    G --> H[Print Reversed List]
    H --> I[Program Ends]
```

---

## 📂 Project Structure

```text
Rovy.Assignment11.2
│
├── Program.cs
│
└── Models
    └── ListNode.cs
```

---

# 📈 Problem 1 — Best Time to Buy and Sell Stock

**LeetCode #121**

## Problem Statement

Given an array of stock prices, determine the maximum profit possible from one buy and one sell.

You must buy before you sell.

---

## 🧑‍🏫 Whiteboard Walkthrough

![Stock Whiteboard](assets/stock_whiteboard.svg)

```text
Prices: [7, 1, 5, 3, 6, 4]

Buy at:  1
Sell at: 6

Profit = 6 - 1 = 5
```

---

## 🧠 Logic

Instead of comparing every price against every future price, the algorithm only needs one pass.

Track:

```text
minPrice  = lowest price seen so far
maxProfit = best profit found so far
```

At each price:

```text
1. Update minPrice if current price is lower
2. Calculate profit if sold today
3. Update maxProfit if this profit is better
```

---

## 🔁 Flowchart

```mermaid
flowchart TD
    A[Start] --> B[minPrice = int.MaxValue]
    B --> C[maxProfit = 0]
    C --> D{More Prices?}
    D -->|Yes| E[Read Current Price]
    E --> F{price < minPrice?}
    F -->|Yes| G[Update minPrice]
    F -->|No| H[Calculate Profit]
    G --> H
    H --> I{profit > maxProfit?}
    I -->|Yes| J[Update maxProfit]
    I -->|No| K[Next Price]
    J --> K
    K --> D
    D -->|No| L[Return maxProfit]
```

---

## 🧪 Dry Run

| Day | Price | Lowest Price | Current Profit | Best Profit |
|----:|------:|-------------:|---------------:|------------:|
| 1 | 7 | 7 | 0 | 0 |
| 2 | 1 | 1 | 0 | 0 |
| 3 | 5 | 1 | 4 | 4 |
| 4 | 3 | 1 | 2 | 4 |
| 5 | 6 | 1 | 5 | 5 |
| 6 | 4 | 1 | 3 | 5 |

---

## 🧾 Pseudocode

```text
SET minPrice = largest possible number
SET maxProfit = 0

FOR each price in prices

    IF price < minPrice
        minPrice = price

    profit = price - minPrice

    IF profit > maxProfit
        maxProfit = profit

RETURN maxProfit
```

---

## ✅ C# Method

```csharp
public static int MaxProfit(int[] prices)
{
    var minPrice = int.MaxValue;
    var maxProfit = 0;

    foreach (var price in prices)
    {
        if (price < minPrice)
            minPrice = price;

        var profit = price - minPrice;

        if (profit > maxProfit)
            maxProfit = profit;
    }

    return maxProfit;
}
```

---

## ⏱ Complexity

| Metric | Complexity |
|--------|------------|
| Time | **O(n)** |
| Space | **O(1)** |

---

# 🔄 Problem 2 — Reverse a Singly Linked List

**LeetCode #206**

## Problem Statement

Given the head of a singly linked list, reverse the list and return the new head.

---

## 🧑‍🏫 Whiteboard Walkthrough

![Linked List Whiteboard](assets/linked_list_whiteboard.svg)

### Before

```text
1 → 2 → 3 → 4 → 5 → null
```

### After

```text
5 → 4 → 3 → 2 → 1 → null
```

---

## 🧠 Logic

Use three pointers:

```text
prev = previous node
curr = current node
next = saved next node
```

The key idea:

```text
Save next before breaking the current link.
Then reverse curr.Next.
Then move prev and curr forward.
```

---

## 🔁 Flowchart

```mermaid
flowchart TD
    A[Start] --> B[prev = null]
    B --> C[curr = head]
    C --> D{curr != null?}
    D -->|Yes| E[next = curr.Next]
    E --> F[curr.Next = prev]
    F --> G[prev = curr]
    G --> H[curr = next]
    H --> D
    D -->|No| I[Return prev]
```

---

## 🔀 Pointer Movement

```mermaid
graph LR
    A[prev] --> B[curr]
    B --> C[next]
    C --> D[remaining list]
```

---

## 🧪 Dry Run

```text
Original:

1 → 2 → 3 → 4 → 5 → null
```

```text
Step 1:

prev = null
curr = 1
next = 2

Flip:
1 → null
```

```text
Step 2:

prev = 1
curr = 2
next = 3

Flip:
2 → 1 → null
```

```text
Step 3:

3 → 2 → 1 → null
```

```text
Step 4:

4 → 3 → 2 → 1 → null
```

```text
Step 5:

5 → 4 → 3 → 2 → 1 → null
```

---

## 🧾 Pseudocode

```text
SET prev = null
SET curr = head

WHILE curr is not null

    SET next = curr.next

    SET curr.next = prev

    SET prev = curr

    SET curr = next

RETURN prev
```

---

## ✅ C# Method

```csharp
public static ListNode ReverseList(ListNode head)
{
    ListNode prev = null;
    var curr = head;

    while (curr != null)
    {
        var next = curr.Next;

        curr.Next = prev;

        prev = curr;
        curr = next;
    }

    return prev;
}
```

---

## ⏱ Complexity

| Metric | Complexity |
|--------|------------|
| Time | **O(n)** |
| Space | **O(1)** |

---

# 🧩 Class Diagram

```mermaid
classDiagram
    class Program {
        +Main()
        +MaxProfit()
        +ReverseList()
        +PrintList()
    }

    class ListNode {
        +int Value
        +ListNode Next
    }

    Program --> ListNode
```

---

# 📊 Complexity Comparison

```mermaid
graph LR
    A[Best Time to Buy and Sell Stock] --> B[Time O(n)]
    A --> C[Space O(1)]

    D[Reverse Linked List] --> E[Time O(n)]
    D --> F[Space O(1)]
```

---

# ▶️ Sample Output

```text
Assignment 11.2

Max Profit: 5

Original List:
1 2 3 4 5

Reversed List:
5 4 3 2 1
```

---

# 💻 Technologies Used

| Technology | Purpose |
|------------|---------|
| C# | Programming Language |
| .NET 10 | Target Framework |
| Console Application | Application Type |
| Arrays | Stock Price Problem |
| Linked Lists | Reverse List Problem |
| Visual Studio | Development Environment |

---

# 🧠 Key Concepts Demonstrated

- Arrays
- Linked Lists
- One-Pass Algorithms
- Greedy Thinking
- Pointer Manipulation
- Big-O Analysis
- Clean C# Code
- Technical Whiteboarding
- Interview-Style Problem Solving

---

# 🧑‍💼 Interview Explanation

If explaining this at a whiteboard:

For the stock problem, I would explain that I only need to scan the array once. I keep track of the lowest price seen so far and compare each current price against it to determine the best possible profit at that moment.

For the linked list problem, I would explain that I reverse the list in-place using three pointers. I save the next node before changing the current pointer so I do not lose the rest of the list.

---

# 👨‍💻 Author

**Robert (Bobby) Rovy**

- 🇺🇸 U.S. Army Veteran
- Microsoft Software & Systems Academy
- AZ-104 Certified
- Aspiring Software Engineer
