using Dapper;
using pj3_api.Model;

namespace pj3_api.Database
{
    public class MSSQLQueryDataSource : MSSQLBaseDataSource
    {
        public MSSQLQueryDataSource(MSSQLSettings mssqlSettings) : base(mssqlSettings)
        {

        }


        /// <summary>
        /// SQL Query Name
        /// </summary>
        protected string SqlName { get; set; }

        /// <summary>
        /// Lấy nội dung Sql Content
        /// </summary>
        protected virtual string SqlContent { get; }

        public async Task<IEnumerable<T>> Select<T>(string pSqlContent, MSSQLDynamicParameters pParams)
        {
            try
            {

                using (var connection = CreateConnection())
                {
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        var result = await connection.QueryAsync<T>(pSqlContent, pParams);
                        return result;
                    }
                    finally
                    {
                        connection.Dispose();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlName = string.Empty;
            }
        }
        /// <summary>
        /// Thực thi tương tác csdl
        /// </summary>
        /// <param name="pSqlContent"></param>
        /// <param name="pParams"></param>
        /// <param name="pCancellationToken"></param>

        /// <returns></returns>
        public async Task<T> First<T>(string pSqlContent, MSSQLDynamicParameters pParams)
        {
            try
            {

                using (var connection = CreateConnection())
                {
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        var result = await connection.QueryFirstOrDefaultAsync<T>(pSqlContent, pParams);
                        return result;
                    }
                    finally
                    {
                        connection.Dispose();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // tránh việc lưu lại thông tin sql
                SqlName = string.Empty;
            }
        }

        /// <summary>
        /// Thực thi tương tác csdl
        /// </summary>
        /// <param name="pSqlContent"></param>
        /// <param name="pParams"></param>
        /// <param name="pCancellationToken"></param>
        /// <returns></returns>

        public async Task<int> Insert(string pSqlContent, MSSQLDynamicParameters pParams)
        {
            try
            {

                using (var connection = CreateConnection())
                {
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        var result = await connection.ExecuteAsync(pSqlContent, pParams);
                        return result;
                    }
                    finally
                    {
                        connection.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // tránh việc lưu lại thông tin sql
                SqlName = string.Empty;
            }
        }

        public async Task<int> Delete(string pSqlContent, MSSQLDynamicParameters pParams)
        {
            try
            {

                using (var connection = CreateConnection())
                {
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        var result = await connection.ExecuteAsync(pSqlContent, pParams);
                        return result;
                    }
                    finally
                    {
                        connection.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // tránh việc lưu lại thông tin sql
                SqlName = string.Empty;
            }
        }

        public async Task<int> Update(string pSqlContent, MSSQLDynamicParameters pParams)
        {
            try
            {

                using (var connection = CreateConnection())
                {
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        var result = await connection.ExecuteAsync(pSqlContent, pParams);
                        return result;
                    }
                    finally
                    {
                        connection.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // tránh việc lưu lại thông tin sql
                SqlName = string.Empty;
            }
        }

    }
}
