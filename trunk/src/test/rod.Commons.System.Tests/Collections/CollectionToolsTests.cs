using System;
using System.Collections.Generic;
using MbUnit.Framework;
using rod.Commons.System.Collections;

namespace rod.Commons.System.Tests.Collections
{
	[TestFixture]
	public class CollectionToolsTests
	{
		[SetUp]
		public void SetUp()
		{
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void AddToDictionaryFromCollection_NullInvalidCollection_ThrowsException()
		{
			var dict = new Dictionary<int, ObjectWithKey>();
			var list = new List<ObjectWithKey> { new ObjectWithKey(1, "One"), new ObjectWithKey(2, "Two") };
			CollectionTools.AddToDictionaryFromCollection(dict, list, null, o => o.Key);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException), "nonUnique must be empty")]
		public void AddToDictionaryFromCollection_InvalidCollectionNonEmpty_ThrowsException()
		{
			var dict = new Dictionary<int, ObjectWithKey>();
			var list = new List<ObjectWithKey> {new ObjectWithKey(1, "One"), new ObjectWithKey(2, "Two")};
			var invalid = new List<ObjectWithKey> {new ObjectWithKey(10, "Ten")};
			CollectionTools.AddToDictionaryFromCollection(dict, list, invalid, o => o.Key);
		}

		[Test]
		public void
			AddToDictionaryFromCollection_NewDictionaryAndListWithUniqueKeys_ReturnsEmptyInvalidRecordListAndCorrectDictionary()
		{
			var dict = new Dictionary<int, ObjectWithKey>();
			var list = new List<ObjectWithKey> {new ObjectWithKey(1, "One"), new ObjectWithKey(2, "Two")};
			var invalid = new List<ObjectWithKey>();
			CollectionTools.AddToDictionaryFromCollection(dict, list, invalid, o => o.Key);

			Assert.AreEqual(2, dict.Count);
			Assert.IsEmpty(invalid);
		}

		[Test]
		public void
			AddToDictionaryFromCollection_NewDictionaryAndListWithNonUniqueKeys_ReturnsInvalidRecordListAndCorrectDictionary()
		{
			var dict = new Dictionary<int, ObjectWithKey>();
			var list = new List<ObjectWithKey>
			           	{new ObjectWithKey(1, "One"), new ObjectWithKey(2, "Two"), new ObjectWithKey(2, "Two")};
			var invalid = new List<ObjectWithKey>();
			CollectionTools.AddToDictionaryFromCollection(dict, list, invalid, o => o.Key);

			Assert.AreEqual(1, dict.Count);
			Assert.AreEqual(2, invalid.Count);
		}

		[Test]
		public void
			AddToDictionaryFromCollection_NonEmptyDictionaryAndListWithUniqueKeys_ReturnsEmptyRecordListAndCorrectDictionary()
		{
			var item = new ObjectWithKey(3, "Three");
			var dict = new Dictionary<int, ObjectWithKey> {{item.Key, item}};
			var list = new List<ObjectWithKey> {new ObjectWithKey(1, "One"), new ObjectWithKey(2, "Two")};
			var invalid = new List<ObjectWithKey>();
			CollectionTools.AddToDictionaryFromCollection(dict, list, invalid, o => o.Key);

			Assert.AreEqual(3, dict.Count);
			Assert.IsEmpty(invalid);
		}

		[Test]
		public void
			AddToDictionaryFromCollection_NonEmptyDictionaryAndListWithNonUniqueKeysNotFromSourceDictionary_ReturnsInvalidRecordListAndCorrectDictionary
			()
		{
			var item = new ObjectWithKey(3, "Three");
			var dict = new Dictionary<int, ObjectWithKey> {{item.Key, item}};
			var list = new List<ObjectWithKey>
			           	{new ObjectWithKey(1, "One"), new ObjectWithKey(2, "Two"), new ObjectWithKey(2, "Two")};
			var invalid = new List<ObjectWithKey>();
			CollectionTools.AddToDictionaryFromCollection(dict, list, invalid, o => o.Key);

			Assert.AreEqual(2, dict.Count);
			Assert.AreEqual(2, invalid.Count);
		}

		[Test]
		public void
			AddToDictionaryFromCollection_NonEmptyDictionaryAndListWithNonUniqueKeysFromSourceDictionary_ReturnsInvalidRecordListAndCorrectDictionary
			()
		{
			var item = new ObjectWithKey(3, "Three");
			var dict = new Dictionary<int, ObjectWithKey> {{item.Key, item}};
			var list = new List<ObjectWithKey>
			           	{
			           		new ObjectWithKey(1, "One"),
			           		new ObjectWithKey(2, "Two"),
			           		new ObjectWithKey(2, "Two"),
			           		new ObjectWithKey(3, "Three")
			           	};
			var invalid = new List<ObjectWithKey>();
			CollectionTools.AddToDictionaryFromCollection(dict, list, invalid, o => o.Key);

			Assert.AreEqual(2, dict.Count);
			Assert.AreEqual(3, invalid.Count);
		}

		#region Nested type: ObjectWithKey

		public class ObjectWithKey
		{
			public ObjectWithKey(int key, string value)
			{
				Key = key;
				Value = value;
			}

			public int Key { get; set; }
			public string Value { get; set; }
		}

		#endregion
	}
}