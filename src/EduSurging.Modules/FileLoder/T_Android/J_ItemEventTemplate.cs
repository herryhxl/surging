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
    
    #line 1 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class J_ItemEventTemplate : J_ItemEventTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\npackage ");
            
            #line 7 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".Event;\r\nimport android.view.View;\r\nimport android.widget.Button;\r\nimport android" +
                    ".widget.Toast;\r\nimport ");
            
            #line 11 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".ViewModel.*;\r\nimport ");
            
            #line 12 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".Service.*;\r\nimport ");
            
            #line 13 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".Data.*;\r\nimport ");
            
            #line 14 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".Event.*;\r\nimport ");
            
            #line 15 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".Common.LoadUtil;\r\nimport ");
            
            #line 16 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".Model.");
            
            #line 16 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code));
            
            #line default
            #line hidden
            this.Write("Model;\r\nimport ");
            
            #line 17 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".ViewModel.");
            
            #line 17 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code));
            
            #line default
            #line hidden
            this.Write("ViewModel;\r\nimport ");
            
            #line 18 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 18 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".R;\r\nimport rx.subscriptions.CompositeSubscription;\r\nimport android.content.Conte" +
                    "xt;\r\nimport ");
            
            #line 21 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 21 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 21 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 21 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.Substring(0, 1).ToUpper() + _models.Code.Substring(1).ToLower()));
            
            #line default
            #line hidden
            this.Write("Binding;\r\n\r\nimport android.support.v4.app.FragmentManager;\r\nimport android.suppor" +
                    "t.v4.app.FragmentTransaction;\r\nimport com.example.yunjoy.Fragment.*;\r\n\r\npublic c" +
                    "lass Item");
            
            #line 27 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code));
            
            #line default
            #line hidden
            this.Write("Event {\r\n    public ");
            
            #line 28 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code));
            
            #line default
            #line hidden
            this.Write("ViewModel _");
            
            #line 28 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.ToLower()));
            
            #line default
            #line hidden
            this.Write(";\r\n\tprivate CompositeSubscription _subscriptions;\r\n\tprivate ");
            
            #line 30 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.Substring(0, 1).ToUpper() + _models.Code.Substring(1).ToLower()));
            
            #line default
            #line hidden
            this.Write("Binding _");
            
            #line 30 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.ToLower()));
            
            #line default
            #line hidden
            this.Write("Binding;\r\n\tprivate Context _context;\r\n\tprivate ");
            
            #line 32 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code));
            
            #line default
            #line hidden
            this.Write("ViewModel _");
            
            #line 32 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.ToLower()));
            
            #line default
            #line hidden
            this.Write("ViewModel;\r\n\tprivate ");
            
            #line 33 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code));
            
            #line default
            #line hidden
            this.Write("Service _");
            
            #line 33 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service;\r\n\tprivate LoadUtil _loading;\r\n\tprivate ");
            
            #line 35 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code));
            
            #line default
            #line hidden
            this.Write("DAO _");
            
            #line 35 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.ToLower()));
            
            #line default
            #line hidden
            this.Write("DAO;\r\n\tprivate FragmentManager _manage;\r\n\r\n    public Item");
            
            #line 38 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code));
            
            #line default
            #line hidden
            this.Write("Event(");
            
            #line 38 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.Substring(0, 1).ToUpper() + _models.Code.Substring(1).ToLower()));
            
            #line default
            #line hidden
            this.Write("Binding ");
            
            #line 38 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.ToLower()));
            
            #line default
            #line hidden
            this.Write("Binding,Context context,CompositeSubscription subscriptions,LoadUtil loading,Frag" +
                    "mentManager manage){\r\n        this._");
            
            #line 39 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.ToLower()));
            
            #line default
            #line hidden
            this.Write("Binding=");
            
            #line 39 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.ToLower()));
            
            #line default
            #line hidden
            this.Write("Binding;\r\n\t\tthis._subscriptions=subscriptions;\r\n\t\tthis._context=context;\r\n\t\tthis." +
                    "_loading=loading;\r\n\t\tthis._");
            
            #line 43 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.ToLower()));
            
            #line default
            #line hidden
            this.Write("ViewModel=new ");
            
            #line 43 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code));
            
            #line default
            #line hidden
            this.Write("ViewModel(context);\r\n\t\tthis._");
            
            #line 44 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service=new ");
            
            #line 44 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code));
            
            #line default
            #line hidden
            this.Write("Service(_context,_loading);\r\n\t\tthis._");
            
            #line 45 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.ToLower()));
            
            #line default
            #line hidden
            this.Write("DAO=new ");
            
            #line 45 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code));
            
            #line default
            #line hidden
            this.Write("DAO(context);\r\n\t\t");
            
            #line 46 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.ToLower()));
            
            #line default
            #line hidden
            this.Write("Binding.set");
            
            #line 46 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code));
            
            #line default
            #line hidden
            this.Write("Event(this);\r\n\t\t");
            
            #line 47 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.ToLower()));
            
            #line default
            #line hidden
            this.Write("Binding.set");
            
            #line 47 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code));
            
            #line default
            #line hidden
            this.Write("Model(_");
            
            #line 47 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ItemEventTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_models.Code.ToLower()));
            
            #line default
            #line hidden
            this.Write("ViewModel);\r\n\t\tthis._manage=manage;\r\n    }\r\n    ///绑定点击事件\r\n    public void onClic" +
                    "k(View view)\r\n\t{\r\n        int Id=view.getId();\r\n            Button vi=(Button)vi" +
                    "ew;\r\n            switch (Id)\r\n\t\t\t{\r\n                \r\n            }\r\n    }\r\n}\r\n");
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
    public class J_ItemEventTemplateBase
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
