using System;
namespace LeetCode
{
    public class ExcelSheetColumn
    {
        public int TitleToNumber(string columnTitle)
        {

            // BCM = [2, 3, 13]
            // Loop 1 -> Sum = 2
            // Loop 2 -> Sum = 2x26+3
            // Loop 3 -> Sum = (2x26+3)x26 + 13

            int sum = 0;

            char[] str = columnTitle.ToCharArray();

            for (int i = 0; i <= str.Length - 1; i++)
                sum = (sum * 26) + (str[i] - 'A' + 1);

            return sum;
        }
    }
}
