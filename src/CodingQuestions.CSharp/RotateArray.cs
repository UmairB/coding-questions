using System;

namespace CodingQuestions.CSharp
{
    public class RotateArray
    {
        public int[] MethodOne(int[] array, int k)
        {
            int len = array.Length;
            int reduced = k % len;
            int cutPoint = reduced <= 0 ? reduced + len : reduced;

            int[] result = new int[len];
            Array.Copy(array, cutPoint, result, 0, len - reduced);
            Array.Copy(array, 0, result, len - cutPoint, cutPoint);

            return result;
        }
    }
}
