//-----------------------------------------------------------------------
// <copyright file="PatientData.cs" company="none">
// Copyright (C) 2013
//
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by 
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//
//   This program is distributed in the hope that it will be useful, 
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details. 
//
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see "http://www.gnu.org/licenses/". 
// </copyright>
// <author>Benito Palacios (pleoNeX)</author>
// <email>benito356@gmail.com</email>
// <date>04/08/2013</date>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MiConsulta
{
    public abstract class PatientData
    {
        private string dataTitle;
        private string data;
        private DateTime lastModification;

        public PatientData()
            : this(string.Empty, string.Empty, DateTime.Now)
        {
        }

        public PatientData(string title, string data)
            : this(title, data, DateTime.Now)
        {
        }
        
        public PatientData(string title, string data, DateTime lastModification)
        {
            this.dataTitle = title;
            this.data = data;
            this.lastModification = lastModification;
        }
        
        protected PatientData(XElement node)
        {
            this.dataTitle = node.Element("Title").Value;
            this.data  = node.Element(this.DataName).Value;
            this.lastModification = DateTime.Parse(node.Element("Date").Value);
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
        
        protected abstract string DataName {
            get;
        }
        
        protected abstract string DataType {
            get;
        }

        public XElement ToXElement()
        {
            XElement node = new XElement(this.DataType);
            node.Add(new XElement("Title", this.dataTitle));
            node.Add(new XElement(this.DataName, this.data));
            node.Add(new XElement("Date", this.lastModification.ToString()));
            
            return node;
        }
        
        public override string ToString()
        {
            return this.LastModification.ToShortDateString() + " " + this.Title;
        }

    }
}
