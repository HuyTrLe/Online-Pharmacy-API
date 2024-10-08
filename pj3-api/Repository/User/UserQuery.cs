﻿namespace pj3_api.Repository.User
{
    public static class UserQuery
    {
        #region User
        public const string GetUserByEmailPassword = "Select * from [User] where Email = @Email and Password = @Password";
        public const string GetUser = "Select * from [User] where ID = @ID";
        public const string GetAllUser = "Select * from [User]";
        public const string GetEducation = "Select * from [Education] where UserID = @UserID";
        public const string InsertUser = @"Insert into [User] (
                                            UserName,
                                            Email,
                                            PhoneNumber,
                                            Address,
                                            Password,
                                            RoleID,
                                            CreateDate)                                         
                                            VALUES
                                            (
                                            @UserName,
                                            @Email,
                                            @PhoneNumber,
                                            @Address,
                                            @Password,
                                            @RoleID,
                                            GETDATE())  
                                            SELECT @ID = SCOPE_IDENTITY()";
        public const string UpdateUserByID = @"Update [User] SET
                                            UserName = @UserName,
                                            Email = @Email,
                                            PhoneNumber = @PhoneNumber,
                                            Address = @Address,
                                            UpdateDate = GETDATE()
                                            WHERE ID = @ID";
        public const string UpdateRoleID = @"Update [User] SET
                                            RoleID = @RoleID
                                            WHERE ID = @ID";
        public const string CheckPassword = "Select * from [User] where ID = @UserID and Password = @Password";
        public const string ChangePassword = @"Update [User] Set
                                                Password = @Password
                                                Where ID = @UserID";
        public const string UpdateFilename = @"Update [User] Set
                                                FileName = @FileName
                                                Where ID = @UserID";
        public const string DeleteEducation = @"DELETE FROM Education where ID = @ID";
        #endregion

        #region Role
        public const string InsertRole = @"Insert into Role(Name) VALUES (@Name)";
        public const string GetRole = @"Select * from Role";
        public const string UpdateRole = @"Update Role set Name = @Name where ID = @ID";
        #endregion

        #region Career
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
        #endregion

        #region Education
        public const string InsertEducation = @"Insert into Education(
                                                UserID,
                                                SchoolName,
                                                SchoolType,
                                                Degree,
                                                [From],
                                                [To])
                                                VALUES(
                                                @UserID,
                                                @SchoolName,
                                                @SchoolType,
                                                @Degree,
                                                @From,
                                                @To)";        
        public const string UpdateEducation = @"Update Education set 
                                                SchoolName = @SchoolName,
                                                SchoolType = @SchoolType,
                                                Degree = @Degree,
                                                [From] = @From,
                                                [To] = @To
                                                where ID = @ID";
        #endregion
    }
}
