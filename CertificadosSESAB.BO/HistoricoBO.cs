
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
	/// Regras de negócio para gerenciamento da classe <see cref='HistoricoBO'/>
	/// 
	/// </summary>
	public class HistoricoBO : MarshalByRefObject, CertificadosSESAB.BO.IHistoricoBO
	{
		/// <summary>
		/// Define o objeto de controle de usuario.
		/// </summary>
		protected IUsuarioBO usuarioBO;
		/// <summary>
		/// Define o objeto de acesso a dados.
		/// </summary>
		protected IHistoricoDAO historicoDAO;
	
		/// <summary>
		/// Inicializa uma instância da classe <see cref="HistoricoBO"/>.
		/// </summary>
		public HistoricoBO(IUsuarioBO usuarioBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
			historicoDAO = daoAccess.HistoricoDAO();
			this.usuarioBO = usuarioBO;
        }
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="HistoricoBO"/> is reclaimed by garbage collection.
		/// </summary>
		~HistoricoBO()
		{
			Dispose();
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			historicoDAO.Dispose();
			usuarioBO.Dispose();
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="eventoparticipante">O(A) eventoparticipante.</param>
		/// <returns>A lista.</returns>
		public IList<CertificadosSESAB.OR.Historico> ListarPorEventoParticipante(EventoParticipante eventoparticipante)
		{
			return historicoDAO.ListarPorEventoParticipante(eventoparticipante);
		}
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		public DataTable ToDataTable(IList<CertificadosSESAB.OR.Historico> lst)
		{
			return historicoDAO.ToDataTable(lst);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CertificadosSESAB.OR.Historico SelecionarPor(string propertyName, object value)
		{
			return historicoDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CertificadosSESAB.OR.Historico SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
		{
			return historicoDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		public CertificadosSESAB.OR.Historico SelecionarPor(string[] propertyName, object[] value)
		{
			return historicoDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		public CertificadosSESAB.OR.Historico SelecionarPorId(object id)
		{
			return historicoDAO.SelecionarPor("IdHistorico",Convert.ChangeType(id,typeof(long)));
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		public IList<CertificadosSESAB.OR.Historico> Listar(string propertyOrder)
		{
			return historicoDAO.Listar(propertyOrder);
		}
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="historico">O(A) historico.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		public CertificadosSESAB.OR.Historico InserirAlterar(CertificadosSESAB.OR.Historico historico, Regisoft.Operacao op)
		{
			historicoDAO.ValidaNotNull(historico);
			historicoDAO.BeginTransaction();
			try 
			{
				if (op==Regisoft.Operacao.Alterar)
					historico = historicoDAO.CopiarParaPersistente(historico.IdHistorico.Value,historico);
				historico = historicoDAO.InserirAlterar(historico,op);
				historicoDAO.CommitTransaction();				
			}			
			catch
			{
				historicoDAO.RollbackTransaction();
				throw;
			}				
			return historico;
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="historico">O(A) historico.</param>
		public void Excluir(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.Historico historico)
		{
			historicoDAO.BeginTransaction();
			try 
			{
				historicoDAO.Excluir(historico);
				historicoDAO.CommitTransaction();				
			}			
			catch
			{
				historicoDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Registro em uso.");
			}
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="lst">A lista.</param>
		public void Excluir(CertificadosSESAB.OR.Usuario u, IList<CertificadosSESAB.OR.Historico> lst)
		{
			historicoDAO.BeginTransaction();
			try 
			{
				foreach (CertificadosSESAB.OR.Historico historico in lst)
				{
					historicoDAO.Excluir(historico);
				}
				historicoDAO.CommitTransaction();				
			}			
			catch
			{
				historicoDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
			}
		}			
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Historico> ListarPor(string dado)
		{
			return historicoDAO.ListarPor(dado);
		}
	}
}
