using B2CLocalizationTool.Service.Abstract;
using B2CLocalizationTool.Shared;
using Microsoft.Extensions.Options;
using System;
using System.Windows.Forms;

namespace B2CLocalizationTool.Client
{
    public partial class BaseForm : Form
    {
        private readonly ILocalizationService _localizationService;
        private readonly ToJsonSettings _toJsonOptions;

        public BaseForm(ILocalizationService localizationService,
            IOptions<ToJsonSettings> toJsonOptions)
        {
            this._localizationService = localizationService;
            this._toJsonOptions = toJsonOptions.Value;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            toJson_textFilePrefix.Text = this._toJsonOptions.FilePrefix;
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
            IResultDTO result = _localizationService.ReadInputAndWriteToXml(excelInputFilePathTextBox.Text, outputFolderPathTextBox.Text);

            if (result.IsSuccess)
            {
                excelInputFilePathTextBox.Text = string.Empty;
                chooseInputFileButton.Text = "Choose file";

                MessageBox.Show($"XML Creation completed. File stored to {result.OutputPath}", "Convert to XML", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                MessageBox.Show($"Something went wrong", "Convert to XML", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            //var outputPath = _localizationService.ReadXmlAndWriteToExcel(xmlInputFilePathTextBox.Text, outputFileFormatComboBox.SelectedItem.ToString(), excelOutputFolderPathTextBox.Text);
            var result = _localizationService.ReadXmlAndWriteToExcel(xmlInputFilePathTextBox.Text, "csv", excelOutputFolderPathTextBox.Text);

            if (result.IsSuccess)
            {
                xmlInputFilePathTextBox.Text = string.Empty;
                xmlInputChooseFileButton.Text = "Choose file";
                outputFileFormatComboBox.SelectedItem = null;

                MessageBox.Show($"Excel/CSV Creation completed. File stored to {result.OutputPath}", "Convert to CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Something went wrong", "Convert to CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        #region To Json Tab
        private void toJson_btnConvert_Click(object sender, EventArgs e)
        {
            IResultDTO result = _localizationService.ReadInputAndWriteToJson(toJson_textInputPath.Text, toJson_textFilePrefix.Text,  toJson_textOutputPath.Text);

            if (result.IsSuccess)
            {
                toJson_textInputPath.Text = string.Empty;
                toJson_btnChooseInput.Text = "Choose file";

                MessageBox.Show($"JSON Creation completed. File stored to {result.OutputPath}", "Convert to JSON", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Something went wrong", "Convert to JSON", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toJson_btnChooseInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                toJson_textInputPath.Text = file.FileName;
                toJson_btnChooseInput.Text = "Choose another file";
            }
        }

        private void toJson_btnChooseOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                toJson_textOutputPath.Text = folderDlg.SelectedPath;
            }
        }

        private void toJson_textInputPath_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(toJson_textInputPath.Text))
            {
                toJson_btnConvert.Enabled = true;
            }
            else
            {
                toJson_btnConvert.Enabled = false;
            }
        }
        #endregion
    }
}
