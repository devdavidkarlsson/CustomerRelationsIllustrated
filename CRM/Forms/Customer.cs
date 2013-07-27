//David Karlsson 20120828
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CRM
{
    /// <summary>
    /// Class representing a Customer 
    /// </summary>
    [Serializable()]
    public class Customer : ISerializable
    {
        private int m_index;
        private string m_company;
        private Address m_address;
        private List<Contact> m_contacts;



        /// <summary>
        /// Constructor for contact
        /// </summary>
        /// <param name="index">integer :index of customer</param>
        /// <param name="name"> string containing name of customer, ie. company.</param>
        /// <param name="address">string containing address of company</param>
        public Customer(int index, string name, Address address)
        {
            m_contacts = new List<Contact>();
            m_company = name;
            m_address = address;
            m_index = index;
        }


        /// <summary>
        /// Serialization for data fetching
        /// </summary>
        /// <param name="info">serial info</param>
        /// <param name="ctxt">serial context</param>
        public Customer(SerializationInfo info, StreamingContext ctxt)
        {
            //m_contacts = new List<Contact>();
            m_contacts=(List<Contact>)info.GetValue("Contacts", typeof(List<Contact>));
            m_company = (string)info.GetValue("Name", typeof(string)); ;
            m_address = (Address)info.GetValue("Address", typeof(Address));
            m_index = (int)info.GetValue("Index", typeof(int)); ;
        }

        /// <summary>
        /// Serialization for data storage
        /// </summary>
        /// <param name="info">serial info</param>
        /// <param name="ctxt">serial context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Contacts", m_contacts);
            info.AddValue("Name", m_company);
            info.AddValue("Address", m_address);
            info.AddValue("Index", m_index);

        }

        /// <summary>
        /// Geter/setter for company name
        /// </summary>
        public string Company
        {
            get
            {
                return m_company;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_company = value;
                }
            }
        }

        /// <summary>
        /// Geter/setter for company index.
        /// </summary>
        public int Index
        {
            get
            {
                return m_index;
            }
            set
            {
                if (value > 0)
                {
                    m_index = value;
                }
            }
        }

        /// <summary>
        /// Geter/Setter for address data
        /// </summary>
        public Address Address
        {
            get
            {
                return m_address;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.PostAdress) || !string.IsNullOrEmpty(value.Zip) || !string.IsNullOrEmpty(value.Adress))
                {
                    m_address = value;
                }
            }
        }

        /// <summary>
        /// Method for adding a contact to a company
        /// </summary>
        /// <param name="contact">Contact object to add</param>
        public void addContact(Contact contact)
        {
            m_contacts.Add(contact);
        }

        /// <summary>
        /// Method for retrival of all contacts in customer
        /// </summary>
        /// <returns>returns list of Contacts</returns>
        public List<Contact> getContacts()
        {
            return m_contacts;
        }

        /// <summary>
        /// Method for retrieving a specific customer from the company.
        /// </summary>
        /// <param name="index">int index of the customer to return</param>
        /// <returns>return Contact object</returns>
        public Contact getContact(int index)
        {
            return m_contacts[index];
        }

        /// <summary>
        /// Remove contact from customer
        /// </summary>
        /// <param name="index">int index of contact to remove.</param>
        public void removeContact(int index)
        {
             m_contacts.RemoveAt(index);
        }

    }
}
