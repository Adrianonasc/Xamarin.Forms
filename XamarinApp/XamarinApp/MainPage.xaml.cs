using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace XamarinApp
{
    public partial class MainPage : ContentPage
    {
        private int TempoInicio, TempoFim;
        Stopwatch watch = Stopwatch.StartNew();


        public MainPage()
        {
            InitializeComponent();
        }

        private void btnTeste1_Clicked(object sender, EventArgs e)
        {
            lblResult.Text = "btnTeste1_Clicked";
        }

        private void btnTeste2_Clicked(object sender, EventArgs e)
        {
            lblResult.Text = "btnTeste2_Clicked";
        }

        private void btnTeste3_Clicked(object sender, EventArgs e)
        {
            string result; 
            foreach (int dimencao in dimencoes)
            {
                result = this.MultiplicarMatrizes(dimencao);
                Debug.WriteLine($"Tempo Total Multiplicação de Matriz:  {watch.ElapsedMilliseconds.ToString()}");
            }
            lblResult.Text = "Teste Finalizado";
        }

        int[] dimencoes = new int[] { 40, 80, 100, 250, 500, 750, 1000 };
        #region Multiplicação de matriz



        public string MultiplicarMatrizes(int Dimensao)
        {

            watch.Reset();
            watch.Start();
            int[,] matriz1 = new int[Dimensao, Dimensao];
            int[,] matriz2 = new int[Dimensao, Dimensao];
            Random random  = new Random();
            int[,] matrizResult = new int[Dimensao, Dimensao];
            for (int i = 0; i < Dimensao; i++)
                for (int j = 0; j < Dimensao; j++)
                {
                    matriz1[i, j] = random.Next(2, 1000);
                    matriz2[i, j] = random.Next(2, 1000);
                }


            for (int i = 0; i < Dimensao; i++)
                for (int j = 0; j < Dimensao; j++)
                    for (int k = 0; k < Dimensao; k++)
                        matrizResult[i, j] += matriz1[i, k] * matriz2[k, j];

            watch.Stop();

            StringBuilder str = new StringBuilder();
            for (int i = 0; i < Dimensao; i++)
            {
                str.Append($"[");
                for (int j = 0; j < Dimensao; j++)
                    str.Append($"{matrizResult[i, j]},");
                str.Append($"] {Environment.NewLine}");
            }

            return str.ToString();
        }
        #endregion
    }
}
