﻿namespace pj3_api.Model.Education
{
    public class Education
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string SchoolName { get; set; }
        public string SchoolType { get; set; }
        public string Degree { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}