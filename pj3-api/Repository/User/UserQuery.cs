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
        public const string InsertRole = @"Insert into Role(Name) VALUES (@Name)";
        public const string GetRole = @"Select * from Role";
        public const string UpdateRole = @"Update Role set Name = @Name where ID = @ID";
        public const string InsertCareer = @"Insert into Career(
                                                UserID,
                                                File,
                                                Status,
                                                CreateDate)
                                                VALUES(
                                                @UserID,
                                                @File,
                                                @Status,
                                                GETDATE())";
        public const string GetCareer = @"select * from Career order by ID desc";
        public const string GetCareerByUserID = @"select * from Career where UserID = @UserID order by ID desc";
        public const string UpdateCareer = @"Update Career set Status = @Status where ID = @ID";
    }
}
