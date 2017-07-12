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
using System.Windows.Forms;

using Autodesk.Connectivity.WebServices;

public class Util
{

    public static void DoAction(Action a)
    {
        try
        {
            a();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    public static string GetAssemblyPath()
    {
        string prefix = "file:///";
        string codebase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
        if (codebase.StartsWith(prefix))
            codebase = codebase.Substring(prefix.Length);

        return Path.GetDirectoryName(codebase);
    }

    public static string VaultPathCombine(string part1, string part2)
    {
        if (!part1.EndsWith("/"))
            part1 = part1 + "/";

        if (part2.StartsWith("/"))
            part2 = part2.Remove(0, 1);

        return part1 + part2;
    }
}

internal static class ExtensionMethods
{
    internal static T[] ToSingleArray<T>(this T obj)
    {
        return new T[] { obj };
    }

    internal static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
    {
        return collection == null || collection.Count() == 0;
    }

    internal static List<T> ShallowCopy<T>(this List<T> origList)
    {
        List<T> newList = new List<T>();
        newList.AddRange(origList);
        return newList;
    }

    
}
