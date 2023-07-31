/*
    Binary Search problem, however, the tricky part is uncovering the search space since it's not outrightly 
    given to us. We would only find it through logical thinking. Because we are trying to find the minimum
    speed for Koko to eat each pile before a given time period, a few things must be considered: 1. Koko can only
    finish a pile per hour at maximum. If she can't, then it must take N hours to fully finish a pile. 2. If
    there are less piles than hours, then Koko would be able to finish it at most by eating at the speed of 
    maximum pile / hour. So if the maximum pile in an array of piles is 30, then Koko can finish all piles within
    the time limit if she eats at 30 / hr. However, we are trying to find the minimum speed she can eat and STILL
    finish within the time limit. If the array is more than the time limit then Koko cannot finish because 
    she is restricted to eating only 1 pile for hour at MOST. Therefore, the search space must be 1 - Maximum in
    the piles array given that the array is shorter in length to the time hour limit. Now, we can perform binary 
    search to uncover the minimum value. And every time we find a K value that is less than the hour amount, we will
    initialize result to that. 

    Time complexity is O(Log(M)) where M is the length of 1 - Maximum amount in the array.
*/

using System;
using System.Linq;
class KokoBannana
{
    public static void Main(string[] args)
    {
        int[] piles = {30,11,23,4,20};
        int hours = 6;

        int answer = GetSolution(piles, hours);
        Console.WriteLine(answer);
    }
    public static int GetSolution(int[] piles, int hours)
    {
        int left = 1;
        int right = piles.Max();
        int result = right;
        double k;
        double count;

        while(left <= right){
            k = (left + right) / 2.0;
            count = 0;
            for(int i = 0; i <= piles.Length - 1; i++){
                count += Math.Ceiling(piles[i] / k);
            }
            if (count > hours)
            {
            left = (int)k + 1;
             }
            else
            {
            right = (int)k - 1;
            result = (int)k;
            }
        }
        return result;
    }
}