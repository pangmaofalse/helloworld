﻿using JiangLiQuery.Web.Data;
using JiangLiQuery.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JiangLiQuery.Web.Services
{
    public class EFCoreRepository : IRepository<Student>
    {
        private readonly DataContext _context;
        public EFCoreRepository(DataContext context)
        {
            _context = context;
        }
        public Student Add(Student newModel)
        {
            _context.Students.Add(newModel);
            _context.SaveChanges();
            return newModel;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

    }
}
