using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

 public bool InsertUpdateData(SqlCommand cmd)
        {
            bool retval = false;

            using (SqlConnection con = new SqlConnection(strConn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                SqlTransaction transaction;

                con.Open();
                transaction = con.BeginTransaction();

                try
                {
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    retval = true;
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    transaction.Rollback();
                    retval = false;
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    SqlConnection.ClearPool(con);
                }
            }

            return retval;
        }
		
		public int InsertData(SqlCommand cmd)
        {
            int retval = 0;

            using (SqlConnection con = new SqlConnection(strConn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.CommandText += " SET @currentID = SCOPE_IDENTITY()";

                SqlParameter currentID = new SqlParameter("@currentID", SqlDbType.Int);
                currentID.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(currentID);

                SqlTransaction transaction;

                con.Open();
                transaction = con.BeginTransaction();


                try
                {
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    retval = (int)currentID.Value;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Fehler: " + ex.Message);
                    transaction.Rollback();
                    retval = 0;
                }
                finally
                {
                    cmd.Dispose();
                    SqlConnection.ClearPool(con);
                }
            }

            return retval;
        }
		
 		public bool CallProcedure(SqlCommand cmd)
        {
            bool retval = false;

            using (SqlConnection con = new SqlConnection(strConn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    retval = true;
                }
                catch
                {
                    retval = false;
                }
                finally
                {
                    cmd.Dispose();
                    SqlConnection.ClearPool(con);
                }
            }

            return retval;
        }	
		
        public DataTable GetData(SqlCommand cmd)
        {
            DataTable dt;

            using (SqlConnection con = new SqlConnection(strConn))
            {
                dt = new DataTable();

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 600;

                    try
                    {
                        con.Open();
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);   
                    }
                    catch
                    {
#if DEBUG
                        throw;
#else
                        //System.Diagnostics.Debug.WriteLine("Fehler: " + ex.Message);
                        return null;
#endif
                    }
                    finally
                    {
                        cmd.Dispose();
                        SqlConnection.ClearPool(con);
                    }
                }

            }

            return dt != null ? dt : null;
        }					
		