using System.Collections.Generic;
using System.Data;

namespace Ezzy.DatabaseLayer
{
    public interface IApplicationDBContext
    {
        List<T> LoadData<T, U>(string storedProcedure, U parameters);
        List<T> LoadDataOutParam<T, U, V>(string storedProcedure, U parameters, out V returnVar, DbType dbType, string returnVarName);
        int SaveData<T>(string storedProcedure, T parameters);
        int SaveMultipleData<T>(string storedProcedure, List<T> parameters);
    }
}