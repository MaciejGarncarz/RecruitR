using System.Data;

namespace RecruitR.Persistence.ConnectionFactory
{
    public interface IConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}