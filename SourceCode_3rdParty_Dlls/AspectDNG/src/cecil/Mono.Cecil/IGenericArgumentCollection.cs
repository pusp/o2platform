//
// IGenericArgumentCollection.cs
//
// Author:
//   Jb Evain (jbevain@gmail.com)
//
// Generated by /CodeGen/cecil-gen.rb do not edit
// Wed Apr 19 19:59:39 CEST 2006
//
// (C) 2005 Jb Evain
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
//

namespace Mono.Cecil {

	using System;
	using System.Collections;

	public class GenericArgumentEventArgs : EventArgs {

		private TypeReference m_item;

		public TypeReference GenericArgument {
			get { return m_item; }
		}

		public GenericArgumentEventArgs (TypeReference item)
		{
			m_item = item;
		}
	}

	public delegate void GenericArgumentEventHandler (
		object sender, GenericArgumentEventArgs ea);

	public interface IGenericArgumentCollection : IIndexedCollection {

		new TypeReference this [int index] { get; }

		IGenericInstance Container { get; }

		event GenericArgumentEventHandler OnGenericArgumentAdded;
		event GenericArgumentEventHandler OnGenericArgumentRemoved;

		void Add (TypeReference value);
		void Clear ();
		bool Contains (TypeReference value);
		int IndexOf (TypeReference value);
		void Insert (int index, TypeReference value);
		void Remove (TypeReference value);
		void RemoveAt (int index);
	}
}
