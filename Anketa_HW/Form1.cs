using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anketa_HW
{
    public partial class Form1 : Form
    {
        BindingList<Anketes> ankets = new BindingList<Anketes>();

        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = ankets;
            listBox1.DisplayMember = "Name";
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
        }

        public class Anketes
        {
        
                public string name { get; set;}
            public string surname { get; set;}
            public string secondname { get; set; }
            public string email { get; set;}

        
        }

  private void AddBtn_Click(object sender, EventArgs e)
        {
            string email = Email.Text;
            Anketes anketes = new Anketes();
            anketes.name = Name.Text;
            anketes.email = Email.Text;
            anketes.surname = Surname.Text;
            anketes.secondname = SecondName.Text;
            ankets.Add(anketes);        
            listBox1.SelectedIndex = -1;

        }

        //метод позволяющий в поля вводить только буквы и backspace
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            listBox1.Text = String.Format(" ", e.Start.ToLongDateString()); 

        }

        private void VisitLink()
        { 
        
                linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(" https://geocult.ru/natalnaya-karta-onlayn-raschet ");
        
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
                VisitLink();

            
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;


                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    foreach (var item in ankets)
                    {
                        sw.WriteLine(item.name);
                        sw.WriteLine(item.secondname);
                        sw.WriteLine(item.email);
                        sw.WriteLine(item.surname);

                    }
                }
            }

        }

        
    }
}
