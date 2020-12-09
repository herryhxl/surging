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
    
    #line 1 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class J_DAOTemplate : J_DAOTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n\r\npackage ");
            
            #line 8 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".Data;\r\n\r\nimport java.util.ArrayList;\r\nimport java.util.List;\r\nimport ");
            
            #line 12 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_package));
            
            #line default
            #line hidden
            this.Write(".ViewModel.");
            
            #line 12 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel;\r\nimport com.example.yunjoy.Base.DBOpenHelper;\r\nimport android.content." +
                    "ContentValues;\r\nimport android.content.Context;\r\nimport android.database.Cursor;" +
                    "\r\nimport android.database.sqlite.SQLiteDatabase;\r\nimport android.util.Log;\r\n\r\n\r\n" +
                    "\r\n");
            
            #line 22 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
 
var CreateSql=new StringBuilder();
var AddContent=new StringBuilder();
var UpdateContent=new StringBuilder();
var Conlums=new StringBuilder();
var Result=new StringBuilder();
var p=1;
foreach(var model in _models.ColumnsList.Where(t=>t.Virtual==false)){
	var CodeType = model.CodeType.Replace("?","");
	var Code=model.Code.Replace("?","");
	var DataType=model.DataType.Replace("?","");
	if(DataType=="xml"){
		DataType="text";
	}
	else if(DataType=="int"||DataType=="bit"){
		DataType="integer";
	}
	else if(DataType=="bigint"){
		DataType="long";
	}
	else if(DataType=="decimal"){
		DataType="float";
	}
	else DataType="text";
		var type="String";
		var rp="getString"+"("+p+")";
			if(CodeType=="string"||CodeType=="Guid"||CodeType=="datetime") 
			{
				type="String";
				rp="getString"+"("+p+")";
			}
			else if(CodeType=="int") {
				type="int";
				rp="getInt"+"("+p+")";
			}
			else if(CodeType=="bigint") {
				type="long";
				rp="getLong"+"("+p+")";
			}
			else if(CodeType=="decimal") {
				type="double";
				rp="getDouble"+"("+p+")";
			}
			else if(CodeType=="bool"){ 
				type="Boolean";
				rp="getInt"+"("+p+")==1";
			}
CreateSql.Append(","+Code+" "+(model.DataType.Replace("?","")=="xml"?"text":model.DataType.Replace("?","")) );//
AddContent.Append("values.put(\""+Code+"\","+_entityName.ToLower()+".get"+_models.Code+
Code+"());\r\n");
Conlums.Append(",\""+Code+"\"");
Result.Append(",cursor."+rp);
p++;
}
var Add=AddContent.ToString();
UpdateContent.Append("values.put(\"_id\","+ _entityName.ToLower()+".get__id());\r\n");
UpdateContent.Append(Add);
var Update=UpdateContent.ToString();
var Con="\"_id\""+Conlums.ToString();
var Re="cursor.getInt(0)"+Result.ToString();

            
            #line default
            #line hidden
            this.Write("public class ");
            
            #line 83 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("DAO {\r\n\tprivate SQLiteDatabase db;\r\n\tprivate static final String TabName=\"t_");
            
            #line 85 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write("\";\r\n\tpublic static String CreateSql=\"create table \"+TabName+\" (_id integer primar" +
                    "y key AUTOINCREMENT ");
            
            #line 86 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(CreateSql));
            
            #line default
            #line hidden
            this.Write(")\";\r\n\tprivate DBOpenHelper helper;\r\n\tprivate String secret_key = \"@#{}*Hndssafd)~" +
                    "GDF\";\r\n\r\n\tpublic ");
            
            #line 90 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("DAO(Context con) {\r\n\t\thelper = new DBOpenHelper(con,TabName);\r\n\t}\r\n\r\n\tpublic stat" +
                    "ic String getCreateSql()\r\n\t{\r\n\t\treturn CreateSql;\r\n\t}\r\n\r\n\r\n\t// 添加\r\n\tpublic long " +
                    "Add(");
            
            #line 101 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel ");
            
            #line 101 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write(") {\r\n\t\tdb = helper.getWritableDatabase();\r\n\t\tContentValues values = new ContentVa" +
                    "lues();\r\n\t\ttry {\r\n\t\t\t\t");
            
            #line 105 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Add));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\treturn db.insert(TabName, null, values);\r\n\r\n\t\t} catch (Exception e) {\r\n\t\t\tt" +
                    "hrow e;\r\n\t\t}finally {\r\n\r\n\t\t\tdb.close();\r\n\t\t}\r\n\r\n\t}\r\n\r\n\t// 更新\r\n\tpublic void Updat" +
                    "e(");
            
            #line 118 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel ");
            
            #line 118 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write(") {\r\n\t\tdb = helper.getWritableDatabase();\r\n\t\tContentValues values = new ContentVa" +
                    "lues();\r\n\t\ttry {\r\n\t\t\t");
            
            #line 122 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Update));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\tdb.update(TabName, values, \"_id = ?\",\r\n\t\t\t\t\tnew String[]{String.valueOf(");
            
            #line 124 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName.ToLower()));
            
            #line default
            #line hidden
            this.Write(".get__id())});\r\n\r\n\t\t} catch (Exception e) {\r\n\t\t\tthrow e;\r\n\t\t}finally {\r\n\t\t\t\tdb.cl" +
                    "ose();\r\n\t\t\t}\r\n\t}\r\n\tpublic ");
            
            #line 132 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel getById(int _id) {\r\n\t\tdb = helper.getWritableDatabase();\r\n\t\tCursor curs" +
                    "or=null;\r\n\t\ttry {\r\n\t\t\tcursor = db.query(TabName, new String[] { ");
            
            #line 136 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Con));
            
            #line default
            #line hidden
            this.Write("}, \"_id = ?\",\r\n\t\t\t\t\tnew String[] { String.valueOf(_id)}, null, null, null);\r\n\r\n\t\t" +
                    "\tif (cursor.moveToNext())\r\n\t\t\t\treturn new ");
            
            #line 140 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel(");
            
            #line 140 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Re));
            
            #line default
            #line hidden
            this.Write(@");
			else
				return null;
		}catch (Exception e) {
			throw e;
		} finally {
			if (cursor != null) {
				cursor.close();
				cursor = null;
			}
			db.close();
		}
	}
	public void delete(Integer... id) {
		if (id.length > 0) {
			try {
				StringBuffer sb = new StringBuffer();
				String[] strbid = new String[id.length];
				for (int i = 0; i < id.length; i++) {
					sb.append('?').append(',');
					strbid[i] = String.valueOf(id[i]);
				}
				sb.deleteCharAt(sb.length() - 1);
				db = helper.getWritableDatabase();
				db.delete(TabName, ""_id in ("" + sb + "")"", strbid);
			}catch (Exception e) {
				throw e;
			} finally {
				db.close();
			}
		}
	}

	public List<");
            
            #line 173 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel> getscrollData(int start, int count) {\r\n\t\tList<");
            
            #line 174 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel> Data = new ArrayList<");
            
            #line 174 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel>();\r\n\t\tdb = helper.getWritableDatabase();\r\n\t\tCursor cursor = db.query(T" +
                    "abName, new String[] { ");
            
            #line 176 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Con));
            
            #line default
            #line hidden
            this.Write("}, null, null, null, null,\r\n\t\t\t\t\"_id desc\", start + \",\" + count);\r\n\t\ttry {\r\n\t\t\twh" +
                    "ile (cursor.moveToNext())\r\n\t\t\t\ttry {\r\n\t\t\t\t\tData.add(new ");
            
            #line 181 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel(");
            
            #line 181 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Re));
            
            #line default
            #line hidden
            this.Write("));\r\n\t\t\t\t} catch (Exception e) {\r\n\r\n\t\t\t\t}\r\n\t\t\treturn Data;\r\n\t\t}catch (Exception e" +
                    ") {\r\n\t\t\tthrow e;\r\n\t\t} finally {\r\n\t\t\tif (cursor != null) {\r\n\t\t\t\tcursor.close();\r\n" +
                    "\t\t\t\tcursor = null;\r\n\t\t\t}\r\n\t\t\tdb.close();\r\n\t\t}\r\n\r\n\t}\r\n\r\n\tpublic List<");
            
            #line 198 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel> getData() {\r\n\t\tList<");
            
            #line 199 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel> DataList = new ArrayList<");
            
            #line 199 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel>();\r\n\t\tdb = helper.getWritableDatabase();\r\n\t\tCursor cursor = db\r\n\t\t\t\t.q" +
                    "uery(TabName, new String[]{");
            
            #line 202 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Con));
            
            #line default
            #line hidden
            this.Write("}, null, null, null, null, null);\r\n\t\ttry {\r\n\t\t\twhile (cursor.moveToNext()) {\r\n\t\t\t" +
                    "\ttry {\r\n\t\t\t\t\tDataList.add(new ");
            
            #line 206 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel(");
            
            #line 206 "E:\JiTuan_Project\TepCloud\DotNetCode\Current\FileLoder\T_Android\J_DAOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Re));
            
            #line default
            #line hidden
            this.Write(@"));
				} catch (Exception e) {
					Log.i(""t"", e.toString());
					e.printStackTrace();
				}
			}
			return DataList;
		}catch (Exception e) {
			throw e;
		} finally {
			if (cursor != null) {
				cursor.close();
				cursor = null;
			}
			db.close();
		}

	}
	public long getCount() {
		db = helper.getWritableDatabase();
		Cursor cursor = db.query(TabName, new String[] { ""count(*)"" }, null,
				null, null, null, null);
		try {
			if (cursor.moveToNext()) {
				return cursor.getLong(0);
			}
			return 0;
		}catch (Exception e) {
			throw e;
		} finally {
			if (cursor != null) {
				cursor.close();
				cursor = null;
			}
			db.close();
		}
	}
}
");
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
    public class J_DAOTemplateBase
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
