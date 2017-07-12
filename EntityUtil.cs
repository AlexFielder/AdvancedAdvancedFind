/*=====================================================================
  
  This file is part of the Autodesk Vault API Code Samples.

  Copyright (C) Autodesk Inc.  All rights reserved.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedAdvancedFind
{
    class EntityClass
    {
        public static EntityClass FILE = new EntityClass("File", "FILE");
        public static EntityClass FLDR = new EntityClass("Folder", "FLDR");
        public static EntityClass ITEM = new EntityClass("Item", "ITEM");
        public static EntityClass CO = new EntityClass("Change Order", "CO");
        public static EntityClass CUSTENT = new EntityClass("Custom Object", "CUSTENT");
        

        /// <summary>
        /// The value to display to the user
        /// </summary>
        public string DisplayName { get; private set;}

        /// <summary>
        /// A code to use when making the web service call.
        /// </summary>
        public string EntityClassId { get; private set;}

        private EntityClass(string displayName, string entityClassId)
        {
            this.DisplayName = displayName;
            this.EntityClassId = entityClassId;
        }

        /// <summary>
        /// Returns the current value of the DisplayName property.
        /// </summary>
        public override string ToString()
        {
            return DisplayName;
        }
    }
}
