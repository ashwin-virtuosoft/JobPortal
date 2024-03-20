namespace JobPortal.Model
{
    public class Admin
    {
        public int AdminId {  get; set; }
        public string Email {  get; set; }
        public string EmployeeNo { get; set; }
        public string Designation { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
