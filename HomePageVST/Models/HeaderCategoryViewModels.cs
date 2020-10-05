namespace HomePageVST.Models
{
    public class HeaderCategoryViewModels
    {
        public int HeaderCategoryId { get; set; }
        public string HeaderCategoryName { get; set; }
        public int HeaderDetailId { get; set; }
        public string HeaderDetailName { get; set; }
        public string HeaderDetailAlias { get; set; }
        public int? ParentId { get; set; }
    }
}