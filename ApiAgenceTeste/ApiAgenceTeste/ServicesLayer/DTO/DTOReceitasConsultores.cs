namespace ApiAgenceTeste.ServicesLayer.DTO
{
    public class DTOReceitasConsultores
    {

        private string _perdiodo;
        private string _receita;
        private string _custo;
        private string _comisao;
        private string _lucro;

        public DTOReceitasConsultores(string periodo, string receita, string comisao, string lucro)
        {
            Periodo = periodo;
            Receita = receita;
            Comisao = comisao;
            Lucro = lucro;
           
        }

        public DTOReceitasConsultores(string periodo, string receita, string comisao, string lucro, string custo)
        {
            Periodo = periodo;
            Receita = receita;
            Comisao = comisao;
            Lucro = lucro;
            CustoFixo = custo;
        }

        public string Periodo { get => _perdiodo; set => _perdiodo = value; }

        public string Receita { get => _receita; set => _receita = value; }

        public string Comisao { get => _comisao; set => _comisao = value; }

        public string Lucro { get => _lucro; set => _lucro = value; }

        public string CustoFixo { get => _custo; set => _custo = value; }

    }
}
