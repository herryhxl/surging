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
    using FileLoder.TemplateModel;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class J_IServiceTemplate : J_IServiceTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\npackage ");
            
            #line 8 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".IService;\r\n\r\nimport ");
            
            #line 10 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".Base.PageList;\r\nimport ");
            
            #line 11 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".Model.");
            
            #line 11 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model;\r\nimport ");
            
            #line 12 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(@".Response.MsgResponse;
import java.util.ArrayList;
import java.util.List;
import okhttp3.MediaType;
import okhttp3.RequestBody;
import retrofit2.Response;
import retrofit2.http.Field;
import retrofit2.http.Body;
import retrofit2.http.FormUrlEncoded;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Multipart;
import retrofit2.http.Query;
import rx.Observable;

");
            
            #line 27 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
 var PKData=_models.ColumnsList.Where(t=>t.PK==true).FirstOrDefault();
	if(PKData==null) throw new Exception("未包含主键字段");

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 31 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
 var sqData=_models.ColumnsList.Where(r=>r.Search != SearchType.Null&&r.Virtual==false).ToList();
		var sum=4+sqData.Count+sqData.Where(r=>r.Search == SearchType.Range).ToList().Count;
		int p=0;
		var Pa=new  StringBuilder();
		
var para=new StringBuilder();
var para2=new StringBuilder();
foreach(var model in _models.ColumnsList.Where(t=>t.Virtual==false)){
	var CodeType = model.CodeType.Replace("?","");
	var Code=model.Code.Replace("?","");
		var type="String";
			if(CodeType=="string"||CodeType=="Guid"||CodeType=="datetime") 
				type="String";
			else if(CodeType=="int") 
				type="int";
			else if(CodeType=="bigint") 
				type="long";
			else if(CodeType=="decimal") 
				type="double";
			else if(CodeType=="bool") 
				type="Boolean";
		para.Append(",@Query(\""+Code+"\")"+type+" "+ Code);
		para2.Append(","+Code);
		}
		
		var ParaStr=para.ToString().Substring(1);
		var ParaStr2=para2.ToString().Substring(1);


		Pa.Append("@Field(\"IsDescending\")Boolean IsDescending,@Field(\"OrderBy\")int OrderBy,@Field(\"Page\")int  Page,@Field(\"PageCount\")int  PageCount");
		foreach(var model in sqData)
		{ 
			var CodeType = model.CodeType.Replace("?","");
			var Code=model.Code.Replace("?","");
			var type="String";
			if(CodeType=="string"||CodeType=="Guid"||CodeType=="datetime") 
				type="String";
			else if(CodeType=="int") 
				type="int";
			else if(CodeType=="bigint") 
				type="long";
			else if(CodeType=="decimal") 
				type="double";
			else if(CodeType=="bool") 
				type="Boolean";
			
			if(model.Search==SearchType.In)
			{
				Pa.Append(",@Field(\""+Code+"s\")String "+Code+"s");
			}
			else if (model.Search == SearchType.Like)
			{
				Pa.Append(",@Field(\"+Code+\")"+type+" "+Code);
			}
			else if (model.Search == SearchType.Equal)
			{
				Pa.Append(",@Field(\"+Code+\")"+type+" "+Code);
			}
			else if (model.Search == SearchType.Range)
			{
				Pa.Append(",@Field(\""+Code+"Begin\")"+type+" "+Code+"Begin");
				Pa.Append(",@Field(\""+Code+"End\")"+type+" "+Code+"End");
			}
		}
		var PaStr=Pa.ToString();

            
            #line default
            #line hidden
            this.Write("\r\npublic interface I");
            
            #line 98 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Service \r\n{\r\n\t@Multipart\r\n    @POST(\"/api/");
            
            #line 101 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("/CreateOrModify\")\r\n    Observable<Response<MsgResponse<Object>>> CreateOrModify(@" +
                    "Body RequestBody model);\r\n\t@FormUrlEncoded\r\n\t@POST(\"/api/");
            
            #line 104 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("/RemoveList\")\r\n    Observable<Response<MsgResponse<Object>>> RemoveList(@Field(\"\"" +
                    ")List<");
            
            #line 105 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.CodeType=="string"?"String":"Integer"));
            
            #line default
            #line hidden
            this.Write("> List");
            
            #line 105 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.Code));
            
            #line default
            #line hidden
            this.Write(");\r\n\t@FormUrlEncoded\r\n\t@POST(\"/api/");
            
            #line 107 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("/GetById\")\r\n    Observable<Response<MsgResponse<");
            
            #line 108 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model>>> GetById(@Field(\"\")");
            
            #line 108 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.CodeType=="string"?"String":"Integer"));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 108 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.Code));
            
            #line default
            #line hidden
            this.Write(");\r\n\t@FormUrlEncoded\r\n\t@POST(\"/api/");
            
            #line 110 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("/GetList\")\r\n\t//");
            
            #line 111 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PaStr));
            
            #line default
            #line hidden
            this.Write("\r\n    Observable<Response<MsgResponse<PageList<");
            
            #line 112 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model>>>> GetList(@Field(\"IsDescending\")Boolean IsDescending,@Field(\"OrderBy\")int" +
                    " OrderBy,@Field(\"Page\")int  Page,@Field(\"PageCount\")int  PageCount);\r\n");
            
            #line 113 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
 if(_models.Code=="Action") {
            
            #line default
            #line hidden
            this.Write("\t@POST(\"/api/Action/Init\")\r\n    Observable<Response<MsgResponse<Object>>> Init();" +
                    "\r\n");
            
            #line 116 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_IServiceTemplate.tt"
 }
            
            #line default
            #line hidden
            this.Write("}\r\n");
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
    public class J_IServiceTemplateBase
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
