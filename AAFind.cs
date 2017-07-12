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
using System.Windows.Forms;

using Autodesk.Connectivity.WebServices;
using Autodesk.Connectivity.Explorer.Extensibility;
using Autodesk.Connectivity.Extensibility.Framework;
using Autodesk.Connectivity.WebServicesTools;
using Autodesk.DataManagement.Client.Framework.Vault.Currency.Connections;
using VDF = Autodesk.DataManagement.Client.Framework;

[assembly: ApiVersion("10.0")]
[assembly: ExtensionId("68A25047-183E-47E5-A123-3344BD9A9D0F")]

namespace AdvancedAdvancedFind
{
    public class AAFind : IExplorerExtension
    {
        private bool? m_isVaultPro = null;

        #region IExtension Members

        public IEnumerable<CommandSite> CommandSites()
        {
            CommandSite site = new CommandSite("Autodesk.AAFind.Site", "Advanced Advanced Find")
            {
                DeployAsPulldownMenu = false,
                Location = CommandSiteLocation.ToolsMenu
            };

            CommandItem cmd = new CommandItem("Autodesk.AAFind.Cmd", "Advanced Advanced Find...")
            {
                Image = Icons.OnesAndZeros,
                Description = "A search that supports OR conditions",
                Hint = "A search that supports OR conditions",
                ToolbarPaintStyle = PaintStyle.TextAndGlyph
            };
            cmd.Execute += new EventHandler<CommandItemEventArgs>(cmd_Execute);

            site.AddCommand(cmd);
            return new CommandSite[] { site };
        }

        public IEnumerable<DetailPaneTab> DetailTabs()
        {
            return null;
        }

        public IEnumerable<string> HiddenCommands()
        {
            return null;
        }

        public IEnumerable<CustomEntityHandler> CustomEntityHandlers()
        {
            return null;
        }

        public void OnLogOff(IApplication application)
        {

        }

        public void OnLogOn(IApplication application)
        {
            
        }

        public void OnShutdown(IApplication application)
        {
        }

        public void OnStartup(IApplication application)
        {
        }

        public string ResourceCollectionName()
        {
            return "Icons";
        }

        #endregion


        void cmd_Execute(object sender, CommandItemEventArgs e)
        {
            Util.DoAction(delegate
            {
                Connection conn = e.Context.Application.Connection;

                // lookup the server product to see if we are Vault Professional
                // remember the value so we don't have to look it up again in this session
                if (m_isVaultPro == null)
                {
                    Product[] products = conn.WebServiceManager.InformationService.GetSystemProducts();
                    m_isVaultPro = products.Any(n => n.ProductName == "Autodesk.Productstream");
                }

                FinderDialog dialog = new FinderDialog(m_isVaultPro.Value, conn);
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK && dialog.GoToLocation)
                {
                    LocationContext location = null;

                    if (dialog.GoToEntity.EntityClass.ServerId == VDF.Vault.Currency.Entities.EntityClassIds.ChangeOrders)
                    {
                        VDF.Vault.Currency.Entities.ChangeOrder co = dialog.GoToEntity as VDF.Vault.Currency.Entities.ChangeOrder;
                        if (co != null)
                            location = new LocationContext(SelectionTypeId.ChangeOrder, co.Number);
                    }
                    else if (dialog.GoToEntity.EntityClass.ServerId == VDF.Vault.Currency.Entities.EntityClassIds.CustomObject)
                    {
                        VDF.Vault.Currency.Entities.CustomObject custom = dialog.GoToEntity as VDF.Vault.Currency.Entities.CustomObject;
                        if (custom != null)
                        {
                            CustEnt custEnt = custom;
                            SelectionTypeId selectionType = new SelectionTypeId(custom.Definition.SystemName);
                            location = new LocationContext(selectionType, custEnt.Num);
                        }
                    }
                    else if (dialog.GoToEntity.EntityClass.ServerId == VDF.Vault.Currency.Entities.EntityClassIds.Files)
                    {
                        VDF.Vault.Currency.Entities.FileIteration file = dialog.GoToEntity as VDF.Vault.Currency.Entities.FileIteration;
                        if (file != null)
                        {
                            location = new LocationContext(SelectionTypeId.File, file.Parent.FullName + "/" + file.EntityName);
                        }
                    }
                    else if (dialog.GoToEntity.EntityClass.ServerId == VDF.Vault.Currency.Entities.EntityClassIds.Folder)
                    {
                        VDF.Vault.Currency.Entities.Folder folder = dialog.GoToEntity as VDF.Vault.Currency.Entities.Folder;
                        if (folder != null)
                            location = new LocationContext(SelectionTypeId.Folder, folder.FullName);
                    }
                    else if (dialog.GoToEntity.EntityClass.ServerId == VDF.Vault.Currency.Entities.EntityClassIds.Items)
                    {
                        VDF.Vault.Currency.Entities.ItemRevision item = dialog.GoToEntity as VDF.Vault.Currency.Entities.ItemRevision;
                        if (item != null)
                            location = new LocationContext(SelectionTypeId.Item, item.ItemNumber);
                    }

                    if (location != null)
                        e.Context.GoToLocation = location;
                }

            });
            
        }
    }
}
