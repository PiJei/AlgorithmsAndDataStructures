#region copyright
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
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using AlgorithmsAndDataStructures.Algorithms.PatternSearch;
namespace AlgorithmsAndDataStructures.Algorithms.Hashing
{
    /// <summary>
    /// Implements a rolling hash algorithm. 
    /// <para>In this form of hashing the new hash value of a string is calculated incrementally by rolling over a window of a fixed size over the string to include new characters and drop previous ones. </para>
    /// </summary>
    public class RollingHash
    {
        /// <summary>
        /// Rolling hash. For a use-case <see cref="RabinKarpSearch"/>
        /// </summary>
        /// <param name="previousHashValue">The previous hash value, using which the new hash value will be computed.</param>
        /// <param name="oldCharToLeft">The character that will be dropped out of rolling hash window and hash value. </param>
        /// <param name="newCharToRight">The new character that will be included in the hash window and hash value. </param>
        /// <param name="rollingWindowLength">The length of the rolling window, measured in characters. </param>
        /// <param name="hashConstant">Hash constant that is computed using <see cref="ComputeHashConstantForRollingHash(int, int, int)"/>. </param>
        /// <param name="prime">A prime number for the modulo operation in the hash function.</param>
        /// <param name="numCharsInAlphabet">The number of characters in alphabet used by the multiply operation. </param>
        /// <returns>The new hash value. </returns>
        public static int GenerateRollingHash(int previousHashValue, char oldCharToLeft, char newCharToRight, int rollingWindowLength, int hashConstant, int prime, int numCharsInAlphabet)
        {
            int rolledHashValue = ((previousHashValue - oldCharToLeft * hashConstant) * numCharsInAlphabet + newCharToRight) % prime;

            return rolledHashValue < 0 ? rolledHashValue + prime : rolledHashValue;
        }

        /// <summary>
        /// Computes the hash constant needed by <see cref="GenerateRollingHash(int, char, char, int, int, int, int)"/>.
        /// </summary>
        /// <param name="rollingWindowLength">The length of the rolling window. </param>
        /// <param name="prime">A prime number for the modulo operation. </param>
        /// <param name="numCharsInAlphabet">The number of characters in alphabet used by the multiply operation. </param>
        /// <returns>Hashing constant computed based on the given prime number, window length, and number of characters in the alphabet. </returns>
        public static int ComputeHashConstantForRollingHash(int rollingWindowLength, int prime, int numCharsInAlphabet)
        {
            int hashConstant = 1;
            for (int i = 0; i < rollingWindowLength - 1; i++)
            {
                hashConstant = (hashConstant * numCharsInAlphabet) % prime;
            }
            return hashConstant;
        }

        /// <summary>
        /// Computes hash value for string <paramref name="text"/>.
        /// </summary>
        /// <param name="text">A string value. </param>
        /// <param name="prime">A prime number for the modulo operation. </param>
        /// <param name="numCharsInAlphabet">The number of characters in alphabet used by the multiply operation. </param>
        /// <returns>Hash value of the string. </returns>
        public static int GetHash(string text, int prime, int numCharsInAlphabet)
        {
            int hash = 0;
            for (int i = 0; i < text.Length; i++)
            {
                hash = (hash * numCharsInAlphabet + text[i]) % prime; /* The modulo is for making the numbers to fit in an integer.*/
            }
            return hash;
        }
    }
}
