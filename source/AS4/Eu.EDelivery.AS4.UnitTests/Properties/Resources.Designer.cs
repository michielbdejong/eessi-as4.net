﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eu.EDelivery.AS4.UnitTests.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Eu.EDelivery.AS4.UnitTests.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to &lt;?xml version=&apos;1.0&apos; encoding=&apos;UTF-8&apos;?&gt;
        ///&lt;soapenv:Envelope xmlns:soapenv=&quot;http://www.w3.org/2003/05/soap-envelope&quot; xmlns:xsd=&quot;http://www.w3.org/1999/XMLSchema&quot; xmlns:eb3=&quot;http://docs.oasis-open.org/ebxml-msg/ebms/v3.0/ns/core/200704/&quot; xmlns:xsi=&quot;http://www.w3.org/1999/XMLSchema-instance/&quot;&gt;
        ///  &lt;soapenv:Header&gt;
        ///    &lt;wsse:Security xmlns:wsse=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd&quot; xmlns:wsu=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string as4_encrypted_envelope {
            get {
                return ResourceManager.GetString("as4_encrypted_envelope", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] as4_encrypted_message {
            get {
                object obj = ResourceManager.GetObject("as4_encrypted_message", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;s12:Envelope xmlns:s12=&quot;http://www.w3.org/2003/05/soap-envelope&quot;&gt;&lt;s12:Header&gt;&lt;Security xmlns=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd&quot;&gt;&lt;BinarySecurityToken EncodingType=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary&quot; ValueType=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3&quot; p4:Id=&quot;cert-c4488537-0e5a-4360-b7f0-a14ba48d52e0&quot; xmlns:p4=&quot;http:// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string as4_soap_signed_message {
            get {
                return ResourceManager.GetString("as4_soap_signed_message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;s12:Envelope xmlns:s12=&quot;http://www.w3.org/2003/05/soap-envelope&quot;&gt;&lt;s12:Header&gt;&lt;Security xmlns=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd&quot;&gt;&lt;BinarySecurityToken EncodingType=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary&quot; ValueType=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3&quot; p4:Id=&quot;cert-c4488537-0e5a-4360-b7f0-a14ba48d52e0&quot; xmlns:p4=&quot;http:// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string as4_soap_untrusted_signed_message {
            get {
                return ResourceManager.GetString("as4_soap_untrusted_signed_message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] as4_soap_wrong_encrypted_message {
            get {
                object obj = ResourceManager.GetObject("as4_soap_wrong_encrypted_message", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;s12:Envelope xmlns:s12=&quot;http://www.w3.org/2003/05/soap-envelope&quot;&gt;&lt;s12:Header&gt;&lt;Security xmlns=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd&quot;&gt;&lt;BinarySecurityToken EncodingType=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary&quot; ValueType=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3&quot; p4:Id=&quot;cert-c4488537-0e5a-4360-b7f0-a14ba48d52e0&quot; xmlns:p4=&quot;http:// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string as4_soap_wrong_signed_message {
            get {
                return ResourceManager.GetString("as4_soap_wrong_signed_message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///--=-M9awlqbs/xWAPxlvpSWrAg==
        ///Content-Type: application/soap+xml; charset=utf-8
        ///
        ///&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;s12:Envelope xmlns:s12=&quot;http://www.w3.org/2003/05/soap-envelope&quot;&gt;&lt;s12:Header&gt;&lt;eb:Messaging xmlns:wsu=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd&quot; xmlns:wsse=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd&quot; xmlns:s12=&quot;http://www.w3.org/2003/05/soap-envelope&quot; wsu:Id=&quot;header-fcd4d20d-3842-479a-bcaf-91a8a6d97275&quot; xm [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string as4message {
            get {
                return ResourceManager.GetString("as4message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] certificate_as4 {
            get {
                object obj = ResourceManager.GetObject("certificate_as4", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to secrets.
        /// </summary>
        internal static string certificate_password {
            get {
                return ResourceManager.GetString("certificate_password", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap earth {
            get {
                object obj = ResourceManager.GetObject("earth", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] flower1 {
            get {
                object obj = ResourceManager.GetObject("flower1", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] flower2 {
            get {
                object obj = ResourceManager.GetObject("flower2", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to --MIMEBoundary_7afbb12a12dd535c2c59cc1fab5b4aadf7a2013d35e98980\r\nContent-Type: application/soap+xml; charset=UTF-8\r\nContent-Transfer-Encoding: binary\r\nContent-ID: &lt;0.6afbb12a12dd535c2c59cc1fab5b4aadf7a2013d35e98980@apache.org&gt;\r\n\r\n&lt;?xml version=&apos;1.0&apos; encoding=&apos;UTF-8&apos;?&gt;&lt;soapenv:Envelope xmlns:soapenv=\&quot;http://www.w3.org/2003/05/soap-envelope\&quot; xmlns:xsd=\&quot;http://www.w3.org/1999/XMLSchema\&quot; xmlns:eb3=\&quot;http://docs.oasis-open.org/ebxml-msg/ebms/v3.0/ns/core/200704/\&quot; xmlns:xsi=\&quot;http://www.w3.org/1999 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string holodeck_as4message {
            get {
                return ResourceManager.GetString("holodeck_as4message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] holodeck_partya_certificate {
            get {
                object obj = ResourceManager.GetObject("holodeck_partya_certificate", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] holodeck_partyc_certificate {
            get {
                object obj = ResourceManager.GetObject("holodeck_partyc_certificate", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;s12:Envelope xmlns:s12=&quot;http://www.w3.org/2003/05/soap-envelope&quot;&gt;
        ///  &lt;s12:Header&gt;
        ///    &lt;eb:Messaging xmlns:wsu=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd&quot; xmlns:wsse=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd&quot; xmlns:s12=&quot;http://www.w3.org/2003/05/soap-envelope&quot; xmlns:eb=&quot;http://docs.oasis-open.org/ebxml-msg/ebms/v3.0/ns/core/200704/&quot;&gt;
        ///      &lt;eb:SignalMessage&gt;
        ///        &lt;eb:MessageInfo&gt;
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string receipt_message {
            get {
                return ResourceManager.GetString("receipt_message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot;?&gt;
        ///&lt;PMode xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns=&quot;eu:edelivery:as4:pmode&quot;&gt;
        ///  &lt;Id&gt;01-receive-pmode&lt;/Id&gt;
        ///  &lt;Mep&gt;OneWay&lt;/Mep&gt;
        ///  &lt;MepBinding&gt;Pull&lt;/MepBinding&gt;
        ///  &lt;Reliability&gt;
        ///    &lt;DuplicateElimination&gt;
        ///      &lt;IsEnabled&gt;false&lt;/IsEnabled&gt;
        ///    &lt;/DuplicateElimination&gt;
        ///  &lt;/Reliability&gt;
        ///  &lt;ReceiptHandling&gt;
        ///    &lt;UseNNRFormat&gt;true&lt;/UseNNRFormat&gt;
        ///    &lt;ReplyPattern&gt;Response&lt;/ReplyPattern&gt;
        ///  &lt;/ReceiptHandling&gt;
        ///  &lt;ErrorHandli [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string receive_01 {
            get {
                return ResourceManager.GetString("receive_01", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;PMode xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns=&quot;eu:edelivery:as4:pmode&quot;&gt;
        ///  &lt;Id&gt;01-pmode&lt;/Id&gt;
        ///  &lt;AllowOverride&gt;false&lt;/AllowOverride&gt;
        ///  &lt;Mep&gt;OneWay&lt;/Mep&gt;
        ///  &lt;MepBinding&gt;Push&lt;/MepBinding&gt;
        ///  &lt;PushConfiguration&gt;
        ///    &lt;Protocol&gt;
        ///      &lt;Url&gt;http://localhost:9090/msh&lt;/Url&gt;
        ///      &lt;UseChunking&gt;false&lt;/UseChunking&gt;
        ///      &lt;UseHttpCompression&gt;false&lt;/UseHttpCompression&gt;
        ///    &lt;/Protocol&gt;
        ///    &lt;TlsConfiguration&gt;
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string send_01 {
            get {
                return ResourceManager.GetString("send_01", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;PMode xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns=&quot;eu:edelivery:as4:pmode&quot;&gt;
        ///  &lt;Id&gt;01-sample-pmode&lt;/Id&gt;
        ///  &lt;AllowOverride&gt;false&lt;/AllowOverride&gt;
        ///  &lt;Mep&gt;OneWay&lt;/Mep&gt;
        ///  &lt;MepBinding&gt;Push&lt;/MepBinding&gt;
        ///  &lt;PushConfiguration&gt;
        ///    &lt;Protocol&gt;
        ///      &lt;Url&gt;http://localhost:9090/msh&lt;/Url&gt;
        ///      &lt;UseChunking&gt;false&lt;/UseChunking&gt;
        ///      &lt;UseHttpCompression&gt;false&lt;/UseHttpCompression&gt;
        ///    &lt;/Protocol&gt;
        ///    &lt;TlsConfigura [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string sendingprocessingmode {
            get {
                return ResourceManager.GetString("sendingprocessingmode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot;?&gt;
        ///&lt;SubmitMessage xmlns=&quot;urn:cef:edelivery:eu:as4:messages&quot;&gt;
        ///  &lt;Collaboration&gt;
        ///    &lt;AgreementRef&gt;
        ///      &lt;PModeId&gt;sample-pmode&lt;/PModeId&gt;
        ///    &lt;/AgreementRef&gt;
        ///  &lt;/Collaboration&gt;
        ///
        ///  &lt;Payloads&gt;
        ///    &lt;Payload&gt;
        ///      &lt;Id&gt;earth&lt;/Id&gt;
        ///      &lt;MimeType&gt;image/jpeg&lt;/MimeType&gt;
        ///      &lt;Location&gt;file:///messages\attachments\earth.jpg&lt;/Location&gt;
        ///      &lt;PayloadProperties/&gt;
        ///    &lt;/Payload&gt;
        ///    &lt;Payload&gt;
        ///      &lt;Id&gt;xml-sample&lt;/Id&gt;
        ///      &lt;MimeType&gt;application/xml&lt;/MimeType&gt;
        ///      &lt;Location&gt;file:/ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string submitmessage {
            get {
                return ResourceManager.GetString("submitmessage", resourceCulture);
            }
        }
    }
}
