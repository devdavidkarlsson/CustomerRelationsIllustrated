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
    /// Class representing a contact in a company
    /// </summary>
    [Serializable()]
    public class Contact : ISerializable
    {
        private string m_name;
        private string m_email;
        private string m_phone;
        private string m_talks;


        /// <summary>
        /// Create a contact
        /// </summary>
        /// <param name="name">string containing name of contact</param>
        /// <param name="email">string containing mail of contact</param>
        /// <param name="phone">string containing phone of contact</param>
        /// <param name="talks">string containing talks with contact</param>
        public Contact(string name, string email, string phone, string talks)
        {
            m_name = name;
            m_email=email;
            m_phone = phone;
            m_talks = talks;
            
        }

        /// <summary>
        /// Serialization for data loading
        /// </summary>
        /// <param name="info">serial info</param>
        /// <param name="ctxt">serial context</param>
        public Contact(SerializationInfo info, StreamingContext ctxt)
        {
            m_name = (string)info.GetValue("Name", typeof(string));
            m_email = (string)info.GetValue("Email", typeof(string));
            m_phone = (string)info.GetValue("Phone", typeof(string));
            m_talks = (string)info.GetValue("Talks", typeof(string));
            //talks = new List<string>();

        }

        /// <summary>
        /// Serialization for data storage
        /// </summary>
        /// <param name="info">serial info</param>
        /// <param name="ctxt">serial context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {

            info.AddValue("Name", m_name);
            info.AddValue("Email", m_email);
            info.AddValue("Phone", m_phone);
            info.AddValue("Talks", m_talks);
        }

        /// <summary>
        /// Geter/setter name
        /// </summary>
        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_name = value;
                }
            }
        }

        /// <summary>
        /// Geter/setter email
        /// </summary>
        public string Email
        {
            get
            {
                return m_email;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_email = value;
                }
            }
        }
        /// <summary>
        /// Geter/setter phone
        /// </summary>
        public string Phone
        {
            get
            {
                return m_phone;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_phone = value;
                }
            }
        }
        /// <summary>
        /// Add a string to the talk paramter.
        /// </summary>
        /// <param name="talk">string containing conversation information</param>
        public void AddTalk(string talk){
            m_talks=talk;
        }

        /// <summary>
        /// Get talks
        /// </summary>
        /// <returns> return string talks</returns>
        public string getTalks()
        {
            return m_talks;
        }
    }
}
