using FicheParser.Model;
using Newtonsoft.Json;
using System.Text;

namespace FicheParser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Processes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Processes()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Filter = "Json File | *.json",
                    FileName = ""
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fl = ofd.FileName;
                    string text = File.ReadAllText(fl, Encoding.Default);
                    if (!string.IsNullOrEmpty(text))
                    {
                        //modele cast etme iþlemi
                        List<FPModel> model = JsonConvert.DeserializeObject<List<FPModel>>(text);

                        //konumlarýn düzeltilmesi
                        List<Vertex> vertices = model.Select(a => a.BoundingPoly).SelectMany(a => a.Vertices).ToList();

                        int minX = vertices.Min(a => a.X);
                        int minY = vertices.Min(a => a.Y);

                        vertices.ForEach(a =>
                        {
                            a.X -= (minX - 1);
                            a.Y -= (minY - 1);
                        });

                        //konumsal yanlýþlýklarýn düzeltilmesi için iþlemler
                        Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
                        for (int i = 0; i < vertices.Count(); i++)
                        {
                            int y = vertices.ElementAt(i).Y;
                            int y20 = y + 30;
                            int yM20 = y - 30;

                            if (vertices.Any(a => a.Y >= yM20 && y20 <= a.Y && vertices.IndexOf(a) != i && keyValuePairs.Any(a => a.Key != y)))
                            {
                                int realOne = vertices.FirstOrDefault(a => a.Y >= yM20 && y20 <= a.Y && vertices.IndexOf(a) != i).Y;
                                keyValuePairs.Add(y, realOne);
                            }
                        }

                        //konumsal yanlýþlýklarýn düzeltilmesi için iþlemler
                        model.ForEach(a =>
                        {
                            a.BoundingPoly.Vertices.ForEach(b =>
                            {
                                if (a.BoundingPoly.Vertices.Any(c => (c.Y - 1) == b.Y || (c.Y - 2) == b.Y || (c.Y - 2) == b.Y || (c.Y - 3) == b.Y))
                                {
                                    b.Y = a.BoundingPoly.Vertices.FirstOrDefault(c => (c.Y - 1) == b.Y || (c.Y - 2) == b.Y || (c.Y - 2) == b.Y || (c.Y - 3) == b.Y).Y;
                                }

                                if (keyValuePairs.Any(a => a.Key == b.Y))
                                {
                                    b.Y = keyValuePairs.FirstOrDefault(a => a.Key == b.Y).Value;
                                }

                            });
                        });

                        for (int i = 1; i < model.Count; i++)
                        {
                            FPModel model2 = model[i];

                            List<Point> points = model2.BoundingPoly.Vertices.Select(a => new Point(a.X, a.Y)).ToList();

                            Pen p = new Pen(Color.Black);
                            Font f = new Font("Arial", 11);
                            SolidBrush solidBrush = new SolidBrush(Color.Black);
                            Graphics graphics = this.CreateGraphics();
                            //graphics.DrawPolygon(p, points.ToArray());
                            Point point = points.FirstOrDefault();
                            graphics.DrawString(model2.Description, f, solidBrush, points.FirstOrDefault());
                        }

                        //sað tarafa modelin ilk satýrýný da attým
                        //burada json üzerinden max bu yapýlabilir
                        string[] lines = model.FirstOrDefault().Description.Split(Environment.NewLine.ToCharArray());
                        lstFiche.DataSource = lines;
                        lstNumbers.DataSource = Enumerable.Range(1, lines.Length).ToArray();

                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Processes();
        }
    }
}