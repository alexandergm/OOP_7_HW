namespace Homework7
{
    internal class App
    {
        private ContactBook cb;
        private ContactBookUI cbui;

        public App(ContactBook cb, ContactBookUI cbui)
        {
            this.cb = cb;
            this.cbui = cbui;
        }

        public App(ContactBook cb)
        {
            this.cb = cb;
            this.cbui = new ConsoleUI();
        }

        public App(ContactBookUI cbui)
        {
            this.cbui = cbui;
            this.cb = new ContactBook();
        }

        public App()
        {
            this.cbui = new ConsoleUI();
            this.cb = new ContactBook();
        }

        private void ShowContactBook()
        {
            cbui.ShowString(cb.ToString());
        }

        private void AddContact()
        {
            try
            {
                Contact contact = cbui.EnterContact("Введите контакт, который хотите добавить: ");
                cb.Add(contact);
                cbui.ShowString("Контакт добавлен.");
            }
            catch (Exception ex)
            {
                cbui.ShowString(ex.Message);
            }
        }

        private void AddContactNumber()
        {
            string name = cbui.EnterString("Введите имя контакта, к которому добавить номер: ");
            try
            {
                PhoneNumber number = cbui.EnterNumber("Введите номер, который хотите добавить: ");
                cb.AddContactNumber(name, number);
                cbui.ShowString("Номер добавлен к контакту.");
            }
            catch (Exception e)
            {
                cbui.ShowString(e.Message);
            }
        }

        private void ChangeContactName()
        {
            string oldName = cbui.EnterString("Введите имя контакта, которое хотите заменить: ");
            string newName = cbui.EnterString("Введите имя, которое хотите чтобы носил этот контакт: ");
            try
            {
                cb.UpdateContactName(oldName, newName);
                cbui.ShowString("Имя контакта заменено.");
            }
            catch (Exception e)
            {
                cbui.ShowString(e.Message);
            }
        }

        private void ChangeContactFirstNumber()
        {
            string name = cbui.EnterString("Введите имя контакта, в котором хотите заменить первый номер: ");
            try
            {
                PhoneNumber number = cbui.EnterNumber("Введите новый первый номер контакта: ");
                cb.UpdateContactFirstNumber(name, number);
                cbui.ShowString("Номер заменён.");
            }
            catch (Exception e)
            {
                cbui.ShowString(e.Message);
            }
        }

        private void ChangeContactNumber()
        {
            string name = cbui.EnterString("Введите имя контакта, в котором хотите заменить номер: ");
            try
            {
                PhoneNumber oldNum = cbui.EnterNumber("Введите номер, который хотите заменить: ");
                PhoneNumber newNum = cbui.EnterNumber("Введите новый номер: ");
                cb.UpdateContactNumber(name, oldNum, newNum);
                cbui.ShowString("Номер заменён.");
            }
            catch (Exception e)
            {
                cbui.ShowString(e.Message);
            }
        }

        private void RemoveContactNumber()
        {
            string name = cbui.EnterString("Введите имя контакта, из которого хотите удалить номер: ");
            try
            {
                PhoneNumber number = cbui.EnterNumber("Введите номер, который хотите удалить: ");
                cb.RemoveContactNumber(name, number);
                cbui.ShowString("Номер удалён.");
            }
            catch (Exception e)
            {
                cbui.ShowString(e.Message);
            }
        }

        private void RemoveContact()
        {
            string name = cbui.EnterString("Введите имя контакта, который хотите удалить: ");
            try
            {
                cb.RemoveContact(name);
                cbui.ShowString("Контакт удалён.");
            }
            catch (ContactDoesNotExistException e)
            {
                cbui.ShowString(e.Message);
            }
        }

        private void Export()
        {
            string filename = cbui.EnterString("Введите название файла, куда хотите сохранить справочник: ");
            bool overwrite = cbui.EnterBool("Если файл с таким именем существует, " +
                    "хотите ли вы перезаписать его?(Да/что-либо кроме да): ");
            bool allNumbersOnSeparateLines =
                    cbui.EnterBool("Вы хотите чтобы каждый номер был на отдельной строке?(Да/Нет): ");
            try
            {
                cb.ExportToTxt(filename, allNumbersOnSeparateLines, overwrite);
                cbui.ShowString("Файл создан.");
            }
            catch (IOException e)
            {
                cbui.ShowString(e.Message);
            }
        }

        private void ImportFromFile()
        {
            string filepath = cbui.EnterString("Введите полный путь до текстового файла" +
                "(например: C:/Program Files/test/test.txt): ");
            try
            {
                cb.ImportFromTxt(filepath);
            }
            catch (Exception e)
            {
                cbui.ShowString(e.Message);
            }
        }
        
        private void ExecuteCommand(int command)
        {
            switch (command)
            {
                case 1: ShowContactBook(); break;
                case 2: AddContact(); break;
                case 3: AddContactNumber(); break;
                case 4: ChangeContactName(); break;
                case 5: ChangeContactFirstNumber(); break;
                case 6: ChangeContactNumber(); break;
                case 7: RemoveContactNumber(); break;
                case 8: RemoveContact(); break;
                case 9: Export(); break;
                default: ImportFromFile(); break;
            }
        }

        public void Work()
        {
            cbui.ShowMenu();
            while (true)
            {
                bool isGoodCommand = false;
                while (!isGoodCommand)
                {
                    try
                    {
                        int command = cbui.GetCommand();
                        if (command == 0)
                        {
                            return;
                        }
                        isGoodCommand = true;
                        ExecuteCommand(command);
                    }
                    catch (NotACommandException e)
                    {
                        cbui.ShowString(e.Message);
                    }
                }
            }
        }
    }
}
