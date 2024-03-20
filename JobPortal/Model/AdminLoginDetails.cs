namespace JobPortal.Model
{
    public class AdminLoginDetails
    {
        public int AdminLoginId {  get; set; }
        public string password {  get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
