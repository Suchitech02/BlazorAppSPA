namespace BlazorAppSPA.Configuration
{
    public class SqlConnectionConfiguration
    {
        public string Value { get; set; }
        public SqlConnectionConfiguration(string value)
        {
            this.Value = value;
        }
    }
}