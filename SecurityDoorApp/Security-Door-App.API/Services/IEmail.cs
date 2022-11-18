namespace Security_Door_App.API.Services
{
    public interface IEmail
    {
        Task<bool> SendEmailAsync(string email,string confirmLink);
       
    }
}
