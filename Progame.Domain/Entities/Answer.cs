using Dapper.Contrib.Extensions;
using Progame.Domain.Models.Request.Answer;
using Progame.Domain.Models.Request.Category;
using System;

namespace Progame.Domain.Entities
{
    [Table("Answer")]
    public class Answer : EntityBase
    {
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }



        public Answer(InsertAnswerRequest request)
        {
            AnswerText = request.AnswerText;
            QuestionId = request.QuestionId;
            this.CreatedAt = DateTime.Now;
        }

        public Answer(UpdateAnswerRequest request)
        {
            AnswerText = request.AnswerText;
            QuestionId = request.QuestionId;
            this.UpdatedAt = DateTime.Now;
        }

        public Answer()
        {
        }
    }
}
