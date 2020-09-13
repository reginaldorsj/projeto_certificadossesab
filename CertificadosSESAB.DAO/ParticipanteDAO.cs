
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
	public class ParticipanteDAO : BaseDAO<Participante, long>, CertificadosSESAB.DAO.IParticipanteDAO
	{
		/// <summary>
		/// Inicializa uma instância da classe <see cref="ParticipanteDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configuração do NHibernate.</param>
        public ParticipanteDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CertificadosSESAB.OR", null)
        {            
        }
		/// <summary>
		/// Inicializa uma instância de <see cref="ParticipanteDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public ParticipanteDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="ParticipanteDAO"/>.
		/// </summary>
		/// <param name="session">A sessão NHibernate.</param>
		/// <param name="configuration">A configuração.</param>
        public ParticipanteDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="ParticipanteDAO"/>.
		/// </summary>
		/// <param name="connection">A conexão.</param>
		public ParticipanteDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="nome"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Participante> ListarPor(string nome)
		{
			ICriteria crit = Get<ICriteria>()
				.Add(Expression.InsensitiveLike("Nome",nome,MatchMode.Anywhere))
				.AddOrder(Order.Asc("Nome"));
			return crit.List<Participante>();
		}
	}
}
