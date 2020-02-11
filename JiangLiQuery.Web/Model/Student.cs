using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JiangLiQuery.Web.Model
{
    public class Student
    {
        public int Id { get; set; }

         //[DataType(DataType.Password)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender gender { get; set; }
    }
}
