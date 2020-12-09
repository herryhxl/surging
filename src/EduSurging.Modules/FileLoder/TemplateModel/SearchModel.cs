namespace FileLoder.TemplateModel
{
    public class SearchModel
    {
        public string SearchName { get; set; }
        public string SearchType { get; set; }
        public SearchType Type { get; set; }

        public bool EM { set; get; }
    }

    public enum SearchType
    {
        In,
        Like,
        Equal,
        Range,
        Null
    }
}