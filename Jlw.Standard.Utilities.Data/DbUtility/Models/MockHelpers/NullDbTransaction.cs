using System.Data;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class NullDbTransaction : IDbTransaction
    {
        public IDbConnection Connection { get; }
        public IsolationLevel IsolationLevel { get; }

        public NullDbTransaction(IDbConnection c, IsolationLevel il)
        {
            Connection = c;
            IsolationLevel = il;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Commit()
        {
            throw new System.NotImplementedException();
        }

        public void Rollback()
        {
            throw new System.NotImplementedException();
        }

    }
}