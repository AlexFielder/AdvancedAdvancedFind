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
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Autodesk.Connectivity.WebServices;
using Autodesk.DataManagement.Client.Framework.Vault.Currency.Connections;
using VDF = Autodesk.DataManagement.Client.Framework;

namespace AdvancedAdvancedFind
{
    public partial class FinderDialog : Form
    {
        private static string PERSISTANCE_KEY = "Autodesk.AdvancedAdvancedFind.Grid";
        private bool m_isVaultPro;
        private Connection m_conn;
        private VDF.Vault.Forms.Models.ViewVaultNavigationModel m_gridContent;

        public bool GoToLocation = false;
        public VDF.Vault.Currency.Entities.IEntity GoToEntity;

        public FinderDialog(bool isVaultPro, Connection conn)
        {
            InitializeComponent();

            m_isVaultPro = isVaultPro;
            m_conn = conn;
            checkBox1.Checked = false;
            InitializeEnitityClassComboBox();
            InitializePropertyComboBox(m_propertyComboBox);
            InitializePropertyComboBox(m_valueComboBox);
            InitializeConditionComboBox();
            InitializeRulesComboBox();
            InitializeGrid();
            
        }

        private void InitializeGrid()
        {
            VDF.Vault.Forms.Controls.VaultBrowserControl.Configuration config =
                new VDF.Vault.Forms.Controls.VaultBrowserControl.Configuration(m_conn, PERSISTANCE_KEY, null);

            config.AddInitialColumn(VDF.Vault.Currency.Properties.PropertyDefinitionIds.Server.EntityName);
            config.AddInitialSortCriteria(VDF.Vault.Currency.Properties.PropertyDefinitionIds.Server.EntityName, true);

            m_gridContent = new VDF.Vault.Forms.Models.ViewVaultNavigationModel();
           
            m_vaultBrowseControl.SetDataSource(config, m_gridContent);
            m_vaultBrowseControl.OptionsBehavior.MultiSelect = false;

            m_vaultBrowseControl.EntityDoubleClick += new EventHandler<VDF.Vault.Forms.Currency.EntityEventArgs>(m_vaultBrowseControl_EntityDoubleClick);
        }

        void m_vaultBrowseControl_EntityDoubleClick(object sender, VDF.Vault.Forms.Currency.EntityEventArgs e)
        {
            if (e.Entity == null)
                return;

            GoToLocation = true;
            GoToEntity = e.Entity;
            DialogResult = DialogResult.OK;
        }

        private void InitializeEnitityClassComboBox()
        {
            m_entityClassComboBox.Items.Add(EntityClass.FILE);
            m_entityClassComboBox.Items.Add(EntityClass.FLDR);

            if (m_isVaultPro)
            {
                m_entityClassComboBox.Items.Add(EntityClass.ITEM);
                m_entityClassComboBox.Items.Add(EntityClass.CO);
                m_entityClassComboBox.Items.Add(EntityClass.CUSTENT);
            }
        }

        private void InitializeRulesComboBox()
        {
            m_ruleComboBox.Items.Add(new RuleItem(SearchRuleType.Must, "Must"));

            // Must not is not currently supported
            //m_ruleComboBox.Items.Add(new RuleItem(SearchRuleType.MustNot, "Must Not"));

            m_ruleComboBox.Items.Add(new RuleItem(SearchRuleType.May, "May"));
        }

        /// <summary>
        /// Intializes the combox box containing the searchable properties available.
        /// </summary>
        private void InitializePropertyComboBox(ComboBox thisBox)
        {
            thisBox.SelectedItem = null;

            EntityClass entityClass = m_entityClassComboBox.SelectedItem as EntityClass;
            if (entityClass == null)
            {
                thisBox.Items.Clear();
                return;
            }

            //get the entire extended list of properties
            PropDef[] defs = m_conn.WebServiceManager.PropertyService.GetPropertyDefinitionsByEntityClassId(entityClass.EntityClassId);

            if (defs != null && defs.Length > 0)
            {
                //wait to draw the combo box until we've added all of the properties
                thisBox.BeginUpdate();

                thisBox.Items.Clear();

                foreach (PropDef def in defs.OrderBy(n => n.DispName))
                {
                    //create a list item type that will hold the property
                    PropDefItem item = new PropDefItem(def);

                    thisBox.Items.Add(item);
                }

                //indicate that we've finished updated the combobox and it can now be re-drawn
                thisBox.EndUpdate();
            }
        }

        private void InitializeConditionComboBox()
        {
            //wait to draw the combo box until we've populated it with conditions
            m_conditionComboBox.BeginUpdate();

            m_conditionComboBox.Items.Clear();
            m_conditionComboBox.SelectedItem = null;
            m_conditionComboBox.Text = String.Empty;

            PropDefItem propDefItem = m_propertyComboBox.SelectedItem as PropDefItem;
            Condition[] allowedConditions = null;

            if (propDefItem == null)
            { } // leave the combo box empty
            else if (propDefItem.PropDef.Typ == DataType.Bool)
            {
                allowedConditions = new Condition[] 
                { 
                    Condition.EQUALS, 
                    Condition.NOT_EQUAL
                };
            }
            else if (propDefItem.PropDef.Typ == DataType.DateTime ||
                propDefItem.PropDef.Typ == DataType.Numeric)
            {
                allowedConditions = new Condition[] 
                { 
                    Condition.EQUALS, 
                    Condition.NOT_EQUAL,
                    Condition.LESS_THAN_OR_EQUAL,
                    Condition.LESS_THAN,
                    Condition.GREATER_THAN_OR_EQUAL,
                    Condition.GREATER_THAN
                };
            }
            else if (propDefItem.PropDef.Typ == DataType.Bool)
            {
                allowedConditions = new Condition[] 
                { 
                    Condition.IS_EMPTY, 
                    Condition.IS_NOT_EMPTY
                };
            }
            else if (propDefItem.PropDef.Typ == DataType.String)
            {

                //populate the combo box with the conditions
                allowedConditions = new Condition[] 
                {
                    Condition.CONTAINS, 
                    Condition.EQUALS, 
                    Condition.DOES_NOT_CONTAIN,
                    Condition.IS_EMPTY,
                    Condition.IS_NOT_EMPTY,
                    Condition.LESS_THAN_OR_EQUAL,
                    Condition.LESS_THAN,
                    Condition.GREATER_THAN_OR_EQUAL,
                    Condition.GREATER_THAN,
                    Condition.NOT_EQUAL
                };
            }

            if (allowedConditions != null)
                m_conditionComboBox.Items.AddRange(allowedConditions);

            //indicated that we're finished populating the combobox and that it can be re-drawn
            m_conditionComboBox.EndUpdate();

        }

        private void m_addCriteriaButton_Click(object sender, EventArgs e)
        {
            //get a local reference of the currently selected PropertyDefinition object
            PropDefItem propertyItem = m_propertyComboBox.SelectedItem as PropDefItem;
            PropDef property;
            property = (propertyItem == null) ? null : propertyItem.PropDef;

            //get local reference of the condition combo boxes currently selected item
            Condition condition = m_conditionComboBox.SelectedItem as Condition;

            if (property == null || condition == null)
                return;

            SearchRuleType rule = SearchRuleType.Must;
            RuleItem ruleItem = m_ruleComboBox.SelectedItem as RuleItem;
            if (ruleItem != null)
                rule = ruleItem.Rule;


            //create a SearchCondition object
            SrchCond searchCondition = new SrchCond();
            searchCondition.PropDefId = property.Id;
            searchCondition.PropTyp = PropertySearchType.SingleProperty;
            searchCondition.SrchOper = condition.Code;
            if(checkBox1.Checked)
            {
                //here we would effectively need to perform a search for everything and then search those results.
                searchCondition.SrchTxt = m_valueComboBox.SelectedItem.ToString();
            }
            else
            {
                searchCondition.SrchTxt = m_valueTextBox.Text;
            }
            
            searchCondition.SrchRule = rule;


            //create the list item to contain the condition
            SrchCondItem searchItem = new SrchCondItem(searchCondition, property);

            //add the SearchCondition object to the search criteria list box
            m_criteriaListBox.Items.Add(searchItem);
        }

        private void m_removeCriteriaButton_Click(object sender, EventArgs e)
        {
            //remove the currently selected search condition item from the list box
            if (m_criteriaListBox.SelectedItem != null)
                m_criteriaListBox.Items.RemoveAt(m_criteriaListBox.SelectedIndex);
        }

        private void m_findButton_Click(object sender, EventArgs e)
        {
            Util.DoAction(delegate
            {
                RunFind();
            });
        }

        private void ClearGrid()
        {
            if (m_gridContent == null || m_gridContent.Content == null)
                return;

            VDF.Vault.Currency.Entities.IEntity [] entities = m_gridContent.Content.ToArray();
            m_gridContent.RemoveContent(entities);

            m_vaultBrowseControl.Refresh();
        }

        private void RunFind()
        {
            //make sure search conditions have been added
            if (m_criteriaListBox.Items.Count > 0)
            {
                //clear out previous search results if they exist
                ClearGrid();

                //build our array of SearchConditions to use for the file search
                SrchCond[] conditions = new SrchCond[m_criteriaListBox.Items.Count];

                for (int i = 0; i < m_criteriaListBox.Items.Count; i++)
                {
                    conditions[i] = ((SrchCondItem)m_criteriaListBox.Items[i]).SrchCond;
                }

                List<VDF.Vault.Currency.Entities.IEntity> results = null;
                if (m_entityClassComboBox.SelectedItem == EntityClass.FILE)
                    results = DoFileSearch(conditions);
                else if (m_entityClassComboBox.SelectedItem == EntityClass.ITEM)
                    results = DoItemSearch(conditions);
                else if (m_entityClassComboBox.SelectedItem == EntityClass.CO)
                    results = DoChangeOrderSearch(conditions);
                else if (m_entityClassComboBox.SelectedItem == EntityClass.FLDR)
                    results = DoFolderSearch(conditions);
                else if (m_entityClassComboBox.SelectedItem == EntityClass.CUSTENT)
                    results = DoCustEntSearch(conditions);

                if (results != null && results.Count > 0)
                {
                    m_gridContent.AddContent(results);
                    m_itemsCountLabel.Text = results.Count + " entities found";
                    m_vaultBrowseControl.Refresh();
                }
                else
                    m_itemsCountLabel.Text = "0 entities found";
            }   
        }

        private List<VDF.Vault.Currency.Entities.IEntity> DoCustEntSearch(SrchCond[] conditions)
        {
            string bookmark = string.Empty;
            SrchStatus status = null;

            //search for files
            List<VDF.Vault.Currency.Entities.IEntity> retVal = new List<VDF.Vault.Currency.Entities.IEntity>();

            while (status == null || retVal.Count < status.TotalHits)
            {
                CustEnt[] ents = m_conn.WebServiceManager.CustomEntityService.FindCustomEntitiesBySearchConditions(
                    conditions, null, ref bookmark, out status);

                if (ents != null)
                {
                    foreach (CustEnt ent in ents)
                    {
                        VDF.Vault.Currency.Entities.CustomObject vdfEnt = new VDF.Vault.Currency.Entities.CustomObject(m_conn, ent);
                        retVal.Add(vdfEnt);
                    }
                }
            }

            return retVal;
        }

        private List<VDF.Vault.Currency.Entities.IEntity> DoFolderSearch(SrchCond[] conditions)
        {
            string bookmark = string.Empty;
            SrchStatus status = null;

            //search for files
            List<VDF.Vault.Currency.Entities.IEntity> retVal = new List<VDF.Vault.Currency.Entities.IEntity>();

            while (status == null || retVal.Count < status.TotalHits)
            {
                Folder[] folders = m_conn.WebServiceManager.DocumentService.FindFoldersBySearchConditions(
                    conditions, null, null, false, ref bookmark, out status);

                if (folders != null)
                {
                    foreach (Folder folder in folders)
                    {
                        VDF.Vault.Currency.Entities.Folder vdfFolder = new VDF.Vault.Currency.Entities.Folder(m_conn, folder);
                        retVal.Add(vdfFolder);
                    }
                }
            }

            return retVal;
        }

        private List<VDF.Vault.Currency.Entities.IEntity> DoChangeOrderSearch(SrchCond[] conditions)
        {
            string bookmark = string.Empty;
            SrchStatus status = null;

            //search for files
            List<VDF.Vault.Currency.Entities.IEntity> retVal = new List<VDF.Vault.Currency.Entities.IEntity>();
            
            while (status == null || retVal.Count < status.TotalHits)
            {
                ChangeOrder[] changeOrders = m_conn.WebServiceManager.ChangeOrderService.FindChangeOrdersBySearchConditions(
                    conditions, null, ref bookmark, out status);

                if (changeOrders != null)
                {
                    foreach (ChangeOrder co in changeOrders)
                    {
                        VDF.Vault.Currency.Entities.ChangeOrder vdfCo = new VDF.Vault.Currency.Entities.ChangeOrder(m_conn, co);
                        retVal.Add(vdfCo);
                    }
                }
            }

            return retVal;
        }

        private List<VDF.Vault.Currency.Entities.IEntity> DoItemSearch(SrchCond[] conditions)
        {
            string bookmark = string.Empty;
            SrchStatus status = null;

            //search for files
            List<VDF.Vault.Currency.Entities.IEntity> retVal = new List<VDF.Vault.Currency.Entities.IEntity>();
            
            while (status == null || retVal.Count < status.TotalHits)
            {
                Item[] items = m_conn.WebServiceManager.ItemService.FindItemRevisionsBySearchConditions(
                    conditions, null, true,
                    ref bookmark, out status);

                if (items != null)
                {
                    foreach (Item item in items)
                    {
                        VDF.Vault.Currency.Entities.ItemRevision vdfItem =
                            new VDF.Vault.Currency.Entities.ItemRevision(m_conn, item);
                        retVal.Add(vdfItem);
                    }
                }
            }

            return retVal;
        }

        private List<VDF.Vault.Currency.Entities.IEntity> DoFileSearch(SrchCond[] conditions)
        {
            string bookmark = string.Empty;
            SrchStatus status = null;

            //search for files
            List<VDF.Vault.Currency.Entities.IEntity> retVal = new List<VDF.Vault.Currency.Entities.IEntity>();
            
            while (status == null || retVal.Count < status.TotalHits)
            {
                FileFolder[] filefolders = m_conn.WebServiceManager.DocumentService.FindFileFoldersBySearchConditions(
                    conditions, null, null, true, true,
                    ref bookmark, out status);

                if (filefolders != null)
                {
                    foreach (FileFolder fileFolder in filefolders)
                    {
                        VDF.Vault.Currency.Entities.Folder folder = 
                            new VDF.Vault.Currency.Entities.Folder(m_conn, fileFolder.Folder);
                        VDF.Vault.Currency.Entities.FileIteration file =
                            new VDF.Vault.Currency.Entities.FileIteration(
                                m_conn, folder, fileFolder.File);
                        retVal.Add(file);
                    }
                }
            }

            return retVal;
        }

        private void m_entityClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializePropertyComboBox(m_propertyComboBox);
            InitializePropertyComboBox(m_valueComboBox);
            InitializeConditionComboBox();

            m_criteriaListBox.Items.Clear();
            
        }

        private void m_propertyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeConditionComboBox();
        }

        private void m_saveSettingsButton_Click(object sender, EventArgs e)
        {
            Util.DoAction(delegate
            {
                RunSave();
            });
        }

        private void RunSave()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".xml";
            saveFile.Filter = "XML files|*.xml";
            saveFile.InitialDirectory = SavedSearch.GetDefaultFolder();

            if (!System.IO.Directory.Exists(saveFile.InitialDirectory))
                System.IO.Directory.CreateDirectory(saveFile.InitialDirectory);

            DialogResult result = saveFile.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                SavedSearch search = new SavedSearch();
                EntityClass entityClass = m_entityClassComboBox.SelectedItem as EntityClass;

                if (entityClass == null)
                {
                    MessageBox.Show("You must select an entity type.");
                    return;
                }

                search.EntityType = entityClass.EntityClassId;
                List<SrchCondItem> conditions = new List<SrchCondItem>();
                foreach (Object o in m_criteriaListBox.Items)
                {
                    SrchCondItem item = o as SrchCondItem;
                    if (item != null)
                        conditions.Add(item);
                }

                if (!conditions.Any())
                {
                    MessageBox.Show("You must have at least one search condition.");
                    return;
                }

                search.Conditions = conditions;

                search.Save(saveFile.FileName);
            }
        }

        private void m_loadSettingsButton_Click(object sender, EventArgs e)
        {
            Util.DoAction(delegate
            {
                RunLoad();
            });
        }

        private void RunLoad()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = ".xml";
            openFile.Filter = "XML files|*.xml";
            openFile.InitialDirectory = SavedSearch.GetDefaultFolder();

            if (!System.IO.Directory.Exists(openFile.InitialDirectory))
                System.IO.Directory.CreateDirectory(openFile.InitialDirectory);

            DialogResult result = openFile.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                SavedSearch search = SavedSearch.Load(openFile.FileName);

                //m_entityClassComboBox.SelectedItem as EntityClass;

                if (search.EntityType == EntityClass.CO.EntityClassId)
                    m_entityClassComboBox.SelectedItem = EntityClass.CO;
                else if (search.EntityType == EntityClass.CUSTENT.EntityClassId)
                    m_entityClassComboBox.SelectedItem = EntityClass.CUSTENT;
                else if (search.EntityType == EntityClass.FILE.EntityClassId)
                    m_entityClassComboBox.SelectedItem = EntityClass.FILE;
                else if (search.EntityType == EntityClass.FLDR.EntityClassId)
                    m_entityClassComboBox.SelectedItem = EntityClass.FLDR;
                else if (search.EntityType == EntityClass.ITEM.EntityClassId)
                    m_entityClassComboBox.SelectedItem = EntityClass.ITEM;
                else
                    throw new Exception("Unknown entity type");

                m_criteriaListBox.Items.Clear();
                m_criteriaListBox.Items.AddRange(search.Conditions.ToArray());
            }
        }

        private void m_valueComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeConditionComboBox();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                m_valueComboBox.Enabled = true;
                m_valueTextBox.Enabled = false;
                //m_valueComboBox.
            }
            else
            {
                m_valueComboBox.Enabled = false;
                m_valueTextBox.Enabled = true;
            }
        }
    }
}
