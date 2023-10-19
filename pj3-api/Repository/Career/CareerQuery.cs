namespace pj3_api.Repository.Career
{
    public static class CareerQuery
    {
        #region User
       
        public const string GetCareer = @"select * from career";
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
                                            Status
                                            ) VALUES(
                                            @Title,
                                            @ShortDescription,
                                            @Description,
                                            @TimeStart,
                                            @TimeEnd,
                                            @Position,
                                            @Price,
                                            @Skill,
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
                                            Status = @Status
                                            Where ID = @ID
                                            ";
        public const string UpdateStatus = @"Update career set
                                            Status = @Status
                                            Where ID = @ID";


        public const string SelectCareerJob = @"select * from CAREERJOB";

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
        #endregion


    }
}
