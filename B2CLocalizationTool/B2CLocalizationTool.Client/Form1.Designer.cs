
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
            this.convertToXMLFileButton = new System.Windows.Forms.Button();
            this.chooseInputFileButton = new System.Windows.Forms.Button();
            this.excelInputFilePath = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.convertToXMLTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.convertToXMLTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(801, 452);
            this.tabControl1.TabIndex = 0;
            // 
            // convertToXMLTab
            // 
            this.convertToXMLTab.Controls.Add(this.convertToXMLFileButton);
            this.convertToXMLTab.Controls.Add(this.chooseInputFileButton);
            this.convertToXMLTab.Controls.Add(this.excelInputFilePath);
            this.convertToXMLTab.Location = new System.Drawing.Point(4, 24);
            this.convertToXMLTab.Name = "convertToXMLTab";
            this.convertToXMLTab.Padding = new System.Windows.Forms.Padding(3);
            this.convertToXMLTab.Size = new System.Drawing.Size(793, 424);
            this.convertToXMLTab.TabIndex = 0;
            this.convertToXMLTab.Text = "To XML";
            this.convertToXMLTab.UseVisualStyleBackColor = true;
            // 
            // convertToXMLFileButton
            // 
            this.convertToXMLFileButton.Enabled = false;
            this.convertToXMLFileButton.Location = new System.Drawing.Point(626, 101);
            this.convertToXMLFileButton.Name = "convertToXMLFileButton";
            this.convertToXMLFileButton.Size = new System.Drawing.Size(158, 23);
            this.convertToXMLFileButton.TabIndex = 5;
            this.convertToXMLFileButton.Text = "Convert to XML";
            this.convertToXMLFileButton.UseVisualStyleBackColor = true;
            this.convertToXMLFileButton.Click += new System.EventHandler(this.convertToXMLFileButton_Click);
            // 
            // chooseInputFileButton
            // 
            this.chooseInputFileButton.Location = new System.Drawing.Point(626, 39);
            this.chooseInputFileButton.Name = "chooseInputFileButton";
            this.chooseInputFileButton.Size = new System.Drawing.Size(158, 23);
            this.chooseInputFileButton.TabIndex = 4;
            this.chooseInputFileButton.Text = "Choose file";
            this.chooseInputFileButton.UseVisualStyleBackColor = true;
            this.chooseInputFileButton.Click += new System.EventHandler(this.chooseInputFileButton_Click);
            // 
            // excelInputFilePath
            // 
            this.excelInputFilePath.Enabled = false;
            this.excelInputFilePath.Location = new System.Drawing.Point(8, 39);
            this.excelInputFilePath.Name = "excelInputFilePath";
            this.excelInputFilePath.Size = new System.Drawing.Size(575, 23);
            this.excelInputFilePath.TabIndex = 3;
            this.excelInputFilePath.TextChanged += new System.EventHandler(this.excelInputFilePath_TextChanged);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage convertToXMLTab;
        private System.Windows.Forms.Button convertToXMLFileButton;
        private System.Windows.Forms.Button chooseInputFileButton;
        private System.Windows.Forms.TextBox excelInputFilePath;
    }
}

