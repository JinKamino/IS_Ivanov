using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_model
{
    public partial class Form1 : Form
    {
        string rulesText;
        string factsDescText;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void downloadRules_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogRules = new OpenFileDialog();
            DialogResult result = openFileDialogRules.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = openFileDialogRules.FileName;
                try
                {
                    rulesText = File.ReadAllText(path);
                    var textBox = this.Controls["rulesOutput"];
                    textBox.Text = rulesText.Replace(",", ", ").Replace(";", " -> ");
                    this.Controls["fLabel1"].Text = path.Split('\\').Last();
                }
                catch (IOException)
                {
                }
            }
        }

        private void downloadDescriprion_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogRules = new OpenFileDialog();
            DialogResult result = openFileDialogRules.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = openFileDialogRules.FileName;
                try
                {
                    factsDescText = File.ReadAllText(path);
                    this.Controls["fLabel2"].Text = path.Split('\\').Last();
                }
                catch (IOException)
                {
                }
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrintResult(ProductModel productModel, List<Rule> rules)
        {
            var curFacts = new HashSet<Fact>(productModel.initialFacts);
            StringBuilder stringBuilder = new StringBuilder();
            int i = 1;
            foreach (var rule in rules)
            {
                if (curFacts.Contains(rule.result))
                    continue;
                stringBuilder.Append(i++);
                stringBuilder.Append(".\r\n");
                stringBuilder.Append("Известные факты:\r\n\t");
                stringBuilder.Append(String.Join(", ", curFacts.Select((f) => f.description)));
                stringBuilder.Append("\r\n\r\n");
                stringBuilder.Append("Примененное правило:\r\n\t");
                stringBuilder.Append(String.Join(", ", rule.facts.Select((f) => f.description)));
                stringBuilder.Append(" -> ");
                stringBuilder.Append(rule.result.description);
                stringBuilder.Append("\r\n\r\n\r\n");
                curFacts.Add(rule.result);
            }
            this.Controls["output"].Text = stringBuilder.ToString();
        }

        private void forwardOut_Click(object sender, EventArgs e)
        {
            if (this.Controls["fLabel1"].Text == "" || this.Controls["fLabel2"].Text == "")
            {
                this.Controls["output"].Text = "Загрузите необходимые файлы";
                return;
            }

            ProductModel productModel = new ProductModel(rulesText, factsDescText, this.Controls["initialText"].Text);
            var soughtFact = productModel.facts.Find((f) => f.label == this.Controls["targetText"].Text);
            if (soughtFact == null)
            {
                this.Controls["output"].Text = "Ошибка в метке целевого факта";
                return;
            }
            var result = productModel.ForwardOutput(soughtFact);
            if (result.Count == 0)
            {
                if (productModel.initialFacts.Contains(soughtFact))
                {
                    this.Controls["output"].Text = "Находится в множестве начальных фактов";
                    return;
                }
                this.Controls["output"].Text = "Вывод невозможен";
                return;
            }

            PrintResult(productModel, result);
        }

        private void backwardOut_Click(object sender, EventArgs e)
        {
            if (this.Controls["fLabel1"].Text == "" || this.Controls["fLabel2"].Text == "")
            {
                this.Controls["output"].Text = "Загрузите необходимые файлы";
                return;
            }

            ProductModel productModel = new ProductModel(rulesText, factsDescText, this.Controls["initialText"].Text);
            var soughtFact = productModel.facts.Find((f) => f.label == this.Controls["targetText"].Text);
            if (soughtFact == null)
            {
                this.Controls["output"].Text = "Ошибка в метке целевого факта";
                return;
            }
            var result = productModel.BackwardOutput(soughtFact);
            if (result.Count == 0)
            {
                if (productModel.initialFacts.Contains(soughtFact))
                {
                    this.Controls["output"].Text = "Находится в множестве начальных фактов";
                    return;
                }
                this.Controls["output"].Text = "Вывод невозможен";
                return;
            }

            PrintResult(productModel, result);
        }
    }
}
