namespace BackEndPortafolioTarjeta.ServicesLayer.DTO
{
    public class DTOConsultor
    {
        private int _id;
        private string _user;
        private string _date1;
        private string _date2;

        public DTOConsultor()
        {
            
        }
        public DTOConsultor(int id, string nombre)
        {
            ID = id;
            UserName = nombre;
        }

        public DTOConsultor(string nombre)
        {
            UserName = nombre;
        }

        public DTOConsultor(string user, string date1, string date2)
        {
            UserName = user;
            Date1 = date1;
            Date2 = date2;
        }

        public int ID { get => _id; set => _id = value; }
        public string UserName { get => _user; set => _user = value; }

        public string Date1 { get => _date1; set => _date1 = value; }
        public string Date2 { get => _date2; set => _date2 = value; }

    }
}
