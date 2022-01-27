
/*
  Fundamentals Section:

  You may use any ES6+ features you like (or none at all).
*/

/*
  1: Create a function that takes an array of numbers and return both the minimum and maximum numbers, in that order.
    - Not all values in the array are known to be numbers.

    Examples
    minMax([1, 2, 3, 4, 5]) ➞ [1, 5]

    minMax([2334454, 5]) ➞ [5, 2334454]

    minMax([1]) ➞ [1, 1]
*/

public string MinMax(string minMax)
{
    // created an array of values, then assign variables to the min and max function, then return a string of that output
    int[] values = { 1, 15, 13, 45, 397, 52222 };
    int min = values.Min();
    int max = values.Max();
    minMax = $"[{min}, {max}]";
    return minMax;
}


/*
  2. Sorting Objects
  Create a function that takes an array of objects and a string field name, and returns the array of objects sorted in ascending order by the field name.

  Example:
  sortObjects[{ text: 'Kim', value: '1'}, { text: 'John', value: 3}, { text: 'Sally', value: 2}], 'value') 
    ➞ [{ text: 'Kim', value: '1'}, { text: 'Sally', value: 2}, { text: 'John', value: 3}]
*/

public void Sort()
{
    // using a dictionary to assign a number to a name. Sorting wasnt working so looked up and found out about SortedDictionary, so I switched to that
    SortedDictionary<string, int> keyValuePairs = new SortedDictionary<string, int>();
    keyValuePairs.Add("Kim", 1); keyValuePairs.Add("John", 3); keyValuePairs.Add("Sally", 2);
    // wasn't sure where to go from here cuz i've never used sorted dictionaries so used https://www.c-sharpcorner.com/UploadFile/dbeniwal321/how-to-sort-items-of-a-sorted-dictionary-with-C-Sharp/ to help
    foreach (KeyValuePair<string, int> name in keyValuePairs.OrderBy(key => key.Value))
    {
        Console.WriteLine($"text: {name.Key}, value: {name.Value}");
    }
}

