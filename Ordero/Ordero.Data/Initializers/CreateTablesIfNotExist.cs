//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Transactions;

//namespace Ordero.Data.Initializers
//{
//    public class CreateTablesIfNotExist<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
//    {
//        /// <summary>
//        /// Ctor
//        /// </summary>
//        public CreateTablesIfNotExist()
//        {
//        }

//        public void InitializeDatabase(TContext context)
//        {
//            bool dbExists;
//            using (new TransactionScope(TransactionScopeOption.Suppress))
//            {
//                dbExists = context.Database.Exists();
//            }
//            if (dbExists)
//            {
//                bool createTables;

//                //check whether tables are already created
//                int numberOfTables = 0;
//                foreach (var t1 in context.Database.SqlQuery<int>("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE table_type = 'BASE TABLE' "))
//                    numberOfTables = t1;

//                createTables = numberOfTables == 0;

//                if (createTables)
//                {
//                    //create all tables
//                    var dbCreationScript = ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();
//                    context.Database.ExecuteSqlCommand(dbCreationScript);

//                    //Seed(context);
//                    context.SaveChanges();


//                }
//            }
//            else
//            {
//                throw new ApplicationException("No database instance");
//            }
//        }
//    }
//}

