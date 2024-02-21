namespace GraduateProjectAPI.DTO
{
    public class InstacesDocumentDto
    {
        public int Id { get; set; }
        public string UserSender { get; set; }
        public string UserExecutor { get; set; }
        public string? Operation {  get; set; }
        public string CommentExecutor { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Executed { get; set; }
        public DateTime? Received { get; set; }
        public int UncompletedPredecessorCount { get; set; }


    }
}
