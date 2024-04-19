using JobPortal.Model;
using JobPortal.Repository;

namespace JobPortal.services
{
    public class UserTypeService
    {
        private readonly IUserTypeInsert _userTypeInsert;

        public UserTypeService(IUserTypeInsert userTypeInsert)
        {
            _userTypeInsert = userTypeInsert;
        }

        public async Task<bool> UserTypeInsert(UserTypeMaster userTypeMaster)
        {
            return await _userTypeInsert.InsertUserType(userTypeMaster);
        }
    }
}
