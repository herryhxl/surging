﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本: 16.0.0.0
//  
//     对此文件的更改可能导致不正确的行为，如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
// ------------------------------------------------------------------------------
namespace FileLoder.T_DotnetCore
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class CoreControllerTemplate : CoreControllerTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\nusing System;\r\nusing System.Linq;\r\nusing System.Threading.Tasks;\r\nusing Edu.Cor" +
                    "e.Site;\r\nusing Edu.Core.Handler;\r\nusing ");
            
            #line 12 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".Service.");
            
            #line 12 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write(";\r\nusing ");
            
            #line 13 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".Entity;\r\nusing ");
            
            #line 14 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".Models;\r\nusing ");
            
            #line 15 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".ModelsCustom;\r\nusing System.ComponentModel;\r\nusing ");
            
            #line 17 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".Base;\r\nusing System.Collections.Generic;\r\nusing Edu.Core.Data;\r\nusing Edu.Core.M" +
                    "odel;\r\nusing Microsoft.AspNetCore.Mvc;\r\n\r\n");
            
            #line 23 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
 var PKData=models.ColumnsList.Where(t=>t.PK==true).FirstOrDefault();
	if(PKData==null) throw new Exception("未包含主键字段");

            
            #line default
            #line hidden
            this.Write("\r\nnamespace ");
            
            #line 27 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".Controllers\r\n{\r\n    /// <summary>\r\n    /// ");
            
            #line 30 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(models.Name));
            
            #line default
            #line hidden
            this.Write("\r\n    /// </summary>\r\n    [Route(\"[controller]/[action]\")]\r\n    [ApiController]\r\n" +
                    "    [Description(\"");
            
            #line 34 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture((models.Comment==null?"":models.Comment)));
            
            #line default
            #line hidden
            this.Write("\")]\r\n    public partial class ");
            
            #line 35 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Controller : ControllerBase\r\n    {\r\n        private readonly I");
            
            #line 37 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Service _");
            
            #line 37 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service;\r\n        private readonly IReturn _helper;\r\n        public ");
            
            #line 39 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Controller(I");
            
            #line 39 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Service ");
            
            #line 39 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service, IReturn helper)\r\n        {\r\n            _");
            
            #line 41 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service = ");
            
            #line 41 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service;\r\n            _helper = helper;\r\n        }\r\n        /// <summary>\r\n      " +
                    "  /// 新增、编辑 ");
            
            #line 45 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(models.Name));
            
            #line default
            #line hidden
            this.Write("\r\n        /// </summary>\r\n        [Description(\"");
            
            #line 47 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(models.Name));
            
            #line default
            #line hidden
            this.Write("新增、编辑\")]\r\n        [HttpPost]\r\n        public async Task<ResponseObject<");
            
            #line 49 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.CodeType));
            
            #line default
            #line hidden
            this.Write(">> CreateOrModify([FromBody]");
            
            #line 49 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Dto m");
            
            #line 49 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write(")\r\n        {\r\n            return await _helper.ReturnObjectAsync<");
            
            #line 51 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.CodeType));
            
            #line default
            #line hidden
            this.Write(">(async re =>\r\n            {\r\n\t\t\t\tif (m");
            
            #line 53 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 53 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.Code));
            
            #line default
            #line hidden
            this.Write(" == ");
            
            #line 53 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.DataType.IndexOf("int")==-1?"\"\"":"0"));
            
            #line default
            #line hidden
            this.Write(")\r\n\t\t\t\t\tre.Msg = \"创建成功\";\r\n                else\r\n\t\t\t\t\tre.Msg = \"更新成功\";\r\n\t\t\t\tvar ");
            
            #line 57 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("=_");
            
            #line 57 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service.CreateOrModifyAsync(m");
            
            #line 57 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write(");\r\n                await _");
            
            #line 58 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service.SaveChangesAsync();\r\n\t\t\t\tre.Data=");
            
            #line 59 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 59 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.Code));
            
            #line default
            #line hidden
            this.Write(";\r\n            });\r\n        }\r\n        /// <summary>\r\n        /// 批量删除");
            
            #line 63 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(models.Name));
            
            #line default
            #line hidden
            this.Write("数据\r\n        /// </summary>\r\n        [Description(\"批量删除");
            
            #line 65 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(models.Name));
            
            #line default
            #line hidden
            this.Write("数据\")]\r\n        [HttpPost]\r\n        public async Task<ResponseObject<string>> Beac" +
                    "hRemove([FromBody]RequestBeach<");
            
            #line 67 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.CodeType));
            
            #line default
            #line hidden
            this.Write("> request)\r\n        {\r\n            return await _helper.ReturnObjectAsync<string>" +
                    "(async re =>\r\n            {\r\n                int delCount=await _");
            
            #line 71 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service.DeleteAsync(request);\r\n                await _");
            
            #line 72 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service.SaveChangesAsync();\r\n                re.Msg = string.Format(\"成功删除{0}条数据。\"" +
                    ", delCount);\r\n            });\r\n        }\r\n        /// <summary>\r\n        /// 批量更" +
                    "新");
            
            #line 77 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(models.Name));
            
            #line default
            #line hidden
            this.Write("字段信息\r\n        /// </summary>\r\n\t\t[Description(\"批量更新");
            
            #line 79 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(models.Name));
            
            #line default
            #line hidden
            this.Write("字段信息\")]\r\n        [HttpPost]\r\n        public async Task<ResponseObject<string>> Be" +
                    "achUpdate([FromBody]RequestBeachModel<");
            
            #line 81 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.CodeType));
            
            #line default
            #line hidden
            this.Write("> request)\r\n        {\r\n            return await _helper.ReturnObjectAsync<string>" +
                    "(async re =>\r\n            {\r\n                int beachCount=await _");
            
            #line 85 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service.BeachOperationAsync(request);\r\n                await _");
            
            #line 86 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service.SaveChangesAsync();\r\n                re.Msg = string.Format(\"成功处理{0}条数据。\"" +
                    ", beachCount);\r\n            });\r\n        }\r\n        /// <summary>\r\n        /// 获" +
                    "取");
            
            #line 91 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(models.Name));
            
            #line default
            #line hidden
            this.Write("信息\r\n        /// </summary>\r\n        [Description(\"获取");
            
            #line 93 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(models.Name));
            
            #line default
            #line hidden
            this.Write("信息\")]\r\n        [HttpPost]\r\n        public async Task<ResponseObject<");
            
            #line 95 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model>> Info([FromBody]RequestModel<");
            
            #line 95 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.CodeType));
            
            #line default
            #line hidden
            this.Write("> request)\r\n        {\r\n            return await _helper.ReturnObjectAsync<");
            
            #line 97 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model>(async re =>\r\n            {\r\n                re.Data =await _");
            
            #line 99 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service.InfoAsync<");
            
            #line 99 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model>(request);\r\n            });\r\n        }\r\n        /// <summary>\r\n        /// " +
                    "分页获取");
            
            #line 103 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(models.Name));
            
            #line default
            #line hidden
            this.Write("列表\r\n        /// </summary>\r\n        [Description(\"分页获取");
            
            #line 105 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(models.Name));
            
            #line default
            #line hidden
            this.Write("列表\")]\r\n        [HttpPost]\r\n        public async Task<ResponseObject<PageList<");
            
            #line 107 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel>>> GetList([FromBody]");
            
            #line 107 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("SearchCondition condition)\r\n        {\r\n            return await _helper.ReturnObj" +
                    "ectAsync<PageList<");
            
            #line 109 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel>>(async re =>\r\n            {\r\n                re.Data =await _");
            
            #line 111 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("Service.PageConditionAsync<");
            
            #line 111 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel,");
            
            #line 111 "D:\C#\eduSurging\FileLoder\T_DotnetCore\CoreControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("SearchCondition>(condition);\r\n            });\r\n        }\r\n    }\r\n}\r\n");
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
    public class CoreControllerTemplateBase
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
