using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Transform;

namespace Crud.AssetManagement.Queries.Shared
{
    // Lightweight raw-SQL query builder over the request's NHibernate ISession
    // (SetParameter / AppendLineIf / SetConditionalParameter), matching the org's
    // NHibernate-backed QueryBuilder. Rows are mapped onto T by column alias.
    //
    // Note: parameters use NHibernate's ":Name" convention.
    public class QueryBuilder
    {
        private readonly StringBuilder _sql;
        private readonly Dictionary<string, object> _parameters = new Dictionary<string, object>();

        public QueryBuilder(string sql)
        {
            _sql = new StringBuilder(sql);
        }

        public string Sql => _sql.ToString();
        public IReadOnlyDictionary<string, object> Parameters => _parameters;

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
            _parameters[name] = value;
            return this;
        }

        // Only binds the parameter when a value is present, mirroring the
        // reference SetConditionalParameter behavior for optional filters.
        // NHibernate rejects parameters that are not in the SQL, so the matching
        // AppendLineIf condition must agree with this one.
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
                _parameters[name] = value;
            }

            return this;
        }

        public async Task<IList<T>> ExecuteListAsync<T>(ISession session)
        {
            return await CreateQuery<T>(session).ListAsync<T>();
        }

        public async Task<T> ExecuteSingleAsync<T>(ISession session)
        {
            return await CreateQuery<T>(session).UniqueResultAsync<T>();
        }

        private IQuery CreateQuery<T>(ISession session)
        {
            var query = session.CreateSQLQuery(Sql);

            foreach (var parameter in _parameters)
            {
                query.SetParameter(parameter.Key, parameter.Value);
            }

            return query.SetResultTransformer(Transformers.AliasToBean<T>());
        }
    }
}
