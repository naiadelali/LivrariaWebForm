using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class DbCommands
{
    private static SqlConnection Connection = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=DbLivraria;Integrated Security=True");

    public static DataTable Consult(string sql)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(sql, Connection);

        try
        {
            Connection.Open();
            da.Fill(dt);
            da.Dispose();
            Connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }

        return dt;
    }

    public static DataTable Consult(string sql, List<SqlParameter> parameters)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(sql, Connection);

        if (parameters.Count > 0)
            foreach (SqlParameter p in parameters)
                da.SelectCommand.Parameters.Add(p);
        try
        {
            Connection.Open();
            da.Fill(dt);
            da.Dispose();
            Connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }

        return dt;
    }

    public static void Execute(string sql, List<SqlParameter> parameters)
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand(sql, Connection);

        if (parameters.Count > 0)
            foreach (SqlParameter p in parameters)
                cmd.Parameters.Add(p);
        try
        {
            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }

    }

    public static void Execute(string sql)
    {
        SqlCommand cmd = new SqlCommand(sql, Connection);

        try
        {
            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }

    }

    public static DataTable ExecuteProcedure(string sql)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(sql, Connection);

        try
        {
            Connection.Open();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);
            da.Dispose();
            Connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }

        return dt;

    }

    public static void ExecuteProcedure(string sql, List<SqlParameter> parametros)
    {
        try
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros.Count > 0)
                    foreach (SqlParameter p in parametros)
                        cmd.Parameters.Add(p);

                cmd.ExecuteNonQuery();
            }

            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }
    }

    public static bool TestConnection()
    {
        try
        {
            Connection.Open();
            Connection.Close();
        }
        catch (Exception)
        {
            return false;
        }
        finally
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }

        return true;
    }
}