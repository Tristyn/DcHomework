using System;
using System.Collections.Generic;
using System.Text;

namespace DhHomework
{
    public static class StringToInt
    {
        // Stoi exists because c's atoi is for ascii, stoi accepts utf-8. C# is utf-16 but let's not talk about that
        private static readonly Dictionary<char, int> _digits = new Dictionary<char, int>
        {
            { '0', 0 },
            { '1', 1 },
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },

            { 'a', 10 },
            { 'b', 11 },
            { 'c', 12 },
            { 'd', 13 },
            { 'e', 14 },
            { 'f', 15 },
            { 'g', 16 },
            { 'h', 17 },
            { 'i', 18 },
            { 'j', 19 },
            { 'k', 20 },
            { 'l', 21 },
            { 'm', 22 },
            { 'n', 23 },
            { 'o', 24 },
            { 'p', 25 },
            { 'q', 26 },
            { 'r', 27 },
            { 's', 28 },
            { 't', 29 },
            { 'u', 30 },
            { 'v', 31 },
            { 'w', 32 },
            { 'x', 33 },
            { 'y', 34 },
            { 'z', 35 },

            { 'A', 10 },
            { 'B', 11 },
            { 'C', 12 },
            { 'D', 13 },
            { 'E', 14 },
            { 'F', 15 },
            { 'G', 16 },
            { 'H', 17 },
            { 'I', 18 },
            { 'J', 19 },
            { 'K', 20 },
            { 'L', 21 },
            { 'M', 22 },
            { 'N', 23 },
            { 'O', 24 },
            { 'P', 25 },
            { 'Q', 26 },
            { 'R', 27 },
            { 'S', 28 },
            { 'T', 29 },
            { 'U', 30 },
            { 'V', 31 },
            { 'W', 32 },
            { 'X', 33 },
            { 'Y', 34 },
            { 'Z', 35 },
        };

        public static int Stoi(string str, out int idx, int @base)
        {
            if (@base > 36 || @base < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(@base), "Must be greater than 1 and less than 37");
            }

            var i = 0;
            // we'll use this to keep track of our position

            // Find the first non-whitespace char
            while (char.IsWhiteSpace(str[i]))
            {
                i++;
            }

            // Detect sign
            bool isPositive = true;
            if (str[i] == '-')
            {
                isPositive = false;
                i++;
            }
            else if (str[i] == '+')
            {
                isPositive = true;
                i++;
            }


            // Detect base by looking at the prefix in the case of base 0
            if (@base == 0)
            {
                if (str[i] == '0')
                {
                    if (str[i + 1] == 'x' || str[i + 1] == 'X')
                    {
                        @base = 16;
                        i += 2;
                    }
                    else
                    {
                        @base = 8;
                        i += 1;
                    }
                }
                else
                {
                    @base = 10;
                }
            }

            // Skip past the prefix depending on the base
            if (@base == 16)
            {
                if (str[i] == '0' && (str[i + 1] == 'x' || str[i + 1] == 'X'))
                {
                    i += 2;
                }
            }
            else if (@base == 8)
            {
                if (str[i] == '0')
                {
                    i += 1;
                }
            }


            // Now i points to the actual 'uint' part of the number
            var firstDigitIndexInNumber = i;

            // We reuse this temp variable a few times instead of declaring over and over again
            // What a maintainence code smell
            int digitValue = 0;

            // Since arabic numerals in english are specified right to left, find the last digit of the number.
            // Make america use RTL arabic numerals again!
            int firstCharAfterNumber = i;
            while (
                firstCharAfterNumber < str.Length &&
                _digits.TryGetValue(str[firstCharAfterNumber], out digitValue) &&
                digitValue < @base)
            {
                firstCharAfterNumber++;
            }
            //// Needed when the string ends after the number
            //if (_digits.TryGetValue(str[firstCharAfterNumber], out digitValue) &&
            //    digitValue < @base)
            //{
            //    firstCharAfterNumber++;
            //}


            // Now parse the uint, working our way backwards from the end
            int number = 0;
            int digitPlace = 0;
            for (var digitIndex = firstCharAfterNumber - 1; digitIndex >= firstDigitIndexInNumber; digitIndex--)
            {
                digitValue = _digits[str[digitIndex]];
                var expandedDigitValue = digitValue * IntPower(@base, digitPlace);
                number += expandedDigitValue;
                digitPlace++;
            }

            if (isPositive == false)
            {
                number = -number;
            }

            idx = firstCharAfterNumber;
            return number;
        }

        private static int IntPower(int @base, int exponent)
        {
            // because .NET only provides pow for doubles
            if (exponent < 0)
                throw new ArgumentOutOfRangeException(nameof(exponent), "Must be positive or zero");

            int val = 1;
            while (exponent != 0)
            {
                if ((exponent & 1) == 1)
                    val *= @base;
                @base *= @base;
                exponent >>= 1;
            }
            return val;
        }
    }
}
