using System;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace XamarinApp
{
    public partial class MainPage : ContentPage
    {
        Stopwatch watch = Stopwatch.StartNew();
        int[] arrQuantRegistro = new int[] { 10, 25, 50, 75, 100, 250, 1000 };
        int[] arrTempoExecucao = new int[7];
        int indexQuantidadeRegisto = 0;
        int[] dimencoes = new int[] { 40, 80, 100, 250, 500, 750, 1000 };
        SQLiteHelpers db = new SQLiteHelpers();

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Teste de Insert Local
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTeste1_Clicked(object sender, EventArgs e)
        {
            if (indexQuantidadeRegisto >= arrQuantRegistro.Length)
            {
                foreach (var item in arrTempoExecucao)
                    Debug.WriteLine(item.ToString(CultureInfo.CurrentCulture));
                indexQuantidadeRegisto = 0;
                return;
            }

            PreTeste();
            lblResult.Text = "Teste de Insert Local Iniciado";
            Usuario usuario;
            Byte[] b = new Byte[100];
            Random rnd = new Random();
            watch.Start();
            for (int i = 0; i < arrQuantRegistro[indexQuantidadeRegisto]; i++)
            {
                rnd.NextBytes(b);
                usuario = new Usuario()
                {
                    Id = i,
                    Nome = "Nome " + i,
                    Idade = i,
                    salario = i * 10,
                    Foto = b
                };
                b = new Byte[100];
                db.InserirCliente(usuario);

            }
            watch.Stop();
            arrTempoExecucao[indexQuantidadeRegisto] = watch.Elapsed.Milliseconds;
            watch.Reset();
            indexQuantidadeRegisto++;
            PosTeste();
            exibirTempo();
        }

        /// <summary>
        /// Insert ao consumir web Service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTeste2_Clicked(object sender, EventArgs e)
        {
            lblResult.Text = "Teste 2";
            Webservice();
        }

        public async void Webservice()
        {
            if (indexQuantidadeRegisto >= arrQuantRegistro.Length)
            {
                foreach (var item in arrTempoExecucao)
                    Debug.WriteLine(item.ToString(CultureInfo.CurrentCulture));
                indexQuantidadeRegisto = 0;
                return;
            }
            PreTeste();

            var client = new HttpClient();
            string uri = "http://webapiadrtcc.azurewebsites.net/api/Usuarios/" + (arrQuantRegistro[indexQuantidadeRegisto] - 1);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            watch.Start();
            var result = await client.GetAsync(uri);
            string json = await result.Content.ReadAsStringAsync();
            var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
            foreach (var usuario in usuarios)
            {
                db.InserirCliente(usuario);
            }
            watch.Stop();
            arrTempoExecucao[indexQuantidadeRegisto] = watch.Elapsed.Milliseconds;
            indexQuantidadeRegisto++;
            watch.Reset();
            PosTeste();
            exibirTempo();

        }

        /// <summary>
        /// Multiplicação de Matriz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTeste3_Clicked(object sender, EventArgs e)
        {
            lblResult.Text = "Teste 3 em execução";
            foreach (int dimencao in dimencoes)
            {
                this.MultiplicarMatrizes(dimencao);
                arrTempoExecucao[indexQuantidadeRegisto] = watch.Elapsed.Milliseconds;
                indexQuantidadeRegisto++;
            }
            indexQuantidadeRegisto = 0;
            lblResult.Text = "Teste Finalizado";
            exibirTempo();
        }

        #region Multiplicação de matriz

        public string MultiplicarMatrizes(int Dimensao)
        {

            watch.Reset();
            watch.Start();
            int[,] matriz1 = new int[Dimensao, Dimensao];
            int[,] matriz2 = new int[Dimensao, Dimensao];
            Random random = new Random();
            int[,] matrizResult = new int[Dimensao, Dimensao];
            for (int i = 0; i < Dimensao; i++)
                for (int j = 0; j < Dimensao; j++)
                {
                    matriz1[i, j] = random.Next(2, 1000);
                    matriz2[i, j] = random.Next(2, 1000);
                }


            for (int i = 0; i < Dimensao; i++)
                for (int j = 0; j < Dimensao; j++)
                     matrizResult[i, j] += matriz1[i, j] * matriz2[i, j];

            watch.Stop();

            return "";
        }
        #endregion

        public void exibirTempo()
        {
            StringBuilder str = new StringBuilder();
            str.Append($"[");
            foreach (var item in arrTempoExecucao)
            {
                str.Append($"{item},");
            }
            str.Append($"] {Environment.NewLine}");
            lblResult.Text = str.ToString();
        }

        public void PosTeste()
        {
          Debug.WriteLine($"Total Resgistros:  {db.CountRegistro()}");
        }

        public void PreTeste()
        {
           db.dropTb();
           db.CreateTb();
        }
    }
}
