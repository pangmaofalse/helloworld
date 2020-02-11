using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JiangLiQuery.Web.Model;
using JiangLiQuery.Web.Services;

namespace JiangLiQuery.Web.ViewComponents
{
    public class WelcomeViewComponent:ViewComponent
    {
        private readonly IRepository<Student> _repository;

        public WelcomeViewComponent(IRepository<Student> repository) {
            _repository = repository;
        }

        public IViewComponentResult Invoke() {
            var count =  _repository.GetAll().Count().ToString();
            return View("Default",count);
        }
    }
}
