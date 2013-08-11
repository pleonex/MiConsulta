// ----------------------------------------------------------------------
// <copyright file="Patient.cs" company="none">
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
//   along with this program.  If not, see <http://www.gnu.org/licenses/>. 
//
// </copyright>
// <author>pleoNeX</author>
// <email>benito356@gmail.com</email>
// <date>07/09/2012 2:05:00</date>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace MiConsulta
{
    public class Patient : ICloneable
    {
        private string icon;
        private List<sPhone> phones = new List<sPhone>();
        private List<DateTime> appointments = new List<DateTime>();
        private List<Note> notes = new List<Note>();
        private List<Photo> photos = new List<Photo>();

        private static string AppDir = System.Windows.Forms.Application.StartupPath;
        private XElement old_element;

        public Patient()
        {
            old_element = ToXElement();
        }
        public Patient(XElement element)
        {
            if (element.Name != "Patient") {
                Error("Invalid element name: " + element.Name);
                return;
            }
            this.old_element = element;

            this.Name    = Get_XValue(element, "Name");
            this.History = Get_XValue(element, "History");
            this.Address = Get_XValue(element, "Address");
            this.Email   = Get_XValue(element, "Email");
            this.icon    = Get_XValue(element, "Icon");
            this.ZipCode = Get_XValue(element, "ZipCode");
            this.City    = Get_XValue(element, "City");
            this.Country = Get_XValue(element, "Country");

            foreach (XElement e in element.Element("Phones").Elements("Phone"))
                phones.Add(sPhone.Parse(e));

            foreach (XElement e in element.Element("Notes").Elements("Note"))
                notes.Add(new Note(e));

            foreach (XElement e in element.Element("Appointments").Elements("Appointment"))
                appointments.Add(DateTime.Parse(e.Value));

            foreach (XElement e in element.Element("Images").Elements("Image"))
                photos.Add(new Photo(e));
        }

        public XElement ToXElement()
        {
            XElement e = new XElement("Patient");

            e.Add(new XElement("Name",    this.Name));
            e.Add(new XElement("History", this.History));
            e.Add(new XElement("Address", this.Address));
            e.Add(new XElement("Email",   this.Email));
            e.Add(new XElement("Icon",    this.icon));
            e.Add(new XElement("ZipCode", this.ZipCode));
            e.Add(new XElement("City",    this.City));
            e.Add(new XElement("Country", this.Country));

            XElement p = new XElement("Phones");
            for (int i = 0; i < phones.Count; i++)
                p.Add(phones[i].ToXElement());
            e.Add(p);

            XElement n = new XElement("Notes");
            for (int i = 0; i < notes.Count; i++)
                n.Add(notes[i].ToXElement());
            e.Add(n);

            XElement a = new XElement("Appointments");
            for (int i = 0; i < appointments.Count; i++)
                a.Add(new XElement("Appointment", appointments[i].ToString()));
            e.Add(a);

            XElement img = new XElement("Images");
            for (int i = 0; i < photos.Count; i++)
                img.Add(photos[i].ToXElement());
            e.Add(img);

            return e;
        }
        
        public string Name
        {
            get;
            set;
        }
        public string History
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string Icon
        {
            get { return Path.Combine(AppDir, icon); }
            set
            {
                string outp = Path.Combine(AppDir, "Icon");
                if (!Directory.Exists(outp))
                    Directory.CreateDirectory(outp);

                string outf = Path.Combine(outp, Path.GetFileName(value));
                if (File.Exists(outf))
                    outf = Path.Combine(outp, Path.GetRandomFileName() + '_' + Path.GetFileName(value));
                File.Copy(value, outf);
                icon = outf.Remove(0, AppDir.Length + 1);
            }
        }
        public string ZipCode
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }

        public int PhonesLength
        {
            get { return phones.Count; }
        }
        public sPhone Get_Phone(int i)
        {
            if (i < 0 || i >= phones.Count)
            {
                Error("Invalid id " + i.ToString() + " in get phone");
                return new sPhone();
            }

            return phones[i];
        }
        public sPhone Get_Phone(Phone_Type type)
        {
            sPhone p = new sPhone();
            for (int i = 0; i < phones.Count; i++)
            {
                if (phones[i].type == type)
                {
                    p = phones[i];
                    break;
                }
            }

            if (String.IsNullOrEmpty(p.number))
            {
                Console.WriteLine("Phone type doesn't found!");
            }

            return p;
        }
        public void Set_Phone(Phone_Type type, string number)
        {
            sPhone ph;
            for (int i = 0; i < phones.Count; i++)
            {
                if (phones[i].type == type)
                {
                    ph = phones[i];
                    ph.number = number;
                    phones[i] = ph;
                    //Error("Phone replaced at " + i.ToString());
                    return;
                }
            }

            // If not found add it
            ph = new sPhone();
            ph.type = type;
            ph.number = number;
            Add_Phone(ph);
            Error("Phone added");
        }
        public void Add_Phone(sPhone p)
        {
            phones.Add(p);
        }

        public Note[] GetNotes()
        {
            return this.notes.ToArray();
        }
        public Note GetNote(int i)
        {
            if (i < 0 || i >= notes.Count)
            {
                Error("Invalid id " + i.ToString() + " in get note");
                return null;
            }

            return notes[i];
        }
        public void SetNotes(PatientData[] notes)
        {
            this.notes.Clear();
            foreach (PatientData note in notes)
                this.notes.Add((Note)note);
        }
        public int NotesLength
        {
            get { return notes.Count; }
        }
        
        public Photo[] GetPhotos()
        {
            return this.photos.ToArray();
        }
        public Photo GetPhoto(int i)
        {
            if (i < 0 || i >= photos.Count)
            {
                Error("Invalid id " + i.ToString() + " in get image");
                return null;
            }

            return photos[i];
        }
        public void SetPhotos(PatientData[] photos)
        {
            this.photos.Clear();
            foreach (PatientData photo in photos)
                this.photos.Add((Photo)photo);
        }
        public int PhotosLength
        {
            get { return photos.Count; }
        }

        public int AppointmentsLength
        {
            get { return appointments.Count; }
        }
        private int NextAppointment_Index()
        {
            int index = -1;
            for (int i = 0; i < appointments.Count; i++)
                if (appointments[i] > DateTime.Now && (index == -1 || appointments[i] < appointments[index]))
                    index = i;

            return index;
        }
        public DateTime Get_Appointment(int i)
        {
            if (i < 0 || i >= appointments.Count)
            {
                Error("Invalid id " + i.ToString() + " in get appointment");
                return new DateTime(1, 1, 1);
            }

            return appointments[i];
        }
        public DateTime Get_NextAppointment()
        {
            int i = NextAppointment_Index();
            Error("Getting next appointment in " + i.ToString());
            if (i != -1)
                return appointments[i];
            else
                return new DateTime(1, 1, 1);
        }
        public DateTime Get_LastAppointment()
        {
            DateTime dt = new DateTime(1, 1, 1);
            for (int i = 0; i < appointments.Count; i++)
                if (appointments[i] < DateTime.Now && appointments[i] > dt)
                    dt = appointments[i];

            return dt;
        }
        public int Set_Appointment(int i, DateTime date)
        {
            if (i < 0 || i >= appointments.Count)
            {
                Error("Invalid id " + i.ToString() + " in set appointment");
                return -1;
            }

            appointments[i] = date;
            appointments.Sort();
            return appointments.FindIndex(d => date.Equals(d));
        }
        public void Set_NextAppointment(DateTime date)
        {
            int index = NextAppointment_Index();

            Error("Setting next appointment to " + index.ToString());
            if (index != -1)
                appointments[index] = date;
            else
                Add_Appointment(date);

            appointments.Sort();
        }
        public int Add_Appointment(DateTime date)
        {
            appointments.Add(date);
            appointments.Sort();
            return appointments.FindIndex(d => date.Equals(d));
        }
        public void Remove_NextAppointment()
        {
            int i = NextAppointment_Index();
            Error("Removing next appointment at " + i.ToString());
            if (i != -1)
                appointments.RemoveAt(i);
        }
        public void Remove_Appointment(int i)
        {
            if (i < 0 || i >= appointments.Count)
            {
                Error("Invalid id " + i.ToString() + " in remove appointment");
                return;
            }

            appointments.RemoveAt(i);
            Error("Removing appointment at " + i.ToString());
        }

        public bool IsEdited
        {
            get
            {
                XElement e = ToXElement();
                return !Compare_XElement(old_element, e);
            }
            set
            {
                if (value) old_element = null;
                else old_element = ToXElement();
            }
        }
        public bool IsNull
        {
            get
            {
                if (String.IsNullOrEmpty(this.Name) || String.IsNullOrEmpty(this.History))
                    return true;
                else
                    return false;
            }
        }

        private static bool Compare_XElement(XElement a, XElement b)
        {
            if (a.Name != b.Name)
                return false;
            if (a.HasAttributes != b.HasAttributes)
                return false;
            if (a.HasElements != b.HasElements)
                return false;
            if (a.IsEmpty != b.IsEmpty)
                return false;
            if (a.NodeType != b.NodeType)
                return false;
            if (a.Value != b.Value)
                return false;

            List<XAttribute> att_a = new List<XAttribute>();
            att_a.AddRange(a.Attributes());
            List<XAttribute> att_b = new List<XAttribute>();
            att_b.AddRange(b.Attributes());

            if (att_a.Count != att_b.Count)
                return false;
            for (int i = 0; i < att_a.Count; i++)
            {
                if (att_a[i].Name != att_b[i].Name)
                    return false;
                if (att_a[i].Value != att_b[i].Value)
                    return false;
            }

            List<XElement> list_a = new List<XElement>();
            list_a.AddRange(a.Elements());
            List<XElement> list_b = new List<XElement>();
            list_b.AddRange(b.Elements());

            if (list_a.Count != list_b.Count)
                return false;
            for (int i = 0; i < list_a.Count; i++)
                if (!Compare_XElement(list_a[i], list_b[i]))
                    return false;
                    
            return true;
        }
        public static string Get_XValue(XElement el, string name)
        {
            XElement e = el.Element(name);
            if (e == null)
            {
                Error(name + " doesn't exist!");
                return "";
            }
            return e.Value;
        }
        private static void Error(string t)
        {
            Console.WriteLine(t);
        }

        public object Clone()
        {
            return new Patient(this.ToXElement());
        }
    }

    public struct sPhone
    {
        public string number;
        public Phone_Type type;

        public static sPhone Parse(XElement e)
        {
            sPhone p = new sPhone();
            p.type = (Phone_Type)Enum.Parse(typeof(Phone_Type), Patient.Get_XValue(e, "Type"));
            p.number = Patient.Get_XValue(e, "Number");
            return p;
        }
        public XElement ToXElement()
        {
            XElement e = new XElement("Phone");
            e.Add(new XElement("Type", Enum.GetName(typeof(Phone_Type), this.type)));
            e.Add(new XElement("Number", this.number));
            return e;
        }
    }
    
    public enum Phone_Type
    {
        Landline,
        Mobile
    }
}
