//David Karlsson 20120828 using:http://www.switchonthecode.com/tutorials/csharp-tutorial-serialize-objects-to-a-file
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CRM
{
    class Serializer
    {
        /// <summary>
        /// Standard constructor
        /// </summary>
        public Serializer()
        {
        }

        /// <summary>
        /// Extended constructor 
        /// </summary>
        /// <param name="filename">filename to save to</param>
        /// <param name="objectToSerialize">object to serialize</param>
        public void SerializeObject(string filename, ObjectToSerialize objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }

        /// <summary>
        /// Deserializing method for making object out of file
        /// </summary>
        /// <param name="filename">filename of file to parse</param>
        /// <returns>Returns the deserialized object</returns>
        public ObjectToSerialize DeSerializeObject(string filename)
        {
            ObjectToSerialize objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = (ObjectToSerialize)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }
    }
}
