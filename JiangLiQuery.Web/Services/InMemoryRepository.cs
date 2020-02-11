using JiangLiQuery.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JiangLiQuery.Web.Services
{
    public class InMemoryRepository : IRepository<Student>
    {

        private List<Student> _students;

        public InMemoryRepository() { 
            _students= new List<Student> {
                new Student{
                    Id=1,
                    FirstName="Nick",
                    LastName="Carter",
                    BirthDate=new DateTime()
               },
                new Student{
                    Id=2,
                    FirstName="Jack",
                    LastName="Tang",
                    BirthDate=Convert.ToDateTime("1990-04-01")
                },
                new Student{
                    Id=3,
                    FirstName="Pangmao",
                    LastName="Yu",
                    BirthDate=Convert.ToDateTime("2010-01-01")
                }
            };
        }

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            return _students.FirstOrDefault(x =>x.Id==id);
        }

        public Student Add(Student newModel) {

            var maxId = _students.Max(x => x.Id);
            newModel.Id = maxId + 1;
            _students.Add(newModel);
            return newModel;
        }
    }
}
