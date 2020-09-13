
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Regisoft.Camadas.Generic;
using System.Data;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Cfg;
using CertificadosSESAB.OR;

namespace CertificadosSESAB.DAO
{
	/// <summary>
	/// Classe para acesso ao banco de dados utilizando o NHiberante.
	/// 
	/// </summary>
	public class HistoricoDAO : BaseDAO<Historico, long>, CertificadosSESAB.DAO.IHistoricoDAO
	{
		/// <summary>
		/// Inicializa uma inst�ncia da classe <see cref="HistoricoDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configura��o do NHibernate.</param>
        public HistoricoDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CertificadosSESAB.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma inst�ncia de <see cref="HistoricoDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public HistoricoDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma inst�ncia da classe <see cref="HistoricoDAO"/>.
		/// </summary>
		/// <param name="session">A sess�o NHibernate.</param>
		/// <param name="configuration">A configura��o.</param>
        public HistoricoDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma inst�ncia da classe <see cref="HistoricoDAO"/>.
		/// </summary>
		/// <param name="connection">A conex�o.</param>
		public HistoricoDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="eventoparticipante">O(A) eventoparticipante.</param>
		/// <returns>A lista.</returns>
		public IList<Historico> ListarPorEventoParticipante(EventoParticipante eventoparticipante)
		{
			return Listar("IdEventoParticipante","IdEventoParticipante",eventoparticipante.IdEventoParticipante,"IdEventoParticipante");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="ideventoparticipante"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Historico> ListarPor(string ideventoparticipante)
		{
			throw new NotImplementedException("N�o implementado.");
		}
	}
}
