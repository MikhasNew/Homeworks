using AbstractFactoryDepo.Pattern.LocomotiveClasse;
using AbstractFactoryDepo.Pattern.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AbstractFactoryDepo.Pattern.Model
{

    public static class XmlReader
    {
        /// <summary> Reads data from xml file.  </summary>
        /// <param name="type">Object type.</param>
        /// <param name="filePath">Data file for deserialization.</param>
        /// <returns> The return type of the object can be explicitly cast to the expected output type.
        /// </returns>
        public static object ReadEntry(Type type, string filePath)
        {
            XmlSerializer formatter = new XmlSerializer(type);
            using (FileStream reader = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                var unit = formatter.Deserialize(reader);
               // Console.WriteLine($"Object {filePath} deserialize " + DateTime.Now.ToString());
                reader.Flush();
                return unit;
            }
        }

        /// <summary> Write data to xml file.  </summary>
        /// <param name="serialisableObject">Object for serialization.</param>
        /// <param name="filePath">Data file for deserialization.</param>
       
        public static void WriteEntry(object serialisableObject, string filePath)
        {
            var typeOfSerialisableObject = serialisableObject.GetType();
            
            XmlSerializer formatter = new XmlSerializer(typeOfSerialisableObject);
            using (FileStream writer = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(writer, serialisableObject);
                Console.WriteLine($"Object {filePath} serialize " + DateTime.Now.ToString());
                writer.Flush();
            }

        }
    }
}
