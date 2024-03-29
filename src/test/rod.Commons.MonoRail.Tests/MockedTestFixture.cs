//------------------------------------------------------------------------------------------------- 
// <copyright file="MockedTestFixture.cs" company="Daniel Dabrowski - rod.blogsome.com">
// Copyright (c) Daniel Dabrowski - rod.blogsome.com.  All rights reserved.
// </copyright>
// <summary>Defines the MockedTestFixture type.</summary>
//-------------------------------------------------------------------------------------------------
namespace Rod.Commons.MonoRail
{
	using Rhino.Mocks;

	/// <summary>
	/// Base class for test fixtures which uses mocks.
	/// </summary>
	public abstract class MockedTestFixture
	{
		protected MockRepository Mocks { get; set; }

		public virtual void SetUp()
		{
			this.Mocks = new MockRepository();
		}
	}
}