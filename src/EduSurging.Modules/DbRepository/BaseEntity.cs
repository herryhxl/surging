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
        ///// ���ʱ��
        ///// </summary>
        //public DateTime AddTime { get; set; }
        ///// <summary>
        ///// ����ʱ��
        ///// </summary>
        //public DateTime UpTime { get; set; }
        ///// <summary>
        ///// ����û�
        ///// </summary>
        //public int? AddUser { get; set; }
        ///// <summary>
        ///// �����û�
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
