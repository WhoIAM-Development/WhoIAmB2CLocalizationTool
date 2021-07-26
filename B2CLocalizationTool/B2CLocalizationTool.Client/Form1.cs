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
            MessageBox.Show("Click to Ok to continue", "Convert to XML", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            }else
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
    }
}
