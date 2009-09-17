// ***********************************************************************
// Copyright (c) 2007 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
//using NUnit.Framework.Syntax;

namespace NUnit.Framework.Tests
{
	[TestFixture()]
	public class TypeAssertTests : MessageChecker
	{
		[Test]
		public void ExactType()
		{
			Expect( "Hello", TypeOf( typeof(System.String) ) );
		}

		[Test,ExpectedException(typeof(AssertionException))]
		public void ExactTypeFails()
		{
			expectedMessage =
				"  Expected: <System.Int32>" + Environment.NewLine +
				"  But was:  <System.String>" + Environment.NewLine;
			Expect( "Hello", TypeOf( typeof(System.Int32) ) );
		}

		[Test]
		public void IsInstanceOf()
		{
            ApplicationException ex = new ApplicationException();

			Assert.IsInstanceOf(typeof(System.Exception), ex );
            Expect( ex, InstanceOf(typeof(Exception)));
#if CLR_2_0
            Assert.IsInstanceOf<Exception>( ex );
#endif
		}

		[Test,ExpectedException(typeof(AssertionException))]
		public void IsInstanceOfFails()
		{
			expectedMessage =
				"  Expected: instance of <System.Int32>" + System.Environment.NewLine + 
				"  But was:  <System.String>" + System.Environment.NewLine;
			Expect( "abc123", InstanceOf( typeof(System.Int32) ) );
		}

		[Test]
		public void IsNotInstanceOf()
		{
			Assert.IsNotInstanceOf(typeof(System.Int32), "abc123" );
			Expect( "abc123", Not.InstanceOf(typeof(System.Int32)) );
#if CLR_2_0
			Assert.IsNotInstanceOf<System.Int32>("abc123");
#endif
		}

		[Test,ExpectedException(typeof(AssertionException))]
		public void IsNotInstanceOfFails()
		{
			expectedMessage =
				"  Expected: not instance of <System.Exception>" + System.Environment.NewLine + 
				"  But was:  <System.ApplicationException>" + System.Environment.NewLine;
			Assert.IsNotInstanceOf( typeof(System.Exception), new ApplicationException() );
		}

        [Test()]
        public void IsAssignableFrom()
        {
            int[] array10 = new int[10];

            Assert.IsAssignableFrom(typeof(int[]), array10);
            Expect(array10, AssignableFrom(typeof(int[])));
#if CLR_2_0
            Assert.IsAssignableFrom<int[]>(array10);
#endif
        }

        [Test, ExpectedException(typeof(AssertionException))]
		public void IsAssignableFromFails()
		{
			int [] array10 = new int [10];
			int [,] array2 = new int[2,2];

			expectedMessage =
				"  Expected: assignable from <System.Int32[,]>" + System.Environment.NewLine + 
				"  But was:  <System.Int32[]>" + System.Environment.NewLine;
			Expect( array10, AssignableFrom( array2.GetType() ) );
		}

		[Test()]
		public void IsNotAssignableFrom()
		{
			int [] array10 = new int [10];

			Assert.IsNotAssignableFrom( typeof(int[,] ),array10);
			Expect( array10, Not.AssignableFrom( typeof(int[,] ) ) );
#if CLR_2_0
			Assert.IsNotAssignableFrom<int[,]>(array10);
#endif
		}

		[Test,ExpectedException(typeof(AssertionException))]
		public void IsNotAssignableFromFails()
		{
			int [] array10 = new int [10];
			int [] array2 = new int[2];

			expectedMessage =
				"  Expected: not assignable from <System.Int32[]>" + System.Environment.NewLine + 
				"  But was:  <System.Int32[]>" + System.Environment.NewLine;
			Expect( array10, Not.AssignableFrom( array2.GetType() ) );
		}
	}
}
