namespace Progame.Domain.Entities
{
    public class Module : EntityBase
    {
        public string ModuleName { get; set; }
        public string SupportText { get; set; }
        public string ImgUrl { get; set; }
        public string Resume { get; set; }
        public int CategoryId { get; set; }
    }
}
