namespace BlazorAppSPA.Configuration
{
    public class SqlConnectionConfiguration
    {
        public string value { get; set; }
        public SqlConnectionConfiguration(string value) =>this.value = value;
       
    }
}