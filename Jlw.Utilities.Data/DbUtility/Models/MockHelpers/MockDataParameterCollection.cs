using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Jlw.Utilities.Data.DbUtility
{
    /// <inheritdoc />
    public class MockDataParameterCollection : DbParameterCollection
    {
        protected IList<DbParameter> Parameters = new List<DbParameter>();

        public override int Add(object value)
        {
            var parameter = value as DbParameter;
            
            int index = -1;
            if (!string.IsNullOrEmpty(parameter?.ParameterName))
                index = this.IndexOf(parameter.ParameterName);
            if (index == -1)
            {
                index = Parameters.Count;
                Parameters.Add(parameter);
            }
            SetParameter(index, parameter);
            return index;
        }

        public override void Clear() => Parameters.Clear();

        public override bool Contains(object value) => Parameters.Contains(value);

        public override int IndexOf(object value) => Parameters.IndexOf(value as DbParameter);

        public override void Insert(int index, object value) => Parameters.Insert(index, value as DbParameter);

        public override void Remove(object value) => Parameters.Remove(value as DbParameter);

        public override void RemoveAt(int index) => Parameters.RemoveAt(index);

        public override void RemoveAt(string parameterName) => Parameters.RemoveAt(IndexOf(parameterName));

        protected override void SetParameter(int index, DbParameter value) => Parameters[index] = value;

        protected override void SetParameter(string parameterName, DbParameter value) => Parameters[IndexOf(parameterName)] = value;

        public override int Count => Parameters.Count;
        public override object SyncRoot => (object) null;

        public override int IndexOf(string parameterName)
        {
            int count = Parameters.Count;
            for (int index = 0; index < count; ++index)
            {
                if (string.Compare(parameterName, Parameters[index].ParameterName, StringComparison.OrdinalIgnoreCase) == 0)
                    return index;
            }
            return -1;
        }

        public override bool Contains(string value) => this.IndexOf(value) != -1;

        public override void CopyTo(Array array, int index) => throw new NotImplementedException();

        public override IEnumerator GetEnumerator() => Parameters.GetEnumerator();

        protected override DbParameter GetParameter(int index) => Parameters.ElementAt(index);

        protected override DbParameter GetParameter(string parameterName) => Parameters.FirstOrDefault(o => o.ParameterName == parameterName);

        public override void AddRange(Array values)
        {
            int length = values.Length;
            for (int index = 0; index < length; ++index)
                this.Add((DbParameter)values.GetValue(index));
        }
    }
}