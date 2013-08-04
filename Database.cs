// ----------------------------------------------------------------------
// <copyright file="Database.cs" company="none">

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
// <date>06/09/2012 15:41:49</date>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MiConsulta
{
    public class Database
    {
        List<Patient> patients;
        bool modified;

        /// <summary>
        /// Create a new database
        /// </summary>
        public Database()
        {
            Create();
        }
        /// <summary>
        /// Read a xml database file.
        /// </summary>
        /// <param name="xmldb">Database file path</param>
        public Database(string xmldb)
        {
            Read(xmldb);
        }

        private void Create()
        {
            Console.WriteLine("Creating new database.");
            patients = new List<Patient>();
            modified = false;
        }
        private void Read(string db_in)
        {
            Console.WriteLine("Reading file {0}", db_in);

            if (!System.IO.File.Exists(db_in))
            {
                Console.WriteLine("DB doesn't exist.");
                Create();
                return;
            }

            XDocument doc = new XDocument();
            try { doc = XDocument.Load(db_in); }
            catch (Exception e) { Console.WriteLine(e.Message + '\n' + e.StackTrace); Create(); return; }

            XElement root = doc.Element("MiConsulta");
            if (root == null)
            {
                Console.WriteLine("Invalid XML file. <MiConsulta> must be the root element");
                Create();
            }

            patients = new List<Patient>();
            foreach (XElement e in root.Elements("Patient"))
                patients.Add(new Patient(e));
            Console.WriteLine("Read {0} elements.", patients.Count.ToString());

            root = null;
            doc = null;
            modified = false;
        }
        public void Write(string db_out)
        {
            Console.WriteLine("Saving file to {0}", db_out);
            if (String.IsNullOrEmpty(db_out))
            {
                Console.WriteLine("Error saving file, it's empty or null.");
                return;
            }

            XDocument doc = new XDocument();

            XElement root = new XElement("MiConsulta");
            foreach (Patient p in patients)
                root.Add(p.ToXElement());
            doc.Add(root);

            if (System.IO.File.Exists(db_out))
                System.IO.File.Delete(db_out);
            doc.Save(db_out);

            root = null;
            doc = null;
            modified = false;
        }

        public void Modify(int id, Patient p)
        {
            if (id >= patients.Count)
            {
                Console.WriteLine("Invalid id to replace patient! -> {0}", id.ToString());
                return;
            }

            Console.WriteLine("Replacing {0} ({1})", id.ToString(), patients[id].Name);
            patients[id] = p;

            modified = true;
        }
        public int Add(Patient p)
        {
            patients.Add(p);
            modified = true;

            int id = (patients.Count - 1);
            Console.WriteLine("Person ({1}) added to {0}", id.ToString(), p.Name);
            return id;
        }
        public void Remove(int id)
        {
            if (id >= patients.Count)
            {
                Console.WriteLine("Invalid id to remove patient! -> {1}", id.ToString());
                return;
            }

            Console.WriteLine("Removing at {0} ({1})", id, patients[id].Name);
            patients.RemoveAt(id);
            modified = true;
        }
        public Patient Get_Patient(int id)
        {
            if (id < 0 || id >= patients.Count)
            {
                Console.WriteLine("Invalid id to get patient! -> {1}", id.ToString());
                return new Patient();
            }

            return (Patient)patients[id].Clone();
        }

        public string[] Get_List(int t)
        {
            List<string> s = new List<string>();
            for (int i = 0; i < patients.Count; i++)
            {
                switch (t)
                {
                    case 0: s.Add(patients[i].History); break;
                    case 1: s.Add(patients[i].Name); break;
                    case 2:
                        for (int p = 0; p < patients[i].PhonesLength; p++)
                            s.Add(patients[i].Get_Phone(p).number);
                        break;
                    case 3: s.Add(patients[i].Address); break;
                    case 4: s.Add(patients[i].Email); break;
                    case 5:
                        for (int n = 0; n < patients[i].NotesLength; n++)
                            s.Add(patients[i].Get_Note(n).title + " (" + patients[i].Name + ')');
                        break;
                    case 6: s.Add(patients[i].Get_LastAppointment().ToString()); break;
                    case 7: s.Add(patients[i].Get_NextAppointment().ToString()); break;
                }
            }
            return s.ToArray();
        }
        public int Search(int t, string value)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                switch (t)
                {
                    case 0: if (patients[i].History == value) return i; break;
                    case 1: if (patients[i].Name == value) return i; break;
                    case 2: 
                        for (int p = 0; p < patients[i].PhonesLength; p++)
                            if (patients[i].Get_Phone(p).number == value)
                                return i;
                         break;
                    case 3: if (patients[i].Address == value) return i; break;
                    case 4: if (patients[i].Email == value) return i; break;
                    case 5:
                        for (int n = 0; n < patients[i].NotesLength; n++)
                            if (patients[i].Get_Note(n).title + " (" + patients[i].Name + ')' == value)
                                return i;
                        break;
                    case 6: if (patients[i].Get_LastAppointment().ToString() == value) return i; break;
                    case 7: if (patients[i].Get_NextAppointment().ToString() == value) return i; break;
                }
            }

            return -1;
        }

        public bool Modified
        {
            get { return modified; }
        }
        public int PatientLength
        {
            get { return patients.Count; }
        }
    }
}
