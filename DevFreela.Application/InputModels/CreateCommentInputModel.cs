namespace DevFreela.Application.Services.Interfaces
{
    public class CreateCommentInputModel
    {
        public string Content { get; set; }
        public int IdUser { get; set; }
        public int IdProject { get; set; }
    }
}