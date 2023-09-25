namespace pj3_api.Model
{
    public class AppSettings
    {
        public MSSQLSettings MSSQLSettings { get; set; }
    }
    public class MSSQLSettings
    {
        public string SQLConnectionString { get; set; }
    }
}
