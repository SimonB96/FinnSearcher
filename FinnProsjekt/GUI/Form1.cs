using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GUI
{
    public partial class FinnSearcher : Form
    {

        private List<FinnScraper.Product> resultat;

        public FinnSearcher()
        {
            InitializeComponent();
            listView1.Columns[4].Width = 0;
            listView1.Columns[5].Width = 0;
            gif.Load("https://i.imgur.com/N4oWOkb.gif");
            gif.Visible = false;
            radioButton1.Checked = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(Execution);
            Thread thread = new Thread(threadStart);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        private void Execution()
        {
            button1.Invoke((MethodInvoker)delegate { gif.Visible = true; });
            Application.DoEvents();

            string searchText = textBox1.Text;
            FinnScraper.FinnScraperBrain Testing = new FinnScraper.FinnScraperBrain();

            resultat = Testing.FinnSearch(searchText);


            listView1.Invoke((MethodInvoker)delegate ()
            {
                listView1.Items.Clear();
                if (resultat != null) {
                foreach (var a in resultat)
                {
                    string[] rowa = { a.Name, a.City, a.Price.ToString() + " kr", a.Kjoretid, a.ImageURL, a.URL, a.GoodValue.ToString() };
                    var listViewItema = new ListViewItem(rowa);
                    listView1.Items.Add(listViewItema);
                }
               
                }
                else
                {
                    navnTxt.Text = "Fant ingen resultater.";
                }
                if (radioButton1.Checked)
                {
                    listView1.ListViewItemSorter = new Sorter(SortOrder.Ascending, 6);
                    listView1.Sort();

                    listView1.Items[0].Selected = true;
                    listView1.Select();
                }
                else
                {
                    listView1.ListViewItemSorter = new Sorter(SortOrder.Ascending, 2);
                    listView1.Sort();
                    listView1.Items[0].Selected = true;
                    listView1.Select();
                }
            });
      
            button1.Invoke((MethodInvoker)delegate { gif.Visible = false; });
           

        }
          private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
         {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(labelLink.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                navnTxt.Text = item.SubItems[0].Text;
                byTxt.Text = item.SubItems[1].Text;
                PrisTxt.Text = item.SubItems[2].Text;
                tidTxt.Text = item.SubItems[3].Text;
                labelLink.Text = "http://www.finn.no" + item.SubItems[5].Text;
                picture.Load(item.SubItems[4].Text);

            }
            else
            {
                return;
            }


        }

        private void gif_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
