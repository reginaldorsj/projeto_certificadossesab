
using System;
using Microsoft.Practices.Unity;

namespace CertificadosSESAB.DAO
{
	/// <summary>
	/// Classe que expõe os DAO's.
	/// 
	/// </summary>
    public class DAOFactory : MarshalByRefObject, CertificadosSESAB.DAO.IDAOFactory
    {
		/// <summary>
		/// Container para injeção de dependência.
		/// </summary>
        private UnityContainer unityContainer;
		/// <summary>
		/// Inicializa uma instância de <see cref="DAOFactory"/>.
		/// </summary>
        public DAOFactory() 
        {			
			Inicialize();
		}
		/// <summary>
		/// Inicializa esta instância.
		/// </summary>
		private void Inicialize() 
		{
			unityContainer = new UnityContainer();
			unityContainer.RegisterType<IEventoDAO, EventoDAO>();
			unityContainer.RegisterType<IEventoParticipanteDAO, EventoParticipanteDAO>();
			unityContainer.RegisterType<IHistoricoDAO, HistoricoDAO>();
			unityContainer.RegisterType<IParticipanteDAO, ParticipanteDAO>();
			unityContainer.RegisterType<IUnidadeDAO, UnidadeDAO>();
			unityContainer.RegisterType<IUsuarioDAO, UsuarioDAO>();
		}
		#region IDAOFactory Members
		/// <summary>
		/// Acesso a classe EventoDAO.
		/// </summary>
		/// <returns></returns>
        public IEventoDAO EventoDAO()
        {
			return unityContainer.Resolve<EventoDAO>();
        }
		/// <summary>
		/// Acesso a classe EventoParticipanteDAO.
		/// </summary>
		/// <returns></returns>
        public IEventoParticipanteDAO EventoParticipanteDAO()
        {
			return unityContainer.Resolve<EventoParticipanteDAO>();
        }
		/// <summary>
		/// Acesso a classe HistoricoDAO.
		/// </summary>
		/// <returns></returns>
        public IHistoricoDAO HistoricoDAO()
        {
			return unityContainer.Resolve<HistoricoDAO>();
        }
		/// <summary>
		/// Acesso a classe ParticipanteDAO.
		/// </summary>
		/// <returns></returns>
        public IParticipanteDAO ParticipanteDAO()
        {
			return unityContainer.Resolve<ParticipanteDAO>();
        }
		/// <summary>
		/// Acesso a classe UnidadeDAO.
		/// </summary>
		/// <returns></returns>
        public IUnidadeDAO UnidadeDAO()
        {
			return unityContainer.Resolve<UnidadeDAO>();
        }
		/// <summary>
		/// Acesso a classe UsuarioDAO.
		/// </summary>
		/// <returns></returns>
        public IUsuarioDAO UsuarioDAO()
        {
			return unityContainer.Resolve<UsuarioDAO>();
        }
		public void Dispose()
		{
			// Nada
		}

        #endregion
		
    }
}
