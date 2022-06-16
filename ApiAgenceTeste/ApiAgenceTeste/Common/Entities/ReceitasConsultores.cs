using BackEndPortafolioTarjeta.Common.Entities;

namespace ApiAgenceTeste.Common.Entities
{
   
    public class ReceitasConsultores : Entity
    {

        private string _perdiodo;
        private string _receita;
        private string _custoFixo;
        private string _comisao;
        private string _lucro;

        public ReceitasConsultores()
        {

        }

        public ReceitasConsultores(string periodo, string receita, string comisao, string lucro)
        {
            Periodo = periodo;
            Receita = receita;
            Comisao = comisao;
            Lucro = lucro;
        }

        public ReceitasConsultores(string periodo, string receita, string comisao, string lucro, string custoFixo)
        {
            Periodo = periodo;
            Receita = receita;
            Comisao = comisao;
            Lucro = lucro;
            CustoFixo = custoFixo;
        }

        public string Periodo { get => _perdiodo; set => _perdiodo = value; }

        public string Receita { get => _receita; set => _receita = value; }

        public string Comisao{ get => _comisao; set => _comisao = value; }

        public string Lucro { get => _lucro; set => _lucro = value; }

        public string CustoFixo { get => _custoFixo; set => _custoFixo = value; }



    }
}
