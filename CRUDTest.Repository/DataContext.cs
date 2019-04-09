using CRUDTest.Repository.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CRUDTest.Repository
{
    public class DataContext
    {
        public List<User> Users { get; set; }

        string jsonPath = "data.json";
        string xmlPath = "data.xml";

        public DataContext()
        {
            Load((int)Enums.DataFormat.JSON);
        }

        public void Load(Enums.DataFormat format)
        {
            switch (format)
            {
                case Enums.DataFormat.JSON:
                    LoadJSON();
                    break;
                case Enums.DataFormat.XML:
                    LoadXML();
                    break;
                default:
                    break;
            }

            if (Users == null)
            {
                InitialiseData();
            }
        }

        private void LoadXML()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<User>));
            TextReader reader = new StreamReader(xmlPath);
            object obj = deserializer.Deserialize(reader);
            Users = (List<User>)obj;
            reader.Close();
        }

        public void Save(Enums.DataFormat format)
        {
            switch (format)
            {
                case Enums.DataFormat.JSON:
                    SaveJSON();
                    break;
                case Enums.DataFormat.XML:
                    SaveXML();
                    break;
                default:
                    break;
            }
        }

        private void SaveXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            using (TextWriter writer = new StreamWriter(xmlPath))
            {
                serializer.Serialize(writer, Users);
            }
        }

        private void SaveJSON()
        {
            string dataString = JsonConvert.SerializeObject(Users);
            File.WriteAllText(jsonPath, dataString);
        }

        private void LoadJSON()
        {
            string dataString = string.Empty;
            try
            {
                dataString = File.ReadAllText(jsonPath);
            }
            catch(Exception e)
            {
                
            }

            if (!string.IsNullOrEmpty(dataString))
            {
                Users = JsonConvert.DeserializeObject<List<User>>(dataString);
            }
        }

        public void InitialiseData()
        {
            Users = new List<User>();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Users.Add(new User
                {
                    id = Guid.NewGuid(),
                    firstName = $"User{i}",
                    lastName = $"McUser{i}",
                    department = $"IT Department {random.Next(1, 4)}",
                    address1 = $"{random.Next()} park street",
                    address2 = $"{random.Next()} road",
                    address3 = "London",
                    town = "London",
                    postCode = $"DA{i} {i + 1}QX"
                });
            }
        }
    }
}
