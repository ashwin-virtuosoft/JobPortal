namespace JobPortal.Model
{
    public class ModerationMaster
    {
        public int ModerationId{  get; set; }
        public string ModerationName {  get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
