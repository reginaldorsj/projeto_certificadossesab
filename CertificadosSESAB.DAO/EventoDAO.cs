
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
	public class EventoDAO : BaseDAO<Evento, long>, CertificadosSESAB.DAO.IEventoDAO
	{
		/// <summary>
		/// Inicializa uma instância da classe <see cref="EventoDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configuração do NHibernate.</param>
        public EventoDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CertificadosSESAB.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma instância de <see cref="EventoDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public EventoDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="EventoDAO"/>.
		/// </summary>
		/// <param name="session">A sessão NHibernate.</param>
		/// <param name="configuration">A configuração.</param>
        public EventoDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="EventoDAO"/>.
		/// </summary>
		/// <param name="connection">A conexão.</param>
		public EventoDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="unidade">O(A) unidade.</param>
		/// <returns>A lista.</returns>
		public IList<Evento> ListarPorUnidade(Unidade unidade)
		{
			return Listar("IdUnidade","IdUnidade",unidade.IdUnidade,"Nome");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="idunidade"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Evento> ListarPor(string idunidade)
		{
			throw new NotImplementedException("Não implementado.");
		}
	}
}
