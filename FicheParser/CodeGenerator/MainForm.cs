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
                    MessageBox.Show("Girdi�iniz kodda k���k harfler bulunmakta.");
                    return;
                }
                else if (insertedText.Length > 8)
                {
                    MessageBox.Show("Girdi�iniz kodun uzunlu�u 8'den b�y�k olamaz.");                    
                }
                else
                {
                    for (int i = 0; i < insertedText.Length; i++)
                    {
                        if (!ValidCharacters.Contains(insertedText[i]))
                        {
                            MessageBox.Show("Girdi�iniz kodda kabul edilemeyecek karakterler bulunmakta.");
                            return;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("L�tfen uygun bir kod giriniz.");
                return;
            }

            //buraya kadar geldiyse kod uygundur demektir
            //fakat olu�turdu�umuz kodlardan birisi olup olmad���n� hashsetten kontrol etmemiz gerekir

            if (!codeGenerator.GeneratedCodes.Contains(txtInsertedCode.Text))
            {
                MessageBox.Show("Girdi�iniz kod uygun fakat random �retilenler aras�nda mevcut de�il.");
            }
            else
            {
                MessageBox.Show("Tebrikler, uygun kod girdiniz.");
            }
        }
    }
}