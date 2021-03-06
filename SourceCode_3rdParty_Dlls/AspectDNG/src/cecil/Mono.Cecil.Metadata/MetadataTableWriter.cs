//
// MetadataTableWriter.cs
//
// Author:
//   Jb Evain (jbevain@gmail.com)
//
// Generated by /CodeGen/cecil-gen.rb do not edit
// Thu May 18 17:36:48 CEST 2006
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

namespace Mono.Cecil.Metadata {

	using System;
	using System.Collections;

	using Mono.Cecil.Binary;

	internal sealed class MetadataTableWriter : BaseMetadataTableVisitor {

		MetadataRoot m_root;
		TablesHeap m_heap;
		MetadataRowWriter m_mrrw;
		MemoryBinaryWriter m_binaryWriter;

		public MetadataTableWriter (MetadataWriter mrv, MemoryBinaryWriter writer)
		{
			m_root = mrv.GetMetadataRoot ();
			m_heap = m_root.Streams.TablesHeap;
			m_binaryWriter = writer;
			m_mrrw = new MetadataRowWriter (this);
		}

		public MetadataRoot GetMetadataRoot ()
		{
			return m_root;
		}

		public override IMetadataRowVisitor GetRowVisitor ()
		{
			return m_mrrw;
		}

		public MemoryBinaryWriter GetWriter ()
		{
			return m_binaryWriter;
		}

		public AssemblyTable GetAssemblyTable ()
		{
			int rid = AssemblyTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as AssemblyTable;

			AssemblyTable table = new AssemblyTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public AssemblyOSTable GetAssemblyOSTable ()
		{
			int rid = AssemblyOSTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as AssemblyOSTable;

			AssemblyOSTable table = new AssemblyOSTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public AssemblyProcessorTable GetAssemblyProcessorTable ()
		{
			int rid = AssemblyProcessorTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as AssemblyProcessorTable;

			AssemblyProcessorTable table = new AssemblyProcessorTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public AssemblyRefTable GetAssemblyRefTable ()
		{
			int rid = AssemblyRefTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as AssemblyRefTable;

			AssemblyRefTable table = new AssemblyRefTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public AssemblyRefOSTable GetAssemblyRefOSTable ()
		{
			int rid = AssemblyRefOSTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as AssemblyRefOSTable;

			AssemblyRefOSTable table = new AssemblyRefOSTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public AssemblyRefProcessorTable GetAssemblyRefProcessorTable ()
		{
			int rid = AssemblyRefProcessorTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as AssemblyRefProcessorTable;

			AssemblyRefProcessorTable table = new AssemblyRefProcessorTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public ClassLayoutTable GetClassLayoutTable ()
		{
			int rid = ClassLayoutTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as ClassLayoutTable;

			ClassLayoutTable table = new ClassLayoutTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public ConstantTable GetConstantTable ()
		{
			int rid = ConstantTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as ConstantTable;

			ConstantTable table = new ConstantTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public CustomAttributeTable GetCustomAttributeTable ()
		{
			int rid = CustomAttributeTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as CustomAttributeTable;

			CustomAttributeTable table = new CustomAttributeTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public DeclSecurityTable GetDeclSecurityTable ()
		{
			int rid = DeclSecurityTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as DeclSecurityTable;

			DeclSecurityTable table = new DeclSecurityTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public EventTable GetEventTable ()
		{
			int rid = EventTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as EventTable;

			EventTable table = new EventTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public EventMapTable GetEventMapTable ()
		{
			int rid = EventMapTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as EventMapTable;

			EventMapTable table = new EventMapTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public ExportedTypeTable GetExportedTypeTable ()
		{
			int rid = ExportedTypeTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as ExportedTypeTable;

			ExportedTypeTable table = new ExportedTypeTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public FieldTable GetFieldTable ()
		{
			int rid = FieldTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as FieldTable;

			FieldTable table = new FieldTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public FieldLayoutTable GetFieldLayoutTable ()
		{
			int rid = FieldLayoutTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as FieldLayoutTable;

			FieldLayoutTable table = new FieldLayoutTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public FieldMarshalTable GetFieldMarshalTable ()
		{
			int rid = FieldMarshalTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as FieldMarshalTable;

			FieldMarshalTable table = new FieldMarshalTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public FieldRVATable GetFieldRVATable ()
		{
			int rid = FieldRVATable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as FieldRVATable;

			FieldRVATable table = new FieldRVATable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public FileTable GetFileTable ()
		{
			int rid = FileTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as FileTable;

			FileTable table = new FileTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public GenericParamTable GetGenericParamTable ()
		{
			int rid = GenericParamTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as GenericParamTable;

			GenericParamTable table = new GenericParamTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public GenericParamConstraintTable GetGenericParamConstraintTable ()
		{
			int rid = GenericParamConstraintTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as GenericParamConstraintTable;

			GenericParamConstraintTable table = new GenericParamConstraintTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public ImplMapTable GetImplMapTable ()
		{
			int rid = ImplMapTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as ImplMapTable;

			ImplMapTable table = new ImplMapTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public InterfaceImplTable GetInterfaceImplTable ()
		{
			int rid = InterfaceImplTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as InterfaceImplTable;

			InterfaceImplTable table = new InterfaceImplTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public ManifestResourceTable GetManifestResourceTable ()
		{
			int rid = ManifestResourceTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as ManifestResourceTable;

			ManifestResourceTable table = new ManifestResourceTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public MemberRefTable GetMemberRefTable ()
		{
			int rid = MemberRefTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as MemberRefTable;

			MemberRefTable table = new MemberRefTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public MethodTable GetMethodTable ()
		{
			int rid = MethodTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as MethodTable;

			MethodTable table = new MethodTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public MethodImplTable GetMethodImplTable ()
		{
			int rid = MethodImplTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as MethodImplTable;

			MethodImplTable table = new MethodImplTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public MethodSemanticsTable GetMethodSemanticsTable ()
		{
			int rid = MethodSemanticsTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as MethodSemanticsTable;

			MethodSemanticsTable table = new MethodSemanticsTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public MethodSpecTable GetMethodSpecTable ()
		{
			int rid = MethodSpecTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as MethodSpecTable;

			MethodSpecTable table = new MethodSpecTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public ModuleTable GetModuleTable ()
		{
			int rid = ModuleTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as ModuleTable;

			ModuleTable table = new ModuleTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public ModuleRefTable GetModuleRefTable ()
		{
			int rid = ModuleRefTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as ModuleRefTable;

			ModuleRefTable table = new ModuleRefTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public NestedClassTable GetNestedClassTable ()
		{
			int rid = NestedClassTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as NestedClassTable;

			NestedClassTable table = new NestedClassTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public ParamTable GetParamTable ()
		{
			int rid = ParamTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as ParamTable;

			ParamTable table = new ParamTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public PropertyTable GetPropertyTable ()
		{
			int rid = PropertyTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as PropertyTable;

			PropertyTable table = new PropertyTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public PropertyMapTable GetPropertyMapTable ()
		{
			int rid = PropertyMapTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as PropertyMapTable;

			PropertyMapTable table = new PropertyMapTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public StandAloneSigTable GetStandAloneSigTable ()
		{
			int rid = StandAloneSigTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as StandAloneSigTable;

			StandAloneSigTable table = new StandAloneSigTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public TypeDefTable GetTypeDefTable ()
		{
			int rid = TypeDefTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as TypeDefTable;

			TypeDefTable table = new TypeDefTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public TypeRefTable GetTypeRefTable ()
		{
			int rid = TypeRefTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as TypeRefTable;

			TypeRefTable table = new TypeRefTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public TypeSpecTable GetTypeSpecTable ()
		{
			int rid = TypeSpecTable.RId;
			if (m_heap.HasTable (rid))
				return m_heap [rid] as TypeSpecTable;

			TypeSpecTable table = new TypeSpecTable ();
			table.Rows = new RowCollection ();
			m_heap.Valid |= 1L << rid;
			m_heap.Tables.Add (table);
			return table;
		}

		public override void VisitTableCollection (TableCollection coll)
		{
			if (m_heap.HasTable (ModuleTable.RId))
				m_binaryWriter.Write (m_heap [ModuleTable.RId].Rows.Count);
			if (m_heap.HasTable (TypeRefTable.RId))
				m_binaryWriter.Write (m_heap [TypeRefTable.RId].Rows.Count);
			if (m_heap.HasTable (TypeDefTable.RId))
				m_binaryWriter.Write (m_heap [TypeDefTable.RId].Rows.Count);
			if (m_heap.HasTable (FieldTable.RId))
				m_binaryWriter.Write (m_heap [FieldTable.RId].Rows.Count);
			if (m_heap.HasTable (MethodTable.RId))
				m_binaryWriter.Write (m_heap [MethodTable.RId].Rows.Count);
			if (m_heap.HasTable (ParamTable.RId))
				m_binaryWriter.Write (m_heap [ParamTable.RId].Rows.Count);
			if (m_heap.HasTable (InterfaceImplTable.RId))
				m_binaryWriter.Write (m_heap [InterfaceImplTable.RId].Rows.Count);
			if (m_heap.HasTable (MemberRefTable.RId))
				m_binaryWriter.Write (m_heap [MemberRefTable.RId].Rows.Count);
			if (m_heap.HasTable (ConstantTable.RId))
				m_binaryWriter.Write (m_heap [ConstantTable.RId].Rows.Count);
			if (m_heap.HasTable (CustomAttributeTable.RId))
				m_binaryWriter.Write (m_heap [CustomAttributeTable.RId].Rows.Count);
			if (m_heap.HasTable (FieldMarshalTable.RId))
				m_binaryWriter.Write (m_heap [FieldMarshalTable.RId].Rows.Count);
			if (m_heap.HasTable (DeclSecurityTable.RId))
				m_binaryWriter.Write (m_heap [DeclSecurityTable.RId].Rows.Count);
			if (m_heap.HasTable (ClassLayoutTable.RId))
				m_binaryWriter.Write (m_heap [ClassLayoutTable.RId].Rows.Count);
			if (m_heap.HasTable (FieldLayoutTable.RId))
				m_binaryWriter.Write (m_heap [FieldLayoutTable.RId].Rows.Count);
			if (m_heap.HasTable (StandAloneSigTable.RId))
				m_binaryWriter.Write (m_heap [StandAloneSigTable.RId].Rows.Count);
			if (m_heap.HasTable (EventMapTable.RId))
				m_binaryWriter.Write (m_heap [EventMapTable.RId].Rows.Count);
			if (m_heap.HasTable (EventTable.RId))
				m_binaryWriter.Write (m_heap [EventTable.RId].Rows.Count);
			if (m_heap.HasTable (PropertyMapTable.RId))
				m_binaryWriter.Write (m_heap [PropertyMapTable.RId].Rows.Count);
			if (m_heap.HasTable (PropertyTable.RId))
				m_binaryWriter.Write (m_heap [PropertyTable.RId].Rows.Count);
			if (m_heap.HasTable (MethodSemanticsTable.RId))
				m_binaryWriter.Write (m_heap [MethodSemanticsTable.RId].Rows.Count);
			if (m_heap.HasTable (MethodImplTable.RId))
				m_binaryWriter.Write (m_heap [MethodImplTable.RId].Rows.Count);
			if (m_heap.HasTable (ModuleRefTable.RId))
				m_binaryWriter.Write (m_heap [ModuleRefTable.RId].Rows.Count);
			if (m_heap.HasTable (TypeSpecTable.RId))
				m_binaryWriter.Write (m_heap [TypeSpecTable.RId].Rows.Count);
			if (m_heap.HasTable (ImplMapTable.RId))
				m_binaryWriter.Write (m_heap [ImplMapTable.RId].Rows.Count);
			if (m_heap.HasTable (FieldRVATable.RId))
				m_binaryWriter.Write (m_heap [FieldRVATable.RId].Rows.Count);
			if (m_heap.HasTable (AssemblyTable.RId))
				m_binaryWriter.Write (m_heap [AssemblyTable.RId].Rows.Count);
			if (m_heap.HasTable (AssemblyProcessorTable.RId))
				m_binaryWriter.Write (m_heap [AssemblyProcessorTable.RId].Rows.Count);
			if (m_heap.HasTable (AssemblyOSTable.RId))
				m_binaryWriter.Write (m_heap [AssemblyOSTable.RId].Rows.Count);
			if (m_heap.HasTable (AssemblyRefTable.RId))
				m_binaryWriter.Write (m_heap [AssemblyRefTable.RId].Rows.Count);
			if (m_heap.HasTable (AssemblyRefProcessorTable.RId))
				m_binaryWriter.Write (m_heap [AssemblyRefProcessorTable.RId].Rows.Count);
			if (m_heap.HasTable (AssemblyRefOSTable.RId))
				m_binaryWriter.Write (m_heap [AssemblyRefOSTable.RId].Rows.Count);
			if (m_heap.HasTable (FileTable.RId))
				m_binaryWriter.Write (m_heap [FileTable.RId].Rows.Count);
			if (m_heap.HasTable (ExportedTypeTable.RId))
				m_binaryWriter.Write (m_heap [ExportedTypeTable.RId].Rows.Count);
			if (m_heap.HasTable (ManifestResourceTable.RId))
				m_binaryWriter.Write (m_heap [ManifestResourceTable.RId].Rows.Count);
			if (m_heap.HasTable (NestedClassTable.RId))
				m_binaryWriter.Write (m_heap [NestedClassTable.RId].Rows.Count);
			if (m_heap.HasTable (GenericParamTable.RId))
				m_binaryWriter.Write (m_heap [GenericParamTable.RId].Rows.Count);
			if (m_heap.HasTable (MethodSpecTable.RId))
				m_binaryWriter.Write (m_heap [MethodSpecTable.RId].Rows.Count);
			if (m_heap.HasTable (GenericParamConstraintTable.RId))
				m_binaryWriter.Write (m_heap [GenericParamConstraintTable.RId].Rows.Count);
		}
	}
}
