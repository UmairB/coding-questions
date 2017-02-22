using System;

namespace CodingQuestions.CSharp
{
    public class TwoSumII
    {
        public static void Run()
        {
            var arry = new int[] { 1, 1, 3, 4, 5 };
            var target = 6;

            var resultOne = MethodOne(arry, target);
            Console.WriteLine("MethodOne: {0},{1}", resultOne[0], resultOne[1]);

            var resultTwo = MethodTwo(arry, target);
            Console.WriteLine("MethodTwo: {0},{1}", resultTwo[0], resultTwo[1]);
        }

        public static int[] MethodOne(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int j = BSearch(numbers, target - numbers[i], i + 1);
                if (j != -1)
                {
                    return new[] { i + 1, j + 1 };
                }
            }

            return null;
        }

        /// <summary>
        /// O(n) runtime, O(1) space – Two pointers:
        /// Let’s assume we have two indices pointing to the ith and jth elements, Ai and Aj
        /// respectively.The sum of Ai and Aj could only fall into one of these three possibilities:
        /// i.  Ai + Aj > target. Increasing i isn’t going to help us, as it makes the sum even bigger. Therefore we should decrement j.
        /// ii. Ai + Aj < target. Decreasing j isn’t going to help us, as it makes the sum even smaller. Therefore we should increment i.
        /// iii.Ai + Aj == target. We have found the answer.
        /// </summary>
        public static int[] MethodTwo(int[] numbers, int target)
        {
            int i = 0;
            int j = numbers.Length - 1;
            while (i < j)
            {
                int sum = numbers[i] + numbers[j];
                if (sum < target)
                {
                    i++;
                }
                else if (sum > target)
                {
                    j--;
                }
                else
                {
                    return new[] { i + 1, j + 1 };
                }
            }

            return null;
        }

        private static int BSearch(int[] arr, int key, int start)
        {
            int left = start;
            int right = arr.Length - 1;
            while (left < right)
            {
                int m = (left + right) / 2;
                if (arr[m] < key)
                {
                    left = m + 1;
                }
                else
                {
                    right = m;
                }
            }

            return left == right && arr[left] == key ? left : -1;
        }
    }
}
