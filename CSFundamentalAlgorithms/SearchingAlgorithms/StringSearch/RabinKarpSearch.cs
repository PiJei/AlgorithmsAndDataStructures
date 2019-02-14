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

        /// <summary>
        /// Implements RabinKarp search algorithm, which is an improvement on NaiveSearch, using hashing.
        /// Hashing plays a crucial role in optimizing search time. Rolling hash methods are preferred, and the ones with the minimum collision. 
        /// </summary>
        /// <param name= "text">The parent string in which we are searching for a subString.</param>
        /// <param name= "subString">The string we want to find in parent string (text).</param>
        /// <returns>The starting index in text at which subString is found.</returns>
        public static int Search(string text, string subString)
        {
            int n = text.Length;
            int m = subString.Length;

            int hashConstant = RollingHash.ComputeHashConstantForRollingHash(subString.Length, PrimeNumber, NumCharacters);
            int subStringHash = RollingHash.GetHash(subString, PrimeNumber, NumCharacters); /* This hash is computed only once. Complexity : O(subString.Length)*/

            string subStringInText = text.Substring(0, m);
            int subStringInTextHash = RollingHash.GetHash(subStringInText, PrimeNumber, NumCharacters);

            for (int i = 0; i < n - 1; i++) /* O(text.Length) */
            {
                if (subStringHash == subStringInTextHash)
                {
                    if (subString == subStringInText) /* This check is necessary as the hash function may have collisions.*/
                    {
                        return i;
                    }
                }

                if (i < n - m)
                {
                    subStringInText = text.Substring(i + 1, m); /* a substring in text, size of subString, starting at index i;*/
                    subStringInTextHash = RollingHash.GetHashRollingForward(subStringInTextHash, text[i], text[i + m], m, hashConstant, PrimeNumber, NumCharacters); /* O(1) with a rolling hash, otherwise: O(subString.Length) */
                }
                else
                {
                    break;
                }
            }

            return -1;
        }
    }
}
