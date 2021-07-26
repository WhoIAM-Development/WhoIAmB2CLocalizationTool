using B2CLocalizationTool.Service;
using B2CLocalizationTool.Service.Abstract;
using System;
using System.Windows.Forms;

namespace B2CLocalizationTool.Client
{
    public partial class BaseForm : Form
    {
        private readonly IExternalDataService _externalDataService;

        public BaseForm(IExternalDataService externalDataService)
        {
            this._externalDataService = externalDataService;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void chooseInputFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                excelInputFilePath.Text = file.FileName;
                chooseInputFileButton.Text = "Choose another file";


            }

        }

        private void convertToXMLFileButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click to Ok to continue", "Convert to XML", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // read appropriate file type and add basic validations

            var outputPath = _externalDataService.ReadFullExcelFile(excelInputFilePath.Text);

            excelInputFilePath.Text = string.Empty;
            chooseInputFileButton.Text = "Choose file";

            MessageBox.Show($"XML Creation completed. File stored to {outputPath}", "Convert to XML", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void excelInputFilePath_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(excelInputFilePath.Text))
            {
                convertToXMLFileButton.Enabled = true;
            }else
            {
                convertToXMLFileButton.Enabled = false;
            }
        }
    }
}
