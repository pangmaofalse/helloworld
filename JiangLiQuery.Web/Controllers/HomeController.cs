using JiangLiQuery.Web.Model;
using JiangLiQuery.Web.Services;
using JiangLiQuery.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JiangLiQuery.Web.Controllers
{ 
    public class HomeController :Controller //Home为MVC默认类
    {
        private readonly IRepository<Student> _repository;

        public HomeController(IRepository<Student> repository) {
            _repository = repository;
        }
    
        public IActionResult Index() {

            /*
            var st = new Student { 
                Id=1,
                FirstName = "Nick",
                LastName = "Carter"
            };
            */
            var list = _repository.GetAll();
            var st = list.Select(x => new StudentViewModel { 
                Id=x.Id,
                Name=$"{x.FirstName}{x.LastName}",
                Age=DateTime.Now.Subtract(x.BirthDate).Days/365
            });
            var vm = new HomeIndexViewModel {
                Students = st
            };

            return View(vm);
            //return new ObjectResult(st);
            //return this.Content("Hello from home controller");
            //return "Hello from HomeController";
        }

        public IActionResult Detail(int id) {

            var student = _repository.GetById(id);
            if (student == null) {
                RedirectToAction(nameof(Index));
               // return View("Not Found");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//防止跨站
        public IActionResult Create(StudentCreateViewModel student) {
            if (ModelState.IsValid)
            {
                var st = new Student
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    BirthDate = student.BirthDate,
                    gender = student.gender
                };
                var newModel = _repository.Add(st);

                //return View("Detail",newModel);
                return RedirectToAction(nameof(Detail), new { id = newModel.Id });
            }
            else {
               
                return View();
            }
        }
    }
}
