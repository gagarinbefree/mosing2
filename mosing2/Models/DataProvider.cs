using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace mosing2.Models
{
    public class DataProvider : ITravelDataProvider
    {
        public Traveling GetTravel()
        {
            XmlDocument xml = LoadXML("Travel.xml");

            return DeserializeXml<Traveling>(xml);
        }

        private XmlDocument LoadXML(string fileName)
        {
            XmlDocument res = new XmlDocument();

            string dataDir = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            var filePath = Path.Combine(dataDir, fileName);
            string brokenXml = File.ReadAllText(filePath);

            res.LoadXml(CureXml("place", brokenXml));

            return res;
        }

        private string CureXml(string tag, string xml)
        {
            Regex regex = new Regex($@"<{tag}\b[^>]*>(.*?)<{tag}>", RegexOptions.Singleline);
            return regex.Replace(xml, delegate (Match m)
            {
                return $"<{tag}>{m.Groups[1]}</{tag}>";
            });
        }

        public T DeserializeXml<T>(XmlDocument document) where T : class
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            XmlReader reader = new XmlNodeReader(document);
            var serializer = new XmlSerializer(typeof(T));
            T res = (T)serializer.Deserialize(reader);

            return res;
        }
    }
}