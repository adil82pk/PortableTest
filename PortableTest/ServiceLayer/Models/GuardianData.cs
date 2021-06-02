namespace ServiceLayer.Models
{
    using System;

    public class GuardianData
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string SectionId { get; set; }
        public string SectionName { get; set; }
        public DateTime WebPublicationDate { get; set; }
        public string WebTitle { get; set; }
        public string WebUrl { get; set; }
        public string ApiUrl { get; set; }
        public bool IsHosted { get; set; }
        public string PillarId { get; set; }
        public string PillarName { get; set; }
    }
}
