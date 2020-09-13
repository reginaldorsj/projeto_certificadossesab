
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
    /// Regras de negócio para gerenciamento da classe <see cref='EventoBO'/>
    /// 
    /// </summary>
    public class EventoBO : MarshalByRefObject, CertificadosSESAB.BO.IEventoBO
    {
        /// <summary>
        /// Define o objeto de controle de usuario.
        /// </summary>
        protected IUsuarioBO usuarioBO;
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected IEventoDAO eventoDAO;

        /// <summary>
        /// Inicializa uma instância da classe <see cref="EventoBO"/>.
        /// </summary>
        public EventoBO(IUsuarioBO usuarioBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
            eventoDAO = daoAccess.EventoDAO();
            this.usuarioBO = usuarioBO;
        }
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="EventoBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~EventoBO()
        {
            Dispose();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            eventoDAO.Dispose();
            usuarioBO.Dispose();
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="unidade">O(A) unidade.</param>
        /// <returns>A lista.</returns>
        public IList<CertificadosSESAB.OR.Evento> ListarPorUnidade(Unidade unidade)
        {
            return eventoDAO.ListarPorUnidade(unidade);
        }
        /// <summary>
        /// Transforma um lista em um DataTable.
        /// </summary>
        /// <param name="lst">A lista.</param>
        /// <returns>O DataTable.</returns>
        public DataTable ToDataTable(IList<CertificadosSESAB.OR.Evento> lst)
        {
            return eventoDAO.ToDataTable(lst);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
        /// <param name="value">O valor procurado na propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CertificadosSESAB.OR.Evento SelecionarPor(string propertyName, object value)
        {
            return eventoDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
        /// <param name="value1">O valor procurado na primeira propriedade.</param>
        /// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
        /// <param name="value2">TO valor procurado na segunda propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CertificadosSESAB.OR.Evento SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
        {
            return eventoDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
        /// <param name="value">O array de valores procurados nas propriedades.</param>
        /// <returns>O objeto selecionado.</returns>
        public CertificadosSESAB.OR.Evento SelecionarPor(string[] propertyName, object[] value)
        {
            return eventoDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="id">O ID do objeto.</param>
        /// <returns>O objeto selecionado.</returns>
        public CertificadosSESAB.OR.Evento SelecionarPorId(object id)
        {
            return eventoDAO.SelecionarPor("IdEvento", Convert.ChangeType(id, typeof(long)));
        }
        /// <summary>
        /// Listar objetos por uma propriedade específica.
        /// </summary>
        /// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
        /// <returns>A lista ordenada.</returns>
        public IList<CertificadosSESAB.OR.Evento> Listar(string propertyOrder)
        {
            return eventoDAO.Listar(propertyOrder);
        }
        /// <summary>
        /// Insere ou altera um objeto no banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="evento">O(A) evento.</param>
        /// <param name="op">A operação.</param>
        /// <returns>O objeto após a persistência.</returns>
        public CertificadosSESAB.OR.Evento InserirAlterar(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.Evento evento, Regisoft.Operacao op)
        {
            evento.IdUnidade = u.IdUnidade;
            evento.ArquivoCertificado = evento.ArquivoCertificado.Replace(" ", "_");
            eventoDAO.ValidaNotNull(evento);
            Evento _ix_evento = eventoDAO.SelecionarPor(new string[] { "IdUnidade", "Nome" }, new object[] { evento.IdUnidade, evento.Nome });
            if ((op == Operacao.Incluir && _ix_evento != null) || (op == Operacao.Alterar && _ix_evento != null && _ix_evento.IdEvento != evento.IdEvento))
                throw new ExceptionRS("Evento já cadastrado na unidade.");

            Evento _ix_evento2 = eventoDAO.SelecionarPor("ArquivoCertificado", evento.ArquivoCertificado);
            if ((op == Operacao.Incluir && _ix_evento2 != null) || (op == Operacao.Alterar && _ix_evento2 != null && _ix_evento2.IdEvento != evento.IdEvento))
                throw new ExceptionRS("Já existe arquivo de certificado cadastrado no sistema com este nome.");

            eventoDAO.BeginTransaction();
            try
            {
                if (op == Regisoft.Operacao.Alterar)
                    evento = eventoDAO.CopiarParaPersistente(evento.IdEvento.Value, evento);
                evento = eventoDAO.InserirAlterar(evento, op);
                eventoDAO.CommitTransaction();
            }
            catch
            {
                eventoDAO.RollbackTransaction();
                throw;
            }
            return evento;
        }
        /// <summary>
        /// Exclui o objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="evento">O(A) evento.</param>
        public void Excluir(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.Evento evento)
        {
            eventoDAO.BeginTransaction();
            try
            {
                eventoDAO.Excluir(evento);
                eventoDAO.CommitTransaction();
            }
            catch
            {
                eventoDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Registro em uso.");
            }
        }
        /// <summary>
        /// Exclui uma lista de objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="lst">A lista.</param>
        public void Excluir(CertificadosSESAB.OR.Usuario u, IList<CertificadosSESAB.OR.Evento> lst)
        {
            eventoDAO.BeginTransaction();
            try
            {
                foreach (CertificadosSESAB.OR.Evento evento in lst)
                {
                    eventoDAO.Excluir(evento);
                }
                eventoDAO.CommitTransaction();
            }
            catch
            {
                eventoDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
            }
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="dado"> O dado para pesquisa.</param>
        /// <returns>A lista.</returns>
        public IList<Evento> ListarPor(string dado)
        {
            return eventoDAO.ListarPor(dado);
        }
    }
}
