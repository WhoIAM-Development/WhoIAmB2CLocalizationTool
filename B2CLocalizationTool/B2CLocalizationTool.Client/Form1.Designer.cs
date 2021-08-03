
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
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
            this.tabPageToJson = new System.Windows.Forms.TabPage();
            this.toJson_labelPrefix = new System.Windows.Forms.Label();
            this.toJson_textFilePrefix = new System.Windows.Forms.TextBox();
            this.toJson_btnChooseOutput = new System.Windows.Forms.Button();
            this.toJson_labelOutput = new System.Windows.Forms.Label();
            this.toJson_textOutputPath = new System.Windows.Forms.TextBox();
            this.toJson_labelInput = new System.Windows.Forms.Label();
            this.toJson_btnConvert = new System.Windows.Forms.Button();
            this.toJson_btnChooseInput = new System.Windows.Forms.Button();
            this.toJson_textInputPath = new System.Windows.Forms.TextBox();
            this.tabPageJsonToCSV = new System.Windows.Forms.TabPage();
            this.jsonToCSV_btnChooseOutputFolder = new System.Windows.Forms.Button();
            this.jsonToCSV_labelOuputFolder = new System.Windows.Forms.Label();
            this.jsonToCSV_textOutputFolder = new System.Windows.Forms.TextBox();
            this.jsonToCSV_labelInputFiles = new System.Windows.Forms.Label();
            this.jsonToCSV_btnConvert = new System.Windows.Forms.Button();
            this.jsonToCSV_btnChooseFiles = new System.Windows.Forms.Button();
            this.jsonToCSV_textInputFiles = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.convertToXMLTab.SuspendLayout();
            this.convertToExcelTab.SuspendLayout();
            this.tabPageToJson.SuspendLayout();
            this.tabPageJsonToCSV.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.convertToXMLTab);
            this.tabControl1.Controls.Add(this.convertToExcelTab);
            this.tabControl1.Controls.Add(this.tabPageToJson);
            this.tabControl1.Controls.Add(this.tabPageJsonToCSV);
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
            this.convertToExcelTab.Text = "XML To CSV";
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
            // tabPageToJson
            // 
            this.tabPageToJson.Controls.Add(this.toJson_labelPrefix);
            this.tabPageToJson.Controls.Add(this.toJson_textFilePrefix);
            this.tabPageToJson.Controls.Add(this.toJson_btnChooseOutput);
            this.tabPageToJson.Controls.Add(this.toJson_labelOutput);
            this.tabPageToJson.Controls.Add(this.toJson_textOutputPath);
            this.tabPageToJson.Controls.Add(this.toJson_labelInput);
            this.tabPageToJson.Controls.Add(this.toJson_btnConvert);
            this.tabPageToJson.Controls.Add(this.toJson_btnChooseInput);
            this.tabPageToJson.Controls.Add(this.toJson_textInputPath);
            this.tabPageToJson.Location = new System.Drawing.Point(4, 24);
            this.tabPageToJson.Name = "tabPageToJson";
            this.tabPageToJson.Size = new System.Drawing.Size(793, 424);
            this.tabPageToJson.TabIndex = 2;
            this.tabPageToJson.Text = "To JSON";
            this.tabPageToJson.UseVisualStyleBackColor = true;
            // 
            // toJson_labelPrefix
            // 
            this.toJson_labelPrefix.AutoSize = true;
            this.toJson_labelPrefix.Location = new System.Drawing.Point(8, 150);
            this.toJson_labelPrefix.Name = "toJson_labelPrefix";
            this.toJson_labelPrefix.Size = new System.Drawing.Size(97, 15);
            this.toJson_labelPrefix.TabIndex = 18;
            this.toJson_labelPrefix.Text = "Output file prefix";
            // 
            // toJson_textFilePrefix
            // 
            this.toJson_textFilePrefix.Location = new System.Drawing.Point(8, 168);
            this.toJson_textFilePrefix.Name = "toJson_textFilePrefix";
            this.toJson_textFilePrefix.Size = new System.Drawing.Size(575, 23);
            this.toJson_textFilePrefix.TabIndex = 17;
            // 
            // toJson_btnChooseOutput
            // 
            this.toJson_btnChooseOutput.Location = new System.Drawing.Point(610, 103);
            this.toJson_btnChooseOutput.Name = "toJson_btnChooseOutput";
            this.toJson_btnChooseOutput.Size = new System.Drawing.Size(158, 23);
            this.toJson_btnChooseOutput.TabIndex = 16;
            this.toJson_btnChooseOutput.Text = "Choose output folder";
            this.toJson_btnChooseOutput.UseVisualStyleBackColor = true;
            this.toJson_btnChooseOutput.Click += new System.EventHandler(this.toJson_btnChooseOutput_Click);
            // 
            // toJson_labelOutput
            // 
            this.toJson_labelOutput.AutoSize = true;
            this.toJson_labelOutput.Location = new System.Drawing.Point(8, 85);
            this.toJson_labelOutput.Name = "toJson_labelOutput";
            this.toJson_labelOutput.Size = new System.Drawing.Size(157, 15);
            this.toJson_labelOutput.TabIndex = 15;
            this.toJson_labelOutput.Text = "Ouput folder path (optional)";
            // 
            // toJson_textOutputPath
            // 
            this.toJson_textOutputPath.Enabled = false;
            this.toJson_textOutputPath.Location = new System.Drawing.Point(8, 103);
            this.toJson_textOutputPath.Name = "toJson_textOutputPath";
            this.toJson_textOutputPath.Size = new System.Drawing.Size(575, 23);
            this.toJson_textOutputPath.TabIndex = 14;
            // 
            // toJson_labelInput
            // 
            this.toJson_labelInput.AutoSize = true;
            this.toJson_labelInput.Location = new System.Drawing.Point(8, 22);
            this.toJson_labelInput.Name = "toJson_labelInput";
            this.toJson_labelInput.Size = new System.Drawing.Size(89, 15);
            this.toJson_labelInput.TabIndex = 13;
            this.toJson_labelInput.Text = "Input file path *";
            // 
            // toJson_btnConvert
            // 
            this.toJson_btnConvert.Enabled = false;
            this.toJson_btnConvert.Location = new System.Drawing.Point(320, 223);
            this.toJson_btnConvert.Name = "toJson_btnConvert";
            this.toJson_btnConvert.Size = new System.Drawing.Size(158, 23);
            this.toJson_btnConvert.TabIndex = 12;
            this.toJson_btnConvert.Text = "Convert to JSON";
            this.toJson_btnConvert.UseVisualStyleBackColor = true;
            this.toJson_btnConvert.Click += new System.EventHandler(this.toJson_btnConvert_Click);
            // 
            // toJson_btnChooseInput
            // 
            this.toJson_btnChooseInput.Location = new System.Drawing.Point(610, 40);
            this.toJson_btnChooseInput.Name = "toJson_btnChooseInput";
            this.toJson_btnChooseInput.Size = new System.Drawing.Size(158, 23);
            this.toJson_btnChooseInput.TabIndex = 11;
            this.toJson_btnChooseInput.Text = "Choose file";
            this.toJson_btnChooseInput.UseVisualStyleBackColor = true;
            this.toJson_btnChooseInput.Click += new System.EventHandler(this.toJson_btnChooseInput_Click);
            // 
            // toJson_textInputPath
            // 
            this.toJson_textInputPath.Enabled = false;
            this.toJson_textInputPath.Location = new System.Drawing.Point(8, 40);
            this.toJson_textInputPath.Name = "toJson_textInputPath";
            this.toJson_textInputPath.Size = new System.Drawing.Size(575, 23);
            this.toJson_textInputPath.TabIndex = 10;
            this.toJson_textInputPath.TextChanged += new System.EventHandler(this.toJson_textInputPath_TextChanged);
            // 
            // tabPageJsonToCSV
            // 
            this.tabPageJsonToCSV.Controls.Add(this.jsonToCSV_btnChooseOutputFolder);
            this.tabPageJsonToCSV.Controls.Add(this.jsonToCSV_labelOuputFolder);
            this.tabPageJsonToCSV.Controls.Add(this.jsonToCSV_textOutputFolder);
            this.tabPageJsonToCSV.Controls.Add(this.jsonToCSV_labelInputFiles);
            this.tabPageJsonToCSV.Controls.Add(this.jsonToCSV_btnConvert);
            this.tabPageJsonToCSV.Controls.Add(this.jsonToCSV_btnChooseFiles);
            this.tabPageJsonToCSV.Controls.Add(this.jsonToCSV_textInputFiles);
            this.tabPageJsonToCSV.Location = new System.Drawing.Point(4, 24);
            this.tabPageJsonToCSV.Name = "tabPageJsonToCSV";
            this.tabPageJsonToCSV.Size = new System.Drawing.Size(793, 424);
            this.tabPageJsonToCSV.TabIndex = 3;
            this.tabPageJsonToCSV.Text = "JSON to CSV";
            this.tabPageJsonToCSV.UseVisualStyleBackColor = true;
            // 
            // jsonToCSV_btnChooseOutputFolder
            // 
            this.jsonToCSV_btnChooseOutputFolder.Location = new System.Drawing.Point(610, 305);
            this.jsonToCSV_btnChooseOutputFolder.Name = "jsonToCSV_btnChooseOutputFolder";
            this.jsonToCSV_btnChooseOutputFolder.Size = new System.Drawing.Size(158, 23);
            this.jsonToCSV_btnChooseOutputFolder.TabIndex = 25;
            this.jsonToCSV_btnChooseOutputFolder.Text = "Choose output folder";
            this.jsonToCSV_btnChooseOutputFolder.UseVisualStyleBackColor = true;
            this.jsonToCSV_btnChooseOutputFolder.Click += new System.EventHandler(this.jsonToCSV_btnChooseOutputFolder_Click);
            // 
            // jsonToCSV_labelOuputFolder
            // 
            this.jsonToCSV_labelOuputFolder.AutoSize = true;
            this.jsonToCSV_labelOuputFolder.Location = new System.Drawing.Point(8, 287);
            this.jsonToCSV_labelOuputFolder.Name = "jsonToCSV_labelOuputFolder";
            this.jsonToCSV_labelOuputFolder.Size = new System.Drawing.Size(157, 15);
            this.jsonToCSV_labelOuputFolder.TabIndex = 24;
            this.jsonToCSV_labelOuputFolder.Text = "Ouput folder path (optional)";
            // 
            // jsonToCSV_textOutputFolder
            // 
            this.jsonToCSV_textOutputFolder.Enabled = false;
            this.jsonToCSV_textOutputFolder.Location = new System.Drawing.Point(8, 305);
            this.jsonToCSV_textOutputFolder.Name = "jsonToCSV_textOutputFolder";
            this.jsonToCSV_textOutputFolder.Size = new System.Drawing.Size(575, 23);
            this.jsonToCSV_textOutputFolder.TabIndex = 23;
            // 
            // jsonToCSV_labelInputFiles
            // 
            this.jsonToCSV_labelInputFiles.AutoSize = true;
            this.jsonToCSV_labelInputFiles.Location = new System.Drawing.Point(8, 24);
            this.jsonToCSV_labelInputFiles.Name = "jsonToCSV_labelInputFiles";
            this.jsonToCSV_labelInputFiles.Size = new System.Drawing.Size(152, 15);
            this.jsonToCSV_labelInputFiles.TabIndex = 22;
            this.jsonToCSV_labelInputFiles.Text = "Input files selected (JSON) *";
            // 
            // jsonToCSV_btnConvert
            // 
            this.jsonToCSV_btnConvert.Enabled = false;
            this.jsonToCSV_btnConvert.Location = new System.Drawing.Point(320, 375);
            this.jsonToCSV_btnConvert.Name = "jsonToCSV_btnConvert";
            this.jsonToCSV_btnConvert.Size = new System.Drawing.Size(158, 23);
            this.jsonToCSV_btnConvert.TabIndex = 21;
            this.jsonToCSV_btnConvert.Text = "Convert to CSV";
            this.jsonToCSV_btnConvert.UseVisualStyleBackColor = true;
            this.jsonToCSV_btnConvert.Click += new System.EventHandler(this.jsonToCSV_btnConvert_Click);
            // 
            // jsonToCSV_btnChooseFiles
            // 
            this.jsonToCSV_btnChooseFiles.Location = new System.Drawing.Point(610, 42);
            this.jsonToCSV_btnChooseFiles.Name = "jsonToCSV_btnChooseFiles";
            this.jsonToCSV_btnChooseFiles.Size = new System.Drawing.Size(158, 23);
            this.jsonToCSV_btnChooseFiles.TabIndex = 20;
            this.jsonToCSV_btnChooseFiles.Text = "Choose file(s)";
            this.jsonToCSV_btnChooseFiles.UseVisualStyleBackColor = true;
            this.jsonToCSV_btnChooseFiles.Click += new System.EventHandler(this.jsonToCSV_btnChooseFiles_Click);
            // 
            // jsonToCSV_textInputFiles
            // 
            this.jsonToCSV_textInputFiles.Location = new System.Drawing.Point(8, 42);
            this.jsonToCSV_textInputFiles.Multiline = true;
            this.jsonToCSV_textInputFiles.Name = "jsonToCSV_textInputFiles";
            this.jsonToCSV_textInputFiles.ReadOnly = true;
            this.jsonToCSV_textInputFiles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.jsonToCSV_textInputFiles.Size = new System.Drawing.Size(575, 229);
            this.jsonToCSV_textInputFiles.TabIndex = 19;
            this.jsonToCSV_textInputFiles.TextChanged += new System.EventHandler(this.jsonToCSV_textInputFiles_TextChanged);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseForm";
            this.Text = "B2C Localization Tool";
            this.tabControl1.ResumeLayout(false);
            this.convertToXMLTab.ResumeLayout(false);
            this.convertToXMLTab.PerformLayout();
            this.convertToExcelTab.ResumeLayout(false);
            this.convertToExcelTab.PerformLayout();
            this.tabPageToJson.ResumeLayout(false);
            this.tabPageToJson.PerformLayout();
            this.tabPageJsonToCSV.ResumeLayout(false);
            this.tabPageJsonToCSV.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPageToJson;
        private System.Windows.Forms.Button toJson_btnChooseOutput;
        private System.Windows.Forms.Label toJson_labelOutput;
        private System.Windows.Forms.TextBox toJson_textOutputPath;
        private System.Windows.Forms.Label toJson_labelInput;
        private System.Windows.Forms.Button toJson_btnConvert;
        private System.Windows.Forms.Button toJson_btnChooseInput;
        private System.Windows.Forms.TextBox toJson_textInputPath;
        private System.Windows.Forms.Label toJson_labelPrefix;
        private System.Windows.Forms.TextBox toJson_textFilePrefix;
        private System.Windows.Forms.TabPage tabPageJsonToCSV;
        private System.Windows.Forms.Button jsonToCSV_btnChooseOutputFolder;
        private System.Windows.Forms.Label jsonToCSV_labelOuputFolder;
        private System.Windows.Forms.TextBox jsonToCSV_textOutputFolder;
        private System.Windows.Forms.Label jsonToCSV_labelInputFiles;
        private System.Windows.Forms.Button jsonToCSV_btnConvert;
        private System.Windows.Forms.Button jsonToCSV_btnChooseFiles;
        private System.Windows.Forms.TextBox jsonToCSV_textInputFiles;
    }
}

