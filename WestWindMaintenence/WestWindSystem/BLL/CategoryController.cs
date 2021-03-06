﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WestWindModels;
using WestWindSystem.DAL;
using WestWindSystem.DataModels;

namespace WestWindSystem.BLL
{
    [DataObject]
    public class CategoryController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Category> ListCategories()
        {
            using (var context = new WestWindContext())
            {
                return context.Categories.ToList();
            }
        }

        public List<DropDownSelection<int>> ListCategoriesNameAndId()
        {
            using (var context = new WestWindContext())
            {
                string sql = "SELECT CategoryID AS 'Value', CategoryName AS 'Text' FROM Categories ORDER BY CategoryName";
                var result = context.Database.SqlQuery<DropDownSelection<int>>(sql);
                return result.ToList();
            }
        }
    }
}
