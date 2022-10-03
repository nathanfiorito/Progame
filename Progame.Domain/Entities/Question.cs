namespace Progame.Domain.Entities
{
    public class Question : EntityBase
    {
        public string QuestionText {get;set;}
        public int ModuleId { get; set; }
        public int CorrectAnswerId { get; set; }
        public int QuestionTypeId { get; set; }
    }
}
