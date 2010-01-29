// This file is part of the OWASP O2 Platform (http://www.owasp.org/index.php/OWASP_O2_Platform) and is released under the Apache 2.0 License (http://www.apache.org/licenses/LICENSE-2.0)
using System;
using System.IO;
using System.Windows.Forms;
using O2.Kernel;
using O2.DotNetWrappers.Windows;
using O2.DotNetWrappers.Network;
using O2.Views.ASCX.classes.MainGUI;
using O2.External.SharpDevelop.Ascx;

namespace O2.Script
{
    public class Main
    {    
        public static void openAscx()
		{
			var sourceCodeAST = (ascx_View_SourceCode_AST)WinForms.showAscxInForm(
				typeof(ascx_View_SourceCode_AST), 
				"View SourceCode AST", 
				700, 
				500);		
							
			sourceCodeAST.loadFile(testFileToUse());		
		}
		
		private static string testFileToUse()
		{
		    //var testFile = @"http://o2platform.googlecode.com/svn/trunk/O2 - All Active Projects/O2_XRules_Database/_Rules/_Samples/HelloWorld.cs";
		    const string testFile = @"http://o2platform.googlecode.com/svn/trunk/O2%20-%20All%20Active%20Projects/O2_XRules_Database/_Rules/_Samples/Windows Controls (ascx)/ascx_View_SourceCode_AST.cs";
            return Web.checkIfFileExistsAndDownloadIfNot(Path.GetFileName(testFile), testFile);
		}
    }
	
	public class ascx_View_SourceCode_AST : UserControl
	{
		public ascx_SourceCodeEditor sourceCodeEditor;
        public TabControl tabControl;
        public TreeView ast_TreeView;
        public TreeView usingDeclarations_TreeView;
        public TreeView types_TreeView;
        public TreeView methods_TreeView;
        public TreeView fields_TreeView;
        public TreeView properties_TreeView;
        public TreeView comments_TreeView;
        public ascx_SourceCodeEditor rewritenCSharpCode_SourceCodeEditor;
        public ascx_SourceCodeEditor rewritenVBNet_SourceCodeEditor;
		
		public ascx_View_SourceCode_AST()
		{
			createGUI();					
		}			
		
		public void createGUI()
		{
			var splitControl = this.add_SplitContainer(
        						true, 		//setOrientationToHorizontal
        						true,		// setDockStyleoFill
        						true);		// setBorderStyleTo3D)
        	var topGroupBox = splitControl.Panel1.add_GroupBox("SourceCode");        	        	
        	
            //var bottomGroupBox = splitControl.Panel2.add_GroupBox("Ast");
            
        	sourceCodeEditor = topGroupBox.add_SourceCodeEditor();
        	
        	tabControl = splitControl.Panel2.add_TabControl();
        	        	
        	ast_TreeView = tabControl.add_Tab("AST").add_TreeView();
        	usingDeclarations_TreeView = tabControl.add_Tab("Using Declarations").add_TreeView();
        	types_TreeView = tabControl.add_Tab("Types").add_TreeView();       	
        	methods_TreeView = tabControl.add_Tab("Methods").add_TreeView();
        	fields_TreeView = tabControl.add_Tab("Fields").add_TreeView();
        	properties_TreeView = tabControl.add_Tab("Properties").add_TreeView();
        	comments_TreeView = tabControl.add_Tab("Comments").add_TreeView();
        	rewritenCSharpCode_SourceCodeEditor = tabControl.add_Tab("Re-writen Code : CSharp").add_SourceCodeEditor();        	
        	rewritenVBNet_SourceCodeEditor = tabControl.add_Tab("Re-writen Code : VB.Net").add_SourceCodeEditor();
        	
        	sourceCodeEditor.eDocumentDataChanged += updateView;    
        	
        	usingDeclarations_TreeView.AfterSelect += showInSourceCode;
        	types_TreeView.AfterSelect += showInSourceCode;
        	methods_TreeView.AfterSelect += showInSourceCode;
        	fields_TreeView.AfterSelect += showInSourceCode;
        	properties_TreeView.AfterSelect += showInSourceCode;
        	comments_TreeView.AfterSelect += showInSourceCode;
 		}
							
		public void loadFile(string fileToLoad)
		{				
			PublicDI.log.info("Loading file into SourceCode Editor: {0}", fileToLoad);
			sourceCodeEditor.loadSourceCodeFile(fileToLoad);
		}
				
		
		public void updateView(string sourceCode)
		{	
			var ast = new Ast_CSharp(sourceCode);
			ast_TreeView.show_Ast(ast);
			types_TreeView.show_List(ast.astDetails.Types, "Text");
			usingDeclarations_TreeView.show_List(ast.astDetails.UsingDeclarations,"Text");
			methods_TreeView.show_List(ast.astDetails.Methods,"Text");
			fields_TreeView.show_List(ast.astDetails.Fields,"Text");
			properties_TreeView.show_List(ast.astDetails.Properties,"Text");
			comments_TreeView.show_List(ast.astDetails.Comments,"Text");
			
			rewritenCSharpCode_SourceCodeEditor.setDocumentContents(ast.astDetails.CSharpCode, ".cs");
			rewritenVBNet_SourceCodeEditor.setDocumentContents(ast.astDetails.VBNetCode, ".vb");								
		}




        //NOTE: these two methods need to be moved to the ascx_SourceCodeEditor control
        public void showInSourceCode(Object sender, TreeViewEventArgs e)
        {
            var treeNoteTag = e.Node.Tag;
            if (treeNoteTag is AstValue)
            {
                var astValue = (AstValue)treeNoteTag;
                PublicDI.log.error("{0} {1} - {2}", astValue.Text, astValue.StartLocation, astValue.EndLocation);

                var textEditorControl = sourceCodeEditor.getObject_TextEditorControl();
                var start = new ICSharpCode.TextEditor.TextLocation(astValue.StartLocation.X - 1, astValue.StartLocation.Y - 1);
                var end = new ICSharpCode.TextEditor.TextLocation(astValue.EndLocation.X - 1, astValue.EndLocation.Y - 1);
                var selection = new ICSharpCode.TextEditor.Document.DefaultSelection(textEditorControl.Document, start, end);
                textEditorControl.ActiveTextAreaControl.SelectionManager.SetSelection(selection);
                setCaretToCurrentSelection(textEditorControl);
            }
        }

        public void setCaretToCurrentSelection(ICSharpCode.TextEditor.TextEditorControl textEditorControl)
        {
            var finalCaretPosition = textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.SelectionCollection[0].StartPosition;
            var tempCaretPosition = new ICSharpCode.TextEditor.TextLocation
                                        {
                                            X = finalCaretPosition.X,
                                            Y = finalCaretPosition.Y + 10
                                        };
            textEditorControl.ActiveTextAreaControl.Caret.Position = tempCaretPosition;
            textEditorControl.ActiveTextAreaControl.TextArea.ScrollToCaret();
            textEditorControl.ActiveTextAreaControl.Caret.Position = finalCaretPosition;
            textEditorControl.ActiveTextAreaControl.TextArea.ScrollToCaret();
        }
	}
}