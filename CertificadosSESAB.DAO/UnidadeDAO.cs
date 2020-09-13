
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
	public class UnidadeDAO : BaseDAO<Unidade, long>, CertificadosSESAB.DAO.IUnidadeDAO
	{
		/// <summary>
		/// Inicializa uma instância da classe <see cref="UnidadeDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configuração do NHibernate.</param>
        public UnidadeDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CertificadosSESAB.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma instância de <see cref="UnidadeDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public UnidadeDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="UnidadeDAO"/>.
		/// </summary>
		/// <param name="session">A sessão NHibernate.</param>
		/// <param name="configuration">A configuração.</param>
        public UnidadeDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="UnidadeDAO"/>.
		/// </summary>
		/// <param name="connection">A conexão.</param>
		public UnidadeDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="Descricao"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Unidade> ListarPor(string descricao)
		{
			ICriteria crit = Get<ICriteria>()
				.Add(Expression.InsensitiveLike("Descricao",descricao,MatchMode.Anywhere))
				.AddOrder(Order.Asc("Descricao"));
			return crit.List<Unidade>();
		}
        public IList<Unidade> ListarAtivos()
        {
            ICriteria crit = Get<ICriteria>()
                .Add(Restrictions.Eq("Ativo",true))
                .AddOrder(Order.Asc("Descricao"));
            return crit.List<Unidade>();
        }
    }
}
