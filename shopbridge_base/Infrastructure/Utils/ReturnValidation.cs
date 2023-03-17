namespace Shopbridge_base.Infrastructure.Utils
{
    public class ReturnValidation
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public ReturnValidation(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
