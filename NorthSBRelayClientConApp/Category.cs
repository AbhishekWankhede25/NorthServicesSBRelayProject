﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthServices
{
    public class Category
    {


        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return string.Format($"CategoryID: {CategoryID}, CategoryName: {CategoryName}, Description: {Description}");
        }
    }
}
