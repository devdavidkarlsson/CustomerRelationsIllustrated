//David Karlsson 20120828  using:http://www.switchonthecode.com/tutorials/csharp-tutorial-serialize-objects-to-a-file
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CRM
{
    /// <summary>
    /// Class for serializing the customer list
    /// </summary>
[Serializable()]
    class ObjectToSerialize: ISerializable
    {
        private List<Customer> customers;
        /// <summary>
        /// Standard constructor
        /// </summary>
        public ObjectToSerialize()
        {
        }
    /// <summary>
    /// Serialization constructor
    /// </summary>
    /// <param name="info">serialization info</param>
    /// <param name="ctxt">serialization context</param>
        public ObjectToSerialize(SerializationInfo info, StreamingContext ctxt)
        {
            customers = (List<Customer>)info.GetValue("Customers", typeof(List<Customer>));
            //customers = new List<Customer>();
        }

    /// <summary>
    /// store data method
    /// </summary>
    /// <param name="info">serialization info</param>
    /// <param name="ctxt">serialization context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Customers", customers);
        }

    /// <summary>
    /// Getter/setter for customer list for serialization
    /// </summary>
        public List<Customer> Customers
        {
            get { return customers; }
            set { customers = value; }
        }

    }
}
