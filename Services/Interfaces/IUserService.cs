namespace Services.Interfaces
{
    public interface IUserService
    {
        bool verifyUser(string password, string foundUserHash);
        string generatePasswordHash(string password);
    }
}
