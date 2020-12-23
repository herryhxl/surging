using System;
using System.Collections.Generic;
using System.Linq;
namespace Edu.Surging.Models.SuperUser.Base
{

	public class SuperUser_E
    {
		#region 枚举转换方法
        /// <summary>
        /// 枚举转换成List
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<EModel> GetListModelEnum(System.Type t)
        {
            List<EModel> l = new List<EModel>();
            Array arr = Enum.GetValues(t);
            for (int i = 0; i < arr.LongLength; i++)
            {
                EModel m = new EModel();
                m.Value = (int)arr.GetValue(i);
                m.Key = Enum.GetName(t, m.Value).StartsWith("_")?Enum.GetName(t, m.Value).Substring(1,Enum.GetName(t, m.Value).Length-1).Replace("_","-"):Enum.GetName(t, m.Value);
                l.Add(m);
            }
            l = l.OrderBy(e => e.Value).ToList();
            return l;
        }
        #endregion
        /// <summary>
        /// 枚举模型
        /// </summary>
        public class EModel
        {
            public string Key { get; set; }
            public int Value { get; set; }
        }
        
		
        public enum SuperUser_PwType
		{
		/// <summary>
		/// MD5
		/// </summary>
			MD5=1,
					/// <summary>
		/// AES
		/// </summary>
			AES=2,
					/// <summary>
		/// Sm3
		/// </summary>
			Sm3=3,
					/// <summary>
		/// Sm2
		/// </summary>
			Sm2=4	}
		
        public enum SuperUser_RegFrom
		{
		/// <summary>
		/// 暂无
		/// </summary>
			暂无=0,
					/// <summary>
		/// React网页端
		/// </summary>
			React网页端=1,
					/// <summary>
		/// Web网页端
		/// </summary>
			Web网页端=2,
					/// <summary>
		/// Android客户端
		/// </summary>
			Android客户端=3,
					/// <summary>
		/// IOS客户端
		/// </summary>
			IOS客户端=4,
					/// <summary>
		/// Windows客户端
		/// </summary>
			Windows客户端=5,
					/// <summary>
		/// Mac客户端
		/// </summary>
			Mac客户端=6,
					/// <summary>
		/// 其它
		/// </summary>
			其它=7	}
		
        public enum SuperUser_Status
		{
		/// <summary>
		/// 等待审核
		/// </summary>
			等待审核=1,
					/// <summary>
		/// 正常
		/// </summary>
			正常=2,
					/// <summary>
		/// 禁用
		/// </summary>
			禁用=3,
					/// <summary>
		/// 用户锁定
		/// </summary>
			用户锁定=4,
					/// <summary>
		/// 重置密码
		/// </summary>
			重置密码=5	}
		
        public enum SuperUser_PassWordLevel
		{
		/// <summary>
		/// 低
		/// </summary>
			低=0,
					/// <summary>
		/// 中
		/// </summary>
			中=1,
					/// <summary>
		/// 高
		/// </summary>
			高=2	}
		
        public enum SuperUserInfo_Sex
		{
		/// <summary>
		/// 男
		/// </summary>
			男=1,
					/// <summary>
		/// 女
		/// </summary>
			女=2	}
	}
}
