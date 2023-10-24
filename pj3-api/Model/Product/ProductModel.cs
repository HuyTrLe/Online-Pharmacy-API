﻿namespace pj3_api.Model.Product
{
    public class ProductModel
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }

        public string Name { get; set; }

        public string Thumbnail { get; set; }

        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Boolean Deleted { get; set; }


    }
	public class ProductGet
	{
		public int ID { get; set; }

        public int CategoryID { get; set; }
	}
}
