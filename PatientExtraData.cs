using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MiConsulta
{
    public class PatientExtraData
    {
        private string dataName;
        private string dataTitle;
        private string data;
        private DateTime lastModification;

        public PatientExtraData(string dataName)
        {
            this.dataName = dataName;
            this.dataTitle = string.Empty;
            this.data = string.Empty;
            this.lastModification = DateTime.Now;
        }

        public PatientExtraData(string dataName, string title, string data, DateTime lastModification)
        {
            this.dataName = dataName;
            this.dataTitle = title;
            this.data = data;
            this.lastModification = lastModification;
        }

        public string Title
        {
            get { return this.dataTitle; }
            set { this.dataTitle = value; this.lastModification = DateTime.Now;  }
        }

        protected string Data
        {
            get { return this.data; }
            set { this.data = value; this.lastModification = DateTime.Now; }
        }

        public DateTime LastModification
        {
            get { return this.lastModification; }
        }

        protected static PatientExtraData Parse(XElement node, string dataName)
        {
            string title = node.Element("Title").Value;
            string data = node.Element(dataName).Value;
            DateTime date = DateTime.Parse(node.Element("Date").Value);
            
            return new PatientExtraData(dataName, title, data, date);
        }

        public XElement ToXElement()
        {
            XElement node = new XElement("Note");
            node.Add(new XElement("Title", this.dataTitle));
            node.Add(new XElement(this.dataName, this.data));
            node.Add(new XElement("Date", this.lastModification.ToString()));
            
            return node;
        }
    }
}
