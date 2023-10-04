namespace pj3_api.Repository.User
{
    public static class UserQuery
    {
        public const string GetUserByEmailPassword = "Select * from [User] where Email = @Email and Password = @Password";
        public const string GetUser = "Select * from [User]";
        public const string InsertUser = @"Insert into [User] (
                                            UserName,
                                            Email,
                                            PhoneNumber,
                                            Address,
                                            Password,
                                            RoleID,
                                            Education,
                                            CreateDate)                                         
                                            VALUES
                                            (
                                            @UserName,
                                            @Email,
                                            @PhoneNumber,
                                            @Address,
                                            @Password,
                                            @RoleID,
                                            @Education,
                                            GETDATE())  
                                            SELECT @ID = SCOPE_IDENTITY()";
        public const string UpdateUserByID = @"Update [User] SET
                                            UserName = @UserName,
                                            Email = @Email,
                                            PhoneNumber = @PhoneNumber,
                                            Address = @Address,
                                            Password = @Password,
                                            RoleID = @RoleID,
                                            Education = @Education,
                                            UpdateDate = GETDATE()
                                            WHERE ID = @ID";
        public const string DeactiveUser = "Select * from [User]";

    }
}
