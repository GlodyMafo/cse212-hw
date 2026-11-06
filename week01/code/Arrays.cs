public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Step 1: Create a new array of doubles with a size equal to length.
        // Step 2: Loop from index 0 to length - 1 to populate each position in the array.
        // Step 3: Calculate the multiple by multiplying the starting number by (i + 1) 
        // so that the first element is number * 1, the second is number * 2, etc.
        // Step 4: Return the fully populated array.

        double[] result = new double[length]; 
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Step 1: Handle edge cases where the list is empty, has only 1 element, or rotation amount is 0.
        // Step 2: Ensure the rotation amount wraps correctly using modulo % in case amount >= data.Count.
        // Step 3: Determine the split index where the rotated portion starts (data.Count - amount).
        // Step 4: Extract the rotated portion (elements that will move to the front) using GetRange.
        // Step 5: Extract the remaining portion (elements that will move to the back) using GetRange.
        // Step 6: Clear the original list to rebuild it with the rotated order.
        // Step 7: Add the rotated elements first, followed by the head elements.

        if (data == null || data.Count == 0 || amount <= 0)
        
            return; 
         amount = amount % data.Count;
         if (amount == 0)
            return;

        int splitIndex = data.Count - amount;
        List<int> rotatedList = data.GetRange(splitIndex, amount);
        List<int> remaining = data.GetRange(0, splitIndex);
        data.Clear();
        data.AddRange(rotatedList);
        data.AddRange(remaining);
    }
}
