using Dapper;
using System;
using System.Data;

namespace Kongsli.LegacyNetFramework.Web.Dapper
{
    public class DapperUriTypeHandler : SqlMapper.TypeHandler<Uri>
    {
        public override void SetValue(IDbDataParameter parameter, Uri value)
            => parameter.Value = value.ToString();
        public override Uri Parse(object value) => new Uri((string)value);
    }
}