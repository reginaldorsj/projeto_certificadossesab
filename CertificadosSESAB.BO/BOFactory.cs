
using System;
using Microsoft.Practices.Unity;

namespace CertificadosSESAB.BO
{
	/// <summary>
	/// Classe que expõe os BO's.
	/// 
	/// </summary>
    public class BOFactory : MarshalByRefObject, CertificadosSESAB.BO.IBOFactory
    {
		/// <summary>
		/// Container para injeção de dependência.
		/// </summary>
        private UnityContainer unityContainer;
		/// <summary>
		/// Instância da classe para acesso estático.
		/// </summary>
        private static BOFactory instance = null;

		/// <summary>
		/// Inicializa uma instância de <see cref="BOFactory"/>.
		/// </summary>
		public BOFactory()
		{
			Inicialize();
		}

		/// <summary>
		/// Lê/Cria uma instância da classe.
		/// </summary>
		/// <returns></returns>
        public static BOFactory getInstance()
        {
            if (instance == null)
            {
                instance = new BOFactory();
            }
            return instance;
        }
		/// <summary>
		/// Inicializa esta instância.
		/// </summary>
		private void Inicialize() 
		{
			unityContainer = new UnityContainer();
			unityContainer.RegisterType<IEventoBO, EventoBO>();
			unityContainer.RegisterType<IEventoParticipanteBO, EventoParticipanteBO>();
			unityContainer.RegisterType<IHistoricoBO, HistoricoBO>();
			unityContainer.RegisterType<IParticipanteBO, ParticipanteBO>();
			unityContainer.RegisterType<IUnidadeBO, UnidadeBO>();
			unityContainer.RegisterType<IUsuarioBO, UsuarioBO>();
		}

		#region IDAOFactory Members
		/// <summary>
		/// Acesso a classe EventoBO.
		/// </summary>
		/// <returns></returns>
        public IEventoBO EventoBO()
        {
			return unityContainer.Resolve<EventoBO>();
        }
		/// <summary>
		/// Acesso a classe EventoParticipanteBO.
		/// </summary>
		/// <returns></returns>
        public IEventoParticipanteBO EventoParticipanteBO()
        {
			return unityContainer.Resolve<EventoParticipanteBO>();
        }
		/// <summary>
		/// Acesso a classe HistoricoBO.
		/// </summary>
		/// <returns></returns>
        public IHistoricoBO HistoricoBO()
        {
			return unityContainer.Resolve<HistoricoBO>();
        }
		/// <summary>
		/// Acesso a classe ParticipanteBO.
		/// </summary>
		/// <returns></returns>
        public IParticipanteBO ParticipanteBO()
        {
			return unityContainer.Resolve<ParticipanteBO>();
        }
		/// <summary>
		/// Acesso a classe UnidadeBO.
		/// </summary>
		/// <returns></returns>
        public IUnidadeBO UnidadeBO()
        {
			return unityContainer.Resolve<UnidadeBO>();
        }
		/// <summary>
		/// Acesso a classe UsuarioBO.
		/// </summary>
		/// <returns></returns>
        public IUsuarioBO UsuarioBO()
        {
			return unityContainer.Resolve<UsuarioBO>();
        }

        #endregion
		
    }
}
