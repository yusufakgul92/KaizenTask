using CodeCreator.Core;

namespace CodeGenerator
{
    public partial class MainForm : Form
    {
        CodeGeneratorLogic codeGenerator = new CodeGeneratorLogic();
        public MainForm()
        {
            InitializeComponent();
            codeGenerator.FillHash();
        }

        private const string ValidCharacters = "ACDEFGHKLMNPRTXYZ234579";

        private void btnLook_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInsertedCode.Text))
            {

                string insertedText = txtInsertedCode.Text;

                if (insertedText.Any(char.IsLower))
                {
                    MessageBox.Show("Girdiðiniz kodda küçük harfler bulunmakta.");
                    return;
                }
                else if (insertedText.Length > 8)
                {
                    MessageBox.Show("Girdiðiniz kodun uzunluðu 8'den büyük olamaz.");                    
                }
                else
                {
                    for (int i = 0; i < insertedText.Length; i++)
                    {
                        if (!ValidCharacters.Contains(insertedText[i]))
                        {
                            MessageBox.Show("Girdiðiniz kodda kabul edilemeyecek karakterler bulunmakta.");
                            return;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen uygun bir kod giriniz.");
                return;
            }

            //buraya kadar geldiyse kod uygundur demektir
            //fakat oluþturduðumuz kodlardan birisi olup olmadýðýný hashsetten kontrol etmemiz gerekir

            if (!codeGenerator.GeneratedCodes.Contains(txtInsertedCode.Text))
            {
                MessageBox.Show("Girdiðiniz kod uygun fakat random üretilenler arasýnda mevcut deðil.");
            }
            else
            {
                MessageBox.Show("Tebrikler, uygun kod girdiniz.");
            }
        }
    }
}