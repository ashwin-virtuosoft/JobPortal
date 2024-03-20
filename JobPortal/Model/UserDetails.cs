namespace JobPortal.Model
{
    public class UserDetails
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber {  get; set; }
        public int CreatedBy {  get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set;}
        public int Status { get; set; }
        public string Remark {  get; set; }
        
    }
}
