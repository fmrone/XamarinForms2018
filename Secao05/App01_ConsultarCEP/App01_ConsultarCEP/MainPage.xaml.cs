using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            InitializeComponent();

            btnBusca.Clicked += BtnBusca_Clicked; 

		}

        private void BtnBusca_Clicked(object sender, EventArgs e)
        {
            try
            {
                var cep = etrCep.Text.Trim();

                if (CepValido(cep))
                {
                    var endereco = ViaCepServico.ObtemEnderecoPor(cep);

                    if (endereco != null)
                        lblResultado.Text = string.Format("Endereço: {0}, {1} - {2}, {3}", endereco.Localidade, endereco.Uf, endereco.Logradouro, endereco.Bairro);
                    else
                        DisplayAlert("INFO", string.Format("Nenhum endereço foi encontrato para o CEP {0}.", cep), "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("ERRO", ex.Message, "OK");
            }
        }

        private bool CepValido(string cep)
        {
            var retorno = true;

            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "O CEP informado deve conter 8 caracteres", "OK");
                retorno = false;
            }

            var cepTryParse = 0;
            if (!int.TryParse(cep, out cepTryParse))
            {
                DisplayAlert("Erro", "O CEP informado deve conter apenas números", "OK");
                retorno = false;
            }

            return retorno;
        }

       
    }
}
