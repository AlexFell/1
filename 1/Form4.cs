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
    public partial class Form4 : Form
    {
        public Label list;
        string holidays;
        string[] holiday;
        string month;
        string url;

        public Form4()
        {
            InitializeComponent();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            holidays = this.dateTimePicker1.Value.ToShortDateString();
            holiday = holidays.Split('.');
            if (holiday[1] == "01") { month = "января"; }
            if (holiday[1] == "02") { month = "февраля"; }
            if (holiday[1] == "03") { month = "марта"; }
            if (holiday[1] == "04") { month = "апреля"; }
            if (holiday[1] == "05") { month = "мая"; }
            if (holiday[1] == "06") { month = "июня"; }
            if (holiday[1] == "07") { month = "июля"; }
            if (holiday[1] == "08") { month = "августа"; }
            if (holiday[1] == "09") { month = "сентября"; }
            if (holiday[1] == "10") { month = "октября"; }
            if (holiday[1] == "11") { month = "ноября"; }
            if (holiday[1] == "12") { month = "декабря"; }
            if (holiday[0] == "01") { holiday[0] = "1"; }
            if (holiday[0] == "02") { holiday[0] = "2"; }
            if (holiday[0] == "03") { holiday[0] = "3"; }
            if (holiday[0] == "04") { holiday[0] = "4"; }
            if (holiday[0] == "05") { holiday[0] = "5"; }
            if (holiday[0] == "06") { holiday[0] = "6"; }
            if (holiday[0] == "07") { holiday[0] = "7"; }
            if (holiday[0] == "08") { holiday[0] = "8"; }
            if (holiday[0] == "09") { holiday[0] = "9"; }

            url = "https://ru.wikipedia.org/wiki/" + holiday[0] + "_" + month;

            int chet = 0;
            string lists = "";

            CQ dom = CQ.CreateFromUrl(url);
            foreach (IDomObject obj in dom.Find("span.mw-headline"))
            {
                if (obj.TextContent == "Международные" || obj.TextContent == "Национальные" || obj.TextContent == "Профессиональные")
                {
                    lists += obj.TextContent += ":\n";
                    foreach (IDomObject obi in dom.Find(".mw-parser-output>ul").Eq(chet))
                    {
                        if (obi.TextContent != "")
                        {
                            lists += obi.TextContent += "\n";
                        }
                    }
                    lists += "\n";
                    chet++;
                }
            }

            list.Text = lists;
            this.Close();
        }
    }
}
