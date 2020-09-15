using System;

namespace DTO
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string ImageDescription { get; set; }
        public string FilePath { get; set; }
        public string MinimalFilePath { get; set; }
        public DateTime? DatePosted { get; set; }
        public bool? IsActive { get; set; }
        public int? HeaderDetailId { get; set; }

        public virtual HeaderDetailDTO HeaderDetail { get; set; }
    }
}
