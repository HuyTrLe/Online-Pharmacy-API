namespace pj3_api.Repository.Specification
{
    public class SpecificationQuery
    {
        public const string GetSpecification = "Select * from [Specification]";
        public const string InsertSpecification = @"Insert into [Specification] (
                                            Name,
                                            Unit
                                            )                                         
                                            VALUES
                                            (
                                            @Name,
                                            @Unit                   
                                            )
                                            SELECT @ID = SCOPE_IDENTITY()";
        public const string UpdateSpecification = @"Update [Specification] SET
                                            Name=@Name,
                                            Unit=@Unit                                      
                                            WHERE ID = @ID";
        public const string GetSpecificationByID = "Select * from [Specification] WHERE ID = @ID";

        public const string DeleteSpecification = @"Delete from [Specification] where ID = @ID";

        public const string CheckUniqueByName = @"Select * from [Specification] where Name = @Name";
    }
}
