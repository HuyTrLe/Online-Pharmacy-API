﻿namespace pj3_api.Repository.Category
{
    public class CategoryQuery
    {
        public const string GetCategory = "Select * from [Category]";
        public const string InsertCategory = @"Insert into [Category] (
                                            Name
                                            )                                         
                                            VALUES
                                            (
                                            @Name
                                            )
                                            SELECT @ID = SCOPE_IDENTITY()";
        public const string UpdateCategory = @"Update [Category] SET
                                            Name=@Name
                                            
                                            WHERE ID = @ID";
        public const string GetCategorybyID = "Select * from [Category] WHERE ID = @ID";
    }
}
