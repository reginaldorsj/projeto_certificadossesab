using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using CertificadosSESAB.OR;
using System.IO;
using System.Net.Http.Headers;
using System.Web;

namespace CertificadosSESAB.API
{
    /// <summary>
    /// Controller da classe <see cref='EventoController'/>
    /// Gerado por RSClass - Gerador de Classes
    /// </summary>
    [Authorize]
    public class EventoController : ApiController
    {
        [HttpPost]
        [Route("evento/certificado")]
        public HttpResponseMessage UploadCertificado()
        {
            var context = System.Web.HttpContext.Current;
            if (context.Request.Files.Count == 0)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            var postedFile = context.Request.Files.Get(0);
            string filename = postedFile.FileName.Replace(" ", "_");
            var filePath = context.Server.MapPath("~/Documentos/" + filename);
            postedFile.SaveAs(filePath);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="id">O ID do objeto.</param>
        /// <returns>O objeto selecionado.</returns>
        [HttpGet]
        [Route("evento/selecionarporid/{id}")]
        public CertificadosSESAB.OR.Evento SelecionarPorId(long id)
        {
            return BOAccess.getBOFactory().EventoBO().SelecionarPorId(id);
        }
        /// <summary>
        /// Listar objetos por uma propriedade específica.
        /// </summary>
        /// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
        /// <returns>A lista ordenada.</returns>
        [HttpGet]
        [Route("evento/listar/{propertyOrder}")]
        public IList<CertificadosSESAB.OR.Evento> Listar(string propertyOrder)
        {
            return BOAccess.getBOFactory().EventoBO().Listar(propertyOrder);
        }
        /// <summary>
        /// Inserir um objeto no banco de dados.
        /// </summary>
        /// <param name="evento">O(A) evento.</param>
        /// <returns>O objeto após a persistência.</returns>
        [HttpPost]
        [Route("evento/inserir")]
        public CertificadosSESAB.OR.Evento Inserir(CertificadosSESAB.OR.Evento evento)
        {
            CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            return BOAccess.getBOFactory().EventoBO().InserirAlterar(u, evento, Regisoft.Operacao.Incluir);
        }
        /// <summary>
        /// Altera um objeto no banco de dados.
        /// </summary>
        /// <param name="evento">O(A) evento.</param>
        /// <returns>O objeto após a persistência.</returns>
        [HttpPut]
        [Route("evento/alterar")]
        public CertificadosSESAB.OR.Evento Alterar(CertificadosSESAB.OR.Evento evento)
        {
            CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            return BOAccess.getBOFactory().EventoBO().InserirAlterar(u, evento, Regisoft.Operacao.Alterar);
        }
        /// <summary>
        /// Exclui o objeto do banco de dados.
        /// </summary>
        /// <param name="evento">O(A) evento.</param>
        [HttpDelete]
        [Route("evento/excluir/{id}")]
        public HttpResponseMessage Excluir(long id)
        {
            CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            CertificadosSESAB.OR.Evento evento = BOAccess.getBOFactory().EventoBO().SelecionarPorId(id);
            BOAccess.getBOFactory().EventoBO().Excluir(u, evento);
            var context = System.Web.HttpContext.Current;
            var filePath = context.Server.MapPath("~/Documentos/" + evento.ArquivoCertificado);
            if (File.Exists(filePath))
                File.Delete(filePath);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        /// <summary>
        /// Exclui uma lista de objeto do banco de dados.
        /// </summary>
        /// <param name="lst">A lista.</param>
        [HttpDelete]
        [Route("evento/excluirlista")]
        public void Excluir(IList<CertificadosSESAB.OR.Evento> lst)
        {
            CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            BOAccess.getBOFactory().EventoBO().Excluir(u, lst);
        }
    }
}
