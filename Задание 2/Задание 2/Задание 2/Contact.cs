using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_2
{
    internal class Contact
    {
        private string Name;
        private string Phone;
        private bool scan = true; 

        public bool sc
        {
            get {return scan;}
            set {scan = value;}
        }
        public string name
        {
            get {return Name;}
            set
            {
                if (value.Length > 0 && value != "")
                {
                    Name = value;
                    scan = true;
                }
                else
                {
                    MessageBox.Show("Некорректные данные для имени, повторите попытку", "Ошибка");
                    scan = false;
                }
            }
        }

        public string phone
        {
            get {return Phone;}
            set
            {
                if (value != "")
                {
                    Phone = value;
                    scan = true;
                }
                else
                {
                    MessageBox.Show("Некорректные данные для номера телефона, повторите попытку", "Ошибка");
                    scan = false;
                }
            }
        }
    }
}
