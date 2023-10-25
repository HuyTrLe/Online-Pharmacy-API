namespace pj3_api.Repository.Career
{
    public static class CareerQuery
    {
        #region User
       
        public const string GetCareer = @"select * from career where GETDATE() between TimeStart and TimeEnd and status != 1";
        public const string GetAllCareer = @"select * from career";
        public const string GetUser = "Select * from [User] where ID = @UserID";
        public const string GetCareerByID = @"select * from career where ID = @ID";
        public const string InsertCareer = @"INSERT INTO CAREER(
                                            Title,
                                            ShortDescription,
                                            Description,
                                            TimeStart,
                                            TimeEnd,
                                            Position,
                                            Price,
                                            Skill,
                                            Status,
                                            CREATEDDATE
                                            ) VALUES(
                                            @Title,
                                            @ShortDescription,
                                            @Description,
                                            @TimeStart,
                                            @TimeEnd,
                                            @Position,
                                            @Price,
                                            @Skill,
                                            @Status,
                                            GETDATE()
                                            )
                                             SELECT @ID = SCOPE_IDENTITY();
                                            ";
        public const string UpdateCareer = @"Update career set
                                            Title = @Title,
                                            ShortDescription = @ShortDescription,
                                            Description = @Description,
                                            TimeStart = @TimeStart,
                                            TimeEnd = @TimeEnd,
                                            Position = @Position,
                                            Price = @Price,
                                            Skill = @Skill,
                                            Status = @Status,
                                            UpdateDate = GETDATE()
                                            Where ID = @ID
                                            ";
        public const string UpdateStatus = @"Update career set
                                            Status = @Status
                                            Where ID = @ID";
        public const string UpdateStatusCareerJob = @"Update CareerJob set
                                            Status = @Status
                                            Where ID = @ID";


        public const string SelectCareerJob = @"select * from CAREERJOB";
       // public const string SelectCareerJobAdmin = @"select * from CAREERJOB";

        public const string InsertCareerJob = @"INSERT INTO CAREERJOB(
                                            JobID,
                                            UserID,
                                            Status,
                                            CreatedDate
                                            ) VALUES(
                                            @JobID,
                                            @UserID,
                                            @Status,
                                            GETDATE()
                                            )
                                         
                                            ";
        public const string UpdateCareerJob = @"Update CAREERJOB set
                                            Status = @Status
                                            Where ID = @ID";
        public const string GetCareersByUserID = @"select ca.*,caj.Status as StatusJob 
                                                    from Career ca
                                                    left join CareerJob caj on ca.ID = caj.JobID and caj.UserID = @UserID
                                                    where GETDATE() between ca.TimeStart and ca.TimeEnd and ca.status != 1";
        public const string GetCareersDetailByUserID = @"select ca.*,caj.Status as StatusJob 
                                                    from Career ca
                                                    left join CareerJob caj on ca.ID = caj.JobID AND caj.UserID = @UserID
                                                    where ca.ID = @ID";
        #endregion


    }
}
