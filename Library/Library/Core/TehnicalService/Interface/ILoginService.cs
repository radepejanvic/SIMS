using Library.Core.Model;

namespace Library.Core.TehnicalService.Interface
{
    public interface ILoginService
    {
        User? Login(string username, string password);
    }
}