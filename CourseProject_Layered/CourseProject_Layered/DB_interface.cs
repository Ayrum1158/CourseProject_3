using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using CourseProject_Layered;

namespace DBI//DataBaseInterface
{
    class DB_interface
    {
        private string ConnectionString;

        /// <summary>
        /// DBI constructor.
        /// </summary>
        /// <param name="DBCM">"InFolder" tries to pick file named "CPDatabase.mdf" in local folder. "OFD" opens a file dialog to choose database file malually.</param>
        public DB_interface(DB_ConstructorMode DBCM)
        {
            StringBuilder SB = new StringBuilder();
            string DB_path = "";
            switch (DBCM)
            {
                case DB_ConstructorMode.InFolder:
                    DB_path = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);
                    DB_path += @"DB\";
                    SB.AppendFormat(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = {0}; Integrated Security = True", DB_path + "CPDatabase.mdf");
                    ConnectionString = SB.ToString();
                    SqlConnection conn = new SqlConnection(ConnectionString);
                    try
                    {                        
                        conn.Open();
                        conn.Close();
                    }
                    catch(SqlException)
                    {
                        MessageBox.Show("No \"CPDatabase.mdf\" found in default directory.\nPlease, choose file manually.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto case DB_ConstructorMode.OFD;
                    }
                    finally
                    {
                        conn.Dispose();
                    }
                    return;
                    //break;
               case DB_ConstructorMode.OFD:
                    OpenFileDialog OFD = new OpenFileDialog();
                    OFD.Filter = "MS SQL Database|*.mdf";
                    var OFD_res = OFD.ShowDialog();
                    if (OFD_res == DialogResult.OK)
                    {
                        DB_path = OFD.FileName;
                    }
                    else
                        throw new InvalidDataException();//bad path
                    break;
            }
            SB.AppendFormat(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = {0}; Integrated Security = True", DB_path + "CPDatabase.mdf");
            ConnectionString = SB.ToString();
        }

        /// <summary>
        /// Method to get whole table data.
        /// </summary>
        /// <param name="Table">Table in database to select from.</param>
        /// <returns></returns>
        public object[] SelectAllFrom(string Table)
        {
            List<object> Values = new List<object>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM " + Table, conn);            

                conn.Open();
                using (SqlDataReader DR = cmdSelectAll.ExecuteReader())
                {
                    if (DR.HasRows)
                        while (DR.Read())
                        {
                            for (int i = 0; i < DR.FieldCount; i++)
                            {
                                Values.Add(DR.GetValue(i));
                            }
                        }
                }
                conn.Close();
            }
            return Values.ToArray();
        }

        /// <summary>
        /// Method to select rows using "WHERE" keyword.
        /// </summary>
        /// <param name="Table">Table to select from.</param>
        /// <param name="WhereParam">Column name to compare with parameter.</param>
        /// <param name="ParamValue">Value to compare.</param>
        /// <returns></returns>
        public object[] SelectRowWhere(string Table, string WhereParam, string ParamValue)
        {
            List<object> Values = new List<object>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmdSelectRowWhere = new SqlCommand();
                cmdSelectRowWhere.Connection = conn;
                StringBuilder SB = new StringBuilder();
                SB.AppendFormat("SELECT * FROM {0} WHERE {1} = {2}", Table, WhereParam, ParamValue);
                cmdSelectRowWhere.CommandText = SB.ToString();

                conn.Open();
                using (SqlDataReader DR = cmdSelectRowWhere.ExecuteReader())
                {
                    if (DR.HasRows)
                        while (DR.Read())
                        {
                            for (int i = 0; i < DR.FieldCount; i++)
                            {
                                Values.Add(DR.GetValue(i));
                            }
                        }
                }
                conn.Close();
            }
            return Values.ToArray();
        }

        /// <summary>
        /// Method to insert 1 row of data in table of database.
        /// </summary>
        /// <param name="Table">Table to insert data in.</param>
        /// <param name="ColumnNames">Names of columns.</param>
        /// <param name="ColumnValues">Values corresponding to the parameters.</param>
        public bool InsertInto(string Table, string[] ColumnNames, object[] ColumnValues)//whole new row
        {
            bool res = true;
            SqlConnection conn = new SqlConnection(ConnectionString);
            int N = ColumnNames.Length;
            SqlCommand cmdInsertIn = new SqlCommand();
            cmdInsertIn.Connection = conn;
            StringBuilder CommandSB = new StringBuilder();//for cmdInsertIn
            CommandSB.AppendFormat("INSERT INTO {0} VALUES(", Table);

            for (int i = 0; i < N; i++)
            {
                CommandSB.AppendFormat("@{0},",ColumnNames[i]);
                cmdInsertIn.Parameters.AddWithValue(ColumnNames[i], ColumnValues[i]);
            }

            cmdInsertIn.CommandText = CommandSB.ToString().TrimEnd(',')+')';

            using (conn)
            {
                conn.Open();
                try
                {
                    cmdInsertIn.ExecuteNonQuery();
                }
                catch(SqlException exc)
                {
                    if (exc.Number == 2627)//2627 - primary key violation code
                    {
                        MessageBox.Show("Cannot execute writing!\nPrimary key violation!", "Data error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        res = false;
                    }
                    else
                        throw new Exception("Something wrong with DB input");
                }
                conn.Close();
            }
            return res;
        }

        /// <summary>
        /// Method to update values in existing row of database.
        /// </summary>
        /// <param name="Table">Table to insert data in.</param>
        /// <param name="ColumnNames">Names of columns.</param>
        /// <param name="ColumnNewValues">Values corresponding to the parameters.</param>
        /// <param name="WhereParam">Column name to compare with parameter.</param>
        /// <param name="ParamValue">Compare parameter.</param>
        public void UpdateWhere(string Table, string[] ColumnNames, object[] ColumnNewValues, string WhereParam, string ParamValue)//N columns in 1 row per call
        {
            /*
                UPDATE table_name
                SET column1 = value1, column2 = value2, ...
                WHERE condition;
            */
            SqlConnection conn = new SqlConnection(ConnectionString);
            int N = ColumnNames.Length;
            SqlCommand cmdUpdateWhere = new SqlCommand();
            cmdUpdateWhere.Connection = conn;
            StringBuilder CommandSB = new StringBuilder();//for cmdUpdateWhere
            string CommandTempString;

            CommandSB.AppendFormat("UPDATE {0} SET ", Table);

            for(int i = 0; i < N; i++)
                CommandSB.AppendFormat("{0} = {1},",ColumnNames[i], ColumnNewValues[i]);

            CommandTempString = CommandSB.ToString();
            CommandTempString = CommandTempString.TrimEnd(',');
            CommandSB.Clear().Append(CommandTempString);
           
            CommandSB.AppendFormat(" WHERE {0} = {1};", WhereParam, ParamValue);

            cmdUpdateWhere.CommandText = CommandSB.ToString();

            for(int i = 0; i < N; i++)
                cmdUpdateWhere.Parameters.AddWithValue(ColumnNames[i], ColumnNewValues[i]);

            using(conn)
            {
                conn.Open();
                var debugV = cmdUpdateWhere.ExecuteNonQuery();
                conn.Close();
            }
        }


        /// <summary>
        /// Method to delete rows in database table.
        /// SqlCommand: "DELETE FROM {Table} WHERE {WhereParam} = {ParamValue}".
        /// </summary>
        /// <param name="Table">Table in database to delete from.</param>
        /// <param name="WhereParam">Column name to compare with parameter.</param>
        /// <param name="ParamValue">Compare parameter.</param>
        /// <returns></returns>
        public int DeleteRows(string Table, string WhereParam, string ParamValue)
        {
            int RowsDeleted;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmdDeleteRow = new SqlCommand();
                cmdDeleteRow.Connection = conn;
                StringBuilder CommandSB = new StringBuilder();
                CommandSB.AppendFormat("DELETE FROM {0} ", Table);
                CommandSB.AppendFormat("WHERE {0} = {1}", WhereParam, ParamValue);
                cmdDeleteRow.CommandText = CommandSB.ToString();
                conn.Open();
                RowsDeleted = cmdDeleteRow.ExecuteNonQuery();
                conn.Close();
            }
            return RowsDeleted;
        }

        /// <summary>
        /// Method to delete ALL rows from table.
        /// </summary>
        /// <param name="Table">Table to clear.</param>
        /// <returns></returns>
        public int ClearTable(string Table)//be careful there
        {
            int RowsDeleted;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmdDeleteRow = new SqlCommand();
                cmdDeleteRow.Connection = conn;
                cmdDeleteRow.CommandText = "DELETE FROM " + Table;
                conn.Open();
                RowsDeleted = cmdDeleteRow.ExecuteNonQuery();
                conn.Close();
            }
            return RowsDeleted;
        }
    }
}
