namespace pj3_api.Repository.ProductImage
{
    public class ProductImageQuery
    {
       
        public const string GetProductImage = "Select * from [ProductImage] ORDER BY ProductID";
        public const string InsertProductImage = @"Insert into [ProductImage] (
                                            ProductID,
                                            Image
                                            )                                         
                                            VALUES
                                            (
                                            @ProductID,
                                            @Image
                                            )
                                            SELECT @ID = SCOPE_IDENTITY()";
        public const string UpdateProductImage = @"Update [ProductImage] SET
                                            ProductID=@ProductID,
                                            Image=@Image                                  
                                            WHERE ID = @ID";
        public const string GetProductImagebyID = "Select * from [ProductImage] WHERE ID = @ID";

        public const string CheckProductImage = "Select * from [ProductImage] WHERE ProductID = @ProductID";

        public const string DeleteImage = @"Delete from [ProductImage] where ID = @ID";
    }
}
