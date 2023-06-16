using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_2
{
    internal class PhoneBook
    {
        private Dictionary<string, string> contacts;
        private ListBox listBox;

        public PhoneBook(ListBox listBox)
        {
            contacts = new Dictionary<string, string>();
            this.listBox = listBox;
        }

        public void Add(string name, string phoneNumber)
        {
            if (contacts.ContainsKey(phoneNumber))
            {
                MessageBox.Show("Контакт уже существует");
                return;
            }
            else
            {
                contacts[phoneNumber] = name;
            }
        }

        public void Delete(string name)
        {
            if (contacts.ContainsKey(name))
            {
                contacts.Remove(name);
                MessageBox.Show("Контакт удален: " + name);
            }
            else
            {
                MessageBox.Show("Контакт не найден.");
            }
        }

        public void Search(string name)
        {
            listBox.Items.Clear();
            bool contactFound = false;
            foreach (var contact in contacts)
            {
                string fullName = contact.Value;
                string phoneNumber = contact.Key;
                if (fullName.ToLower().Contains(name.ToLower()))
                {
                    MessageBox.Show("Найдено совпадение: Имя: " + fullName + ", Телефон: " + phoneNumber);
                    contactFound = true;
                }
            }

            if (!contactFound)
            {
                MessageBox.Show("Контакт не найден");
            }
        }

        public void GetAllContacts()
        {
            if (contacts.Count > 0)
            {
                foreach (var contact in contacts)
                {
                    listBox.Items.Add(contact.Value + " " + contact.Key);
                }
            }
            else
            {
                MessageBox.Show("Телефонная книга пуста");
            }
        }

        public Dictionary<string, string> GetContacts()
        {
            return contacts;
        }
    }
}
