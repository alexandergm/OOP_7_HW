namespace Homework7
{
    internal interface ContactBookUI
    {
        void ShowString(string message);
        void ShowMenu();
        int GetCommand();
        Contact EnterContact(string prompt);
        PhoneNumber EnterNumber(string prompt);
        String EnterString(string prompt);
        bool EnterBool(string prompt);
    }
}
