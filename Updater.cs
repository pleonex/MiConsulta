// ----------------------------------------------------------------------
// <copyright file="Updater.cs" company="none">

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
// <date>10/09/2012 17:32:41</date>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using System.Reflection;

namespace MiConsulta
{
    public static class Updater
    {
        public static string upd_file = "https://dl.dropbox.com/u/3981393/jkl/MiConsulta_Update.xml";
        public static string ping_web = "google.es";

        public static bool Check_Internet()
        {
            Ping ping = new Ping();
            PingReply reply;
            try { reply = ping.Send(ping_web, 1000); }
            catch (Exception e) { Console.WriteLine("Exception at ping\n {0}", e.Message); return false; }
            ping.Dispose();
            ping = null;

            Console.WriteLine("Ping to google.es -> {0}", Enum.GetName(typeof(IPStatus), reply.Status));
            if (reply.Status != IPStatus.Success)
                return false;
            else
                return true;
        }

        public static bool Check_Update()
        {
            Console.WriteLine("Checking updates...");
            XDocument doc = XDocument.Load(upd_file);
            XElement root = doc.Element("Update");

            // Get the last version
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            foreach (XElement v in root.Elements("Version"))
            {
                Version cv = new Version(v.Element("Number").Value);
                if (cv > version)
                    version = cv;
                Console.WriteLine(cv.ToString());
            }

            root = null;
            doc = null;

            return (version > Assembly.GetExecutingAssembly().GetName().Version);
        }

        public static void Get_UpdateParam(out string log, out Version version, out string[,] files)
        {
            log = "";
            version = Assembly.GetExecutingAssembly().GetName().Version;
            files = new string[0,2];

            Console.WriteLine("Getting update params...");
            XDocument doc = XDocument.Load(upd_file);
            XElement root = doc.Element("Update");

            // Get the last version
            foreach (XElement v in root.Elements("Version"))
            {
                Version cv = new Version(v.Element("Number").Value);
                if (cv > version)
                    version = cv;
            }

            // Get the parameters
            foreach (XElement v in root.Elements("Version"))
            {
                Version cv = new Version(v.Element("Number").Value);
                if (cv != version)
                    continue;

                version = cv;
                log = v.Element("ChangeLog").Value;

                List<XElement> xfiles = new List<XElement>();
                xfiles.AddRange(v.Elements("File"));
                files = new string[xfiles.Count, 2];
                for (int i = 0; i < xfiles.Count; i++)
                {
                    files[i, 0] = xfiles[i].Value;
                    files[i, 1] = xfiles[i].Attribute("Execute").Value;
                }
                Console.WriteLine("{0} file to download", xfiles.Count.ToString());
            }

            root = null;
            doc = null;
        }
    }
}
