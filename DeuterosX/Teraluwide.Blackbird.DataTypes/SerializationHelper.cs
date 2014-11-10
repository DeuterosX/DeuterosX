using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Teraluwide.Blackbird.DataTypes
{
    /// <summary>
    /// This class contains methods for serializing and deserializing runtime objects. The methods are completely generic.
    /// </summary>
    public static class SerializationHelper
    {
        /// <summary>
        /// This method serializes any object that implements XML serialization.
        /// </summary>
        /// <param name="obj">The runtime object to be serialized.</param>
        /// <returns>The serialized XML representing the runtime object, wrapped in an XmlDocument object for ease of use.</returns>
        public static XmlDocument SerializeObject(object obj)
        {
            XmlDocument xmlDoc = new System.Xml.XmlDocument();
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                serializer.Serialize(ms, obj);
                ms.Position = 0;
                xmlDoc.Load(ms);
            }
            return xmlDoc;
        }

        /// <summary>
        /// This method deserializes any object that implements XML serialization.
        /// </summary>
        /// <param name="xml">An XmlDocument object containing the XML structure that represents the runtime object to be deserialized.</param>
        /// <param name="t">The object type to deserialize the XML into.</param>
        /// <returns>A generic object, deserialized from the XML. The calling code must cast this into the proper type before assigning it.</returns>
        public static object DeSerializeObject(XmlDocument xml, Type t)
        {
            XmlSerializer serializer = new XmlSerializer(t);
            object oOut;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                xml.Save(ms);
                ms.Position = 0;
                oOut = serializer.Deserialize(ms);
            }
            return oOut;
        }
    }
}
