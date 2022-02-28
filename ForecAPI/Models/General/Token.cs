namespace ForecAPI.Models.General
{
    public class Token
    {
            public string Tokenstring { get; set; }
            public DateTime Expiration { get; set; }
            public ApplicationUser CurrentUser { get; set; }
            public string ErrorMessage { get; set; }

        
    }
}
