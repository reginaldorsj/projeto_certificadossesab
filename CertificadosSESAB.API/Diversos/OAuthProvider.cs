using System;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Owin.Security.OAuth;
using CertificadosSESAB.OR;

namespace CertificadosSESAB.API
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        #region[GrantResourceOwnerCredentials]
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var userName = context.UserName;
                var password = context.Password;
                string idUnidade, id;
                if (userName == "XXXXXXX")
                {
                    if (password != "XXXXXXX")
                    {
                        context.SetError("invalid_grant", "Dados inválidos. Tente outra vez.");
                        return;
                    }
                    id = "0";
                    idUnidade = "0";
                }
                else
                {
                    CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPor("Login", userName);
                    if (u == null || u.Senha != password)
                    {
                        context.SetError("invalid_grant", "Dados inválidos. Tente outra vez.");
                        return;
                    }
                    else if ("01234567890".IndexOf(u.Senha) >= 0)
                    {
                        context.SetError("invalid_grant", "Esta senha precisa ser alterada.");
                        return;
                    }
                    id = u.IdUsuario.ToString();
                    idUnidade = u.IdUnidade.IdUnidade.ToString();
                }

                var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Sid, id),
                            new Claim(ClaimTypes.Name, userName),
                            new Claim(ClaimTypes.NameIdentifier, id)
                        };
                ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims,
                            Startup.OAuthOptions.AuthenticationType);

                var properties = CreateProperties(userName, idUnidade);
                var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                context.Validated(ticket);

            });
        }
        #endregion

        #region[ValidateClientAuthentication]
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }
        #endregion

        #region[TokenEndpoint]
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
        #endregion

        #region[CreateProperties]
        public static AuthenticationProperties CreateProperties(string userName, string idUnidade)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
                {
                    { "userName", userName },
                    { "idUnidade", idUnidade }
                };
            return new AuthenticationProperties(data);
        }
        #endregion


    }
}
