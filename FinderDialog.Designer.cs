namespace AdvancedAdvancedFind
{
    partial class FinderDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinderDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_itemsCountLabel = new System.Windows.Forms.Label();
            this.m_propertyComboBox = new System.Windows.Forms.ComboBox();
            this.m_ruleComboBox = new System.Windows.Forms.ComboBox();
            this.m_conditionComboBox = new System.Windows.Forms.ComboBox();
            this.m_valueTextBox = new System.Windows.Forms.TextBox();
            this.m_findButton = new System.Windows.Forms.Button();
            this.m_addCriteriaButton = new System.Windows.Forms.Button();
            this.m_removeCriteriaButton = new System.Windows.Forms.Button();
            this.m_criteriaListBox = new System.Windows.Forms.ListBox();
            this.m_entityClassComboBox = new System.Windows.Forms.ComboBox();
            this.m_vaultBrowseControl = new Autodesk.DataManagement.Client.Framework.Vault.Forms.Controls.VaultBrowserControl();
            this.m_saveSettingsButton = new System.Windows.Forms.Button();
            this.m_loadSettingsButton = new System.Windows.Forms.Button();
            this.m_valueComboBox = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search For:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Property:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rule:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Condition:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(406, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Value:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Find items that match this criteria:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Search Results:";
            // 
            // m_itemsCountLabel
            // 
            this.m_itemsCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_itemsCountLabel.AutoSize = true;
            this.m_itemsCountLabel.Location = new System.Drawing.Point(25, 390);
            this.m_itemsCountLabel.Name = "m_itemsCountLabel";
            this.m_itemsCountLabel.Size = new System.Drawing.Size(40, 13);
            this.m_itemsCountLabel.TabIndex = 7;
            this.m_itemsCountLabel.Text = "0 items";
            // 
            // m_propertyComboBox
            // 
            this.m_propertyComboBox.FormattingEnabled = true;
            this.m_propertyComboBox.Location = new System.Drawing.Point(28, 53);
            this.m_propertyComboBox.Name = "m_propertyComboBox";
            this.m_propertyComboBox.Size = new System.Drawing.Size(154, 21);
            this.m_propertyComboBox.TabIndex = 8;
            this.m_propertyComboBox.SelectedIndexChanged += new System.EventHandler(this.m_propertyComboBox_SelectedIndexChanged);
            // 
            // m_ruleComboBox
            // 
            this.m_ruleComboBox.FormattingEnabled = true;
            this.m_ruleComboBox.Location = new System.Drawing.Point(188, 52);
            this.m_ruleComboBox.Name = "m_ruleComboBox";
            this.m_ruleComboBox.Size = new System.Drawing.Size(79, 21);
            this.m_ruleComboBox.TabIndex = 9;
            // 
            // m_conditionComboBox
            // 
            this.m_conditionComboBox.FormattingEnabled = true;
            this.m_conditionComboBox.Location = new System.Drawing.Point(278, 52);
            this.m_conditionComboBox.Name = "m_conditionComboBox";
            this.m_conditionComboBox.Size = new System.Drawing.Size(121, 21);
            this.m_conditionComboBox.TabIndex = 10;
            // 
            // m_valueTextBox
            // 
            this.m_valueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_valueTextBox.Location = new System.Drawing.Point(409, 52);
            this.m_valueTextBox.Name = "m_valueTextBox";
            this.m_valueTextBox.Size = new System.Drawing.Size(202, 20);
            this.m_valueTextBox.TabIndex = 11;
            // 
            // m_findButton
            // 
            this.m_findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_findButton.Location = new System.Drawing.Point(635, 53);
            this.m_findButton.Name = "m_findButton";
            this.m_findButton.Size = new System.Drawing.Size(75, 23);
            this.m_findButton.TabIndex = 12;
            this.m_findButton.Text = "Find Now";
            this.m_findButton.UseVisualStyleBackColor = true;
            this.m_findButton.Click += new System.EventHandler(this.m_findButton_Click);
            // 
            // m_addCriteriaButton
            // 
            this.m_addCriteriaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_addCriteriaButton.Location = new System.Drawing.Point(455, 85);
            this.m_addCriteriaButton.Name = "m_addCriteriaButton";
            this.m_addCriteriaButton.Size = new System.Drawing.Size(75, 23);
            this.m_addCriteriaButton.TabIndex = 13;
            this.m_addCriteriaButton.Text = "Add";
            this.m_addCriteriaButton.UseVisualStyleBackColor = true;
            this.m_addCriteriaButton.Click += new System.EventHandler(this.m_addCriteriaButton_Click);
            // 
            // m_removeCriteriaButton
            // 
            this.m_removeCriteriaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_removeCriteriaButton.Location = new System.Drawing.Point(536, 85);
            this.m_removeCriteriaButton.Name = "m_removeCriteriaButton";
            this.m_removeCriteriaButton.Size = new System.Drawing.Size(75, 23);
            this.m_removeCriteriaButton.TabIndex = 14;
            this.m_removeCriteriaButton.Text = "Remove";
            this.m_removeCriteriaButton.UseVisualStyleBackColor = true;
            this.m_removeCriteriaButton.Click += new System.EventHandler(this.m_removeCriteriaButton_Click);
            // 
            // m_criteriaListBox
            // 
            this.m_criteriaListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_criteriaListBox.FormattingEnabled = true;
            this.m_criteriaListBox.Location = new System.Drawing.Point(28, 123);
            this.m_criteriaListBox.Name = "m_criteriaListBox";
            this.m_criteriaListBox.Size = new System.Drawing.Size(583, 95);
            this.m_criteriaListBox.TabIndex = 15;
            // 
            // m_entityClassComboBox
            // 
            this.m_entityClassComboBox.FormattingEnabled = true;
            this.m_entityClassComboBox.Location = new System.Drawing.Point(80, 6);
            this.m_entityClassComboBox.Name = "m_entityClassComboBox";
            this.m_entityClassComboBox.Size = new System.Drawing.Size(102, 21);
            this.m_entityClassComboBox.TabIndex = 17;
            this.m_entityClassComboBox.SelectedIndexChanged += new System.EventHandler(this.m_entityClassComboBox_SelectedIndexChanged);
            // 
            // m_vaultBrowseControl
            // 
            this.m_vaultBrowseControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_vaultBrowseControl.Location = new System.Drawing.Point(28, 248);
            this.m_vaultBrowseControl.Name = "m_vaultBrowseControl";
            this.m_vaultBrowseControl.Size = new System.Drawing.Size(682, 139);
            this.m_vaultBrowseControl.TabIndex = 18;
            // 
            // m_saveSettingsButton
            // 
            this.m_saveSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_saveSettingsButton.Location = new System.Drawing.Point(635, 82);
            this.m_saveSettingsButton.Name = "m_saveSettingsButton";
            this.m_saveSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.m_saveSettingsButton.TabIndex = 19;
            this.m_saveSettingsButton.Text = "Save...";
            this.m_saveSettingsButton.UseVisualStyleBackColor = true;
            this.m_saveSettingsButton.Click += new System.EventHandler(this.m_saveSettingsButton_Click);
            // 
            // m_loadSettingsButton
            // 
            this.m_loadSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_loadSettingsButton.Location = new System.Drawing.Point(635, 111);
            this.m_loadSettingsButton.Name = "m_loadSettingsButton";
            this.m_loadSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.m_loadSettingsButton.TabIndex = 20;
            this.m_loadSettingsButton.Text = "Load...";
            this.m_loadSettingsButton.UseVisualStyleBackColor = true;
            this.m_loadSettingsButton.Click += new System.EventHandler(this.m_loadSettingsButton_Click);
            // 
            // m_valueComboBox
            // 
            this.m_valueComboBox.FormattingEnabled = true;
            this.m_valueComboBox.Location = new System.Drawing.Point(230, 78);
            this.m_valueComboBox.Name = "m_valueComboBox";
            this.m_valueComboBox.Size = new System.Drawing.Size(202, 21);
            this.m_valueComboBox.TabIndex = 21;
            this.m_valueComboBox.SelectedIndexChanged += new System.EventHandler(this.m_valueComboBox_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(28, 80);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(199, 17);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "use Vault Property for search criteria:";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FinderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 412);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.m_valueComboBox);
            this.Controls.Add(this.m_loadSettingsButton);
            this.Controls.Add(this.m_saveSettingsButton);
            this.Controls.Add(this.m_vaultBrowseControl);
            this.Controls.Add(this.m_entityClassComboBox);
            this.Controls.Add(this.m_criteriaListBox);
            this.Controls.Add(this.m_removeCriteriaButton);
            this.Controls.Add(this.m_addCriteriaButton);
            this.Controls.Add(this.m_findButton);
            this.Controls.Add(this.m_valueTextBox);
            this.Controls.Add(this.m_conditionComboBox);
            this.Controls.Add(this.m_ruleComboBox);
            this.Controls.Add(this.m_propertyComboBox);
            this.Controls.Add(this.m_itemsCountLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(720, 436);
            this.Name = "FinderDialog";
            this.Text = "Advanced Advanced Find";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label m_itemsCountLabel;
        private System.Windows.Forms.ComboBox m_propertyComboBox;
        private System.Windows.Forms.ComboBox m_ruleComboBox;
        private System.Windows.Forms.ComboBox m_conditionComboBox;
        private System.Windows.Forms.Button m_findButton;
        private System.Windows.Forms.Button m_addCriteriaButton;
        private System.Windows.Forms.Button m_removeCriteriaButton;
        private System.Windows.Forms.ListBox m_criteriaListBox;
        private System.Windows.Forms.TextBox m_valueTextBox;
        private System.Windows.Forms.ComboBox m_entityClassComboBox;
        private Autodesk.DataManagement.Client.Framework.Vault.Forms.Controls.VaultBrowserControl m_vaultBrowseControl;
        private System.Windows.Forms.Button m_saveSettingsButton;
        private System.Windows.Forms.Button m_loadSettingsButton;
        private System.Windows.Forms.ComboBox m_valueComboBox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}