namespace pj3_api.Repository.Product
{
    public class ProductQuery
    {
       
        public const string GetProduct = "Select * from [Product]";
        public const string InsertProduct = @"Insert into [Product] (
                                            CategoryID,
                                            Name,
                                            Thumbnail,
                                            Description,
                                            CreatedDate,
                                            UpdatedDate,
                                            Deleted
                                            )                                         
                                            VALUES
                                            (
                                            @CategoryID,
                                            @Name,
                                            @Thumbnail,
                                            @Description,
                                            @CreatedDate,
                                            @UpdatedDate,
                                            @Deleted
                                            GETDATE())  
                                            SELECT @ID = SCOPE_IDENTITY()";
        public const string UpdateProduct = @"Update [Product] SET
                                            CategoryID=@CategoryID,
                                            Name=@Name,
                                            Thumbnail=@Thumbnail,
                                            Description=@Description,
                                            CreatedDate=@CreatedDate,
                                            UpdatedDate=@UpdatedDate,
                                            Deleted=@Deleted,
                                            UpdateDate = GETDATE()
                                            WHERE ID = @ID";
        public const string GetProductbyID = "Select * from [Product] WHERE ID = @ID";
    }
}
