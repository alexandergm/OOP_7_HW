using System.Text;

namespace Homework7
{
    internal class ContactBook
    {
        private readonly static string NO_CONTACT = "Не найден контакт с именем ";
        private readonly static string DUPLICATE_CONTACT = "Повторное имя контакта.";
        private List<Contact> contacts;

        public ContactBook(List<Contact> contacts)
        {
            this.contacts = contacts;
        }

        public ContactBook()
        {
            this.contacts = new List<Contact>();
        }

        public int IndexOf(String name)
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].GetName().Equals(name))
                {
                    return i;
                }
            }
            return -1;
        }

        private int CheckNameExists(string name)
        {
            int index = IndexOf(name);
            if (index == -1)
            {
                throw new ContactDoesNotExistException(NO_CONTACT);
            }
            return index;
        }

        private void CheckNameNotExists(string name)
        {
            int index = IndexOf(name);
            if (index != -1)
            {
                throw new ContactDoesNotExistException(DUPLICATE_CONTACT);
            }
        }

        public void Add(Contact contact)
        {
            CheckNameNotExists(contact.GetName());
            contacts.Add(contact);
        }

        public void AddContactNumber(string name, PhoneNumber number)
        {
            int index = CheckNameExists(name);
            contacts[index].AddNumber(number);
        }

        public void UpdateContactName(string oldName, string newName)
        {
            int index = CheckNameExists(oldName);
            contacts[index].UpdateName(newName);
        }

        public void UpdateContactNumber(string name, PhoneNumber oldNum, PhoneNumber newNum)
        {
            int index = CheckNameExists(name);
            contacts[index].UpdateNumber(oldNum, newNum);
        }

        public void UpdateContactFirstNumber(string name, PhoneNumber newNum)
        {
            int index = CheckNameExists(name);
            contacts[index].UpdateFirstNumber(newNum);
        }

        public void RemoveContactNumber(string name, PhoneNumber number)
        {
            int index = CheckNameExists(name);
            contacts[index].RemoveNumber(number);
        }

        public void RemoveContact(string name)
        {
            int index = CheckNameExists(name);
            contacts.RemoveAt(index);
        }

        public string AsString(bool allNumbersOnSeparateLines)
        {
            if (contacts.Count == 0)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < contacts.Count - 1; i++)
            {
                sb.Append(contacts[i].AsString(allNumbersOnSeparateLines));
                sb.Append('\n');
            }
            sb.Append(contacts[contacts.Count - 1].AsString(allNumbersOnSeparateLines));
            return sb.ToString();
        }

        public override string ToString()
        {
            return AsString(false);
        }

        public void ExportToTxt(string filename, bool allNumbersOnSeparateLines, bool overwriteIfExists)
        {
            string filepath = filename + ".txt";
            if (!File.Exists(filepath) || overwriteIfExists)
            {
                File.WriteAllText(filepath, AsString(allNumbersOnSeparateLines));
            }
        }

        public void ImportFromTxt(string filepath)
        {
            string text = File.ReadAllText(filepath).Replace(" ", "").Replace("\n", "");
            string[] entries = text.Split('.');
            foreach (string entry in entries)
            {
                if (entry == "")
                {
                    continue;
                }
                int colon = entry.IndexOf(':');
                string name = entry.Substring(0, colon);
                string[] numbers = entry.Substring(colon + 1).Split(',');
                List<PhoneNumber> numbersList = new List<PhoneNumber>();
                foreach (string number in numbers)
                {
                    numbersList.Add(new PhoneNumber(number));
                }
                Add(new Contact(name, numbersList));
            }
        }
    }
}
