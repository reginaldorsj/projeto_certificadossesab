
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
	public class EventoParticipanteDAO : BaseDAO<EventoParticipante, long>, CertificadosSESAB.DAO.IEventoParticipanteDAO
	{
		/// <summary>
		/// Inicializa uma instância da classe <see cref="EventoParticipanteDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configuração do NHibernate.</param>
        public EventoParticipanteDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CertificadosSESAB.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma instância de <see cref="EventoParticipanteDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public EventoParticipanteDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="EventoParticipanteDAO"/>.
		/// </summary>
		/// <param name="session">A sessão NHibernate.</param>
		/// <param name="configuration">A configuração.</param>
        public EventoParticipanteDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="EventoParticipanteDAO"/>.
		/// </summary>
		/// <param name="connection">A conexão.</param>
		public EventoParticipanteDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="participante">O(A) participante.</param>
		/// <returns>A lista.</returns>
		public IList<EventoParticipante> ListarPorParticipante(Participante participante)
		{
			return Listar("IdParticipante","IdParticipante",participante.IdParticipante,"IdParticipante");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="evento">O(A) evento.</param>
		/// <returns>A lista.</returns>
		public IList<EventoParticipante> ListarPorEvento(Evento evento)
		{
            ICriteria crit = Get<ICriteria>()
                .CreateAlias("IdEvento","evento",NHibernate.SqlCommand.JoinType.InnerJoin)
                .Add(Expression.Eq("evento.IdEvento", evento.IdEvento))
                .CreateAlias("IdParticipante", "participante", NHibernate.SqlCommand.JoinType.InnerJoin)
                    .AddOrder(Order.Asc("participante.Nome"));
            return crit.List<EventoParticipante>();
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="idparticipante"> O dado para pesquisa.</param>
        /// <returns>A lista.</returns>
        public IList<EventoParticipante> ListarPor(string idparticipante)
		{
			throw new NotImplementedException("Não implementado.");
		}
	}
}
