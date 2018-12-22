using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Data
{
    public class MySQLDataProvider : IEfDataProvider
    {
        /// <summary>
        /// Get connection factory
        /// </summary>
        /// <returns>Connection factory</returns>
        public virtual IDbConnectionFactory GetConnectionFactory()
        {
            return new MySqlConnectionFactory();
        }

        ///// <summary>
        ///// A value indicating whether this data provider supports stored procedures
        ///// </summary>
        public bool StoredProceduresSupported
        {
            get { return false; }       // TODO: much faster to use
        }

        ///// <summary>
        ///// Gets a support database parameter object (used by stored procedures)
        ///// </summary>
        ///// <returns>Parameter</returns>
        public DbParameter GetParameter()
        {
            return new MySqlParameter();
        }

        public string ProviderInvariantName
        {
            get { return "MySql.Data.MySqlClient"; }
        }
    }
}
