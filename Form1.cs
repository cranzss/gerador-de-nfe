using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace geradordenf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        static Random rand = new Random();

        static string SerieNF()
        {

            // Gera um número entre 1 e 9 dígitos
            int quantidadeDigitos = rand.Next(1, 4); // 1 a 9
            int menor = (int)Math.Pow(10, quantidadeDigitos - 1);
            int maior = (int)Math.Pow(10, quantidadeDigitos) - 1;

            int numeroAleatorio = rand.Next(menor, maior + 1);
            string serie = numeroAleatorio.ToString().PadLeft(3, '0');

            return serie;
        }
        static string NumeroNF()
        {
            

            // Gera um número entre 1 e 9 dígitos
            int quantidadeDigitos = rand.Next(4, 8); // 1 a 9
            int menor = (int)Math.Pow(10, quantidadeDigitos - 1);
            int maior = (int)Math.Pow(10, quantidadeDigitos) - 1;

            int numeroAleatorio = rand.Next(menor, maior + 1);
            string numerocomzero = numeroAleatorio.ToString().PadLeft(9, '0');

            return numerocomzero;
        }

        static string CodNF(Random rando, int minLength)
        {
            const string chars = "0123456789";
            char[] result = new char[minLength];

            // Gere caracteres aleatórios até alcançar o tamanho mínimo especificado
            for (int i = 0; i < minLength; i++)
            {
                result[i] = chars[rando.Next(chars.Length)];
            }

            return new string(result);
        }

        static string CodUF(string uf)
        {
            switch (uf)
            {
                case "AC": return "12";
                case "AL": return "27";
                case "AP": return "16";
                case "AM": return "13";
                case "BA": return "29";
                case "CE": return "23";
                case "DF": return "53";
                case "ES": return "32";
                case "GO": return "52";
                case "MA": return "21";
                case "MT": return "51";
                case "MS": return "50";
                case "MG": return "31";
                case "PA": return "15";
                case "PB": return "25";
                case "PR": return "41";
                case "PE": return "26";
                case "PI": return "22";
                case "RJ": return "33";
                case "RN": return "24";
                case "RS": return "43";
                case "RO": return "11";
                case "RR": return "14";
                case "SC": return "42";
                case "SP": return "35";
                case "SE": return "28";
                case "TO": return "17";
            }

            return uf;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string GerarCNPJ()
            {
                // Gerar 8 números aleatórios de 0 a 9 e 4 números (0001), e depois calcular eles
                // Colocar eles na maskedTextBox

                Random rnd = new Random();
                int n1 = rnd.Next(0, 10);
                int n2 = rnd.Next(0, 10);
                int n3 = rnd.Next(0, 10);
                int n4 = rnd.Next(0, 10);
                int n5 = rnd.Next(0, 10);
                int n6 = rnd.Next(0, 10);
                int n7 = rnd.Next(0, 10);
                int n8 = rnd.Next(0, 10);
                int n9 = 0;
                int n10 = 0;
                int n11 = 0;
                int n12 = 1;

                int Soma1 = n1 * 5 + n2 * 4 + n3 * 3 + n4 * 2 + n5 * 9 + n6 * 8 + n7 * 7 + n8 * 6 + n9 * 5 + n10 * 4 + n11 * 3 + n12 * 2;

                int DV1 = Soma1 % 11;

                if (DV1 < 2)
                {
                    DV1 = 0;
                }
                else
                {
                    DV1 = 11 - DV1;
                }

                int Soma2 = n1 * 6 + n2 * 5 + n3 * 4 + n4 * 3 + n5 * 2 + n6 * 9 + n7 * 8 + n8 * 7 + n9 * 6 + n10 * 5 + n11 * 4 + n12 * 3 + DV1 * 2;

                int DV2 = Soma2 % 11;

                if (DV2 < 2)
                {
                    DV2 = 0;
                }
                else
                {
                    DV2 = 11 - DV2;
                }

                return n1.ToString() + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9 + n10 + n11 + n12 + DV1 + DV2;
            }

            textBox2.Text = GerarCNPJ();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            textBox2.MaxLength = 18;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //mês e ano da nota
            string Data = DateTime.Now.ToString("yy''MM");

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecione uma UF válida.");
                return;
            }

            string cnpj = textBox2.Text;
            //bool caracterepescial = cnpj.Contains(".") || cnpj.Contains("/") || cnpj.Contains("-");

            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
            {
                MessageBox.Show("Por favor insira um documento válido");
                return;
            }

            if (cnpj.Length == 0)
            {
                MessageBox.Show("Por favor insira o documento do emissor/fornecedor");
                return;
            }
            
            string uf = comboBox1.SelectedItem.ToString();
            string ufcod = CodUF(uf);


            //série da nf
            string ser = SerieNF();

            //número da nf
            string num = NumeroNF();

            //código numérico da nf
            Random rando = new Random(DateTime.Now.Millisecond);
            string cod = CodNF(rando, 8);

            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            //chave nf com 43 digitos
            string chave = ufcod + Data + cnpj + "55" + ser + num + "1" + cod;

            // cálculo do dígito verificador da NF
            int peso = 2;
            int soma = 0;

            for (int i = chave.Length - 1; i >= 0; i--)
            {
                int digito = int.Parse(chave[i].ToString());
                soma += digito * peso;

                peso++;
                if (peso > 9)
                    peso = 2;
            }

            int resto = soma % 11;
            int digitoVerificador = 11 - resto;
            if (digitoVerificador > 9)
                digitoVerificador = 0;

            string digit = digitoVerificador.ToString();

            string chavenfe = chave + digit;

            textBox1.Text = chavenfe;
            textBox3.Text = num.TrimStart('0');
            textBox4.Text = ser.TrimStart('0');
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            TextBox textBox = sender as TextBox;
            string numeros = new string(textBox.Text.Where(char.IsDigit).ToArray());

            // Se já tiver 14 dígitos e a tecla pressionada não for de controle (como backspace), bloqueia
            if (numeros.Length >= 14 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.None;
            string url = "https://github.com/cranzss";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
