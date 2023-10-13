namespace MagicOKRs.Controllers
{
    public class KeyResult
    {
        public required Guid KeyResultId { get; set; }
        public required Guid ObjectiveId { get; set; }
        public required string KeyResultTitle {get; set;}
        public required string KeyResultStatement {get; set;}
        public string? KeyResultDescription {get; set;}
        public required string KeyResultCategorie {get; set;}
        public required string KeyResultOwnerId {get; set;}

    }
}