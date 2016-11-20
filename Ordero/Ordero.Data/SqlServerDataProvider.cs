//using Ordero.Core.Data;
//using Ordero.Data.Initializers;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Ordero.Data
//{
//    public class SqlServerDataProvider : IDataProvider
//    {
//        #region Methods

//        /// <summary>
//        /// Set database initializer
//        /// </summary>
//        public virtual void SetDatabaseInitializer()
//        {
//            var initializer = new CreateTablesIfNotExist<OrderoEntities>();
//            Database.SetInitializer(initializer);
//        }
//        #endregion Methods

//    }
//}
