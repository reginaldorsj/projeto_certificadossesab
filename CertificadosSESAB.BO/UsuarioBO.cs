
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
    /// Regras de negócio para gerenciamento da classe <see cref='UsuarioBO'/>
    /// 
    /// </summary>
    public class UsuarioBO : MarshalByRefObject, CertificadosSESAB.BO.IUsuarioBO
    {
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected IUsuarioDAO usuarioDAO;

        /// <summary>
        /// Inicializa uma instância da classe <see cref="UsuarioBO"/>.
        /// </summary>
        public UsuarioBO()
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
            usuarioDAO = daoAccess.UsuarioDAO();
        }
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="UsuarioBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~UsuarioBO()
        {
            Dispose();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            usuarioDAO.Dispose();
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="unidade">O(A) unidade.</param>
        /// <returns>A lista.</returns>
        public IList<CertificadosSESAB.OR.Usuario> ListarPorUnidade(Unidade unidade)
        {
            return usuarioDAO.ListarPorUnidade(unidade);
        }
        /// <summary>
        /// Transforma um lista em um DataTable.
        /// </summary>
        /// <param name="lst">A lista.</param>
        /// <returns>O DataTable.</returns>
        public DataTable ToDataTable(IList<CertificadosSESAB.OR.Usuario> lst)
        {
            return usuarioDAO.ToDataTable(lst);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
        /// <param name="value">O valor procurado na propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CertificadosSESAB.OR.Usuario SelecionarPor(string propertyName, object value)
        {
            return usuarioDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
        /// <param name="value1">O valor procurado na primeira propriedade.</param>
        /// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
        /// <param name="value2">TO valor procurado na segunda propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CertificadosSESAB.OR.Usuario SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
        {
            return usuarioDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
        /// <param name="value">O array de valores procurados nas propriedades.</param>
        /// <returns>O objeto selecionado.</returns>
        public CertificadosSESAB.OR.Usuario SelecionarPor(string[] propertyName, object[] value)
        {
            return usuarioDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="id">O ID do objeto.</param>
        /// <returns>O objeto selecionado.</returns>
        public CertificadosSESAB.OR.Usuario SelecionarPorId(object id)
        {
            return usuarioDAO.SelecionarPor("IdUsuario", Convert.ChangeType(id, typeof(long)));
        }
        /// <summary>
        /// Listar objetos por uma propriedade específica.
        /// </summary>
        /// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
        /// <returns>A lista ordenada.</returns>
        public IList<CertificadosSESAB.OR.Usuario> Listar(string propertyOrder)
        {
            return usuarioDAO.Listar(propertyOrder);
        }
        /// <summary>
        /// Insere ou altera um objeto no banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="usuario">O(A) usuario.</param>
        /// <param name="op">A operação.</param>
        /// <returns>O objeto após a persistência.</returns>
        public CertificadosSESAB.OR.Usuario InserirAlterar(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.Usuario usuario, Regisoft.Operacao op)
        {
            usuario.IdUnidade = u.IdUnidade;
            usuario.Nome = stringf.UmEspacoEntre(stringf.SemAcentos(usuario.Nome)).Trim().ToUpper();
            usuario.EMail = usuario.EMail.ToLower().Trim();
            usuarioDAO.ValidaNotNull(usuario);
            if (!stringf.ValidaEmail(usuario.EMail))
                throw new ExceptionRS("Email inválido.");

            if (usuario.Login != usuario.Login.ToLower())
                throw new ExceptionRS("Informe o login em letras minúsculas");

            Usuario _ix_usuario_login = usuarioDAO.SelecionarPor(new string[] { "Login" }, new object[] { usuario.Login });
            if ((op == Operacao.Incluir && _ix_usuario_login != null) || (op == Operacao.Alterar && _ix_usuario_login != null && _ix_usuario_login.IdUsuario != usuario.IdUsuario))
                throw new ExceptionRS("Login já cadastrado.");

            usuarioDAO.BeginTransaction();
            try
            {
                if (op == Regisoft.Operacao.Alterar)
                    usuario = usuarioDAO.CopiarParaPersistente(usuario.IdUsuario.Value, usuario);
                usuario = usuarioDAO.InserirAlterar(usuario, op);
                usuarioDAO.CommitTransaction();
            }
            catch
            {
                usuarioDAO.RollbackTransaction();
                throw;
            }
            return usuario;
        }
        /// <summary>
        /// Exclui o objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="usuario">O(A) usuario.</param>
        public void Excluir(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.Usuario usuario)
        {
            if (u.IdUsuario == usuario.IdUsuario)
                throw new ExceptionRS("Você não pode excluir seu próprio usuário.");

            usuarioDAO.BeginTransaction();
            try
            {
                usuarioDAO.Excluir(usuario);
                usuarioDAO.CommitTransaction();
            }
            catch
            {
                usuarioDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Registro em uso.");
            }
        }
        /// <summary>
        /// Exclui uma lista de objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="lst">A lista.</param>
        public void Excluir(CertificadosSESAB.OR.Usuario u, IList<CertificadosSESAB.OR.Usuario> lst)
        {
            usuarioDAO.BeginTransaction();
            try
            {
                foreach (CertificadosSESAB.OR.Usuario usuario in lst)
                {
                    usuarioDAO.Excluir(usuario);
                }
                usuarioDAO.CommitTransaction();
            }
            catch
            {
                usuarioDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
            }
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="dado"> O dado para pesquisa.</param>
        /// <returns>A lista.</returns>
        public IList<Usuario> ListarPor(string dado)
        {
            return usuarioDAO.ListarPor(dado);
        }
        public Usuario AlterarSenha(Usuario usuario, string senha)
        {
            /*
            if (usuario.Login == "sa" || usuario.Login.StartsWith("sa@"))
                usuario.Senha = stringf.Encrypt(senha, "Regisoft");
            else
                usuario.Senha = senha;
            */
            usuario.Senha = senha;
            usuarioDAO.BeginTransaction();
            try
            {
                usuarioDAO.InserirAlterar(usuario, Regisoft.Operacao.Alterar);
                usuarioDAO.CommitTransaction();
            }
            catch
            {
                usuarioDAO.RollbackTransaction();
                throw;
            }
            return usuario;
        }
    }
}
