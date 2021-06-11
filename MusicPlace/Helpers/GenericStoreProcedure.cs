using FastMember;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.Helpers
{
    public static class GenericStoreProcedure
    {
        public static async Task<List<T>> GetAll<T>(string StoreProcedure, string conn) where T : class, new()
        {
            var response = new List<T>();
            try
            {
                using (SqlConnection sql = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand(StoreProcedure, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        await sql.OpenAsync();

                        using (var lector = await cmd.ExecuteReaderAsync())
                        {

                            while (await lector.ReadAsync())
                            {
                                var newObjeto = new T();
                                MapDataToObject(lector, newObjeto);
                                response.Add(newObjeto);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response = null;
            }
            return response;
        }

        public static async Task<List<T>> GetAllByParameter<T>(string StoreProcedure, string _conex, SqlParameter[] parametros) where T : class, new()
        {
            var respose = new List<T>();
            try
            {
                using (SqlConnection sql = new SqlConnection(_conex))
                {
                    using (SqlCommand cmd = new SqlCommand(StoreProcedure, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        foreach (var item in parametros)
                        {
                            cmd.Parameters.Add(item);
                        }
                        await sql.OpenAsync();

                        using (var lector = await cmd.ExecuteReaderAsync())
                        {

                            while (await lector.ReadAsync())
                            {
                                var newObjeto = new T();
                                MapDataToObject(lector, newObjeto);
                                respose.Add(newObjeto);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return respose;
        }

        public static async Task<T> GetByParameters<T>(string StoreProcedure, string _conex, SqlParameter[] parametros) where T : class, new()
        {

            var respose = new T();
            try
            {
                using (SqlConnection sql = new SqlConnection(_conex))
                {
                    using (SqlCommand cmd = new SqlCommand(StoreProcedure, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        if (parametros != null)
                            foreach (var item in parametros)
                            {
                                cmd.Parameters.Add(item);
                            }
                        await sql.OpenAsync();

                        using (var lector = await cmd.ExecuteReaderAsync())
                        {

                            while (await lector.ReadAsync())
                            {
                                //var newObjeto = new T();
                                MapDataToObject(lector, respose);
                                // return respose;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return respose;

        }

        public static async Task<T> SendAndGetData<T>(string StoreProcedure, string _conex, SqlParameter[] parametros) where T : class, new()
        {
            var respose = new T();
            try
            {
                using (SqlConnection sql = new SqlConnection(_conex))
                {
                    using (SqlCommand cmd = new SqlCommand(StoreProcedure, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        foreach (var item in parametros)
                        {
                            cmd.Parameters.Add(item);
                        }
                        await sql.OpenAsync();

                        using (var lector = await cmd.ExecuteReaderAsync())
                        {

                            while (await lector.ReadAsync())
                            {
                                //var newObjeto = new T();
                                MapDataToObject(lector, respose);
                                // return respose;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                respose = new T();
            }

            return respose;


        }


        public static async Task<bool> ProcedureBoolean<T>(string storeProcvcedure, string _conex, SqlParameter[] parametros) where T : class, new()
        {
            var retorno = false;
            try
            {
                using (SqlConnection sql = new SqlConnection(_conex))
                {
                    using (SqlCommand cmd = new SqlCommand(storeProcvcedure, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        foreach (var item in parametros)
                        {
                            cmd.Parameters.Add(item);
                        }

                        await sql.OpenAsync();

                        await cmd.ExecuteNonQueryAsync();
                        retorno = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                retorno = false;
            }
            return retorno;

        }

        /// <summary>
        /// retorna un entero basado en los datos del store procedure
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeProcvcedure"></param>
        /// <param name="_conex"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>

        public static async Task<int> Procedureint<T>(string storeProcvcedure, string _conex, SqlParameter[] parametros) where T : class, new()
        {
            int retorno = 0;
            try
            {
                using (SqlConnection sql = new SqlConnection(_conex))
                {
                    using (SqlCommand cmd = new SqlCommand(storeProcvcedure, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        foreach (var item in parametros)
                        {
                            cmd.Parameters.Add(item);
                        }

                        await sql.OpenAsync();

                        retorno = await cmd.ExecuteNonQueryAsync();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                retorno = 0;
            }
            return retorno;

        }


        public static void MapDataToObject<T>(this SqlDataReader dataReader, T newObject)
        {
            if (newObject == null) throw new ArgumentNullException(nameof(newObject));

            // Fast Member Usage
            var objectMemberAccessor = TypeAccessor.Create(newObject.GetType());
            var propertiesHashSet =
                    objectMemberAccessor
                    .GetMembers()
                    .Select(mp => mp.Name)
                    .ToHashSet();

            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                if (propertiesHashSet.Contains(dataReader.GetName(i)))
                {
                    objectMemberAccessor[newObject, dataReader.GetName(i)]
                        = dataReader.IsDBNull(i) ? null : dataReader.GetValue(i);
                }
            }
        }

    }
}
