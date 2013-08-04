// ----------------------------------------------------------------------
// <copyright file="Patient.cs" company="none">

// Copyright (C) 2012
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
        string name;
        string history;
        string address;
        string email;
        string icon;
        List<sPhone> phones;
        List<sNote> notes;
        List<DateTime> appointments;
        List<sImage> images;

        string app_dir = System.Windows.Forms.Application.StartupPath + Path.DirectorySeparatorChar;
        XElement old_element;

        public Patient(XElement element)
        {
            if (element.Name != "Patient")
            {
                Error("Invalid element name: " + element.Name);
                return;
            }
            this.old_element = element;

            name = Get_XValue(element, "Name");
            history = Get_XValue(element, "History");
            address = Get_XValue(element, "Address");
            email = Get_XValue(element, "Email");
            icon = Get_XValue(element, "Icon");

            phones = new List<sPhone>();
            foreach (XElement e in element.Element("Phones").Elements("Phone"))
                phones.Add(sPhone.Parse(e));

            notes = new List<sNote>();
            foreach (XElement e in element.Element("Notes").Elements("Note"))
                notes.Add(sNote.Parse(e));

            appointments = new List<DateTime>();
            foreach (XElement e in element.Element("Appointments").Elements("Appointment"))
                appointments.Add(DateTime.Parse(e.Value));

            images = new List<sImage>();
            foreach (XElement e in element.Element("Images").Elements("Image"))
                images.Add(sImage.Parse(e));
        }
        public Patient()
        {
            name = history = address = email = "";
            phones = new List<sPhone>();
            notes = new List<sNote>();
            appointments = new List<DateTime>();
            images = new List<sImage>();
            old_element = ToXElement();
        }

        public XElement ToXElement()
        {
            XElement e = new XElement("Patient");

            e.Add(new XElement("Name", name));
            e.Add(new XElement("History", history));
            e.Add(new XElement("Address", address));
            e.Add(new XElement("Email", email));
            e.Add(new XElement("Icon", icon));

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
            for (int i = 0; i < images.Count; i++)
                img.Add(images[i].ToXElement());
            e.Add(img);

            return e;
        }
        public bool Compare_XElement(XElement a, XElement b)
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

        #region Propiedades
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string History
        {
            get { return history; }
            set { history = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Icon
        {
            get { return app_dir + icon; }
            set
            {
                string outp = app_dir + "Icon" + Path.DirectorySeparatorChar;
                if (!Directory.Exists(outp))
                    Directory.CreateDirectory(outp);

                if (File.Exists(outp + Path.GetFileName(value)))
                    outp += Path.GetRandomFileName() + '_' + Path.GetFileName(value);
                else
                    outp += Path.GetFileName(value);
                File.Copy(value, outp);
                icon = outp.Replace(app_dir, "");
            }
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
        public sPhone Get_Phone(string number)
        {
            sPhone p = new sPhone();
            for (int i = 0; i < phones.Count; i++)
            {
                if (phones[i].number == number)
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
        public void Set_Phone(int i, sPhone p)
        {
            if (i < 0 || i >= phones.Count)
            {
                Error("Invalid id " + i.ToString() + " in set phone");
                return;
            }

            phones[i] = p;
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

        public int NotesLength
        {
            get { return notes.Count; }
        }
        public sNote Get_Note(int i)
        {
            if (i < 0 || i >= notes.Count)
            {
                Error("Invalid id " + i.ToString() + " in get note");
                return new sNote();
            }

            return notes[i];
        }
        public void Set_Note(int i, sNote note)
        {
            if (i < 0 || i >= notes.Count)
            {
                Error("Invalid id " + i.ToString() + " in set note");
                return;
            }

            notes[i] = note;
        }
        public void Add_Note(sNote note)
        {
            notes.Add(note);
        }
        public void Note_Up(int i)
        {
            if (i <= 0)
            {
                Error("You can't up this note");
                return;
            }

            sNote note = notes[i];
            notes.RemoveAt(i);
            notes.Insert(i - 1, note);
        }
        public void Note_Down(int i)
        {
            if (i >= notes.Count - 1)
            {
                Error("You can't up this note");
                return;
            }

            sNote note = notes[i];
            notes.RemoveAt(i);
            notes.Insert(i + 1, note);
        }
        public void Remove_Note(int i)
        {
            if (i < 0 || i >= notes.Count)
            {
                Error("Invalid id " + i.ToString() + " in remove note");
                return;
            }

            notes.RemoveAt(i);
            Error("Removing note at " + i.ToString());
        }

        public int ImagesLength
        {
            get { return images.Count; }
        }
        public sImage Get_Image(int i)
        {
            if (i < 0 || i >= images.Count)
            {
                Error("Invalid id " + i.ToString() + " in get image");
                return new sImage();
            }

            return images[i];
        }
        public void Set_Image(int i, sImage image)
        {
            if (i < 0 || i >= images.Count)
            {
                Error("Invalid id " + i.ToString() + " in set image");
                return;
            }

            images[i] = image;
        }
        public void Add_Image(sImage image)
        {
            images.Add(image);
        }
        public void Image_Up(int i)
        {
            if (i <= 0)
            {
                Error("You can't up this note");
                return;
            }

            sImage image = images[i];
            images.RemoveAt(i);
            images.Insert(i - 1, image);
        }
        public void Image_Down(int i)
        {
            if (i >= images.Count - 1)
            {
                Error("You can't up this note");
                return;
            }

            sImage image = images[i];
            images.RemoveAt(i);
            images.Insert(i + 1, image);
        }
        public void Remove_Image(int i)
        {
            if (i < 0 || i >= images.Count)
            {
                Error("Invalid id " + i.ToString() + " in remove image");
                return;
            }

            images.RemoveAt(i);
            Error("Removing image at " + i.ToString());
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

        public bool Edited
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
        public bool Null
        {
            get
            {
                if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(history))
                    return true;
                else
                    return false;
            }
        }
        #endregion

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
    public struct sNote
    {
        public string title;
        public string msg;
        public DateTime date;

        public sNote(string title, string msg)
        {
            this.title = title;
            this.msg = msg;
            this.date = DateTime.Now;
        }
        
        public static sNote Parse(XElement e)
        {
            sNote note = new sNote();
            note.title = Patient.Get_XValue(e, "Title");
            note.msg = Patient.Get_XValue(e, "Message");
            note.date = DateTime.Parse(Patient.Get_XValue(e, "Date"));
            return note;
        }
        public XElement ToXElement()
        {
            XElement e = new XElement("Note");
            e.Add(new XElement("Title", this.title));
            e.Add(new XElement("Message", this.msg));
            e.Add(new XElement("Date", this.date.ToString()));
            return e;
        }
    }
    public struct sImage
    {
        public string title;
        public string relative_path;
        public DateTime date;

        public static sImage Parse(XElement e)
        {
            sImage img = new sImage();
            img.title = Patient.Get_XValue(e, "Title");
            img.relative_path = Patient.Get_XValue(e, "Path");
            img.date = DateTime.Parse(Patient.Get_XValue(e, "Date"));
            return img;
        }
        public XElement ToXElement()
        {
            XElement e = new XElement("Image");
            e.Add(new XElement("Title", this.title));
            e.Add(new XElement("Path", this.relative_path));
            e.Add(new XElement("Date", this.date.ToString()));
            return e;
        }
    }

    public enum Phone_Type
    {
        Landline,
        Mobile
    }
}
