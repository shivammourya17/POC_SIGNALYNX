using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Crud.AssetManagement.Infrastructure.Contracts;

namespace Crud.AssetManagement.Queries.Shared
{
    // Lightweight raw-SQL query builder over Dapper, playing the same role as
    // the org's NHibernate-backed QueryBuilder (SetParameter / AppendLineIf /
    // SetConditionalParameter), but executed via ADO.NET against
    // IDbConnectionFactory instead of an NHibernate session.
    //
    // Note: parameters use Dapper's "@Name" convention rather than the ":Name"
    // convention used by the NHibernate QueryBuilder in the reference example.
    public class QueryBuilder
    {
        private readonly StringBuilder _sql;
        private readonly DynamicParameters _parameters = new DynamicParameters();

        public QueryBuilder(string sql)
        {
            _sql = new StringBuilder(sql);
        }

        public string Sql => _sql.ToString();
        public DynamicParameters Parameters => _parameters;

        public QueryBuilder AppendLine(string sql)
        {
            _sql.AppendLine(sql);
            return this;
        }

        public QueryBuilder AppendLineIf(bool condition, string sql)
        {
            if (condition)
            {
                _sql.AppendLine(sql);
            }

            return this;
        }

        public QueryBuilder SetParameter(string name, object value)
        {
            _parameters.Add(name, value);
            return this;
        }

        // Only binds the parameter when a value is present, mirroring the
        // reference SetConditionalParameter behavior for optional filters.
        public QueryBuilder SetConditionalParameter(string name, object value)
        {
            var hasValue = value switch
            {
                null => false,
                string s => !string.IsNullOrEmpty(s),
                int i => i > 0,
                _ => true
            };

            if (hasValue)
            {
                _parameters.Add(name, value);
            }

            return this;
        }

        public async Task<IEnumerable<T>> ExecuteAsync<T>(IDbConnectionFactory connectionFactory)
        {
            using var connection = connectionFactory.CreateConnection();
            return await connection.QueryAsync<T>(Sql, Parameters);
        }

        public async Task<IList<T>> ExecuteListAsync<T>(IDbConnectionFactory connectionFactory)
        {
            var result = await ExecuteAsync<T>(connectionFactory);
            return result.ToList();
        }

        public async Task<T> ExecuteSingleAsync<T>(IDbConnectionFactory connectionFactory)
        {
            using var connection = connectionFactory.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(Sql, Parameters);
        }
    }
}
