using Dapper.Contrib.Extensions;
using Progame.Domain.Models.Request.QuestionType;
using System;

namespace Progame.Domain.Entities
{
    [Table("QuestionType")]
    public class QuestionType : EntityBase
    {
        public string Type { get; set; }

        public QuestionType(InsertQuestionTypeRequest request)
        {
            Type = request.Type;
            CreatedAt = DateTime.Now;
        }

        public QuestionType(UpdateQuestionTypeRequest request)
        {
            Type = request.Type;
            UpdatedAt = DateTime.Now;
        }

        public QuestionType()
        {
        }
    }
}
