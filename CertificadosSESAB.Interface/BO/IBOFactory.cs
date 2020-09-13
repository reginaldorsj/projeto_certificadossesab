
using System;

namespace CertificadosSESAB.BO
{
	/// <summary>
	/// Classe que expõe os BO's.
	/// 
	/// </summary>
    public interface IBOFactory
    {
		/// <summary>
		/// Acesso a classe EventoBO.
		/// </summary>
		/// <returns></returns>
		IEventoBO EventoBO();
		/// <summary>
		/// Acesso a classe EventoParticipanteBO.
		/// </summary>
		/// <returns></returns>
		IEventoParticipanteBO EventoParticipanteBO();
		/// <summary>
		/// Acesso a classe HistoricoBO.
		/// </summary>
		/// <returns></returns>
		IHistoricoBO HistoricoBO();
		/// <summary>
		/// Acesso a classe ParticipanteBO.
		/// </summary>
		/// <returns></returns>
		IParticipanteBO ParticipanteBO();
		/// <summary>
		/// Acesso a classe UnidadeBO.
		/// </summary>
		/// <returns></returns>
		IUnidadeBO UnidadeBO();
		/// <summary>
		/// Acesso a classe UsuarioBO.
		/// </summary>
		/// <returns></returns>
		IUsuarioBO UsuarioBO();

    }
}
