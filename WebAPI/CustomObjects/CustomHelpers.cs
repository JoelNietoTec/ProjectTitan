namespace WebAPI.CustomObjects
{
    public class CustomHelpers
    {
        public string IsNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            return value;
        }
    }
}