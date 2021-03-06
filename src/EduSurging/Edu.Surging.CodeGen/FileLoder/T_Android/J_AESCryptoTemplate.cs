﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本: 16.0.0.0
//  
//     对此文件的更改可能导致不正确的行为，如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
// ------------------------------------------------------------------------------
namespace FileLoder.T_Android
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_AESCryptoTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class J_AESCryptoTemplate : J_AESCryptoTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\npackage ");
            
            #line 7 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_AESCryptoTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".Base;\r\nimport java.security.SecureRandom;\r\nimport javax.crypto.Cipher;\r\nimport j" +
                    "avax.crypto.KeyGenerator;\r\nimport javax.crypto.SecretKey;\r\nimport javax.crypto.s" +
                    "pec.IvParameterSpec;\r\nimport javax.crypto.spec.SecretKeySpec;\r\n\r\npublic class AE" +
                    "SCrypto {\r\n\tpublic static String encrypt(String seed, String cleartext)\r\n\t\t\tthro" +
                    "ws Exception {\r\n\t\tbyte[] rawKey = getRawKey(seed.getBytes());\r\n\t\tbyte[] result =" +
                    " encrypt(rawKey, cleartext.getBytes());\r\n\t\treturn toHex(result);\r\n\t}\r\n\r\n\tpublic " +
                    "static String decrypt(String seed, String encrypted)\r\n\t\t\tthrows Exception {\r\n\t\tb" +
                    "yte[] rawKey = getRawKey(seed.getBytes());\r\n\t\tbyte[] enc = toByte(encrypted);\r\n\t" +
                    "\tbyte[] result = decrypt(rawKey, enc);\r\n\t\treturn new String(result);\r\n\t}\r\n\r\n\tpri" +
                    "vate static byte[] getRawKey(byte[] seed) throws Exception {\r\n\t\tKeyGenerator kge" +
                    "n = KeyGenerator.getInstance(\"AES\");\r\n\t\tSecureRandom sr = SecureRandom.getInstan" +
                    "ce(\"SHA1PRNG\", \"Crypto\");\r\n\t\tsr.setSeed(seed);\r\n\t\tkgen.init(128, sr); // 192 and" +
                    " 256 bits may not be available\r\n\t\tSecretKey skey = kgen.generateKey();\r\n\t\tbyte[]" +
                    " raw = skey.getEncoded();\r\n\t\treturn raw;\r\n\t}\r\n\r\n\tprivate static byte[] encrypt(b" +
                    "yte[] raw, byte[] clear) throws Exception {\r\n\t\tSecretKeySpec skeySpec = new Secr" +
                    "etKeySpec(raw, \"AES\");\r\n\t\tCipher cipher = Cipher.getInstance(\"AES\");\r\n\t\tcipher.i" +
                    "nit(Cipher.ENCRYPT_MODE, skeySpec, new IvParameterSpec(\r\n\t\t\t\tnew byte[cipher.get" +
                    "BlockSize()]));\r\n\t\tbyte[] encrypted = cipher.doFinal(clear);\r\n\t\treturn encrypted" +
                    ";\r\n\t}\r\n\r\n\tprivate static byte[] decrypt(byte[] raw, byte[] encrypted)\r\n\t\t\tthrows" +
                    " Exception {\r\n\t\tSecretKeySpec skeySpec = new SecretKeySpec(raw, \"AES\");\r\n\t\tCiphe" +
                    "r cipher = Cipher.getInstance(\"AES\");\r\n\t\tcipher.init(Cipher.DECRYPT_MODE, skeySp" +
                    "ec, new IvParameterSpec(\r\n\t\t\t\tnew byte[cipher.getBlockSize()]));\r\n\t\tbyte[] decry" +
                    "pted = cipher.doFinal(encrypted);\r\n\t\treturn decrypted;\r\n\t}\r\n\r\n\tprivate static St" +
                    "ring toHex(String txt) {\r\n\t\treturn toHex(txt.getBytes());\r\n\t}\r\n\r\n\tprivate static" +
                    " String fromHex(String hex) {\r\n\t\treturn new String(toByte(hex));\r\n\t}\r\n\r\n\tprivate" +
                    " static byte[] toByte(String hexString) {\r\n\t\tint len = hexString.length() / 2;\r\n" +
                    "\t\tbyte[] result = new byte[len];\r\n\t\tfor (int i = 0; i < len; i++)\r\n\t\t\tresult[i] " +
                    "= Integer.valueOf(hexString.substring(2 * i, 2 * i + 2),\r\n\t\t\t\t\t16).byteValue();\r" +
                    "\n\t\treturn result;\r\n\t}\r\n\r\n\tprivate static String toHex(byte[] buf) {\r\n\t\tif (buf =" +
                    "= null)\r\n\t\t\treturn \"\";\r\n\t\tStringBuffer result = new StringBuffer(2 * buf.length)" +
                    ";\r\n\t\tfor (int i = 0; i < buf.length; i++) {\r\n\t\t\tappendHex(result, buf[i]);\r\n\t\t}\r" +
                    "\n\t\treturn result.toString();\r\n\t}\r\n\r\n\tprivate final static String HEX = \"01234567" +
                    "89ABCDEF\";\r\n\r\n\tprivate static void appendHex(StringBuffer sb, byte b) {\r\n\t\tsb.ap" +
                    "pend(HEX.charAt((b >> 4) & 0x0f)).append(HEX.charAt(b & 0x0f));\r\n\t}\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class J_AESCryptoTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
