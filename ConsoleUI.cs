namespace Homework7
{
    internal class ConsoleUI : ContactBookUI
    {

        public bool EnterBool(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine().ToLower().Equals("да");
        }

        public Contact EnterContact(string prompt)
        {
            Console.WriteLine(prompt);
            string name = EnterString("Введите имя контакта: ");
            PhoneNumber number = EnterNumber("Введите номер контакта: ");
            return new Contact(name, number);
        }

        public PhoneNumber EnterNumber(string prompt)
        {
            Console.Write(prompt);
            string number = Console.ReadLine();
            return new PhoneNumber(number);
        }

        public string EnterString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public int GetCommand()
        {
            Console.Write("Введите номер команды: ");
            string commString = Console.ReadLine();
            bool isGood = true;
            int num = 0;
            try
            {
                num = Int32.Parse(commString);
                if (num < 0 || num > 10)
                {
                    isGood = false;
                }
            }
            catch (FormatException)
            {
                isGood = false;
            }
            if (isGood)
            {
                return num;
            }
            throw new NotACommandException("Некорректная команда.");
        }

        public void ShowMenu()
        {
            Console.WriteLine("Команды:");
            Console.WriteLine("0 - выход;");
            Console.WriteLine("1 - показать справочник;");
            Console.WriteLine("2 - добавить контакт;");
            Console.WriteLine("3 - добавить номер в контакт;");
            Console.WriteLine("4 - изменить имя контакта;");
            Console.WriteLine("5 - изменить первый номер в контакте;");
            Console.WriteLine("6 - изменить указанный номер в контакте;");
            Console.WriteLine("7 - удалить номер из контакта;");
            Console.WriteLine("8 - удалить контакт из справочника;");
            Console.WriteLine("9 - экспортировать справочник в указанном формате;");
            Console.WriteLine("10 - импортировать справочник из указанного файла.");
        }

        public void ShowString(string message)
        {
            Console.WriteLine(message);
        }
    }
}
