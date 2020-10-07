using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class CoporateCitizenCategoryDTO
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DatePosted { get; set; }

        public virtual ICollection<CoporateCitizenContentDTO> CoporateCitizenContents { get; set; }
    }
}
