using B2CLocalizationTool.Service.Abstract;
using System;
using System.Windows.Forms;

namespace B2CLocalizationTool.Client
{
    public partial class BaseForm : Form
    {
        private readonly ILocalizationService _localizationService;

        public BaseForm(ILocalizationService localizationService)
        {
            this._localizationService = localizationService;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        #region To XML Tab
        private void chooseInputFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                excelInputFilePathTextBox.Text = file.FileName;
                chooseInputFileButton.Text = "Choose another file";
            }
        }

        private void convertToXMLFileButton_Click(object sender, EventArgs e)
        {
            var outputPath = _localizationService.ReadInputAndWriteToXml(excelInputFilePathTextBox.Text, outputFolderPathTextBox.Text);

            excelInputFilePathTextBox.Text = string.Empty;
            chooseInputFileButton.Text = "Choose file";

            MessageBox.Show($"XML Creation completed. File stored to {outputPath}", "Convert to XML", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void excelInputFilePath_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(excelInputFilePathTextBox.Text))
            {
                convertToXMLFileButton.Enabled = true;
            }
            else
            {
                convertToXMLFileButton.Enabled = false;
            }
        }

        private void chooseOutputFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                outputFolderPathTextBox.Text = folderDlg.SelectedPath;
            }
        }
        #endregion

        #region To Excel Tab
        private void xmlInputChooseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                xmlInputFilePathTextBox.Text = file.FileName;
                xmlInputChooseFileButton.Text = "Choose another file";
            }
        }

        private void excelOutputChooseFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                excelOutputFolderPathTextBox.Text = folderDlg.SelectedPath;
            }
        }

        private void convertToExcelButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Not implemented!", "Convert to CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;

            //var outputPath = _localizationService.ReadXmlAndWriteToExcel(xmlInputFilePathTextBox.Text, outputFileFormatComboBox.SelectedItem.ToString(), excelOutputFolderPathTextBox.Text);
            var outputPath = _localizationService.ReadXmlAndWriteToExcel(xmlInputFilePathTextBox.Text, "csv", excelOutputFolderPathTextBox.Text);

            xmlInputFilePathTextBox.Text = string.Empty;
            xmlInputChooseFileButton.Text = "Choose file";
            outputFileFormatComboBox.SelectedItem = null;

            MessageBox.Show($"Excel/CSV Creation completed. File stored to {outputPath}", "Convert to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void outputFileFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(xmlInputFilePathTextBox.Text) && outputFileFormatComboBox.SelectedItem != null)
            {
                convertToExcelButton.Text = $"Convert to {outputFileFormatComboBox.SelectedItem}";
                convertToExcelButton.Enabled = true;
            }
            else
            {
                convertToExcelButton.Enabled = false;
            }
        }

        private void xmlInputFilePathTextBox_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(xmlInputFilePathTextBox.Text) && outputFileFormatComboBox.SelectedItem != null)
            if (!string.IsNullOrEmpty(xmlInputFilePathTextBox.Text))
            {
                //convertToExcelButton.Text = $"Convert to {outputFileFormatComboBox.SelectedItem}";
                convertToExcelButton.Enabled = true;
            }
            else
            {
                convertToExcelButton.Enabled = false;
            }
        }
        #endregion

    }
}
