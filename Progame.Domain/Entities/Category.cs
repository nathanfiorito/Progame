using Dapper.Contrib.Extensions;
using Progame.Domain.Models.Request.Category;
using System;

namespace Progame.Domain.Entities
{
    [Table("Category")]
    public class Category : EntityBase
    {
        public string CategoryName {get; set;}



        public Category(InsertCategoryRequest request)
        {
            CategoryName = request.CategoryName;
            this.CreatedAt = DateTime.Now;
        }

        public Category()
        {
        }
    }
}
