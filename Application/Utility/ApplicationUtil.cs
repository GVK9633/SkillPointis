namespace Application.Utility
{
    public class ApplicationUtil
    {
        public string GenerateEmailVerificationToken()
        { 
          // Generate a token (e.g., JWT or a GUID) 
          return Guid.NewGuid().ToString(); 
        }
    }
}
