using System;

namespace Library
{
    public interface IDataGenerator
    {
        void Generate(Action action, int amount);
        void GenerateUsers(int librarians, int members);
    }
}