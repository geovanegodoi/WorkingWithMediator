namespace ReportsGeneratorEngine.Models
{
    public class EmailModel
    {
        
    }

    public class EmailResponse
    {
        public EmailResponse(int code)
        {
            Code = code;
        }

        public int Code { get; set; }
        public string Message { get; set; }
        public bool IsOk() => Code == 0;
    }
}
