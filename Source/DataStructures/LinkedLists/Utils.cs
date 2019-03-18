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
 * along with CSFundamentals.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.IO;
using System.Xml.Serialization;

namespace CSFundamentals.DataStructures.LinkedLists
{
    public class Utils
    {
        public static T DeepCopy<T>(T obj)
        {
            string serializedData = string.Empty;
            T deepCopy;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, obj);
                serializedData = sw.ToString();
            }
            using (StringReader stringReader = new StringReader(serializedData))
            {
                deepCopy = (T)serializer.Deserialize(stringReader);
            }

            return deepCopy;
        }
    }
}
