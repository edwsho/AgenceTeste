using BackEndPortafolioTarjeta.Persistence.DAO;
using BackEndPortafolioTarjeta.Persistence.DAO.Interfaces;

namespace BackEndPortafolioTarjeta.Persistence.Factory
{
    public static class DAOFactory
    {
        /// <summary>
        /// Devuelve instancia de DAOConsultor
        /// </summary>
        /// <returns>DAOUsuario</returns>
        public static DAOConsultor CreateDAOConsultor()
        {
            return new DAOConsultor();
        }



    }
}
