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
    /// Contact view for adding/editing contacts
    /// </summary>
    public partial class ContactView : Form
    {
        private Contact m_contact;

        /// <summary>
        /// Constructor for view used for adding new Contact
        /// </summary>
        public ContactView()
        {
            InitializeComponent();
            Text = "Add Contact";
        }

        /// <summary>
        /// Constructor for editing contact data
        /// </summary>
        /// <param name="contact">Contact to edit</param>
        public ContactView(Contact contact)
        {
            InitializeComponent();
            Text = "Edit Contact";
            m_contact = contact;//new Contact(contact.Name, contact.Email, contact.Phone);
            tbName.Text = m_contact.Name;
            tbPhone.Text = m_contact.Phone;
            tbEmail.Text = m_contact.Email;
            tbTalk.Text = m_contact.getTalks();
        }

        /// <summary>
        /// Geter/setter for contact viewed in the contactView
        /// </summary>
        public Contact Contact
        {
            get { return m_contact; }
            set {
                if (!string.IsNullOrEmpty(value.Name))
                {
                    m_contact = value;
                }
            }

        }

        /// <summary>
        /// Ok button, create contact
        /// </summary>
        /// <param name="sender">sending object</param>
        /// <param name="e">event arg. sent</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("A person must have a name.");
            }
            else
            {
                m_contact = new Contact(tbName.Text, tbEmail.Text, tbPhone.Text, tbTalk.Text);
                DialogResult = DialogResult.OK;
            }

        }

        /// <summary>
        /// Cancel pushed, just close with cancel.
        /// </summary>
        /// <param name="sender">sending object</param>
        /// <param name="e">event arg. sent</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
