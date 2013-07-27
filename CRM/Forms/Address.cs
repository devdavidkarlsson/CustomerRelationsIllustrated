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
    /// Class handling complete address data
    /// </summary>
    [Serializable()]
    public class Address : ISerializable
    {
        private string m_postAddress;
        private string m_zip;
        private string m_address;

        /// <summary>
        /// Constructor for address
        /// </summary>
        /// <param name="pAddress">string containing post address</param>
        /// <param name="zip">string containing zip code</param>
        /// <param name="address">string containing the rest of the address</param>
       public Address(string pAddress, string zip, string address)
        {
           m_postAddress = pAddress;
           m_zip = zip;
           m_address = address;
        }

        /// <summary>
        /// Serialization for data fetching
        /// </summary>
        /// <param name="info">serial info</param>
        /// <param name="ctxt">serial context</param>
       public Address(SerializationInfo info, StreamingContext ctxt)
       {
           m_postAddress = (string)info.GetValue("PostAddress", typeof(string));
           m_address = (string)info.GetValue("Address", typeof(string));
           m_zip = (string)info.GetValue("Zip", typeof(string));
       }

       /// <summary>
       /// Serialization for data storage
       /// </summary>
       /// <param name="info">serial info</param>
       /// <param name="ctxt">serial context</param>
       public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
       {
           info.AddValue("PostAddress", m_postAddress);
           info.AddValue("Address", m_address);
           info.AddValue("Zip", m_zip);
       }

        /// <summary>
        /// Geter/setter for postaddress
        /// </summary>
        public string PostAdress
        {
            get
            {
                return m_postAddress;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_postAddress = value;
                }
            }
        }

        /// <summary>
        /// Geter/setter for zip
        /// </summary>
        public string Zip
        {
            get
            {
                return m_zip;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_zip = value;
                }
            }
        }

        /// <summary>
        /// Geter/setter for address
        /// </summary>
        public string Adress
        {
            get
            {
                return m_address;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_address = value;
                }
            }
        }
        /// <summary>
        /// convert data to string
        /// </summary>
        /// <returns>returns a string of all address data</returns>
        public override string ToString()
        {
            return m_postAddress+" "+ m_zip+" "+m_address;
        }
    }
}