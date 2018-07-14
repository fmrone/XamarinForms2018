using App01_ConsultarCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCepServico
    {
        private static string enderecoUrl = "http://viacep.com.br/ws/{0}/json";

        public static Endereco ObtemEnderecoPor(string cep)
        {
            try
            {
                WebClient wc = new WebClient();
                var endereco = JsonConvert.DeserializeObject<Endereco>(wc.DownloadString(string.Format(enderecoUrl, cep)));

                if (endereco.Cep == null)
                    return null;

                return endereco;
            }
            catch
            {
                throw;
            }
        }

    }
}
