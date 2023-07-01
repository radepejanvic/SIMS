namespace Library.GUI.Helpers.Generator
{
    public interface IUserGenerator
    {
        void GenerateMembershipCards(int start, int length);
        void GenerateMemberships();
        void GenerateUsers(int librarians, int members);
    }
}