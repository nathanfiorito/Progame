using Dapper.Contrib.Extensions;
using Progame.Domain.Models.Request.Question;
using System;

namespace Progame.Domain.Entities
{
    [Table("Question")]
    public class Question : EntityBase
    {
        public string QuestionText {get;set;}
        public int ModuleId { get; set; }
        public int? CorrectAnswerId { get; set; }
        public int QuestionTypeId { get; set; }



        public Question(UpdateQuestionRequest request)
        {
            QuestionText = request.QuestionText;
            ModuleId = request.ModuleId;
            CorrectAnswerId = request.CorrectAnswerId == 0 ? null : request.CorrectAnswerId;
            QuestionTypeId = request.QuestionTypeId;
            UpdatedAt = DateTime.Now;
        }

        public Question(InsertQuestionRequest request)
        {
            QuestionText = request.QuestionText;
            ModuleId = request.ModuleId;
            CorrectAnswerId = request.CorrectAnswerId == 0 ? null : request.CorrectAnswerId;
            QuestionTypeId = request.QuestionTypeId;
            CreatedAt = DateTime.Now;
        }

        public Question()
        {
        }
    }
}
