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

 using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using gg.requires;

namespace TestRequires
{
    [TestClass]
    public class RequiresTest
    {
#if DEBUG
        [TestMethod]
        public void IsTrueGreenPath()
        {
            Requires.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void IsTrueRedPath()
        {
            Requires.IsTrue(false);
        }

        [TestMethod]
        public void IsFalseGreenPath()
        {
            Requires.IsFalse(false);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void IsFalseRedPath()
        {
            Requires.IsFalse(true);
        }

        [TestMethod]
        public void IsInIntRangeGreenPath()
        {
            Requires.IsInRange(0, 0, 1);
            Requires.IsInRange(-1, -1, 0);
            Requires.IsInRange(1, 0, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void IsBelowIntRange()
        {
            Requires.IsInRange(-1, 0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void IsAboveIntRange()
        {
            Requires.IsInRange(1, 0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void NullIntRange()
        {
            Requires.IsInRange(0, 0, 0);
        }

        [TestMethod]
        public void IsInFloatRangeGreenPath()
        {
            Requires.IsInRange(0f, 0f, 1f);
            Requires.IsInRange(-0.5f, -1f, 0f);
            Requires.IsInRange(0.5f, 0f, 2f);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void IsBelowFloatRange()
        {
            Requires.IsInRange(-1f, 0f, 1f);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void IsAboveFloatRange()
        {
            Requires.IsInRange(1.1f, 0f, 1f);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void NullFloatRange()
        {
            Requires.IsInRange(0f, 0f, 0f);
        }

        [TestMethod]
        public void IsInDoubleRangeGreenPath()
        {
            Requires.IsInRange(0.0, 0.0, 1.0);
            Requires.IsInRange(-0.5, -1, 0f);
            Requires.IsInRange(0.5, 0, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void IsBelowDoubleRange()
        {
            Requires.IsInRange(-0.1, 0.0, 1.0);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void IsAboveDoubleRange()
        {
            Requires.IsInRange(1.1, 0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void NullDoubleRange()
        {
            Requires.IsInRange(1.0, 1.0, 0.0);
        }

        [TestMethod]
        public void IsNotNullGreenPath()
        {
            Requires.IsNotNull(new object());
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void IsNotNullRedPath()
        {
            Requires.IsNotNull(null);
        }

        [TestMethod]
        public void IsNullGreenPath()
        {
            Requires.IsNull(null);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void IsNullRedPath()
        {
            Requires.IsNull(new object());
        }

        [TestMethod]
        public void IsNotNullOrEmptyGreenPath()
        {
            Requires.IsNotNullOrEmpty("foo");
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void IsNullOrEmptyNullRedPath()
        {
            Requires.IsNotNullOrEmpty((string) null);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void IsNullOrEmptyEmptyRedPath()
        {
            Requires.IsNotNullOrEmpty("");
        }

        [TestMethod]
        public void IsNotNullOrEmptyCollectionGreenPath()
        {
            Requires.IsNotNullOrEmpty(new List<int>() { 1 });
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void IsNullOrEmptyNullCollectionRedPath()
        {
            Requires.IsNotNullOrEmpty((List<int>) null);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void IsNullOrEmptyEmptyCollectionRedPath()
        {
            Requires.IsNotNullOrEmpty(new List<int>());
        }

        [TestMethod]
        public void CollectionContainsGreenPath()
        {
            ICollection<int> collection = new List<int>() { 1 };
            Requires.Contains(collection, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void CollectionContainsNullRedPath()
        {
            Requires.Contains((ICollection<int>)null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void CollectionContainsEmptyRedPath()
        {
            Requires.Contains(new List<int>(), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void ListContainsRedPath()
        {
            Requires.Contains(new List<int>(2), 1);
        }

        [TestMethod]
        public void CollectionNotContainsGreenPath()
        {
            ICollection<int> collection = new List<int>();
            Requires.NotContains(collection, 2);

            collection = new List<int>() { 1 };
            Requires.NotContains(collection, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void CollectionNotContainsNullRedPath()
        {
            Requires.NotContains((ICollection<int>)null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void CollectionNotContainsRedPath()
        {
            Requires.NotContains(new List<int>() { 1 }, 1);
        }

        [TestMethod]
        public void ContainsKeyGreenPath()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            dictionary[1] = "foo";

            Requires.ContainsKey(dictionary, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void ContainsKeyNullRedPath()
        {
            Requires.ContainsKey((Dictionary<int, string>) null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void ContainsKeyRedPath()
        {
            Requires.ContainsKey(new Dictionary<int, string>(), 1);
        }

        [TestMethod]
        public void NotContainsKeyGreenPath()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            Requires.NotContainsKey(dictionary, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void NotContainsKeyNullRedPath()
        {
            Requires.NotContainsKey((Dictionary<int, string>)null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(RequirementFailedException))]
        public void NotContainsKeyRedPath()
        {
            Requires.NotContainsKey(new Dictionary<int, string>() { { 1, "foo" } }, 1);
        }

#else
        [TestMethod]
        public void IsTrueRedPathIgnoredIfRequiredDisabled()
        {
            Requires.IsTrue(false);
        }

        [TestMethod]
        public void IsFalseRedPathIgnoredIfRequiredDisabled()
        {
            Requires.IsFalse(true);
        }
        
        [TestMethod]
        public void IsNotNullRedPathIgnoredIfRequiredDisabled()
        {
            Requires.IsNotNull(null);
        }
        
        [TestMethod]
        public void IsNullRedPathIgnoredIfRequiredDisabled()
        {
            Requires.IsNull(new object());
        }    

        [TestMethod]
        public void IsIntRangeRedPathIgnoredIfRequiredDisabled()
        {
            Requires.IsInRange(0, 0, 0);
        }   
        
        [TestMethod]
        public void IsFloatRangeRedPathIgnoredIfRequiredDisabled()
        {
            Requires.IsInRange(0f, 0f, 0f);
        }
        
        [TestMethod]
        public void IsDoubleRangeRedPathIgnoredIfRequiredDisabled()
        {
            Requires.IsInRange(-1.0, -1.0, -2.0);
        }    
 
        [TestMethod]
        public void IsNullOrEmptyNullRedPathIgnoredIfRequiredDisabled()
        {
            Requires.IsNotNullOrEmpty((string) null);
        }

        [TestMethod]
        public void IsNullOrEmptyEmptyRedPathIgnoredIfRequiredDisabled()
        {
            Requires.IsNotNullOrEmpty("");
        }

        [TestMethod]
        public void IsNullOrEmptyNullCollectionRedPathIgnoredIfRequiredDisabled()
        {
            Requires.IsNotNullOrEmpty((List<int>)null);
        }

        [TestMethod]
        public void IsNullOrEmptyEmptyCollectionRedPathIgnoredIfRequiredDisabled()
        {
            Requires.IsNotNullOrEmpty(new List<int>());
        }

        [TestMethod]
        public void CollectionContainsNullRedPathIgnoredIfRequiredDisabled()
        {
            Requires.Contains((List<int>)null, 1);
        }

        [TestMethod]
        public void CollectionContainsEmptyRedPathIgnoredIfRequiredDisabled()
        {
            Requires.Contains(new List<int>(), 1);
        }

        [TestMethod]
        public void CollectionContainsRedPathIgnoredIfRequiredDisabled()
        {
            Requires.Contains(new List<int>(2), 1);
        }

        [TestMethod]
        public void CollectionNotContainsNullRedPathIgnoredIfRequiredDisabled()
        {
            Requires.NotContains((ICollection<int>)null, 1);
        }

        [TestMethod]
        public void CollectionNotContainsRedPathIgnoredIfRequiredDisabled()
        {
            Requires.NotContains(new List<int>() { 1 }, 1);
        }

        [TestMethod]
        public void ContainsKeyNullRedPathIgnoredIfRequiredDisabled()
        {
            Requires.ContainsKey((Dictionary<int, string>) null, 1);
        }

        [TestMethod]
        public void ContainsKeyRedPathIgnoredIfRequiredDisabled()
        {
            Requires.ContainsKey(new Dictionary<int, string>(), 1);
        }

        [TestMethod]
        public void NotContainsKeyNullRedPathIgnoredIfRequiredDisabled()
        {
            Requires.ContainsKey((Dictionary<int, string>)null, 1);
        }

        [TestMethod]
        public void NotContainsKeyRedPathIgnoredIfRequiredDisabled()
        {
            Requires.ContainsKey(new Dictionary<int, string>() { { 1, "foo" } }, 1);
        }

#endif
    }
}
