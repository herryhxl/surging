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
    
    #line 1 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class ViewModelTemplate : ViewModelTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Syste" +
                    "m.Web;\r\nusing ");
            
            #line 10 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".Entity;\r\nusing ");
            
            #line 11 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".Base;\r\nusing System.Xml.Linq;\r\nusing Edu.Core.Data;\r\nusing Edu.Core.Model;\r\nusin" +
                    "g System.Text;\r\nusing System.Xml.Serialization;\r\nusing System.IO;\r\n\r\nnamespace ");
            
            #line 19 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_projectName));
            
            #line default
            #line hidden
            this.Write(".Models\r\n{\r\n\tpublic class ");
            
            #line 21 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("_DataModel\r\n\t{\r\n");
            
            #line 23 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
 foreach(var model in _models.ColumnsList.Where(t=>t.Virtual==false)){
            
            #line default
            #line hidden
            this.Write("\t\t/// <summary>\r\n\t\t/// ");
            
            #line 25 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Name));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t/// </summary>\r\n");
            
            #line 27 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
 if(model.FK){
            
            #line default
            #line hidden
            this.Write("\t\tpublic ");
            
            #line 28 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.C_CodeType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 28 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n");
            
            #line 29 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
 } else if(model.EM){
            
            #line default
            #line hidden
            this.Write("\t\tpublic virtual string ");
            
            #line 30 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code+"String"));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t{ \r\n\t\t\tget\r\n\t\t\t{\r\n");
            
            #line 34 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
 if(model.IsNull){
            
            #line default
            #line hidden
            this.Write("\t\t\t\tif(");
            
            #line 35 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code));
            
            #line default
            #line hidden
            this.Write("==null) return \"\";\r\n");
            
            #line 36 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
}
            
            #line default
            #line hidden
            this.Write("\t\t\t\tswitch((int)");
            
            #line 37 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code));
            
            #line default
            #line hidden
            this.Write(")\r\n\t\t\t\t{\r\n");
            
            #line 39 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
 foreach(var value in model.EmodelList){
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\tcase ");
            
            #line 40 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(value.Attribute));
            
            #line default
            #line hidden
            this.Write(":\r\n\t\t\t\t\t\treturn \"");
            
            #line 41 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(value.Description.StartsWith("_")?value.Description.Substring(1,value.Description.Length-1).Replace("_","-"):value.Description));
            
            #line default
            #line hidden
            this.Write("\";\r\n");
            
            #line 42 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
}
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\tdefault:\r\n\t\t\t\t\t\treturn \"\";\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t}\r\n\t\tpublic ");
            
            #line 48 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.EnumName));
            
            #line default
            #line hidden
            
            #line 48 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.IsNull ? "?":""));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 48 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n");
            
            #line 49 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
 } else if(model.DataType.StartsWith("xml")){
	var xmltype=_entityName+"_"+model.Code+"XMLModel";
			xmltype="List<"+xmltype+">";

            
            #line default
            #line hidden
            this.Write("\t\tpublic ");
            
            #line 53 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.CodeType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 53 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n\t\tpublic virtual ");
            
            #line 54 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(xmltype));
            
            #line default
            #line hidden
            this.Write(" Xml_");
            
            #line 54 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code));
            
            #line default
            #line hidden
            this.Write("\r\n        {\r\n            get \r\n\t\t\t{\r\n\t\t\t\tif(");
            
            #line 58 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code));
            
            #line default
            #line hidden
            this.Write("!=null)\r\n\t\t\t\t{\r\n\t\t\t\t\t");
            
            #line 60 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(xmltype));
            
            #line default
            #line hidden
            this.Write(" cloneObject = default(");
            
            #line 60 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(xmltype));
            
            #line default
            #line hidden
            this.Write(");\r\n                    StringBuilder buffer = new StringBuilder();\r\n            " +
                    "        buffer.Append(");
            
            #line 62 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code));
            
            #line default
            #line hidden
            this.Write(");\r\n                    XmlSerializer serializer = new XmlSerializer(typeof(");
            
            #line 63 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(xmltype));
            
            #line default
            #line hidden
            this.Write("));\r\n                    using (TextReader reader = new StringReader(buffer.ToStr" +
                    "ing()))\r\n                    {\r\n                        Object obj = serializer." +
                    "Deserialize(reader);\r\n                        cloneObject = (");
            
            #line 67 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(xmltype));
            
            #line default
            #line hidden
            this.Write(")obj;\r\n                    }\r\n                    return cloneObject;\r\n\t\t\t\t}\t\r\n\t\t" +
                    "\t\telse\r\n\t\t\t\t\treturn null;\r\n\t\t\t}\r\n            set \r\n\t\t\t{ \r\n\t\t\t\tStringBuilder buff" +
                    "er = new StringBuilder();\r\n\t\t\t\tXmlSerializer se = new XmlSerializer(typeof(");
            
            #line 77 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(xmltype));
            
            #line default
            #line hidden
            this.Write("));\r\n\t\t\t\tusing (TextWriter writer = new StringWriter(buffer))\r\n\t\t\t\t{\r\n\t\t\t\t\tse.Ser" +
                    "ialize(writer, value);\r\n\t\t\t\t}\r\n\t\t\t\t");
            
            #line 82 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code));
            
            #line default
            #line hidden
            this.Write(" =buffer.ToString(); \r\n\t\t\t}\r\n        }\r\n");
            
            #line 85 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
 } else{
            
            #line default
            #line hidden
            this.Write("\t\tpublic ");
            
            #line 86 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.C_CodeType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 86 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n");
            
            #line 87 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
}}
            
            #line default
            #line hidden
            this.Write("\t}\r\n\tpublic class ");
            
            #line 89 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Model:");
            
            #line 89 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("_DataModel\r\n\t{\r\n\t\tpublic string ");
            
            #line 91 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("Text { get; set; }\r\n");
            
            #line 92 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
 foreach(var model in _models.ColumnsList){
	if(model.Virtual){ 
		if(model.CodeType.EndsWith("Entity")&&model.CodeType.Replace("Entity", "")==_entityName){
            
            #line default
            #line hidden
            this.Write("\t\t\tpublic ");
            
            #line 95 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.CodeType.Replace("Entity", "_DataModel")));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 95 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code.Replace("?", "")));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n\t\t\tpublic int ");
            
            #line 96 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code.Replace("?", "")));
            
            #line default
            #line hidden
            this.Write("Count { get; set; }\r\n\t\t");
            
            #line 97 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
}else{
            
            #line default
            #line hidden
            this.Write("\t\t\tpublic ");
            
            #line 98 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.CodeType.Replace("Entity", "Model").Replace("IList", "List")));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 98 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code.Replace("?", "")));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n\t\t\tpublic int ");
            
            #line 99 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code.Replace("?", "")));
            
            #line default
            #line hidden
            this.Write("Count { get; set; }\r\n\t\t");
            
            #line 100 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
}} else if(model.FK){
            
            #line default
            #line hidden
            this.Write("\t\tpublic string ");
            
            #line 101 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code.Replace("?", "")));
            
            #line default
            #line hidden
            this.Write("Text { get; set; }\r\n");
            
            #line 102 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
}}
            
            #line default
            #line hidden
            this.Write("\t}\r\n");
            
            #line 104 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
 foreach(var model in _models.ColumnsList.Where(t=>t.DataType.StartsWith("xml")==true)){
            
            #line default
            #line hidden
            this.Write("\tpublic class ");
            
            #line 105 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("_");
            
            #line 105 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Code));
            
            #line default
            #line hidden
            this.Write("XMLModel\r\n\t{\r\n");
            
            #line 107 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
if(model.XModel!=null){foreach(var item in model.XModel){
            
            #line default
            #line hidden
            this.Write("\t\tpublic ");
            
            #line 108 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.CodeType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 108 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Code));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n");
            
            #line 109 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
}}
            
            #line default
            #line hidden
            this.Write("\t}\r\n");
            
            #line 111 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\Templates\ViewModelTemplate.tt"
}
            
            #line default
            #line hidden
            this.Write("}");
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
    public class ViewModelTemplateBase
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
