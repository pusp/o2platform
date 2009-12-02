//
// ITypeDefinitionCollection.cs
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

	public class TypeDefinitionEventArgs : EventArgs {

		private TypeDefinition m_item;

		public TypeDefinition TypeDefinition {
			get { return m_item; }
		}

		public TypeDefinitionEventArgs (TypeDefinition item)
		{
			m_item = item;
		}
	}

	public delegate void TypeDefinitionEventHandler (
		object sender, TypeDefinitionEventArgs ea);

	public interface ITypeDefinitionCollection : IIndexedCollection, IReflectionVisitable {

		new TypeDefinition this [int index] { get; }
		TypeDefinition this [string fullName] { get; }

		ModuleDefinition Container { get; }

		event TypeDefinitionEventHandler OnTypeDefinitionAdded;
		event TypeDefinitionEventHandler OnTypeDefinitionRemoved;

		void Add (TypeDefinition value);
		void Clear ();
		bool Contains (TypeDefinition value);
		bool Contains (string fullName);
		int IndexOf (TypeDefinition value);
		void Remove (TypeDefinition value);
		void RemoveAt (int index);
	}
}
