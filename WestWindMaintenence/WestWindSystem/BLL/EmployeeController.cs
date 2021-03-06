﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindModels;
using WestWindSystem.DAL;

namespace WestWindSystem.BLL
{
    public class EmployeeController
    {
        public List<Employee> ListEmployees()
        {
            using (var context = new WestWindContext())
            {
                return context.Employees.ToList();
            }
        }
    }
}
