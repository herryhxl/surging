﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本: 16.0.0.0
//  
//     对此文件的更改可能导致不正确的行为，如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
// ------------------------------------------------------------------------------
namespace FileLoder.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class ControllerTemplate : ControllerTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\nusing System.Linq;\r\nusing System.Net.Http;\r\nusing System.Threading" +
                    ".Tasks;\r\nusing System.Web.Http;\r\nusing Edu.Core.Site;\r\nusing Edu.Core.Handler;\r\n" +
                    "using ");
            
            #line 13 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".Service.");
            
            #line 13 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write(";\r\nusing ");
            
            #line 14 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".Entity;\r\nusing ");
            
            #line 15 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".Models;\r\nusing System.ComponentModel;\r\nusing System.Data.Entity;\r\nusing ");
            
            #line 18 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".Base;\r\nusing System.Collections.Generic;\r\nusing Edu.Core.Data;\r\nusing Edu.Core.M" +
                    "odel;\r\n\r\n");
            
            #line 23 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
 var PKData=models.ColumnsList.Where(t=>t.PK==true).FirstOrDefault();
	if(PKData==null) throw new Exception("未包含主键字段");

            
            #line default
            #line hidden
            this.Write("\r\nnamespace ");
            
            #line 27 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".Controllers\r\n{\r\n\t//");
            
            #line 29 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture((models.Comment==null? "":models.Comment)));
            
            #line default
            #line hidden
            this.Write("\r\n    [Description(\"");
            
            #line 30 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture((models.Comment==null?"":models.Comment)));
            
            #line default
            #line hidden
            this.Write("[");
            
            #line 30 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_columnsStr));
            
            #line default
            #line hidden
            this.Write("]\")]\r\n    public partial class ");
            
            #line 31 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Controller : ApiController\r\n    {\r\n        private readonly I");
            
            #line 33 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Service _");
            
            #line 33 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service;\r\n        private readonly IWorkContext _workContext;\r\n        private re" +
                    "adonly IReturn _helper;\r\n        public ");
            
            #line 36 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Controller(I");
            
            #line 36 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Service ");
            
            #line 36 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service, IWorkContext workContext,IReturn helper)\r\n        {\r\n            _");
            
            #line 38 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service = ");
            
            #line 38 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service;\r\n            _workContext = workContext;\r\n            _helper = helper;\r" +
                    "\n        }\r\n        [Description(\"新增/编辑\")]\r\n        [HttpPost]\r\n        public a" +
                    "sync Task<HttpResponseMessage> CreateOrModify([FromBody]");
            
            #line 44 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model m");
            
            #line 44 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write(")\r\n        {\r\n            return await _helper.ReturnAsync(async re =>\r\n         " +
                    "   {\r\n\t\t\t\tif (m");
            
            #line 48 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 48 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.Code));
            
            #line default
            #line hidden
            this.Write(" == ");
            
            #line 48 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.DataType.IndexOf("int")==-1?"\"\"":"0"));
            
            #line default
            #line hidden
            this.Write(")\r\n\t\t\t\t\tre.Msg = \"创建成功\";\r\n                else\r\n\t\t\t\t\tre.Msg = \"更新成功\";\r\n          " +
                    "      var MenuInfo=_workContext.MenuInfo();\r\n\t\t\t\tvar ");
            
            #line 53 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("=_");
            
            #line 53 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service.CreateOrModify(m");
            
            #line 53 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write(",null,_workContext.IsAuth,MenuInfo);\r\n                await _");
            
            #line 54 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service.SaveChangesAsync();\r\n\t\t\t\tre.Object=");
            
            #line 55 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 55 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.Code));
            
            #line default
            #line hidden
            this.Write(";\r\n            });\r\n        }\r\n        [Description(\"批量删除\")]\r\n        [HttpPost]\r" +
                    "\n        public async Task<HttpResponseMessage> RemoveList([FromBody]RequestBeac" +
                    "hModel<");
            
            #line 60 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.CodeType));
            
            #line default
            #line hidden
            this.Write("> Request)\r\n        {\r\n            return await _helper.ReturnAsync(async re =>\r\n" +
                    "            {\r\n                re.Msg = \"全部删除成功\";\r\n                var MenuInfo=" +
                    "_workContext.MenuInfo();\r\n                int DelCount=await _");
            
            #line 66 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service.Delete(Request,null,null,_workContext.IsAuth,MenuInfo);\r\n                " +
                    "await _");
            
            #line 67 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write(@"Service.SaveChangesAsync();
                re.Msg = string.Format(""成功删除{0}条数据。"", DelCount);
            });
        }
		[Description(""批量操作"")]
        [HttpPost]
        public async Task<HttpResponseMessage> BeachOperation([FromBody]RequestBeachModel<");
            
            #line 73 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.CodeType));
            
            #line default
            #line hidden
            this.Write("> Request)\r\n        {\r\n            return await _helper.ReturnAsync(async re =>\r\n" +
                    "            {\r\n                var MenuInfo=_workContext.MenuInfo();\r\n          " +
                    "      int BeachCount=await _");
            
            #line 78 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service.BeachOperation(Request,null,null,_workContext.IsAuth,MenuInfo);\r\n        " +
                    "        await _");
            
            #line 79 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service.SaveChangesAsync();\r\n                re.Msg = string.Format(\"成功处理{0}条数据。\"" +
                    ", BeachCount);\r\n            });\r\n        }\r\n        [Description(\"查看\")]\r\n       " +
                    " [HttpPost]\r\n        public async Task<HttpResponseMessage> GetById([FromBody]Re" +
                    "questModel<");
            
            #line 85 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.CodeType));
            
            #line default
            #line hidden
            this.Write(@"> Request)
        {
            return await _helper.ReturnAsync(async re =>
            {
                re.Msg = ""查询成功"";
				var MenuInfo=_workContext.MenuInfo();
				//re.MenuInfo=_workContext.ProcessMenuInfo(MenuInfo);
                re.Object =await _");
            
            #line 92 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service.GetModelById(Request,null,_workContext.IsAuth,MenuInfo);\r\n            });" +
                    "\r\n        }\r\n\t\t//当(Page=1)时返回总页数和总记录数\r\n\t\t[Description(\"列表管理【");
            
            #line 96 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("】[");
            
            #line 96 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write(".CreateOrModify,");
            
            #line 96 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write(".RemoveList,");
            
            #line 96 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write(".BeachOperation,");
            
            #line 96 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write(".GetById]\")]\r\n        [HttpPost]\r\n        public async Task<HttpResponseMessage> " +
                    "GetList([FromBody]");
            
            #line 98 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write(@"SearchCondition Condition)
        {
            return await _helper.ReturnAsync(async re =>
            {
				var MenuInfo=_workContext.MenuInfo();
				if(Condition.Page==1)
					re.MenuInfo=_workContext.ProcessMenuInfo(MenuInfo);
                re.Object =await _");
            
            #line 105 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service.");
            
            #line 105 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("PageSearch(Condition,null,null,_workContext.IsAuth,MenuInfo);\r\n            });\r\n " +
                    "       }\r\n    }\r\n}\r\n");
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
    public class ControllerTemplateBase
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
