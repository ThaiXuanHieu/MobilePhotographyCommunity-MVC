using MobilePhotographyCommunity.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Data.ViewModel
{
    public class CategoryVm
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Tên danh mục không được để trống")]
        [MinLength(4, ErrorMessage ="Tên danh mục phải ít nhất 4 ký tự")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Mô tả danh mục không được để trống")]
        [MinLength(10, ErrorMessage = "Mô tả danh mục phải ít nhất 10 ký tự")]
        public string Description { get; set; }

        public string MetaTitle { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public User User { get; set; }
    }
}
