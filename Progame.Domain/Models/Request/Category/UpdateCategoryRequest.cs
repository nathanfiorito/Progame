﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Models.Request.Category
{
    public class UpdateCategoryRequest : BaseRequest
    {
        public string CategoryName {get;set;}
    }
}