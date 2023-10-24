namespace pj3_api.Model.User
{
    public class UserModelResult
    {
        public UserModel UserModel { get; set; }
        public List<Education> Education { get; set; }
    }
    public class UserModelUpdateRole
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
    }

}
