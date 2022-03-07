namespace ProjectManager.Application.Services
{
    public interface IAuthService
    {
        Task<string> CreateToken(string login, string password);
        string GetHash(string value);
    }
}
