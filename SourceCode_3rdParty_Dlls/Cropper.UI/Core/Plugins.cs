#region License Information

/**********************************************************************************
Shared Source License for Cropper
Copyright 9/07/2004 Brian Scott
http://blogs.geekdojo.net/brian

This license governs use of the accompanying software ('Software'), and your
use of the Software constitutes acceptance of this license.

You may use the Software for any commercial or noncommercial purpose,
including distributing derivative works.

In return, we simply require that you agree:
1. Not to remove any copyright or other notices from the Software. 
2. That if you distribute the Software in source code form you do so only
   under this license (i.e. you must include a complete copy of this license
   with your distribution), and if you distribute the Software solely in
   object form you only do so under a license that complies with this
   license.
3. That the Software comes "as is", with no warranties. None whatsoever.
   This means no express, implied or statutory warranty, including without
   limitation, warranties of merchantability or fitness for a particular
   purpose or any warranty of title or non-infringement. Also, you must pass
   this disclaimer on whenever you distribute the Software or derivative
   works.
4. That no contributor to the Software will be liable for any of those types
   of damages known as indirect, special, consequential, or incidental
   related to the Software or this license, to the maximum extent the law
   permits, no matter what legal theory it�s based on. Also, you must pass
   this limitation of liability on whenever you distribute the Software or
   derivative works.
5. That if you sue anyone over patents that you think may apply to the
   Software for a person's use of the Software, your license to the Software
   ends automatically.
6. That the patent rights, if any, granted in this license only apply to the
   Software, not to any derivative works you make.
7. That the Software is subject to U.S. export jurisdiction at the time it
   is licensed to you, and it may be subject to additional export or import
   laws in other places.  You agree to comply with all such laws and
   regulations that may apply to the Software after delivery of the software
   to you.
8. That if you are an agency of the U.S. Government, (i) Software provided
   pursuant to a solicitation issued on or after December 1, 1995, is
   provided with the commercial license rights set forth in this license,
   and (ii) Software provided pursuant to a solicitation issued prior to
   December 1, 1995, is provided with �Restricted Rights� as set forth in
   FAR, 48 C.F.R. 52.227-14 (June 1987) or DFAR, 48 C.F.R. 252.227-7013
   (Oct 1988), as applicable.
9. That your rights under this License end automatically if you breach it in
   any way.
10.That all rights not expressly granted to you in this license are reserved.

**********************************************************************************/

#endregion

#region Using Directives

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;
using System.Security;
using System.Windows.Forms;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper.Core
{
	/// <summary> 
	/// Summary description for Plugins.
	/// </summary>
	public sealed class Plugins : MarshalByRefObject
	{
		#region Member Variables

		private const string PluginFolder = @"plugins";
		private const string PluginExtensionFilter = "*.dll";
		private const string PluginInterfaceName = "IPersistableImageFormat";

		#endregion

		private Plugins() { }

		public static ImageOutputCollection Load()
		{
			ImageOutputCollection imageOutputCollection = new ImageOutputCollection();

            IPersistableImageFormat imageFormatPlugin = null;

            //DC load from current Dll
            var assembly = Assembly.GetExecutingAssembly();
            foreach (Type testType in assembly.GetTypes())
            {
                //Look for public types and ignore abstract classes
                
                if (testType.IsPublic && testType.Attributes != TypeAttributes.Abstract)
                {
                    //Does the type implement the proper interface
                    //
                    if ((testType.GetInterface(PluginInterfaceName, true)) != null && testType.IsClass && !testType.IsAbstract)
                    {
                        object pluginObject = assembly.CreateInstance(testType.FullName);
                        imageFormatPlugin = (IPersistableImageFormat)pluginObject;
                        imageOutputCollection.Add(imageFormatPlugin);
                    }
                }
            }
            

            /*
			foreach (string path in LoadValidAssemblies())
			{
				try
				{
					Assembly assembly;
					assembly = Assembly.LoadFrom(path);
					IPersistableImageFormat imageFormatPlugin;
					imageFormatPlugin = ExamineAssembly(assembly);
					if (imageFormatPlugin != null)
						imageOutputCollection.Add(imageFormatPlugin);
				}
				catch (FileLoadException e)
				{
					Debug.WriteLine(e.Message);
				}
			}*/
			return imageOutputCollection;
		}

		private static IPersistableImageFormat ExamineAssembly(Assembly assembly)
		{
			IPersistableImageFormat imageFormatPlugin = null;

			try
			{
				//Enumerate through the assembly object
				//
				foreach (Type testType in assembly.GetTypes())
				{
					//Look for public types and ignore abstract classes
					//
					if (testType.IsPublic && testType.Attributes != TypeAttributes.Abstract)
					{
						//Does the type implement the proper interface
						//
						if ((testType.GetInterface(PluginInterfaceName, true)) != null && testType.IsClass && !testType.IsAbstract)
						{
							object pluginObject = assembly.CreateInstance(testType.FullName);
							imageFormatPlugin = (IPersistableImageFormat)pluginObject;
						}
					}
				}
			}
			catch (ReflectionTypeLoadException) { }
			catch (FileLoadException) { }
			return imageFormatPlugin;
		}

		private static string[] ParsePluginDirectory()
		{
			string[] pluginPaths = new string[0];
			string directory = (Path.Combine(Application.StartupPath, PluginFolder));
			if (Directory.Exists(directory))
				pluginPaths = Directory.GetFileSystemEntries(directory, PluginExtensionFilter);

			return pluginPaths;
		}

		private static string[] LoadValidAssemblies()
		{
			// Create a temporary app domain so that we can unload assemblies
			//
			AppDomain domain = AppDomain.CreateDomain("TempDomain" + Guid.NewGuid());
			domain.SetupInformation.ApplicationBase = Environment.CurrentDirectory;

			string[] validAssemblies = new string[] { };

			try
			{
				// Find the name of this assembly and load it into the domain
				//
				AssemblyName objName = Assembly.GetExecutingAssembly().GetName(false);
				domain.Load(objName);

				// Create an instance of this type 
				// in the temporary domain
				//
				BindingFlags binding = BindingFlags.CreateInstance |
															 BindingFlags.NonPublic | BindingFlags.Instance;

				ObjectHandle handle = domain.CreateInstanceFrom(
					objName.CodeBase, typeof(Plugins).ToString(), false,
					binding, null, null, null, null, null);

				Plugins helper = (Plugins)handle.Unwrap();

				validAssemblies = helper.DiscoverPluginAssembliesHelper();
			}
			catch (BadImageFormatException) { }
			catch (FileNotFoundException) { }
			catch (SecurityException) { }
			finally
			{
				// Unload any unwanted assemblies
				//
				AppDomain.Unload(domain);
			}
			return validAssemblies;
		}

		// Should not be made static even though no memebr fields are ever accessed.
		private string[] DiscoverPluginAssembliesHelper()
		{
			ArrayList assemblies = new ArrayList();
			foreach (string pluginPath in ParsePluginDirectory())
			{
				try
				{
					Assembly assembly = Assembly.LoadFile(pluginPath);
					//Enumerate through the assembly object
					//
					foreach (Type type in assembly.GetTypes())
					{
						//Look for public types and ignore abstract classes
						//
						if (type.IsPublic && type.Attributes != TypeAttributes.Abstract)
							if ((type.GetInterface(PluginInterfaceName, false)) != null)
								assemblies.Add(pluginPath);
					}
				}
				catch (ReflectionTypeLoadException) { }
				catch (FileLoadException) { }
			}

			return (string[])assemblies.ToArray(typeof(string));
		}
	}
}
