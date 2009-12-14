// This file is part of the OWASP O2 Platform (http://www.owasp.org/index.php/OWASP_O2_Platform) and is released under the Apache 2.0 License (http://www.apache.org/licenses/LICENSE-2.0)
using System;
using O2.External.WinFormsUI.Forms;
using O2.External.WinFormsUI.O2Environment;
using O2.ImportExport.OunceLabs.Ozasmt_OunceV6;
using O2.Kernel.Interfaces.Views;
using O2.Scanner.MsCatNet.Ascx;
using O2.Views.ASCX.O2Findings;
using O2.External.SharpDevelop;

namespace O2.Scanner.MsCatNet
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            HandleO2MessageOnSD.setO2MessageFileEventListener();
            ascx_FindingsViewer.o2AssessmentLoadEngines.Add(new O2AssessmentLoad_OunceV6());
            ascx_FindingsViewer.o2AssessmentSave = new O2AssessmentSave_OunceV6();

            if (O2AscxGUI.launch("O2 Scanner - MsCatNet"))
            {
                O2AscxGUI.openAscx(typeof (ascx_MsCatNet), O2DockState.Document, "O2 Scanner - MsCatNet");
                //O2AscxGUI.openAscx(typeof(ascx_FindingsViewer), O2DockState.DockBottomAutoHide, "O2 Findings Viewer");
            }
        }
    }
}
