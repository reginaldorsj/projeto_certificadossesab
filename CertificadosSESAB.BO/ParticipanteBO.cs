
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
    /// Regras de negócio para gerenciamento da classe <see cref='ParticipanteBO'/>
    /// 
    /// </summary>
    public class ParticipanteBO : MarshalByRefObject, CertificadosSESAB.BO.IParticipanteBO
    {
        public IEventoParticipanteDAO eventoParticipanteDAO;
        /// <summary>
        /// Define o objeto de controle de usuario.
        /// </summary>
        protected IUsuarioBO usuarioBO;
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected IParticipanteDAO participanteDAO;

        /// <summary>
        /// Inicializa uma instância da classe <see cref="ParticipanteBO"/>.
        /// </summary>
        public ParticipanteBO(IUsuarioBO usuarioBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
            participanteDAO = daoAccess.ParticipanteDAO();
            this.usuarioBO = usuarioBO;
            eventoParticipanteDAO = daoAccess.EventoParticipanteDAO();
        }
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="ParticipanteBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~ParticipanteBO()
        {
            Dispose();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            participanteDAO.Dispose();
            usuarioBO.Dispose();
            eventoParticipanteDAO.Dispose();
        }
        /// <summary>
        /// Transforma um lista em um DataTable.
        /// </summary>
        /// <param name="lst">A lista.</param>
        /// <returns>O DataTable.</returns>
        public DataTable ToDataTable(IList<CertificadosSESAB.OR.Participante> lst)
        {
            return participanteDAO.ToDataTable(lst);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
        /// <param name="value">O valor procurado na propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CertificadosSESAB.OR.Participante SelecionarPor(string propertyName, object value)
        {
            return participanteDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
        /// <param name="value1">O valor procurado na primeira propriedade.</param>
        /// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
        /// <param name="value2">TO valor procurado na segunda propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CertificadosSESAB.OR.Participante SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
        {
            return participanteDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
        /// <param name="value">O array de valores procurados nas propriedades.</param>
        /// <returns>O objeto selecionado.</returns>
        public CertificadosSESAB.OR.Participante SelecionarPor(string[] propertyName, object[] value)
        {
            return participanteDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="id">O ID do objeto.</param>
        /// <returns>O objeto selecionado.</returns>
        public CertificadosSESAB.OR.Participante SelecionarPorId(object id)
        {
            return participanteDAO.SelecionarPor("IdParticipante", Convert.ChangeType(id, typeof(long)));
        }
        /// <summary>
        /// Listar objetos por uma propriedade específica.
        /// </summary>
        /// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
        /// <returns>A lista ordenada.</returns>
        public IList<CertificadosSESAB.OR.Participante> Listar(string propertyOrder)
        {
            return participanteDAO.Listar(propertyOrder);
        }
        /// <summary>
        /// Insere ou altera um objeto no banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="participante">O(A) participante.</param>
        /// <param name="op">A operação.</param>
        /// <param name="evento">O evento.</param>
        /// <returns>O objeto após a persistência.</returns>
        public CertificadosSESAB.OR.Participante InserirAlterar(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.Participante participante, Regisoft.Operacao op, Evento evento)
        {
            participante.Nome = stringf.UmEspacoEntre(participante.Nome).Trim();
            if (participante.Email != null)
                participante.Email = participante.Email.ToLower();
            participanteDAO.ValidaNotNull(participante);
            if (!stringf.VCPF(participante.Cpf))
                throw new ExceptionRS("CPF inválido.");
            if (participante.Email != null && !stringf.ValidaEmail(participante.Email))
                throw new ExceptionRS("Email inválido.");
            Participante _ix_participante_cpf = participanteDAO.SelecionarPor(new string[] { "Cpf" }, new object[] { participante.Cpf });
            if (op == Operacao.Incluir && _ix_participante_cpf != null)
            {
                op = Operacao.Alterar;
                participante.IdParticipante = _ix_participante_cpf.IdParticipante;
            }
            else if (op == Operacao.Alterar && _ix_participante_cpf != null && _ix_participante_cpf.IdParticipante != participante.IdParticipante)
                throw new ExceptionRS("Já existe participante com este CPF.");

            participanteDAO.BeginTransaction();
            try
            {
                if (op == Regisoft.Operacao.Alterar)
                    participante = participanteDAO.CopiarParaPersistente(participante.IdParticipante.Value, participante);
                participante = participanteDAO.InserirAlterar(participante, op);

                EventoParticipante ep_tmp = eventoParticipanteDAO.SelecionarPor("IdEvento", evento, "IdParticipante", participante);
                if (ep_tmp == null)
                {
                    ep_tmp = new EventoParticipante()
                    {
                        IdEvento = evento,
                        IdParticipante = participante
                    };
                    eventoParticipanteDAO.Inserir(ep_tmp);
                }

                participanteDAO.CommitTransaction();
            }
            catch
            {
                participanteDAO.RollbackTransaction();
                throw;
            }
            return participante;
        }
        /// <summary>
        /// Exclui o objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="participante">O(A) participante.</param>
        public void Excluir(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.Participante participante, Evento evento)
        {
            participanteDAO.BeginTransaction();
            try
            {
                EventoParticipante ep_tmp = eventoParticipanteDAO.SelecionarPor("IdEvento", evento, "IdParticipante", participante);
                eventoParticipanteDAO.Excluir(ep_tmp);
                if (eventoParticipanteDAO.ListarPorParticipante(participante).Count == 0)
                    participanteDAO.Excluir(participante);
                participanteDAO.CommitTransaction();
            }
            catch
            {
                participanteDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Registro em uso.");
            }
        }
        /// <summary>
        /// Exclui uma lista de objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="lst">A lista.</param>
        public void Excluir(CertificadosSESAB.OR.Usuario u, IList<CertificadosSESAB.OR.Participante> lst, Evento evento)
        {
            participanteDAO.BeginTransaction();
            try
            {
                foreach (CertificadosSESAB.OR.Participante participante in lst)
                {
                    EventoParticipante ep_tmp = eventoParticipanteDAO.SelecionarPor("IdEvento", evento, "IdParticipante", participante);
                    eventoParticipanteDAO.Excluir(ep_tmp);
                    if (eventoParticipanteDAO.ListarPorParticipante(participante).Count == 0)
                        participanteDAO.Excluir(participante);
                }
                participanteDAO.CommitTransaction();
            }
            catch
            {
                participanteDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
            }
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="dado"> O dado para pesquisa.</param>
        /// <returns>A lista.</returns>
        public IList<Participante> ListarPor(string dado)
        {
            return participanteDAO.ListarPor(dado);
        }
    }
}
