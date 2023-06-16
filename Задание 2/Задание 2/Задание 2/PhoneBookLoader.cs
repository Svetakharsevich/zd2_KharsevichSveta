using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Задание_2
{
    internal class PhoneBookLoader
    {
        public static void Load(PhoneBook phoneBook, string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length >= 3)
                    {
                        string fullName = parts[0] + " " + parts[1];
                        string phoneNumber = parts[2];
                        phoneBook.Add(fullName, phoneNumber);
                    }
                    else if (parts.Length == 2)
                    {
                        string fullName = parts[0];
                        string phoneNumber = parts[1];
                        phoneBook.Add(fullName, phoneNumber);
                    }
                }
                MessageBox.Show("Данные загружены из файла: " + fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);

            }
        }

        public static void Save(PhoneBook phoneBook, string fileName)
        {
            try
            {
                List<string> lines = new List<string>();
                Dictionary<string, string> contacts = phoneBook.GetContacts();
                foreach (var contact in contacts)
                {
                    string[] fullNameParts = contact.Key.Split(' ');
                    string firstName = fullNameParts[0];
                    string lastName = fullNameParts[1];
                    string phoneNumber = contact.Value;
                    string line = $"{firstName} {lastName} {phoneNumber}";
                    lines.Add(line);
                }
                File.WriteAllLines(fileName, lines);
                MessageBox.Show("Данные сохранены в файл: " + fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message);
            }
        }
    }
}
