//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eu.EDelivery.AS4.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Eu.EDelivery.AS4.Properties.Resources", typeof(Resources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to config.
        /// </summary>
        public static string configurationfolder {
            get {
                return ResourceManager.GetString("configurationfolder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to external.
        /// </summary>
        public static string externalfolder {
            get {
                return ResourceManager.GetString("externalfolder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to receive-pmodes.
        /// </summary>
        public static string receivepmodefolder {
            get {
                return ResourceManager.GetString("receivepmodefolder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to send-pmodes.
        /// </summary>
        public static string sendpmodefolder {
            get {
                return ResourceManager.GetString("sendpmodefolder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to settings.xml.
        /// </summary>
        public static string settingsfilename {
            get {
                return ResourceManager.GetString("settingsfilename", resourceCulture);
            }
        }
    }
}
