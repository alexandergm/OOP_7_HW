using System.Text;

namespace Homework7
{
    internal class Contact
    {
        private readonly static string NO_NUMBER = "В контакте нет указанного номера.";
        private readonly static string DUPLICATE_NUMBER = "Номер уже есть в этом контакте.";
        private string name;
        private List<PhoneNumber> numbers;

        public string GetName()
        {
            return name;
        }

        public List<PhoneNumber> GetNumbers()
        {
            return numbers;
        }

        public Contact(string name, List<PhoneNumber> numbers)
        {
            if (numbers.Count == 0)
            {
                throw new EmptyContactException("Нельзя создать контакт без номеров.");
            }
            this.name = name;
            this.numbers = numbers;
        }

        public Contact(string name, PhoneNumber number)
        {
            this.name = name;
            this.numbers = new List<PhoneNumber>();
            this.numbers.Add(number);
        }

        public void AddNumber(PhoneNumber number)
        {
            if (numbers.Contains(number))
            {
                throw new NumberAlreadyInContactException(DUPLICATE_NUMBER);
            }
            numbers.Add(number);
        }

        public void UpdateName(string newName)
        {
            name = newName;
        }

        public void RemoveNumber(PhoneNumber number)
        {
            if (!numbers.Contains(number))
            {
                throw new NumberDoesNotExistException(NO_NUMBER);
            }
            if (numbers.Count == 1)
            {
                throw new RemovingOnlyNumberException("Нельзя удалять единственный номер в контакте.");
            }
            numbers.Remove(number);
        }

        public void UpdateNumber(PhoneNumber oldNum, PhoneNumber newNum)
        {
            if (!numbers.Contains(oldNum))
            {
                throw new NumberDoesNotExistException(NO_NUMBER);
            }
            if (numbers.Contains(newNum))
            {
                throw new NumberAlreadyInContactException(DUPLICATE_NUMBER);
            }
            int index = numbers.IndexOf(oldNum);
            numbers.RemoveAt(index);
            numbers.Insert(index, newNum);
        }

        public void UpdateFirstNumber(PhoneNumber newNum)
        {
            if (numbers.Contains(newNum))
            {
                throw new NumberAlreadyInContactException(DUPLICATE_NUMBER);
            }
            numbers.RemoveAt(0);
            numbers.Insert(0, newNum);
        }

        public string AsString(bool allNumbersOnSeparateLines)
        {
            string start = name + ": ";
            string separator = allNumbersOnSeparateLines ? ",\n" + new string(' ', name.Length) : ", ";
            StringBuilder sb = new StringBuilder(start);
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                sb.Append(numbers[i]);
                sb.Append(separator);
            }
            sb.Append(numbers[numbers.Count - 1]);
            sb.Append('.');
            return sb.ToString();
        }

        public override string ToString()
        {
            return AsString(false);
        }
    }
}
