namespace MagicOKRs.Controllers
{
    public class Objective
    {
        public required Guid ObjectiveId { get; set; }
        public DateOnly CreationDate { get; set; }
        public required string ObjectiveTitle { get; set; }
        public required string ObjectiveStatement { get; set; }
        public string? ObjectiveDescription { get; set; }
        public required string ObjectiveCategorie {get; set;}
        public required string ObjectiveOwnerId {get; set;}
        public required string ObjectiveDuration {get; set;}
    }
}