/*  
    Binary Search problem. The difficulty in this is finding the proper search space that can ensure that
    both parts from both arrays properly make up the left section of the combined array. This is done by finding
    the mid point of the shortest array, and then subtracting the longer array with the half along with the mid
    point and 2 to account for the index/length confusion. Then, we check if the last elements of both subsets
    are less than the opposing mid + 1 elements, if so then it means the arrays are in correct order. then we 
    can check if its an odd or even length in the total array. if it's odd, then the median is the minimum of the
    mid + 1 of the two arrays. Else, it would be the max of the mid of each left array added with the minimum of the
    mid + 1 elements / 2. If any of the mid elements are > then we must rechange the search space of the shortest 
    array.

    Time complexity should be O(log N) since it's just a binary search.



*/



using System;

class MedianTwoSorted
{
    public static void Main(string[] args)
    {
        int[] arrayA = {1, 2};
        int[] arrayB = {3, 4};
        float answer = GetSolution(arrayA, arrayB);
        Console.WriteLine(answer);
    }
    private static float GetSolution(int[] array1, int[] array2)
    {
        int total = array1.Length + array2.Length;
        int half = total / 2;
        int[] shortArray;
        int[] longArray;
        
        if(array1.Length >= array2.Length)
        {
            shortArray = array2;
            longArray = array1;
        } else {
            shortArray = array1;
            longArray = array2; 
        }
        int shortLeft = 0;
        int shortRight = shortArray.Length - 1;
        int mid;

        int longArrayPointer;

        while(shortLeft <= shortRight)
        {   
            mid = (shortLeft + shortRight) / 2;
            longArrayPointer = half - mid - 2;
            if(shortArray[mid] <= longArray[longArrayPointer + 1] && longArray[longArrayPointer] <= shortArray[mid + 1])
            {
                if(total % 2 == 0)
                {
                    float median = (Math.Max(shortArray[mid], longArray[longArrayPointer]) + Math.Min(shortArray[mid + 1], longArray[longArrayPointer])) / 2.0f;
                    return median;
                } else 
                {
                    float median = Math.Min(shortArray[mid + 1], longArray[longArrayPointer]);
                    return median;
                }
            } else if (shortArray[mid] > longArray[longArrayPointer + 1])
            {
                shortRight = mid - 1;
            }
            else
            {
                shortLeft = mid + 1;
            }
        }
        throw new InvalidOperationException("Input arrays are not sorted.");
    }
}