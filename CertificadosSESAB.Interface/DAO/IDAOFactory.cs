
using System;

namespace CertificadosSESAB.DAO
{
	/// <summary>
	/// Classe que expõe os DAO's.
	/// 
	/// </summary>
    public interface IDAOFactory : IDisposable
    {
		/// <summary>
		/// Acesso a classe EventoDAO.
		/// </summary>
		/// <returns></returns>
		IEventoDAO EventoDAO();
		/// <summary>
		/// Acesso a classe EventoParticipanteDAO.
		/// </summary>
		/// <returns></returns>
		IEventoParticipanteDAO EventoParticipanteDAO();
		/// <summary>
		/// Acesso a classe HistoricoDAO.
		/// </summary>
		/// <returns></returns>
		IHistoricoDAO HistoricoDAO();
		/// <summary>
		/// Acesso a classe ParticipanteDAO.
		/// </summary>
		/// <returns></returns>
		IParticipanteDAO ParticipanteDAO();
		/// <summary>
		/// Acesso a classe UnidadeDAO.
		/// </summary>
		/// <returns></returns>
		IUnidadeDAO UnidadeDAO();
		/// <summary>
		/// Acesso a classe UsuarioDAO.
		/// </summary>
		/// <returns></returns>
		IUsuarioDAO UsuarioDAO();

    }
}
