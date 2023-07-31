/*
    This is a binary search problem. The main task is to define the search space first, and then we can
    establish our left-most, right-most, and mid point boundaries. The search space in this case is 
    a matrix which means we have to binary search the rows, and then binary search elements within certain row. If there
    are no matches within searched row, then we would devolve back to the outer binary search the rows.
    
    time complexity should be O(log(m * n)) because we are halving both M(the matrix itself) and N(elements within 
    a specific row). Space Complexity is O(1) because we are only searching through the given array so nothing
    grows in terms of space.
    /
*/

using System;

class Search2D
{
    public static void Main(string[] args)
    {
        int[][] matrix = new int[][] {
            new int[] {1, 3, 5, 7},
            new int[] {10, 11, 16, 20},
            new int[] {23, 30, 34, 60}
        };
        int target = 15;

        bool answer = GetSolution(matrix, target);
        Console.WriteLine(answer);
    }

    public static bool GetSolution(int[][] matrix, int target)
    {
        int rowLeft = 0;
        int rowRight = matrix.Length - 1;

        while(rowLeft <= rowRight){
            int midRow = ((rowRight + rowLeft) / 2);
            if(SearchRow(matrix[midRow], target)){
                return true;
            }
            else{
                if(matrix[midRow][0] > target){
                    rowRight = midRow - 1;
                } else {
                    rowLeft = midRow + 1;
                }
            }
        }
        return false;

    }

    public static bool SearchRow(int[] row, int target)
    {
        int left = 0;
        int right = row.Length - 1;

        while(left <= right){
            int mid = (right + left) / 2;
            if(row[mid] < target){
                left = mid + 1;
            }
            else if(row[mid] > target){
                right = mid - 1;
            }
            else{
                return true;
            }
        }
        return false;
    }
}