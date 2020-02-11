using JiangLiQuery.Web.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JiangLiQuery.Web.ViewModels
{
    public class StudentCreateViewModel
    {
        [Display(Name = "名")] //[DataType(DataType.Password)]
        [Required(ErrorMessage ="请输入名")]
        public string FirstName { get; set; }

        [Display(Name = "姓"), Required(ErrorMessage="请输入姓"),MaxLength(10)]
        public string LastName { get; set; }

        [Display(Name = "出生日期")]
        [DataType(DataType.Date,ErrorMessage ="请输入正确的出生日期")]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-MM-dd}",NullDisplayText ="1990-01-01")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "性别")]
        [Required(ErrorMessage ="请选择性别")]
        public Gender gender { get; set; }
    }
}
