// This file is part of the OWASP O2 Platform (http://www.owasp.org/index.php/OWASP_O2_Platform) and is released under the Apache 2.0 License (http://www.apache.org/licenses/LICENSE-2.0)
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Data;
using O2.Kernel;
using O2.Kernel.Interfaces.O2Core;
using O2.DotNetWrappers.DotNet;
using O2.Views.ASCX.DataViewers;
using O2.Views.ASCX.classes.MainGUI;
using O2.Views.ASCX.classes;


namespace O2.Script
{	
    public class ascx_Running_Processes_Details : UserControl
    {    
    	private static IO2Log log = PublicDI.log;
		private ascx_TableList tableList;				
		
		public static void openAscx()
		{
			WinForms.showAscxInForm(
				typeof(ascx_Running_Processes_Details), 
				"Running Process Details", 
				700, 
				500);		
		}
		
        public ascx_Running_Processes_Details()
    	{
    		createGUI();
    	}    	
    	
    	public void createGUI()
        {
        	var columns = new List<string> { "ProcessName", "Id", "SessionId", "MainModule", "MainWindowTitle", "FileName", "WorkingDirectory", "Arguments"};
        	tableList = this.add_TableList("Processes");
        	tableList.setDataTable(GetRunningProcesses());        	

     	}
    	    	    	    	    
    
   		// this method was based on the code from http://www.dreamincode.net/forums/showtopic67090.htm
   		// (this version has some modifications on the original code, and was copied from reflector)
	    public static DataTable GetRunningProcesses()
		{
		    string wmiClass = "Win32_Process";
		    string condition = "";
		    string[] queryProperties = new string[] { "Name", "ProcessId", "Caption", "ExecutablePath", "CommandLine" };
		    SelectQuery wmiQuery = new SelectQuery(wmiClass, condition, queryProperties);
		    ManagementScope scope = new ManagementScope(@"\\.\root\CIMV2");
		    ManagementObjectCollection runningProcesses = new ManagementObjectSearcher(scope, wmiQuery).Get();
		    DataTable queryResults = new DataTable();
		    queryResults.Columns.Add("Name", Type.GetType("System.String"));
		    queryResults.Columns.Add("ProcessId", Type.GetType("System.Int32"));
		    queryResults.Columns.Add("Caption", Type.GetType("System.String"));
		    queryResults.Columns.Add("Path", Type.GetType("System.String"));
		    queryResults.Columns.Add("CommandLine", Type.GetType("System.String"));
		    foreach (ManagementObject obj in runningProcesses)
		    {
		        DataRow row = queryResults.NewRow();
		        row["Name"] = obj["Name"].ToString();
		        row["ProcessId"] = Convert.ToInt32(obj["ProcessId"]);
		        if (obj["Caption"] != null)
		        {
		            row["Caption"] = obj["Caption"].ToString();
		        }
		        if ((obj["ExecutablePath"] != null) && (obj["CommandLine"] != null))
		        {
		            string rawCommandLine = obj["CommandLine"].ToString();
		            string executablePath = obj["ExecutablePath"].ToString();
		            row["Path"] = executablePath;
		            if (rawCommandLine.StartsWith("\"" + executablePath + "\""))
		            {
		                rawCommandLine = rawCommandLine.Substring(executablePath.Length + 2);
		            }
		            else if (rawCommandLine.StartsWith(executablePath))
		            {
		                rawCommandLine = rawCommandLine.Substring(executablePath.Length);
		            }
		            row["CommandLine"] = rawCommandLine;
		        }
		        queryResults.Rows.Add(row);
		    }
		    return queryResults;
		}
	}


    // Here are the extra classes created (manually) and which wrap the required functionality from System.Management.dll
    // A powerfull next step would be to use an AST to automatically build this code

    public class SelectQuery
    {
        public object obj;
        public SelectQuery(string wmiClass, string condition, string[] queryProperties)
        {
            obj = "SelectQuery".ctor("System.Management", wmiClass, condition, queryProperties);
        }
    }

    public class ManagementScope
    {
        public object obj;

        public ManagementScope(string path)
        {
            obj = "ManagementScope".ctor("System.Management", path);
        }
    }

    public class ManagementObjectSearcher
    {
        public object obj;

        public ManagementObjectSearcher(ManagementScope scope, SelectQuery wmiQuery)
        {
            obj = "ManagementObjectSearcher".ctor("System.Management", scope.obj, wmiQuery.obj);
        }

        public ManagementObjectCollection Get()
        {
            var managementObjectCollection = new ManagementObjectCollection();
            managementObjectCollection.obj = obj.invoke("Get");
            return managementObjectCollection;
        }
    }

    public class ManagementObjectCollection : ICollection, IEnumerable, IDisposable
    {
        public object obj;

        public IEnumerator GetEnumerator()
        {
            var list = new List<ManagementObject>();
            foreach (var item in (ICollection)obj)
            {
                var managementObject = new ManagementObject();
                managementObject.obj = item;
                ((ManagementBaseObject)managementObject).obj = item;
                list.Add(managementObject);
                //PublicDI.log.info("item: {0}", item.GetType());
            }
            return list.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class ManagementObject : ManagementBaseObject, ICloneable
    {
        public object obj;
    }

    public class ManagementBaseObject : Component, ICloneable, ISerializable
    {
        public object obj;

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public object this[string propertyName]
        {
            get
            {
                return obj.invoke("get_Item", propertyName);
            }
        }
    }
}
