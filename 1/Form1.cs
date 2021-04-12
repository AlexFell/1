using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsQuery;

namespace _1
{
    public partial class Form1 : Form
    {
        string holidays;
        string[] holiday;
        string url;        

        static string Month(string a, string c)
        {
            string b = "";
            if (a == "01") { b = "января"; }
            if (a == "02") { b = "февраля"; }
            if (a == "03") { b = "марта"; }
            if (a == "04") { b = "апреля"; }
            if (a == "05") { b = "мая"; }
            if (a == "06") { b = "июня"; }
            if (a == "07") { b = "июля"; }
            if (a == "08") { b = "августа"; }
            if (a == "09") { b = "сентября"; }
            if (a == "10") { b = "октября"; }
            if (a == "11") { b = "ноября"; }
            if (a == "12") { b = "декабря"; }
            if (c == "01") { c = "1"; }
            if (c == "02") { c = "2"; }
            if (c == "03") { c = "3"; }
            if (c == "04") { c = "4"; }
            if (c == "05") { c = "5"; }
            if (c == "06") { c = "6"; }
            if (c == "07") { c = "7"; }
            if (c == "08") { c = "8"; }
            if (c == "09") { c = "9"; }
            return b;
        }

        public Form1()
        {
            InitializeComponent();
            this.Controls.Remove(button4);
            this.Controls.Remove(label2);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            int chet = 0;
            this.Controls.Remove(button1);
            this.Controls.Remove(button2);
            this.Controls.Remove(button3);
            this.Controls.Remove(label1);
            this.Controls.Add(button4);
            this.Controls.Add(label2);
            holidays = DateTime.Now.ToShortDateString();
            holiday = holidays.Split('.');
            string month = Month(holiday[1], holiday[0]);
            url = "https://ru.wikipedia.org/wiki/" + holiday[0] + "_" + month;

            CQ dom = CQ.CreateFromUrl(url);
            foreach (IDomObject obj in dom.Find("span.mw-headline"))
            {
                if (obj.TextContent == "Международные" || obj.TextContent == "Национальные" || obj.TextContent == "Профессиональные")
                {
                    label2.Text += obj.TextContent += ":\n";
                    foreach (IDomObject obi in dom.Find(".mw-parser-output>ul").Eq(chet))
                    {
                        if (obi.TextContent != "")
                        {
                            label2.Text += obi.TextContent += "\n";
                        }
                    }
                    label2.Text += "\n";
                    chet++;
                }
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int chet = 0;
            this.Controls.Remove(button1);
            this.Controls.Remove(button2);
            this.Controls.Remove(button3);
            this.Controls.Remove(label1);
            this.Controls.Add(button4);
            this.Controls.Add(label2);
            holidays = DateTime.Now.AddDays(1).ToShortDateString();
            holiday = holidays.Split('.');
            string month = Month(holiday[1], holiday[0]);
            url = "https://ru.wikipedia.org/wiki/" + holiday[0] + "_" + month;

            CQ dom = CQ.CreateFromUrl(url);
            foreach (IDomObject obj in dom.Find("span.mw-headline"))
            {
                if (obj.TextContent == "Международные" || obj.TextContent == "Национальные" || obj.TextContent == "Профессиональные")
                {
                    label2.Text += obj.TextContent += ":\n";
                    foreach (IDomObject obi in dom.Find(".mw-parser-output>ul").Eq(chet))
                    {
                        if (obi.TextContent != "")
                        {
                            label2.Text += obi.TextContent += "\n";
                        }
                    }
                    label2.Text += "\n";
                    chet++;
                }
            }          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.list = this.label2;
            form4.Show();
            this.Controls.Remove(button1);
            this.Controls.Remove(button2);
            this.Controls.Remove(button3);
            this.Controls.Remove(label1);
            this.Controls.Add(button4);
            this.Controls.Add(label2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            this.Controls.Remove(button4);
            this.Controls.Remove(label2);
            this.Controls.Add(button1);
            this.Controls.Add(button2);
            this.Controls.Add(button3);
            this.Controls.Add(label1);
        }
    }
}
