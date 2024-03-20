namespace JobPortal.Model
{
    public class UserLoginDetails
    {
        public int UserLoginId {  get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
