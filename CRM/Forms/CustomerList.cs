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
    /// Class representing a List of customers
    /// </summary>
    public class CustomerList
    {
        private List<Customer> customers;

        /// <summary>
        /// Constructor instantiating the list
        /// </summary>
        public CustomerList()
        {
            customers = new List<Customer>();
        }

        /// <summary>
        /// Returns int with the number of customers in the list.
        /// </summary>
        public int Count
        {
            get { return customers.Count; }
        }

        /// <summary>
        /// Add new customer(company) to the list
        /// </summary>
        /// <param name="company">company name</param>
        /// <param name="address">address of the company</param>
        public void addCustomer(string company, Address address)
        {
            customers.Add(new Customer(customers.Count, company, address));
        }

        /// <summary>
        /// Retrive a customer from the list
        /// </summary>
        /// <param name="index">int index of the customer to return</param>
        /// <returns>returns a Customer object</returns>
        public Customer getCustomer(int index){
            return customers[index];
        }
            
        /// <summary>
        /// Add existing customer to the list
        /// </summary>
        /// <param name="cust">Customer object to add</param>
        public void addCustomer(Customer cust)
        {
            customers.Add(cust);
        }

        /// <summary>
        /// Remove specific customer from the list
        /// </summary>
        /// <param name="index">index of customer to remove</param>
        public void removeCustomer(int index)
        {
            customers.RemoveAt(index);
        }

        /// <summary>
        /// Convert customerList to array
        /// </summary>
        /// <returns>Returns an array of all customers in the list</returns>
        public Customer[] ToArray(){
            return customers.ToArray();
        }

        /// <summary>
        /// Store customer list data in data file.
        /// </summary>
        public void store() {
        
        //save the car list to a file
        ObjectToSerialize objectToSerialize = new ObjectToSerialize();
        objectToSerialize.Customers = customers;

        Serializer serializer = new Serializer();
        serializer.SerializeObject("outputFile.txt", objectToSerialize);
        }

        /// <summary>
        /// Load customer data from data file.
        /// </summary>
        public void fetch() {
            ObjectToSerialize objectToSerialize = new ObjectToSerialize();
            Serializer serializer = new Serializer();
            objectToSerialize = serializer.DeSerializeObject("outputFile.txt");
            customers = objectToSerialize.Customers;
        }
    }
}
