/**
 * (c) 2007 - 2016 gg.org released under creative commons, CC BY-NC-SA 4.0
 * 
 * (Attribution, NonCommercial, ShareAlike) 
 *  
 *  You are free to:
 *      Share — copy and redistribute the material in any medium or format
 *      Adapt — remix, transform, and build upon the material
 *      The licensor cannot revoke these freedoms as long as you follow the license terms.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace gg.requires
{
    public class RequirementFailedException : Exception
    {
        public RequirementFailedException() : base()
        {
        }

        public RequirementFailedException(string message) : base( message )
        {
        }
    }

    public static class Requires
    {
        [Conditional("DEBUG")]
        public static void IsTrue(bool b)
        {
            Console.WriteLine("foo");
            if (!b) throw new RequirementFailedException("Failed required boolean value (true).");
        }

        [Conditional("DEBUG")]
        public static void IsFalse(bool b)
        {
            if (b) throw new RequirementFailedException("Failed required boolean value (false).");
        }

        [Conditional("DEBUG")]
        public static void IsInRange(int value, int min, int max) 
        {
            if (value < min || value >= max) throw new RequirementFailedException($"Failed required is value in range ({value}, {min}, {max}).");
        }

        [Conditional("DEBUG")]
        public static void IsInRange(float value, float min, float max)
        {
            if (value < min || value >= max) throw new RequirementFailedException($"Failed required is value in range ({value}, {min}, {max}).");
        }

        [Conditional("DEBUG")]
        public static void IsInRange(double value, double min, double max)
        {
            if (value < min || value >= max) throw new RequirementFailedException($"Failed required is value in range ({value}, {min}, {max}).");
        }

        [Conditional("DEBUG")]
        public static void IsNotNull(object obj)
        {
            if (obj == null) throw new RequirementFailedException("Failed object requirements (not null).");
        }

        [Conditional("DEBUG")]
        public static void IsNull(object obj)
        {
            if (obj != null) throw new RequirementFailedException("Failed object requirements (null).");
        }

        [Conditional("DEBUG")]
        public static void IsNotNullOrEmpty(string str)
        {
            if (String.IsNullOrEmpty(str)) throw new RequirementFailedException("Failed string requirements (not null or empty).");
        }

        [Conditional("DEBUG")]
        public static void IsNotNullOrEmpty(ICollection collection)
        {
            if (collection == null || collection.Count == 0 ) throw new RequirementFailedException("Failed collection requirements (not null or empty).");
        }

        [Conditional("DEBUG")]
        public static void Contains<T>(ICollection<T> collection, T value)
        {
            if (collection == null || collection.Count == 0 || !collection.Contains(value) )
                throw new RequirementFailedException("Failed IList requirements (contains value).");
        }

        [Conditional("DEBUG")]
        public static void NotContains<T>(ICollection<T> collection, T value)
        {
            if (collection == null || (collection.Count > 0 && collection.Contains(value)))
                throw new RequirementFailedException("Failed IList requirements (does not contain value).");
        }

        [Conditional("DEBUG")]
        public static void ContainsKey<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary == null || dictionary.Count == 0 || !dictionary.ContainsKey(key))
                throw new RequirementFailedException("Failed IDictionary requirements (contains key).");
        }

        [Conditional("DEBUG")]
        public static void NotContainsKey<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key )
        {
            if (dictionary == null || ( dictionary.Count > 0 && dictionary.ContainsKey(key)))
                throw new RequirementFailedException("Failed IDictionary requirements (does not contain key).");
        }
    }
}
