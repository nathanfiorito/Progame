using Dapper.Contrib.Extensions;

namespace Progame.Domain.Entities
{
    [Table("Category")]
    public class Category : EntityBase
    {
        public string CategoryName {get; set;}
    }
}
