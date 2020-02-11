using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JiangLiQuery.Web.Controllers
{
    [Route("about")]
    public class AboutController
    {
        [Route("")]
        public string Me()
        {

            return "Me";
        }

        [Route("company")]
        public string Company() {
            return "Company";
        }
    }
}
