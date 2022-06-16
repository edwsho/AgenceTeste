namespace BackEndPortafolioTarjeta.Common.Entities
{
    public class Consultor : Entity
    {
        private string _user;
        private string _costoFixo;

        private string _date1;
        private string _date2;

        public Consultor()
        {

        }

        public Consultor(int _id)
        {
            Id = _id;   
        }

        public Consultor(string user)
        {
            _user = user;
        }

        public Consultor(string user, string custo)
        {
            _user = user;
            _costoFixo = custo;
        }

        public Consultor(string user, string date1, string date2)
        {
            User = user;
            Date1 = date1;
            Date2 = date2;
        } 

        public string User { get => _user; set => _user = value; }
        public string CostoFixo { get => _costoFixo; set => _costoFixo = value; }

        public string Date1 { get => _date1; set => _date1 = value; }
        public string Date2 { get => _date2; set => _date2 = value; }
    }
}
