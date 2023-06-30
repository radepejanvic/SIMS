namespace Library.Service.TehnicalService.Interface
{
    public interface ILoginService
    {
        void Login(string username, string Password, MainViewModel mainViewModel);
        void LoginDirector(MainViewModel mainViewModel);
        void LoginDoctor(MainViewModel mainViewModel, string username);
        void LoginNurse(MainViewModel mainViewModel);
        void LoginPatient(MainViewModel mainViewModel, string username);
    }
}