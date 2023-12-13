namespace DevFreela.Application.Services.Interfaces
{
    public class UpdateProjectInputModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
    
        public void Update()
        {
            Id = Id;
            Title = Title;
            Description = Description;
            TotalCost = TotalCost;
        }
    }
}