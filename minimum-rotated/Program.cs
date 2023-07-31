/*
    This is a binary search problem. However, the array is not sorted meaning that one overall search will not work.
    Instead we can look at this problem as two sorted arrays combined into one. We will use logical based thinking
    to find which of the two array contains the minimum value and then sort that. We can infer that the left
    side does not include the minimum value if the left most value is greater than the right most but less than
    the mid point. Therefore, we will initialize left to be mid + 1. Before doing that, we will also store
    the standing answer as the mid point and then consistently compare it. Eventually, we should be able to find
    the minimum value in the right sorted array because it is sorted so it's left most element should be the
    automatic minimum.

    Time complexity is O(Log(n)) because it is a search.


*/


using System;

class MinimumRotated
{
    public static void Main(string[] args)
    {
        int[] array = {3,4,5,1,2};
        int answer = GetSolution(array);
        Console.WriteLine(answer);
    }

    private static int GetSolution(int[] array)
    {
        int res = array[0];
        int left = 0;
        int right = array.Length - 1;
        int mid;

        while(left <= right)
        {
            if(array[left] < array[right]){
                res = Math.Min(res, array[left]);
                break;
            }
            mid = (left + right) / 2;
            res = Math.Min(res, array[mid]);
            if(array[left] <= array[mid]){
                left = mid + 1;
            }
            else{
                right = mid - 1;
            }
        }
        return res;
    }
}