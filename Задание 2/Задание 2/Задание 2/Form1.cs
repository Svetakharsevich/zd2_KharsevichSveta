using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Задание_2
{
    public partial class Form1 : Form
    {
        Contact ct = new Contact();
        PhoneBook phonebook;

        public Form1()
        {
            InitializeComponent();
            phonebook = new PhoneBook(listBox1);
            button5.Visible = false;
            button6.Visible = true;

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка");
                return;
            }
            foreach (var ch in textBox1.Text)
            {
                if (char.IsDigit(ch))
                {
                    MessageBox.Show("Имя не может состоять из цифр", "Ошибка");
                    return;
                }
            }
            foreach (var ch in textBox2.Text)
            {
                if (char.IsLetter(ch))
                {
                    MessageBox.Show("Номер может состоять только из цифр", "Ошибка");
                    return;
                }
            }
            if(textBox2.Text.Length<14||textBox2.Text.Length>14)
            {
                MessageBox.Show("Длина номера телефона должна состовлять 14 символов", "Ошибка");
                return;

            }
            ct.name = textBox1.Text;
            ct.phone = textBox2.Text;
            if (ct.sc == true)
            {
                phonebook.Add(ct.name, ct.phone);
                listBox1.Items.Clear();
                phonebook.GetAllContacts();
                MessageBox.Show("Контакт добавлен");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                phonebook.Search(textBox3.Text);
                phonebook.GetAllContacts();
            }
            else MessageBox.Show("Поле не заполнено", "Ошибка");
            foreach (var ch in textBox3.Text)
            {
                if (char.IsDigit(ch))
                {
                    MessageBox.Show("Имя не может состоять из цифр", "Ошибка");
                    return;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                listBox1.Items.Clear();
                phonebook.Delete(textBox4.Text);
                listBox1.Items.Clear();
                phonebook.GetAllContacts();
            }
            else MessageBox.Show("Поле не заполнено", "Ошибка");
            foreach (var ch in textBox4.Text)
            {
                if (char.IsLetter(ch))
                {
                    MessageBox.Show("Номер может состоять только из цифр", "Ошибка");
                    return;
                }
            }
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                PhoneBookLoader.Load(phonebook, fileName);
                listBox1.Items.Clear();
                phonebook.GetAllContacts();
                button5.Visible = true;
                MessageBox.Show("Выбран файл: " + fileName);
            }
            else
            {
                MessageBox.Show("Файл не выбран");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("phone.txt"))
            {
                foreach (var item in listBox1.Items)
                {
                    writer.WriteLine(item.ToString());
                }
            }
            MessageBox.Show("Список контактов сохранен в файл phone.txt");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
