namespace ProductManagementRestAPI.ExceptionHandling
{
    public class ErrorDetails
    {
        public string Code { get; set; }
        public string ErrorMessage { get; set; }


        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }
    }
}