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
using System.Xml.Serialization;

using Autodesk.Connectivity.WebServices;

namespace AdvancedAdvancedFind
{

    /// <summary>
    /// Wrapper for a PropDef object use in list displays 
    /// </summary>
    class PropDefItem
    {
        public PropDef PropDef;

        public PropDefItem(PropDef propDef)
        {
            this.PropDef = propDef;
        }

        public override string ToString()
        {
            return PropDef.DispName;
        }
    }


    /// <summary>
    /// Wrapper for a SrchCond object use in list displays  
    /// </summary>
    [XmlRoot("SearchConditionItem")]
    public class SrchCondItem
    {
        public SrchCond SrchCond;
        public PropDef PropDef;

        public SrchCondItem() { }

        public SrchCondItem(SrchCond srchCond, PropDef propDef)
        {
            this.SrchCond = srchCond;
            this.PropDef = propDef;
        }

        public override string ToString()
        {
            string conditionName = Condition.GetCondition(SrchCond.SrchOper).DisplayName;
            return String.Format("{0} {1} {2} {3}", PropDef.DispName, SrchCond.SrchRule, conditionName, SrchCond.SrchTxt);
        }
    }

    /// <summary>
    /// Wrapper for a SearchRuleType enum value for use in list displays
    /// </summary>
    public class RuleItem
    {
        public SearchRuleType Rule { get; private set; }
        public string DisplayName { get; private set; }

        public RuleItem(SearchRuleType rule, string displayName)
        {
            this.Rule = rule;
            this.DisplayName = displayName;
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
