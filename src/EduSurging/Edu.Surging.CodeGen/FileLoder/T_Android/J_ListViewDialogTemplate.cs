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
    
    #line 1 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ListViewDialogTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class J_ListViewDialogTemplate : J_ListViewDialogTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("package ");
            
            #line 6 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ListViewDialogTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(@".Dialog;
import android.content.Context;
import android.databinding.DataBindingUtil;
import android.support.design.widget.BottomSheetBehavior;
import android.support.design.widget.BottomSheetDialog;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AdapterView;
import android.widget.BaseAdapter;

import ");
            
            #line 16 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ListViewDialogTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".Adapter.RegisterTypeListAdapter;\r\nimport ");
            
            #line 17 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ListViewDialogTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".ViewModel.EnumViewModel;\r\nimport ");
            
            #line 18 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ListViewDialogTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 18 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ListViewDialogTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".R;\r\nimport ");
            
            #line 19 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ListViewDialogTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 19 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ListViewDialogTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 19 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ListViewDialogTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".ListdataLayoutBinding;\r\n\r\nimport java.util.ArrayList;\r\nimport java.util.List;\r\n\r" +
                    "\npublic class ListViewDialog {\r\n    private Context _context;\r\n    private Botto" +
                    "mSheetDialog bottomSheetDialog;\r\n    private List<EnumViewModel> _data;\r\n    pri" +
                    "vate int TagId;\r\n    private ListdataLayoutBinding _listdataLayoutBinding;\r\n    " +
                    "private AdapterView.OnItemClickListener _liser;\r\n    private BaseAdapter _adater" +
                    ";\r\n    public ListViewDialog(Context context){\r\n        this._context=context;\r\n" +
                    "        _listdataLayoutBinding = DataBindingUtil.inflate(LayoutInflater.from(_co" +
                    "ntext), R.layout.listdata_layout, null, false);\r\n    }\r\n    public int getTagId(" +
                    "){\r\n        return TagId;\r\n    }\r\n    public void setTagId(int Id){\r\n        thi" +
                    "s.TagId=Id;\r\n    }\r\n    public void setAdater(BaseAdapter t){\r\n        this._ada" +
                    "ter=t;\r\n    }\r\n    public BaseAdapter getAdater(){\r\n        return _adater;\r\n   " +
                    " }\r\n    public void setLiser(AdapterView.OnItemClickListener liser){\r\n        th" +
                    "is._liser=liser;\r\n        _listdataLayoutBinding.ListDataView.setOnItemClickList" +
                    "ener(_liser);\r\n    }\r\n    public Object getItem(int position){\r\n        return _" +
                    "adater.getItem(position);\r\n    }\r\n\r\n    public void Show() {\r\n        if(bottomS" +
                    "heetDialog!=null){\r\n            if(!bottomSheetDialog.isShowing())\r\n            " +
                    "    bottomSheetDialog.show();\r\n        }\r\n        else {\r\n            bottomShee" +
                    "tDialog = new BottomSheetDialog(_context);\r\n            View view = _listdataLay" +
                    "outBinding.getRoot();\r\n            bottomSheetDialog.setContentView(view);\r\n    " +
                    "        View parent = (View) view.getParent();\r\n            BottomSheetBehavior " +
                    "behavior = BottomSheetBehavior.from(parent);\r\n            _listdataLayoutBinding" +
                    ".ListDataView.setAdapter(_adater);\r\n            _listdataLayoutBinding.ListDataV" +
                    "iew.setOnItemClickListener(_liser);\r\n            behavior.setState(BottomSheetBe" +
                    "havior.STATE_EXPANDED);\r\n\t\t\tbottomSheetDialog.setCanceledOnTouchOutside(false);\r" +
                    "\n            bottomSheetDialog.setCancelable(false);\r\n//\r\n//        contentView." +
                    "measure(0, 0);\r\n//        behavior.setPeekHeight(contentView.getMeasuredHeight()" +
                    ");\r\n//        CoordinatorLayout.LayoutParams params = (CoordinatorLayout.LayoutP" +
                    "arams) parent.getLayoutParams();\r\n//        params.gravity = Gravity.TOP | Gravi" +
                    "ty.CENTER_HORIZONTAL;\r\n//        parent.setLayoutParams(params);\r\n            bo" +
                    "ttomSheetDialog.show();\r\n        }\r\n    }\r\n\r\n\r\n\r\n    public void Dismiss() {\r\n  " +
                    "      if(bottomSheetDialog.isShowing()) {\r\n            bottomSheetDialog.dismiss" +
                    "();\r\n        }\r\n    }\r\n}\r\n\r\n\r\n\r\n");
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
    public class J_ListViewDialogTemplateBase
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
