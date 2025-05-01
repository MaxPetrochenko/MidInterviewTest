using Xunit;

namespace MidInterviewTest;

/*
    You are given an n x n 2D matrix representing an image, 
    rotate the image by 90 degrees (clockwise).
    
    Extra:
    You have to rotate the matrix in-place, which means you 
    have to modify the input 2D matrix directly. 
    DO NOT allocate another 2D matrix and do the rotation.
    
    Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
    Output: [[7,4,1],[8,5,2],[9,6,3]]
    
    1 2 3      7 4 1
    4 5 6  ->  8 5 2
    7 8 9      9 6 3
*/
public static class MatrixRotator
{
    public static int[][] Rotate(int[][] matrix)
    {
        int length = matrix[0].Length;
        int n = length - 1;
        int radius = n;

        for (int i = 0; i <= n; i++)
            for (int j = 0; j <= n; j++)
            {
                var first = Do(ref matrix, i, j, radius, n);
                var original = (0, 0, matrix[0][0]);
                while (first.Item1 != i && first.Item2 != j)
                {
                    matrix[original.Item1][original.Item2] = first.Item3;
                    matrix[first.Item1][first.Item2] = original.Item3;
                    first = Do(ref matrix, first.Item1, first.Item2, radius, n);
                    
                }
            }
        return matrix;
    }

    public static (int, int, int) Do(ref int[][] matrix, int i, int j, int radius, int n)
    {
        //rad == n -1
        //
        //
        //
        int dx = (j + radius) % n;
        var newIndexI = n - radius + j;
        var newIndexJ = j + radius > n ? n : j + radius;
        return (newIndexI, newIndexJ, matrix[newIndexI][newIndexJ]);
    }
}

public class TestMatrixRotator
{
    [Theory]
    [InlineData(
         1, 2, 3, 4, 5, 6, 7, 8, 9,
         7, 4, 1, 8, 5, 2, 9, 6, 3 
    )]
    public void Test(params int[] input)
    {
        var originalMatrix = new int[3][];
        for (int i = 0; i < 3; i++)
        {
            originalMatrix[i] = new int[3];
            for (int j = 0; j < 3; j++)
            {
                originalMatrix[i][j] = input[i * 3 + j];
            }
        }
        var expectedMatrix = new int[3][];
        for (int i = 0; i < 3; i++)
        {
            expectedMatrix[i] = new int[3];
            for (int j = 0; j < 3; j++)
            {
                expectedMatrix[i][j] = input[i * 3 + j + 9];
            }
        }
        var actualMatrix = MatrixRotator.Rotate(originalMatrix);
        Assert.Equal(expectedMatrix, actualMatrix);
    }
  
}