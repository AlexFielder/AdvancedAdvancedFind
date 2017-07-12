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
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AdvancedAdvancedFind
{
    [XmlRoot("SavedSearch")]
    public class SavedSearch
    {
        private static String SAVED_SEARCH_FOLDER = "SavedSearches";

        [XmlElement("Condition")]
        public List<SrchCondItem> Conditions;

        [XmlElement("EntityType")]
        public string EntityType;

        public static string GetDefaultFolder()
        {
            return Path.Combine(Util.GetAssemblyPath(), SAVED_SEARCH_FOLDER);
        }

        public void Save(string filePath)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SavedSearch));
                    serializer.Serialize(writer, this);
                }
            }
            catch
            { }
        }

        public static SavedSearch Load(string fileName)
        {
            SavedSearch retVal = new SavedSearch();

            try
            {
                string xmlPath = Path.Combine(Util.GetAssemblyPath(), SAVED_SEARCH_FOLDER);
                xmlPath = Path.Combine(xmlPath, fileName);

                using (System.IO.StreamReader reader = new System.IO.StreamReader(xmlPath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SavedSearch));
                    retVal = (SavedSearch)serializer.Deserialize(reader);
                }
            }
            catch
            { }

            return retVal;
        }
    }
}
