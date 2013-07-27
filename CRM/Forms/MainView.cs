//David Karlsson 20120828

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CRM
{
    /// <summary>
    /// Class for the mainView of the application
    /// </summary>
    public partial class MainView : Form
    {

        CustomerList custList;
        
        /// <summary>
        /// Construct the mainview
        /// </summary>
        public MainView()
        {
            InitializeComponent();
            Text = "Customer Relations, An Illustrative System";
            custList= new CustomerList();
            this.Controls.Add( MakeListView(custList));
            pBarMood.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        }

        /// <summary>
        /// make and populate the list of customers
        /// </summary>
        /// <param name="custs">customerList to use</param>
        /// <returns>returns a listview with all the customers</returns>
        private ListView MakeListView(CustomerList custs)
        {
            listView.Clear();
            //ListView listView = new ListView();
            //listView.Dock = DockStyle.Fill;
            //listView.Dock = DockStyle.Right;
            listView.View = View.Details;
            listView.Columns.Add("Index", 50);
            listView.Columns.Add("Name", 200);
            listView.Columns.Add("Address", 400);
            listView.Width = 690;
            

            foreach (Customer cust in custs.ToArray())
            {
                ListViewItem item = new ListViewItem(cust.Index.ToString());
                item.SubItems.Add(cust.Company);
                item.SubItems.Add(cust.Address.ToString());
                listView.Items.Add(item);
                
            }
            return listView;
        }


        /// <summary>
        /// Add button handler, for adding customers
        /// </summary>
        /// <param name="sender">sending object</param>
        /// <param name="e">sent event args.</param>
        private void btnAddCust_Click(object sender, EventArgs e)
        {
            CustomerView custView = new CustomerView(string.Format("Add New Customer"));
            //custView.Show();
            if (custView.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("OK detected!");
                Customer cust = custView.Customer;
                cust.Index = custList.Count;
                custList.addCustomer(cust);
                MakeListView(custList);
            }
            else
            {

            }
        
        }

        /// <summary>
        /// Event handler for the remove customer button
        /// </summary>
        /// <param name="sender">sending object</param>
        /// <param name="e">sent event args.</param>
        private void btnRemCust_Click(object sender, EventArgs e)
        {
            if (listView.Items.Count > 0 && listView.SelectedItems.Count==1)
            {
                custList.removeCustomer(listView.Items.IndexOf(listView.SelectedItems[0]));
                MakeListView(custList);
            }
        }

        /// <summary>
        /// Event handler for editing a customer selected in the list. 
        /// </summary>
        /// <param name="sender">sending object</param>
        /// <param name="e">sent event args.</param>
        private void btnEditCust_Click(object sender, EventArgs e)
        {
            if (listView.Items.Count > 0 && listView.SelectedItems.Count==1)
            {
                CustomerView custView = new CustomerView( string.Format("Edit Customer"),custList.getCustomer(listView.Items.IndexOf(listView.SelectedItems[0])));
                
                //custView.Show();
                if (custView.ShowDialog() == DialogResult.OK)
                {
                    custList.removeCustomer(listView.Items.IndexOf(listView.SelectedItems[0]));
                    Console.WriteLine("OK detected!");
                    Customer cust = custView.Customer;
                    cust.Index = custList.Count;
                    custList.addCustomer(cust);
                    MakeListView(custList);
                }
                else
                {

                }
               
            }
        }

        /// <summary>
        /// Nothing, pass
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

          //AutoLoad could be here..
            
        }

        /// <summary>
        /// Save button event handler
        /// </summary>
        /// <param name="sender">sending object</param>
        /// <param name="e">sent event args.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            custList.store();
            MessageBox.Show("File saved...");
        }

        /// <summary>
        /// Load button event handler
        /// </summary>
        /// <param name="sender">sending object</param>
        /// <param name="e">sent event args.</param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            custList.fetch();
            MessageBox.Show("Data loaded from file...");
            MakeListView(custList);
        }

        /// <summary>
        /// Selected customer changed, update the mood bar.
        /// </summary>
        /// <param name="sender">sending object</param>
        /// <param name="e">sent event args.</param>
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.Items.Count > 0 && listView.SelectedItems.Count == 1)
            {
                int tmp = WordCount.AnalyzeCustomer(custList.getCustomer(listView.Items.IndexOf(listView.SelectedItems[0])));
                
                //Limits:
                if (tmp > 200)
                {
                    pBarMood.Value = 200;
                }
                else if (tmp < 0)
                {
                    pBarMood.Value = 0;
                }
                else
                {
                    pBarMood.Value = WordCount.AnalyzeCustomer(custList.getCustomer(listView.Items.IndexOf(listView.SelectedItems[0])));
                }

                //Colors:
                if (pBarMood.Value < 100)
                {
                    pBarMood.ForeColor = Color.Red;
                }
                else if (pBarMood.Value == 100)
                {
                    pBarMood.ForeColor = Color.Yellow;
                }
                else if (pBarMood.Value > 100)
                {
                    pBarMood.ForeColor = Color.Green;
                }
                

            }
        }

        /// <summary>
        /// Help button click handler
        /// </summary>
        /// <param name="sender">sending object</param>
        /// <param name="e">sent event args.</param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a simple Customer Relation Application.\n Use the database to store Customers and respective contacts in each company, write down short impressions that you get from the conversations with each contact. The main window bar will show you if each company, as a whole, is happy with your performance in general. Created by david, david@inkorgen.nu");
        }








    }
}
