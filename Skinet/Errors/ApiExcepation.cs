namespace API.Errors
{
    public class ApiExcepation:ApiResponse
    {
        public ApiExcepation(int statusCode, string message = null,string details=null) : base(statusCode, message)
        {
            Details = details;
        }

        public String Details {  get; set; }
    }
}
