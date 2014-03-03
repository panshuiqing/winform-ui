using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tlw.ZPG.Infrastructure.Utils
{
    public class SerializeUtils
    {
        #region XmlSerialize

        public static void XmlSerializeTo(object obj, Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(stream, obj);
        }

        public static void XmlSerializeTo(object obj, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(stream, obj);
                stream.Close();
            }
        }

        public static byte[] XmlSerializeTo(object obj)
        {
            byte[] bytes = null;
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, obj);
                bytes = stream.ToArray();
                stream.Close();
            }
            return bytes;
        }

        public static T XmlDeserializeFrom<T>(Stream stream)
        {
            T obj = default(T);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            obj = (T)serializer.Deserialize(stream);
            return obj;
        }

        public static T XmlDeserializeFrom<T>(string fileName)
        {
            T obj = default(T);
            using (Stream stream = File.OpenRead(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                obj = (T)serializer.Deserialize(stream);
                stream.Close();
            }
            return obj;
        }

        public static T XmlDeserializeFrom<T>(byte[] bytes)
        {
            T obj = default(T);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                obj = (T)serializer.Deserialize(stream);
                stream.Close();
            }
            return obj;
        } 

        #endregion

        #region BinarySerialize

        public static void BinarySerializeTo(object obj, Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
        }

        public static void BinarySerializeTo(object obj, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, obj);
                stream.Close();
            }
        }

        public static byte[] BinarySerialize(object obj)
        {
            byte[] bytes = null;
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                bytes = stream.ToArray();
                stream.Close();
            }
            return bytes;
        }

        public static T BinaryDeserializeFrom<T>(Stream stream)
        {
            T obj = default(T);
            BinaryFormatter formatter = new BinaryFormatter();
            obj = (T)formatter.Deserialize(stream);
            return obj;
        }

        public static T BinaryDeserializeFrom<T>(string fileName)
        {
            T obj = default(T);
            using (Stream stream = File.OpenRead(fileName))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                obj = (T)formatter.Deserialize(stream);
                stream.Close();
            }
            return obj;
        }

        public static T BinaryDeserializeFrom<T>(byte[] bytes)
        {
            T obj = default(T);
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                obj = (T)formatter.Deserialize(stream);
                stream.Close();
            }
            return obj;
        }

        public static object BinaryDeserializeFrom(byte[] bytes)
        {
            return BinaryDeserializeFrom<object>(bytes);
        }  

        #endregion
    }
}
