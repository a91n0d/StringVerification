using System;
using System.Globalization;

namespace StringVerification
{
    public static class IsbnVerifier
    {
        /// <summary>
        /// Verifies if the string representation of number is a valid ISBN-10 identification number of book.
        /// </summary>
        /// <param name="number">The string representation of book's number.</param>
        /// <returns>true if number is a valid ISBN-10 identification number of book, false otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if number is null or empty or whitespace.</exception>
        public static bool IsValid(string number)
        {
            if (string.IsNullOrWhiteSpace(number) || number.Length == 0)
            {
                throw new ArgumentException("number is null or empty or whitespace.", nameof(number));
            }

            int sum = 0;
            int coef = 10;
            int len = 10;
            for (int i = 0; i < number.Length; i++)
            {
                if ((i == 1 || i == 5 || i == 11) && number[i] == '-')
                {
                    len++;
                }
                else if (i == number.Length - 1 && number[i] == 'X')
                {
                    sum += 10 * coef--;
                }
                else if (char.IsNumber(number[i]))
                {
                    sum += int.Parse(number[i].ToString(), CultureInfo.InvariantCulture) * coef--;
                }
                else
                {
                    return false;
                }
            }

            return sum % 11 == 0 && number.Length == len;            
        }
    }
}
