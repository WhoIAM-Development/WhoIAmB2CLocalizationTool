﻿
namespace B2CLocalizationTool.Client
{
    partial class BaseForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.convertToXMLTab = new System.Windows.Forms.TabPage();
            this.chooseOutputFolderButton = new System.Windows.Forms.Button();
            this.outputFolderPathLabel = new System.Windows.Forms.Label();
            this.outputFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.inputFileLabel = new System.Windows.Forms.Label();
            this.convertToXMLFileButton = new System.Windows.Forms.Button();
            this.chooseInputFileButton = new System.Windows.Forms.Button();
            this.excelInputFilePathTextBox = new System.Windows.Forms.TextBox();
            this.convertToExcelTab = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.outputFileFormatComboBox = new System.Windows.Forms.ComboBox();
            this.excelOutputChooseFolderButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.excelOutputFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.convertToExcelButton = new System.Windows.Forms.Button();
            this.xmlInputChooseFileButton = new System.Windows.Forms.Button();
            this.xmlInputFilePathTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.convertToXMLTab.SuspendLayout();
            this.convertToExcelTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.convertToXMLTab);
            this.tabControl1.Controls.Add(this.convertToExcelTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(801, 452);
            this.tabControl1.TabIndex = 0;
            // 
            // convertToXMLTab
            // 
            this.convertToXMLTab.Controls.Add(this.chooseOutputFolderButton);
            this.convertToXMLTab.Controls.Add(this.outputFolderPathLabel);
            this.convertToXMLTab.Controls.Add(this.outputFolderPathTextBox);
            this.convertToXMLTab.Controls.Add(this.inputFileLabel);
            this.convertToXMLTab.Controls.Add(this.convertToXMLFileButton);
            this.convertToXMLTab.Controls.Add(this.chooseInputFileButton);
            this.convertToXMLTab.Controls.Add(this.excelInputFilePathTextBox);
            this.convertToXMLTab.Location = new System.Drawing.Point(4, 24);
            this.convertToXMLTab.Name = "convertToXMLTab";
            this.convertToXMLTab.Padding = new System.Windows.Forms.Padding(3);
            this.convertToXMLTab.Size = new System.Drawing.Size(793, 424);
            this.convertToXMLTab.TabIndex = 0;
            this.convertToXMLTab.Text = "To XML";
            this.convertToXMLTab.UseVisualStyleBackColor = true;
            // 
            // chooseOutputFolderButton
            // 
            this.chooseOutputFolderButton.Location = new System.Drawing.Point(610, 102);
            this.chooseOutputFolderButton.Name = "chooseOutputFolderButton";
            this.chooseOutputFolderButton.Size = new System.Drawing.Size(158, 23);
            this.chooseOutputFolderButton.TabIndex = 9;
            this.chooseOutputFolderButton.Text = "Choose output folder";
            this.chooseOutputFolderButton.UseVisualStyleBackColor = true;
            this.chooseOutputFolderButton.Click += new System.EventHandler(this.chooseOutputFolderButton_Click);
            // 
            // outputFolderPathLabel
            // 
            this.outputFolderPathLabel.AutoSize = true;
            this.outputFolderPathLabel.Location = new System.Drawing.Point(8, 84);
            this.outputFolderPathLabel.Name = "outputFolderPathLabel";
            this.outputFolderPathLabel.Size = new System.Drawing.Size(157, 15);
            this.outputFolderPathLabel.TabIndex = 8;
            this.outputFolderPathLabel.Text = "Ouput folder path (optional)";
            // 
            // outputFolderPathTextBox
            // 
            this.outputFolderPathTextBox.Enabled = false;
            this.outputFolderPathTextBox.Location = new System.Drawing.Point(8, 102);
            this.outputFolderPathTextBox.Name = "outputFolderPathTextBox";
            this.outputFolderPathTextBox.Size = new System.Drawing.Size(575, 23);
            this.outputFolderPathTextBox.TabIndex = 7;
            // 
            // inputFileLabel
            // 
            this.inputFileLabel.AutoSize = true;
            this.inputFileLabel.Location = new System.Drawing.Point(8, 21);
            this.inputFileLabel.Name = "inputFileLabel";
            this.inputFileLabel.Size = new System.Drawing.Size(89, 15);
            this.inputFileLabel.TabIndex = 6;
            this.inputFileLabel.Text = "Input file path *";
            // 
            // convertToXMLFileButton
            // 
            this.convertToXMLFileButton.Enabled = false;
            this.convertToXMLFileButton.Location = new System.Drawing.Point(320, 222);
            this.convertToXMLFileButton.Name = "convertToXMLFileButton";
            this.convertToXMLFileButton.Size = new System.Drawing.Size(158, 23);
            this.convertToXMLFileButton.TabIndex = 5;
            this.convertToXMLFileButton.Text = "Convert to XML";
            this.convertToXMLFileButton.UseVisualStyleBackColor = true;
            this.convertToXMLFileButton.Click += new System.EventHandler(this.convertToXMLFileButton_Click);
            // 
            // chooseInputFileButton
            // 
            this.chooseInputFileButton.Location = new System.Drawing.Point(610, 39);
            this.chooseInputFileButton.Name = "chooseInputFileButton";
            this.chooseInputFileButton.Size = new System.Drawing.Size(158, 23);
            this.chooseInputFileButton.TabIndex = 4;
            this.chooseInputFileButton.Text = "Choose file";
            this.chooseInputFileButton.UseVisualStyleBackColor = true;
            this.chooseInputFileButton.Click += new System.EventHandler(this.chooseInputFileButton_Click);
            // 
            // excelInputFilePathTextBox
            // 
            this.excelInputFilePathTextBox.Enabled = false;
            this.excelInputFilePathTextBox.Location = new System.Drawing.Point(8, 39);
            this.excelInputFilePathTextBox.Name = "excelInputFilePathTextBox";
            this.excelInputFilePathTextBox.Size = new System.Drawing.Size(575, 23);
            this.excelInputFilePathTextBox.TabIndex = 3;
            this.excelInputFilePathTextBox.TextChanged += new System.EventHandler(this.excelInputFilePath_TextChanged);
            // 
            // convertToExcelTab
            // 
            this.convertToExcelTab.Controls.Add(this.label3);
            this.convertToExcelTab.Controls.Add(this.outputFileFormatComboBox);
            this.convertToExcelTab.Controls.Add(this.excelOutputChooseFolderButton);
            this.convertToExcelTab.Controls.Add(this.label1);
            this.convertToExcelTab.Controls.Add(this.excelOutputFolderPathTextBox);
            this.convertToExcelTab.Controls.Add(this.label2);
            this.convertToExcelTab.Controls.Add(this.convertToExcelButton);
            this.convertToExcelTab.Controls.Add(this.xmlInputChooseFileButton);
            this.convertToExcelTab.Controls.Add(this.xmlInputFilePathTextBox);
            this.convertToExcelTab.Location = new System.Drawing.Point(4, 24);
            this.convertToExcelTab.Name = "convertToExcelTab";
            this.convertToExcelTab.Size = new System.Drawing.Size(793, 424);
            this.convertToExcelTab.TabIndex = 1;
            this.convertToExcelTab.Text = "To Excel";
            this.convertToExcelTab.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Choose output format * ";
            this.label3.Visible = false;
            // 
            // outputFileFormatComboBox
            // 
            this.outputFileFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputFileFormatComboBox.Items.AddRange(new object[] {
            "Excel",
            "CSV"});
            this.outputFileFormatComboBox.Location = new System.Drawing.Point(8, 97);
            this.outputFileFormatComboBox.Name = "outputFileFormatComboBox";
            this.outputFileFormatComboBox.Size = new System.Drawing.Size(575, 23);
            this.outputFileFormatComboBox.TabIndex = 18;
            this.outputFileFormatComboBox.Visible = false;
            this.outputFileFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.outputFileFormatComboBox_SelectedIndexChanged);
            // 
            // excelOutputChooseFolderButton
            // 
            this.excelOutputChooseFolderButton.Location = new System.Drawing.Point(610, 151);
            this.excelOutputChooseFolderButton.Name = "excelOutputChooseFolderButton";
            this.excelOutputChooseFolderButton.Size = new System.Drawing.Size(158, 23);
            this.excelOutputChooseFolderButton.TabIndex = 16;
            this.excelOutputChooseFolderButton.Text = "Choose output folder";
            this.excelOutputChooseFolderButton.UseVisualStyleBackColor = true;
            this.excelOutputChooseFolderButton.Click += new System.EventHandler(this.excelOutputChooseFolderButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ouput folder path (optional)";
            // 
            // excelOutputFolderPathTextBox
            // 
            this.excelOutputFolderPathTextBox.Enabled = false;
            this.excelOutputFolderPathTextBox.Location = new System.Drawing.Point(8, 152);
            this.excelOutputFolderPathTextBox.Name = "excelOutputFolderPathTextBox";
            this.excelOutputFolderPathTextBox.Size = new System.Drawing.Size(575, 23);
            this.excelOutputFolderPathTextBox.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Input file path *";
            // 
            // convertToExcelButton
            // 
            this.convertToExcelButton.Enabled = false;
            this.convertToExcelButton.Location = new System.Drawing.Point(311, 265);
            this.convertToExcelButton.Name = "convertToExcelButton";
            this.convertToExcelButton.Size = new System.Drawing.Size(158, 23);
            this.convertToExcelButton.TabIndex = 12;
            this.convertToExcelButton.Text = "Export to CSV";
            this.convertToExcelButton.UseVisualStyleBackColor = true;
            this.convertToExcelButton.Click += new System.EventHandler(this.convertToExcelButton_Click);
            // 
            // xmlInputChooseFileButton
            // 
            this.xmlInputChooseFileButton.Location = new System.Drawing.Point(610, 33);
            this.xmlInputChooseFileButton.Name = "xmlInputChooseFileButton";
            this.xmlInputChooseFileButton.Size = new System.Drawing.Size(158, 23);
            this.xmlInputChooseFileButton.TabIndex = 11;
            this.xmlInputChooseFileButton.Text = "Choose file";
            this.xmlInputChooseFileButton.UseVisualStyleBackColor = true;
            this.xmlInputChooseFileButton.Click += new System.EventHandler(this.xmlInputChooseFileButton_Click);
            // 
            // xmlInputFilePathTextBox
            // 
            this.xmlInputFilePathTextBox.Enabled = false;
            this.xmlInputFilePathTextBox.Location = new System.Drawing.Point(8, 33);
            this.xmlInputFilePathTextBox.Name = "xmlInputFilePathTextBox";
            this.xmlInputFilePathTextBox.Size = new System.Drawing.Size(575, 23);
            this.xmlInputFilePathTextBox.TabIndex = 10;
            this.xmlInputFilePathTextBox.TextChanged += new System.EventHandler(this.xmlInputFilePathTextBox_TextChanged);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "BaseForm";
            this.Text = "B2C Localization Tool";
            this.tabControl1.ResumeLayout(false);
            this.convertToXMLTab.ResumeLayout(false);
            this.convertToXMLTab.PerformLayout();
            this.convertToExcelTab.ResumeLayout(false);
            this.convertToExcelTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage convertToXMLTab;
        private System.Windows.Forms.Button convertToXMLFileButton;
        private System.Windows.Forms.Button chooseInputFileButton;
        private System.Windows.Forms.TextBox excelInputFilePathTextBox;
        private System.Windows.Forms.Label inputFileLabel;
        private System.Windows.Forms.Label outputFolderPathLabel;
        private System.Windows.Forms.TextBox outputFolderPathTextBox;
        private System.Windows.Forms.Button chooseOutputFolderButton;
        private System.Windows.Forms.TabPage convertToExcelTab;
        private System.Windows.Forms.Button excelOutputChooseFolderButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox excelOutputFolderPathTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button convertToExcelButton;
        private System.Windows.Forms.Button xmlInputChooseFileButton;
        private System.Windows.Forms.TextBox xmlInputFilePathTextBox;
        private System.Windows.Forms.ComboBox outputFileFormatComboBox;
        private System.Windows.Forms.Label label3;
    }
}

