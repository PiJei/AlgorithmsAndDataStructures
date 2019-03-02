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

namespace CSFundamentalAlgorithms.Hashing
{
    public class RollingHash
    {
        /// <summary>
        /// Implements a rolling hash function. 
        /// A use-case is Rabin-Karp search algorithm. 
        /// </summary>
        /// <param name="previousHashValue">Specifies the previous hash value, using which the new hash value will be computed.</param>
        /// <param name="oldCharToLeft">Specifies the character that will be omitted from the hash, and thus the rolling window. </param>
        /// <param name="newCharToRight">Specifies the new character that will be included in the hash and thus in the rolling window. </param>
        /// <param name="rollingWindowLength">Specifies the size of the rolling window. </param>
        /// <param name="hashConstant">Specifies the hash constant that is computed using ComputeHashConstantForRollingHash() method</param>
        /// <param name="prime">Specifies a prime number for the modulo operation in the hash function.</param>
        /// <param name="numCharsInAlphabet">Specifies the number of characters in alphabet needed by the hash function in the multiplication operation. </param>
        /// <returns>The hash value. </returns>
        public static int GetHashRollingForward(int previousHashValue, char oldCharToLeft, char newCharToRight, int rollingWindowLength, int hashConstant, int prime, int numCharsInAlphabet)
        {
            int rolledHashValue = ((previousHashValue - oldCharToLeft * hashConstant) * numCharsInAlphabet + newCharToRight) % prime;

            return rolledHashValue < 0 ? rolledHashValue + prime : rolledHashValue;
        }

        /// <summary>
        /// Computes the hash constant needed for the rolling hash. 
        /// </summary>
        /// <param name="rollingWindowLength">Specifies the size of the rolling window. </param>
        /// <param name="prime">Specifies a prime number for the modulo operation</param>
        /// <param name="numCharsInAlphabet">Specifies the number of characters in alphabet for the multiply operation. </param>
        /// <returns>Hashing constant based on the given prime number, window size, and numCharsInAlphabet. </returns>
        public static int ComputeHashConstantForRollingHash(int rollingWindowLength, int prime, int numCharsInAlphabet)
        {
            int HashConstant = 1;
            for (int i = 0; i < rollingWindowLength - 1; i++)
            {
                HashConstant = (HashConstant * numCharsInAlphabet) % prime;
            }
            return HashConstant;
        }

        /// <summary>
        /// Computes hash value for a string
        /// </summary>
        /// <param name="s">Specifies a string. </param>
        /// <param name="prime">Specifies a prime number for the modulo operation</param>
        /// <param name="numCharsInAlphabet">Specifies the number of characters in alphabet for the multiply operation. </param>
        /// <returns>Hash value of the string. </returns>
        public static int GetHash(string s, int prime, int numCharsInAlphabet)
        {
            int hash = 0;
            for (int i = 0; i < s.Length; i++)
            {
                hash = (hash * numCharsInAlphabet + s[i]) % prime; /* The modulo is for the numbers to fit in an integer.*/
            }
            return hash;
        }
    }
}
