//-----------------------------------------------------------------------
// <copyright file="DataEditor.cs" company="none">
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
using System.Windows.Forms;

namespace MiConsulta
{
    /// <summary>
    /// Description of IDataEditor.
    /// </summary>
    public class DataEditor : DataForm  // TODO: MUST be abstract class, but makes problems to the UI Designer
    {
        protected DataEditor()
        { }
        
        protected DataEditor(PatientData data)
            : base(data)
        { }
        
        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (!this.CheckData())
                return;
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        
        protected virtual bool CheckData() { return false; }  // TODO: Must be abstract method
    }
}
