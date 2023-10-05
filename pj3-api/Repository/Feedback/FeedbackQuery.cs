namespace pj3_api.Repository.Feedback
{
    public class FeedbackQuery
    {
        public const string GetFeedback = "Select * from [FeedBack]";

        public const string InsertFeedback = @"Insert into [FeedBack] (
                                            FullName,
                                            CompanyName,
                                            Email,
                                            PhoneNumber,
                                            Subject,
                                            Comment,
                                            CreateDate)                                         
                                            VALUES
                                            (
                                            @FullName,
                                            @CompanyName,
                                            @Email,
                                            @PhoneNumber,
                                            @Subject,
                                            @Comment,
                                            GETDATE())  
                                            SELECT @ID = SCOPE_IDENTITY()";
    }
}
