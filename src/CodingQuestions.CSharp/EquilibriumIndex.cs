namespace CodingQuestions.CSharp
{
    /// <summary>
    /// Equilibrium index of an array is an index such that the sum of elements at lower indexes is equal to the sum of elements at higher indexes. 
    /// For example, in an array A:
    /// A[0] = -7, A[1] = 1, A[2] = 5, A[3] = 2, A[4] = -4, A[5] = 3, A[6]=0
    ///
    /// 3 is an equilibrium index, because:
    /// A[0] + A[1] + A[2] = A[4] + A[5] + A[6]
    ///
    /// 6 is also an equilibrium index, because sum of zero elements is zero, i.e., A[0] + A[1] + A[2] + A[3] + A[4] + A[5]=0
    /// </summary>
    public class EquilibriumIndex
    {
        /// <summary>
        /// Simple brute force. Is O(n^2)
        /// </summary>
        public static int MethodOne(int[] arr)
        {
            int i, j;
            int leftsum, rightsum;

            int length = arr.Length;
            for (i = 0; i < length; ++i)
            {
                leftsum = 0;
                rightsum = 0;

                for (j = 0; j < i; j++)
                    leftsum += arr[j];

                for (j = i + 1; j < length; j++)
                    rightsum += arr[j];

                if (leftsum == rightsum)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Find right sum first. Then subtract as array is traversed for left sum. Is O(n)
        /// </summary>
        public static int MethodTwo(int[] arr)
        {
            int leftsum = 0;
            int sum = 0;
            int length = arr.Length;

            for (int i = 0; i < length; i++)
                sum += arr[i];

            for (int i = 0; i < length; i++)
            {
                int value = arr[i];

                // take away the current element to produce the current rightsum
                sum -= value;

                if (leftsum == sum)
                    return i;

                leftsum += value;
            }

            return -1;
        }
    }
}
