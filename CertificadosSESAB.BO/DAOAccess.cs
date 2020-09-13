
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Regisoft;
using Microsoft.Practices.Unity;
using CertificadosSESAB.DAO;

namespace CertificadosSESAB.BO
{
	/// <summary>
	/// Classe que gerencia o acesso aos DAO's.
	/// .
	/// </summary>
    public class DAOAccess    {
		/// <summary>
		/// Acesso ao objeto que cria os DAO's
		/// </summary>
        protected static IDAOFactory daoFactory = null;
		/// <summary>
		/// Inicializa uma instância de <see cref="DAOAccess"/>.
		/// </summary>
		private DAOAccess() { }
		/// <summary>
		/// Get the DAO factory./>.
		/// </summary>
		public static IDAOFactory GetDAOFactory() 
		{
			lock (typeof(DAOAccess))
			{
				if (daoFactory == null)
				{
					UnityContainer uc = new UnityContainer();
					uc.RegisterType<IDAOFactory, DAOFactory>();
					daoFactory = uc.Resolve<DAOFactory>();
				}
				return daoFactory;
			}
		}
	}
}
