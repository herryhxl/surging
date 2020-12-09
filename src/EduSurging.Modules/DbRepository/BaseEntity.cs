using System;

namespace EFRepository
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract partial class BaseEntity<T>
    {
        public T Id { set; get; }
        ///// <summary>
        ///// 添加时间
        ///// </summary>
        //public DateTime AddTime { get; set; }
        ///// <summary>
        ///// 更新时间
        ///// </summary>
        //public DateTime UpTime { get; set; }
        ///// <summary>
        ///// 添加用户
        ///// </summary>
        //public int? AddUser { get; set; }
        ///// <summary>
        ///// 更新用户
        ///// </summary>
        //public int? UpUser { get; set; }
        //public static bool operator ==(T lhs, T rhs)
        //{
        //    return lhs.Equals(rhs);
        //}
        //public static bool operator !=(T lhs, T rhs)
        //{
        //   return !lhs.Equals(rhs);
        //}
    }
}
