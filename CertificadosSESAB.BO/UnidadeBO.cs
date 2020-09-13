
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Regisoft;
using CertificadosSESAB.OR;
using CertificadosSESAB.DAO;

namespace CertificadosSESAB.BO
{
	/// <summary>
	/// Regras de negócio para gerenciamento da classe <see cref='UnidadeBO'/>
	/// 
	/// </summary>
	public class UnidadeBO : MarshalByRefObject, CertificadosSESAB.BO.IUnidadeBO
	{
		/// <summary>
		/// Define o objeto de controle de usuario.
		/// </summary>
		protected IUsuarioBO usuarioBO;
		/// <summary>
		/// Define o objeto de acesso a dados.
		/// </summary>
		protected IUnidadeDAO unidadeDAO;
	
		/// <summary>
		/// Inicializa uma instância da classe <see cref="UnidadeBO"/>.
		/// </summary>
		public UnidadeBO(IUsuarioBO usuarioBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
			unidadeDAO = daoAccess.UnidadeDAO();
			this.usuarioBO = usuarioBO;
        }
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="UnidadeBO"/> is reclaimed by garbage collection.
		/// </summary>
		~UnidadeBO()
		{
			Dispose();
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			unidadeDAO.Dispose();
			usuarioBO.Dispose();
		}
        public IList<Unidade> ListarAtivos()
        {
            return unidadeDAO.ListarAtivos();
        }
        /// <summary>
        /// Transforma um lista em um DataTable.
        /// </summary>
        /// <param name="lst">A lista.</param>
        /// <returns>O DataTable.</returns>
        public DataTable ToDataTable(IList<CertificadosSESAB.OR.Unidade> lst)
		{
			return unidadeDAO.ToDataTable(lst);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CertificadosSESAB.OR.Unidade SelecionarPor(string propertyName, object value)
		{
			return unidadeDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CertificadosSESAB.OR.Unidade SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
		{
			return unidadeDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		public CertificadosSESAB.OR.Unidade SelecionarPor(string[] propertyName, object[] value)
		{
			return unidadeDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		public CertificadosSESAB.OR.Unidade SelecionarPorId(object id)
		{
			return unidadeDAO.SelecionarPor("IdUnidade",Convert.ChangeType(id,typeof(long)));
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		public IList<CertificadosSESAB.OR.Unidade> Listar(string propertyOrder)
		{
			return unidadeDAO.Listar(propertyOrder);
		}
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="unidade">O(A) unidade.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		public CertificadosSESAB.OR.Unidade InserirAlterar(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.Unidade unidade, Regisoft.Operacao op)
		{
            unidade.Descricao = stringf.UmEspacoEntre(unidade.Descricao).Trim().ToUpper();
			unidadeDAO.ValidaNotNull(unidade);
			unidadeDAO.BeginTransaction();
			try 
			{
				if (op==Regisoft.Operacao.Alterar)
					unidade = unidadeDAO.CopiarParaPersistente(unidade.IdUnidade.Value,unidade);
				unidade = unidadeDAO.InserirAlterar(unidade,op);
				unidadeDAO.CommitTransaction();				
			}			
			catch
			{
				unidadeDAO.RollbackTransaction();
				throw;
			}				
			return unidade;
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="unidade">O(A) unidade.</param>
		public void Excluir(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.Unidade unidade)
		{
			unidadeDAO.BeginTransaction();
			try 
			{
				unidadeDAO.Excluir(unidade);
				unidadeDAO.CommitTransaction();				
			}			
			catch
			{
				unidadeDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Registro em uso.");
			}
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="lst">A lista.</param>
		public void Excluir(CertificadosSESAB.OR.Usuario u, IList<CertificadosSESAB.OR.Unidade> lst)
		{
			unidadeDAO.BeginTransaction();
			try 
			{
				foreach (CertificadosSESAB.OR.Unidade unidade in lst)
				{
					unidadeDAO.Excluir(unidade);
				}
				unidadeDAO.CommitTransaction();				
			}			
			catch
			{
				unidadeDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
			}
		}			
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Unidade> ListarPor(string dado)
		{
			return unidadeDAO.ListarPor(dado);
		}
	}
}
