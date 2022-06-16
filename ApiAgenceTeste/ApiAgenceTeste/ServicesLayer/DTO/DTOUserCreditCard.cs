namespace BackEndPortafolioTarjeta.ServicesLayer.DTO
{
    public class DTOUserCreditCard
    {

        private int _id;
        private string _nombre;
        private string _numeroTarjeta;
        private string _fechaExp;
        private string _cvv;

        public DTOUserCreditCard(int id, string nombre, string numeroTarjeta, string fechaExp, string cvv)
        {
            Id = id;
            Nombre = nombre;
            NumeroTarjeta = numeroTarjeta;
            FechaExp = fechaExp;
            CVV = cvv;
           
        }

        public int Id { get => _id; set => _id = value; }

        public string Nombre { get => _nombre; set => _nombre = value; }

        public string NumeroTarjeta { get => _numeroTarjeta; set => _numeroTarjeta = value; }

        public string FechaExp { get => _fechaExp; set => _fechaExp = value; }

        public string CVV { get => _cvv; set => _cvv = value; }

    }
}
