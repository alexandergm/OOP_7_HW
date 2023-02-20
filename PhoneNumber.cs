using System.Text.RegularExpressions;

namespace Homework7
{
    internal class PhoneNumber
    {
        private string phoneNumber;

        private bool CheckNumber(string number)
        {
            return Regex.Match(number, "((\\+7)|8)[0-9]{10}").Success;
        }

        public PhoneNumber(string number)
        {
            if(!CheckNumber(number))
            {
                throw new NotANumberException("Строка не является номером телефона.");
            }
            phoneNumber = number;
        }

        public string GetNumber()
        {
            return phoneNumber;
        }

        public override string ToString()
        {
            return phoneNumber;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !(obj is PhoneNumber))
            {
                return false;
            }
            return this.phoneNumber.Equals(((PhoneNumber)obj).phoneNumber);
        }
    }
}
