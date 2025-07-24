namespace RestAPI.VMs
{
    public class SearchGroup
    {
        public int? GroupId { get; set; }

        public string? Name { get; set; } 

        public int? YearId { get; set; }

        public int? LevelId { get; set; }

        public int? MajorId { get; set; }

        public int? ParentGroupId { get; set; }
    }
}
