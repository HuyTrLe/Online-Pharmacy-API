namespace pj3_api.Model.Product
{
    public class ProductModel
    {
        public int ID { get; set; }

        public int? CategoryID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Thumbnail { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Boolean Deleted { get; set; }
    }
}
