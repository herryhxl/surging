using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Surging.EntityFramework
{
    public class BaseCondition
    {
        /// <summary>
		/// 页码
		/// </summary>
		public int? Page { get; set; }
        /// <summary>
        /// 每页大小
        /// </summary>
        public int? PageCount { get; set; }
        /// <summary>
        /// 是否降序
        /// </summary>
        public bool IsDescending { get; set; }

        public bool IsAll { get; set; }

        public bool ExportData { set; get; }
    }
    public class RequestBeach<T>
    {
        public List<T> List { set; get; }
    }
    public class RequestBeachModel<T> : RequestBeach<T>
    {
        public string FieldName { set; get; }
        public string Value { set; get; }
    }
    public class RequestModel<T>
    {
        /// <summary>
        /// 数据编号
        /// </summary>
        public T Id { set; get; }
        //public T ApplyID { set; get; }
        //public T Value { set; get; }
    }
}
