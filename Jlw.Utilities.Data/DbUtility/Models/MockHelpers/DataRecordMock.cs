using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Jlw.Utilities.Data.DbUtility
{
    public class DataRecordMock : IDataRecord
    {
        protected IDictionary<string, object> _data = new Dictionary<string, object>();

        public int FieldCount => _data.Count;

        public object this[int i]
        {
            get
            {
                if (i < 0 || i > _data.Count)
                    throw new IndexOutOfRangeException($"Index was outside the bounds of the array: {i}");

                return _data.ElementAt(i);
            }
        }

        public object this[string name]
        {
            get
            {
                if (!_data.ContainsKey(name))
                    throw new IndexOutOfRangeException($"Unable to find a column with the name: {name}");

                return _data[name];
            }
            set => _data[name] = value;
        }
            
        public void Add(string name, object o)
        {
            _data.Add(name, o);
        }

        public bool GetBoolean(int i)
        {
            return DataUtility.ParseBool(this[i]);
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            return DataUtility.ParseDateTime(this[i]);
        }

        public decimal GetDecimal(int i)
        {
            return DataUtility.ParseDecimal(this[i]);
        }

        public double GetDouble(int i)
        {
            return DataUtility.ParseDouble(this[i]);
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            return DataUtility.ParseInt(this[i]);
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public string GetName(int i)
        {
            return _data.Keys.ToList()[i];
        }

        public int GetOrdinal(string name)
        {
            return _data.Keys.ToList().IndexOf(name);
        }

        public string GetString(int i)
        {
            return DataUtility.ParseString(this[i]);
        }

        public object GetValue(int i)
        {
            return this[i];
        }

        public int GetValues(object[] values)
        {
            int count = values.Length;
            int max = Math.Min(count, _data.Count);

            for(int i = 0; i<max; i++)
            {
                values[i] = this[i];
            }

            return max;
        }

        public bool IsDBNull(int i)
        {
            var o = this[i];
            return o == null || o is DBNull;
        }

    }
}
