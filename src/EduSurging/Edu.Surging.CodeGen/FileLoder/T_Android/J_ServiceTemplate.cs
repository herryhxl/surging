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
    
    #line 1 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class J_ServiceTemplate : J_ServiceTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\npackage ");
            
            #line 8 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_pcckage));
            
            #line default
            #line hidden
            this.Write(".Service;\r\nimport android.content.Context;\r\nimport ");
            
            #line 10 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_pcckage));
            
            #line default
            #line hidden
            this.Write(".Base.*;\r\nimport java.util.List;\r\nimport ");
            
            #line 12 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_pcckage));
            
            #line default
            #line hidden
            this.Write(".Common.LoadUtil;\r\nimport ");
            
            #line 13 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_pcckage));
            
            #line default
            #line hidden
            this.Write(".IService.I");
            
            #line 13 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Service;\r\nimport com.example.yunjoy.Base.PageList;\r\nimport ");
            
            #line 15 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_pcckage));
            
            #line default
            #line hidden
            this.Write(".Model.");
            
            #line 15 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model;\r\nimport com.google.gson.Gson;\r\nimport okhttp3.MediaType;\r\nimport okhttp3.R" +
                    "equestBody;\r\nimport ");
            
            #line 19 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_pcckage));
            
            #line default
            #line hidden
            this.Write(".Response.MsgResponse;\r\nimport ");
            
            #line 20 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_pcckage));
            
            #line default
            #line hidden
            this.Write(".Response.NoneDataResponse;\r\n\r\nimport retrofit2.Response;\r\nimport rx.Observable;\r" +
                    "\n\r\n");
            
            #line 25 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
 var PKData=_models.ColumnsList.Where(t=>t.PK==true).FirstOrDefault();
	if(PKData==null) throw new Exception("未包含主键字段");

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 29 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
 var sqData=_models.ColumnsList.Where(r=>r.Search != SearchType.Null&&r.Virtual==false).ToList();
		var sum=4+sqData.Count+sqData.Where(r=>r.Search == SearchType.Range).ToList().Count;
		int p=0;
		var Pa=new  StringBuilder();
		var Pa2=new  StringBuilder();


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
		para.Append(","+type+" "+ Code);
		para2.Append(","+Code);
		}
		
		var ParaStr=para.ToString().Substring(1);
		var ParaStr2=para2.ToString().Substring(1);





		Pa.Append("Boolean IsDescending,int OrderBy,int  Page,int  PageCount");
		Pa2.Append("IsDescending,OrderBy,Page,PageCount");
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
				Pa.Append(",String "+Code+"s");
				Pa2.Append(","+Code+"s");
			}
			else if (model.Search == SearchType.Like)
			{
				Pa.Append(","+type+" "+Code);
				Pa2.Append(","+Code);
			}
			else if (model.Search == SearchType.Equal)
			{
				Pa.Append(","+type+" "+Code);
				Pa2.Append(","+Code);
			}
			else if (model.Search == SearchType.Range)
			{
				Pa.Append(","+type+" "+Code+"Begin");
				Pa.Append(","+type+" "+Code+"End");

				Pa2.Append(","+Code+"Begin");
				Pa2.Append(","+Code+"End");
			}
		}
		var PaStr=Pa.ToString();
		var PaStr2=Pa2.ToString();

            
            #line default
            #line hidden
            this.Write("\r\npublic class ");
            
            #line 109 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Service\r\n{\r\n    private Context _context;\r\n\tprivate LoadUtil _loading;\r\n    publi" +
                    "c ");
            
            #line 113 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Service(Context context,LoadUtil loading){\r\n        this._context=context;\r\n\t\tthi" +
                    "s._loading=loading;\r\n    }\r\n\tpublic Observable<Msg<Object>> CreateOrModify(");
            
            #line 117 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model ");
            
            #line 117 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write(")//");
            
            #line 117 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ParaStr));
            
            #line default
            #line hidden
            this.Write("\r\n\t{\r\n\t\tGson gson = new Gson();\r\n        String post");
            
            #line 120 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write(" = gson.toJson(");
            
            #line 120 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write(");\r\n        RequestBody ");
            
            #line 121 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Body = RequestBody.create(MediaType.parse(\"application/json; charset=utf-8\"),post" +
                    "");
            
            #line 121 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write(");\r\n\t\treturn ServiceFactory.createService(I");
            
            #line 122 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Service.class).CreateOrModify(");
            
            #line 122 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Body)\r\n                .compose(new DefaultTransformer<Response<MsgResponse<Objec" +
                    "t>>, MsgResponse<Object>,Msg<Object>>(_context,_loading));\r\n\t}\r\n\tpublic Observab" +
                    "le<Msg<Object>> RemoveList(List<");
            
            #line 125 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.CodeType=="string"?"String":"Integer"));
            
            #line default
            #line hidden
            this.Write("> ");
            
            #line 125 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.Code));
            
            #line default
            #line hidden
            this.Write(")\r\n\t{\r\n\t\treturn ServiceFactory.createService(I");
            
            #line 127 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Service.class).RemoveList(");
            
            #line 127 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.Code));
            
            #line default
            #line hidden
            this.Write(")\r\n                .compose(new DefaultTransformer<Response<MsgResponse<Object>>," +
                    " MsgResponse<Object>,Msg<Object>>(_context,_loading));\r\n\t}\r\n\tpublic Observable<M" +
                    "sg<");
            
            #line 130 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model>> GetById(");
            
            #line 130 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.CodeType=="string"?"String":PKData.CodeType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 130 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.Code));
            
            #line default
            #line hidden
            this.Write(")\r\n\t{\r\n        return ServiceFactory.createService(I");
            
            #line 132 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Service.class).GetById(");
            
            #line 132 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PKData.Code));
            
            #line default
            #line hidden
            this.Write(")\r\n                .compose(new DefaultTransformer<Response<MsgResponse<");
            
            #line 133 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model>>, MsgResponse<");
            
            #line 133 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model>,Msg<");
            
            #line 133 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model>>(_context,_loading));\r\n    }\r\n    public Observable<Msg<PageList<");
            
            #line 135 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model>>> GetList(Boolean IsDescending,int OrderBy,int  Page,int  PageCount)\r\n\t{\r\n" +
                    "        return ServiceFactory.createService(I");
            
            #line 137 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Service.class).GetList(IsDescending,OrderBy,Page,PageCount)//");
            
            #line 137 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PaStr2));
            
            #line default
            #line hidden
            this.Write("\r\n                .compose(new DefaultTransformer<Response<MsgResponse<PageList<");
            
            #line 138 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model>>>, MsgResponse<PageList<");
            
            #line 138 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model>>,Msg<PageList<");
            
            #line 138 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model>>>(_context,_loading));\r\n    }\r\n");
            
            #line 140 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
 if(_models.Code=="Action") {
            
            #line default
            #line hidden
            this.Write("\tpublic Observable<Msg<Object>> Init()\r\n\t{\r\n\t\treturn ServiceFactory.createService" +
                    "(IActionService.class).Init()\r\n\t\t\t\t.compose(new DefaultTransformer<Response<MsgR" +
                    "esponse<Object>>, MsgResponse<Object>,Msg<Object>>(_context,_loading));\r\n\t}\r\n");
            
            #line 146 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_ServiceTemplate.tt"
 }
            
            #line default
            #line hidden
            this.Write("}\r\n\r\n");
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
    public class J_ServiceTemplateBase
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
