
using System;
using System.Collections.Generic;
using System.Text;
using CertificadosSESAB.OR;
using CertificadosSESAB.BO;

namespace CertificadosSESAB
{
	/// <summary>
	/// Classe que gerencia o acesso aos BO's.
	/// Gerado por RSClass - Gerador de Classes.
	/// </summary>
	public class BOAccess
	{
		/// <summary>
		/// Inicializa o componente de acesso aos BO's. O acesso é feito sem a utilização de servidor de aplicação.
		/// </summary>
        protected static IBOFactory boFactory = new BOFactory();
		/// <summary>
		/// Esta classe não pode ser instanciada.
		/// </summary>
        private BOAccess() {}
		
        #region BOAccess Members		

		/// <summary>
		/// Lê o componente de acesso aos BO's.
		/// </summary>
		/// <returns>O BOFactory.</returns>
        public static IBOFactory getBOFactory()
        {
            return boFactory;            
        }
		
        #endregion
		
    }
}
