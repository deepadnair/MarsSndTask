﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarsSndTask.Config {

    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class MarsResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MarsResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("StandardTask.Config.MarsResources", typeof(MarsResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to C:\Users\kisho\Downloads\TestDatad.xlsx..
        /// </summary>
        internal static string ExcelPath {
            get {
                return ResourceManager.GetString("ExcelPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to true.
        /// </summary>
        internal static string IsLogin {
            get {
                return ResourceManager.GetString("IsLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to C:\Users\kisho\Downloads\IntershipProject-master - Copy\MarsStandardTask-master\MarsSndTask\TestReports\Reports\.
        /// </summary>
        internal static string ReportPath {
            get {
                return ResourceManager.GetString("ReportPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to C:\Users\kisho\Downloads\IntershipProject-master - Copy\MarsStandardTask-master\MarsSndTask\TestReports\Screenshots\.
        /// </summary>
        internal static string ScreenshotPath {
            get {
                return ResourceManager.GetString("ScreenshotPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://localhost:5000/Home.
        /// </summary>
        internal static string Url {
            get {
                return ResourceManager.GetString("Url", resourceCulture);
            }
        }
    }
}
