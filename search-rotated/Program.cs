/*
    Binary Search so we must uncover the search space. However, since this is unsorted which consist of two
    sorted arrays, we must decide where the target is: the left side, or the right side. This is done by checking
    if target is falls within the left and mid pointer or within the mid and right pointers. Afterwards, we can
    move our left or right pointer which means we will be binary searching one of the already sorted arrays, and
    then we can find the target.
*/

using System;

class SearchRotated
{
    public static void Main(string[] args)
    {
        int[] array = {4,5,6,7,0,1,2};
        int target = 5;
        int answer = GetSolution(array, target);

        Console.WriteLine(answer);
    }

    private static int GetSolution(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;
        int mid;

        while(left <= right)
        {   
            mid = (left + right) / 2;
            if(array[mid] == target){
                return mid;
            }
            if(array[left] < array[right]){
                if(array[mid] < target){
                    left = mid + 1;
                }
                else if(array[mid] > target){
                    right = mid - 1;
                }
                else{
                    return mid;
                }
            } 

            if(array[left] <= array[mid]){
                if(array[left] <= target && target <= array[mid]){
                    right = mid - 1;
                } else {
                    left = mid + 1;
                }
            }  else
            {

                if (array[mid] < target && target <= array[right])
                {
                    left = mid + 1; 
                }
                else
                {
                    right = mid - 1; 
                }
            }
        } return -1;
    }
}