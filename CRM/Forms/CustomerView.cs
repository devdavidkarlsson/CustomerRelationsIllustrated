//David Karlsson 20120828
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRM
{
    /// <summary>
    /// Customer view class, for viewing a customer
    /// </summary>
    public partial class CustomerView : Form
    {
        private Customer m_cust;

        /// <summary>
        /// Constructor for adding a new customer
        /// </summary>
        /// <param name="title">title of window/form</param>
        public CustomerView(string title)
        {
            InitializeComponent();
            Text = title;
            
        }

        /// <summary>
        /// Constructor for editing a customer
        /// </summary>
        /// <param name="title">title of window/form</param>
        /// <param name="cust">customer to edit</param>
        public CustomerView(string title, Customer cust)
        {
            InitializeComponent();
            Text = title;
            m_cust = cust;
            tbName.Text = m_cust.Company;
            tbAddr.Text = m_cust.Address.Adress;
            tbPostAddr.Text = m_cust.Address.PostAdress;
            tbZip.Text = m_cust.Address.Zip;
            MakeListView();
        }

        /// <summary>
        /// Geter/Setter for customer
        /// </summary>
        public Customer Customer
        {
            get { return m_cust; }
        }

        /// <summary>
        /// Event handler for OK button
        /// </summary>
        /// <param name="sender">sending object</param>
        /// <param name="e">sent event args.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            
            Address address = new Address(tbPostAddr.Text, tbZip.Text,tbAddr.Text);
            if (m_cust == null)
            {
                m_cust = new Customer(0, tbName.Text, address);
            }
            else
            {
                m_cust.Company = tbName.Text;
                m_cust.Address = address;
            }
            //MessageBox.Show(m_cust.ToString());
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Event handler for add contact button click
        /// </summary>
        /// <param name="sender">sending object</param>
        /// <param name="e">sent event args.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
           Address address = new Address(tbPostAddr.Text, tbZip.Text, tbAddr.Text);
           if (m_cust == null)
           {
               m_cust = new Customer(0, tbName.Text, address);
           }
           else
           {
               m_cust.Company = tbName.Text;
               m_cust.Address = address;
           }
           ContactView contactView = new ContactView();
           if (contactView.ShowDialog() == DialogResult.OK)
           {
              m_cust.addContact(contactView.Contact);
              MakeListView();
           }
        }

        /// <summary>
        /// Cancel button click, just cancel the form
        /// </summary>
        /// <param name="sender">sending object</param>
        /// <param name="e">sent event args.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            
        }

        /// <summary>
        /// Make and populate the list of contacts
        /// </summary>
        /// <returns>Returns ListView of with all contacts of a company</returns>
        private ListView MakeListView()
        {
             lVCont.Clear();
            //ListView listView = new ListView();
            //listView.Dock = DockStyle.Fill;
            //listView.Dock = DockStyle.Right;
            lVCont.View = View.Details;
            lVCont.Columns.Add("Name", 200);
            //lVCont.Columns.Add("Talk", 400);
            lVCont.Width = 650;
            lblCount.Text = m_cust.getContacts().Count.ToString();

            foreach (Contact contact in m_cust.getContacts())
            {
                ListViewItem item = new ListViewItem(contact.Name);
                //item.SubItems.Add(contact.getTalks()[0]);
                lVCont.Items.Add(item);
                
            }
            return lVCont;
        }

        /// <summary>
        /// Remove button handler, remove selected contact from list.
        /// </summary>
        /// <param name="sender">sending object</param>
        /// <param name="e">sent event args.</param>
        private void btnRem_Click(object sender, EventArgs e)
        {
            if (lVCont.Items.Count > 0 && lVCont.SelectedItems.Count == 1)
            {
                m_cust.removeContact(lVCont.Items.IndexOf(lVCont.SelectedItems[0]));
                MakeListView();
            }
        }

        /// <summary>
        /// Method handling the edit button event, for editing contact
        /// </summary>
        /// <param name="sender">sending object</param>
        /// <param name="e">sent event args.</param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
           
           Address address = new Address(tbPostAddr.Text, tbZip.Text, tbAddr.Text);
           if (m_cust==null)
           {
            m_cust = new Customer(0, tbName.Text, address);
           }
            if(lVCont.SelectedItems.Count>0){
           ContactView contactView = new ContactView(m_cust.getContact(lVCont.Items.IndexOf(lVCont.SelectedItems[0])));
           if (contactView.ShowDialog() == DialogResult.OK)
           {
              m_cust.removeContact(lVCont.Items.IndexOf(lVCont.SelectedItems[0]));
              m_cust.addContact(contactView.Contact);
              MakeListView();
           
            }
            }
        }





    }
}
