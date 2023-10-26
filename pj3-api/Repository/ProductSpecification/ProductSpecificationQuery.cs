namespace pj3_api.Repository.ProductSpecification
{
    public class ProductSpecificationQuery
    {
       
        public const string GetProductSpecification = "Select * from [ProductSpecification] ORDER BY ProductID";
        public const string InsertProductSpecification = @"Insert into [ProductSpecification] (
                                            ProductID,
                                            SpecID,
                                            SpecName,
                                            SpecValue,
                                            SpecUnit
                                            )                                         
                                            VALUES
                                            (
                                            @ProductID,
                                            @SpecID,
                                            @SpecName,
                                            @SpecValue,
                                            @SpecUnit )
                                            SELECT @ID = SCOPE_IDENTITY()";
        public const string UpdateProductSpecification = @"Update [ProductSpecification] SET
                                            ProductID=@ProductID,
                                            SpecID=@SpecID,
                                            SpecName=@SpecName,
                                            SpecValue=@SpecValue,
                                            SpecUnit=@SpecUnit
                                            WHERE ID = @ID";
        public const string GetProductSpecificationByID = "Select * from [ProductSpecification] WHERE ID = @ID";

        public const string DeleteProductSpecification = @"Delete from [ProductSpecification] where ID = @ID";

        public const string CheckSpecName = @"Select * from [ProductSpecification] where ProductID = @ProductID AND SpecName = @SpecName";

        public const string CheckSpecCount = "Select * from [ProductSpecification] WHERE ProductID = @ProductID";
    }
}
