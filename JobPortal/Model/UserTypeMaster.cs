namespace JobPortal.Model
{
    public class UserTypeMaster
    {
        public int UserTypeId {  get; set; }
        public string UserType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
