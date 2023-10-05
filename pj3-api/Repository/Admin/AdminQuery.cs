namespace pj3_api.Repository.Admin
{
    public static class AdminQuery
    {
        public const string GetMovies = "Select * from Movie";

        public const string GetMoviesByID = "Select * from Movie where ID = @ID";

        public const string InsertMovie = @"Insert into Movie (
                                            Name,
                                            Description,
                                            Year,
                                            Image)                                         
                                            VALUES
                                            (
                                            @Name,
                                            @Description,
                                            @Year,
                                            @Image)
                                            SELECT @ID = SCOPE_IDENTITY()";

    }
}
