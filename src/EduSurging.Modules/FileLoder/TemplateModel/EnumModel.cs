using System.Collections.Generic;

namespace FileLoder.TemplateModel
{
    public class EnumModel
    {
        /// <summary>
        ///     枚举名称
        /// </summary>
        public string EnumName { get; set; }

        /// <summary>
        ///     枚举内容
        /// </summary>
        public List<EnumValueModel> Values { get; set; }
    }

    public class EnumValueModel
    {
        public int Attribute { get; set; }
        public string Description { get; set; }
    }
}