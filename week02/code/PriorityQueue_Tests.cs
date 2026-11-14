using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities (Low: 1, Medium: 5, High: 10) and dequeue them.
    // Expected Result: dequeued items in order of highest priority first ("High", then "Medium", then "Low").
    // Defect(s) Found: Previously, the loop condition stopped before the last item (Count - 1), used '>=' instead of '>' for ties breaking incorrectly, and did not remove the item from the queue list via RemoveAt.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with equal priority in FIFO order, and test dequeuing from an empty queue.
    // dequeue items with equal priority in FIFO order ("FirstHigh", then "SecondHigh"), and dequeuing an empty queue throws an InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Previously, using '>=' instead of '>' overwrote earlier items on tie rather than preserving FIFO order.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstHigh", 10);
        priorityQueue.Enqueue("SecondHigh", 10);
        priorityQueue.Enqueue("Low", 1);

        Assert.AreEqual("FirstHigh", priorityQueue.Dequeue());
        Assert.AreEqual("SecondHigh", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());

        var emptyQueue = new PriorityQueue();
        var exception = Assert.ThrowsException<InvalidOperationException>(() => emptyQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    // Add more test cases as needed below.
}