
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
	/// Regras de negócio para gerenciamento da classe <see cref='EventoParticipanteBO'/>
	/// 
	/// </summary>
	public class EventoParticipanteBO : MarshalByRefObject, CertificadosSESAB.BO.IEventoParticipanteBO
	{
		/// <summary>
		/// Define o objeto de controle de usuario.
		/// </summary>
		protected IUsuarioBO usuarioBO;
		/// <summary>
		/// Define o objeto de acesso a dados.
		/// </summary>
		protected IEventoParticipanteDAO eventoparticipanteDAO;
	
		/// <summary>
		/// Inicializa uma instância da classe <see cref="EventoParticipanteBO"/>.
		/// </summary>
		public EventoParticipanteBO(IUsuarioBO usuarioBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
			eventoparticipanteDAO = daoAccess.EventoParticipanteDAO();
			this.usuarioBO = usuarioBO;
        }
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="EventoParticipanteBO"/> is reclaimed by garbage collection.
		/// </summary>
		~EventoParticipanteBO()
		{
			Dispose();
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			eventoparticipanteDAO.Dispose();
			usuarioBO.Dispose();
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="participante">O(A) participante.</param>
		/// <returns>A lista.</returns>
		public IList<CertificadosSESAB.OR.EventoParticipante> ListarPorParticipante(Participante participante)
		{
			return eventoparticipanteDAO.ListarPorParticipante(participante);
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="evento">O(A) evento.</param>
		/// <returns>A lista.</returns>
		public IList<CertificadosSESAB.OR.EventoParticipante> ListarPorEvento(Evento evento)
		{
			return eventoparticipanteDAO.ListarPorEvento(evento);
		}
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		public DataTable ToDataTable(IList<CertificadosSESAB.OR.EventoParticipante> lst)
		{
			return eventoparticipanteDAO.ToDataTable(lst);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CertificadosSESAB.OR.EventoParticipante SelecionarPor(string propertyName, object value)
		{
			return eventoparticipanteDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CertificadosSESAB.OR.EventoParticipante SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
		{
			return eventoparticipanteDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		public CertificadosSESAB.OR.EventoParticipante SelecionarPor(string[] propertyName, object[] value)
		{
			return eventoparticipanteDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		public CertificadosSESAB.OR.EventoParticipante SelecionarPorId(object id)
		{
			return eventoparticipanteDAO.SelecionarPor("IdEventoParticipante",Convert.ChangeType(id,typeof(long)));
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		public IList<CertificadosSESAB.OR.EventoParticipante> Listar(string propertyOrder)
		{
			return eventoparticipanteDAO.Listar(propertyOrder);
		}
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="eventoparticipante">O(A) eventoparticipante.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		public CertificadosSESAB.OR.EventoParticipante InserirAlterar(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.EventoParticipante eventoparticipante, Regisoft.Operacao op)
		{
			eventoparticipanteDAO.ValidaNotNull(eventoparticipante);
			EventoParticipante _ix_evento_participante = eventoparticipanteDAO.SelecionarPor(new string[]{ "IdParticipante" , "IdEvento" }, new object[]{ eventoparticipante.IdParticipante , eventoparticipante.IdEvento });
			 if ((op == Operacao.Incluir && _ix_evento_participante != null) ||(op == Operacao.Alterar && _ix_evento_participante != null && _ix_evento_participante.IdEventoParticipante != eventoparticipante.IdEventoParticipante))
				throw new ExceptionRS("Violação do índice: IX_EVENTO_PARTICIPANTE");

			eventoparticipanteDAO.BeginTransaction();
			try 
			{
				if (op==Regisoft.Operacao.Alterar)
					eventoparticipante = eventoparticipanteDAO.CopiarParaPersistente(eventoparticipante.IdEventoParticipante.Value,eventoparticipante);
				eventoparticipante = eventoparticipanteDAO.InserirAlterar(eventoparticipante,op);
				eventoparticipanteDAO.CommitTransaction();				
			}			
			catch
			{
				eventoparticipanteDAO.RollbackTransaction();
				throw;
			}				
			return eventoparticipante;
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="eventoparticipante">O(A) eventoparticipante.</param>
		public void Excluir(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.EventoParticipante eventoparticipante)
		{
			eventoparticipanteDAO.BeginTransaction();
			try 
			{
				eventoparticipanteDAO.Excluir(eventoparticipante);
				eventoparticipanteDAO.CommitTransaction();				
			}			
			catch
			{
				eventoparticipanteDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Registro em uso.");
			}
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="lst">A lista.</param>
		public void Excluir(CertificadosSESAB.OR.Usuario u, IList<CertificadosSESAB.OR.EventoParticipante> lst)
		{
			eventoparticipanteDAO.BeginTransaction();
			try 
			{
				foreach (CertificadosSESAB.OR.EventoParticipante eventoparticipante in lst)
				{
					eventoparticipanteDAO.Excluir(eventoparticipante);
				}
				eventoparticipanteDAO.CommitTransaction();				
			}			
			catch
			{
				eventoparticipanteDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
			}
		}			
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<EventoParticipante> ListarPor(string dado)
		{
			return eventoparticipanteDAO.ListarPor(dado);
		}
	}
}
