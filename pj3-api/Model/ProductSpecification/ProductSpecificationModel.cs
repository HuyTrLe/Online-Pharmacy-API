namespace pj3_api.Model.ProductSpecification
{
    public class ProductSpecificationModel
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

       public int SpecID { get; set; }

        public string SpecName { get; set; }

        public string SpecValue { get; set; }

        public string SpecUnit { get; set; }
    }
}
