/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of CSFundamentalAlgorithms project.
 *
 * CSFundamentalAlgorithms is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * CSFundamentalAlgorithms is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with CSFundamentalAlgorithms.  If not, see <http://www.gnu.org/licenses/>.
 */

namespace CSFundamentalAlgorithms.SearchingAlgorithms.StringSearch
{
    public class RabinKarpSearch
    {
        private const int NumCharacters = 256;
        private const int PrimeNumber = 101;

        private int HashConstant = 1;

        /// <summary>
        /// Implements RabinKarp search algorithm, which is an improvement on NaiveSearch, using hashing.
        /// Hashing plays a crucial role in optimizing search time. Rolling hash methods are preferred, and the ones with the minimum collision. 
        /// </summary>
        /// <param name="text">The parent string in which we are searching for a subString.</param>
        /// <param name="subString">The string we want to find in parent string (text).</param>
        /// <returns>The starting index in text at which subString is found.</returns>
        public int Search(string text, string subString)
        {
            if (HashConstant == 1)
            {
                ComputeHashConstant(subString.Length);
            }

            int subStringHash = GetHash(subString); /* This hash is computed only once. Complexity : O(subString.Length)*/

            string subStringInText = text.Substring(0, subString.Length);
            int subStringInTextHash = GetHash(subStringInText);

            for (int i = 0; i < text.Length - 1; i++) /* O(text.Length) */
            {
                if (subStringHash == subStringInTextHash)
                {
                    if (subString == subStringInText) /* This check is necessary as the hash function may have collisions.*/
                    {
                        return i;
                    }
                }

                if (i < text.Length - subString.Length)
                {
                    subStringInText = text.Substring(i + 1, subString.Length); /* a substring in text, size of subString, starting at index i;*/
                    subStringInTextHash = GetHashRollingForward(subStringInTextHash, text[i], text[i + subString.Length], subString.Length); /* O(1) with a rolling hash, otherwise: O(subString.Length) */
                }
                else
                {
                    break;
                }
            }

            return -1;
        }

        /// <summary>
        /// Implements a rolling hash function. 
        /// </summary>
        public int GetHashRollingForward(int previousHash, char oldCharToLeft, char newCharToRight, int windowLength)
        {
            if (HashConstant == 1)
            {
                ComputeHashConstant(windowLength);
            }

            int hashValue = ((previousHash - oldCharToLeft * HashConstant) * NumCharacters + newCharToRight) % PrimeNumber;
            if (hashValue < 0)
                hashValue += PrimeNumber;
            return hashValue;
        }

        /// <summary>
        /// Cmputes the hash constant needed for the rolling hash
        /// </summary>
        /// <param name="windowLength">Length of the window in rolling hash. </param>
        /// <returns></returns>
        public int ComputeHashConstant(int windowLength)
        {
            for (int i = 0; i < windowLength - 1; i++)
            {
                HashConstant = (HashConstant * NumCharacters) % PrimeNumber;
            }
            return HashConstant;
        }

        /// <summary>
        /// Computes hash value for a string
        /// </summary>
        /// <param name="s">Specifies a string. </param>
        /// <returns>Hash value of the string. </returns>
        public int GetHash(string s)
        {
            int hash = 0;
            for (int i = 0; i < s.Length; i++)
            {
                hash = (hash * NumCharacters + s[i]) % PrimeNumber; // The modula is for the numbers to fit in an integer.
            }
            return hash;
        }
    }
}
