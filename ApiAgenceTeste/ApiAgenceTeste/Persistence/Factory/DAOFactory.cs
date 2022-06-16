using BackEndPortafolioTarjeta.Persistence.DAO;
using BackEndPortafolioTarjeta.Persistence.DAO.Interfaces;

namespace BackEndPortafolioTarjeta.Persistence.Factory
{
    public static class DAOFactory
    {

        /// <summary>
        /// Devuelve instancia de DAOUserCreditCard
        /// </summary>
        /// <returns>DAOUsuario</returns>
        public static DAOUserCreditCard CreateDAOUserCreditCard()
        {
            return new DAOUserCreditCard();
        }

        /// <summary>
        /// Devuelve instancia de DAOUserCreditCard
        /// </summary>
        /// <returns>DAOUsuario</returns>
        public static DAOConsultor CreateDAOConsultor()
        {
            return new DAOConsultor();
        }



    }
}
