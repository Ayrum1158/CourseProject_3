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

        public DB_interface(DB_ConstructorMode DBCM)
        {
            StringBuilder SB = new StringBuilder();
            string DB_path = "";
            switch (DBCM)
            {
                case DB_ConstructorMode.InFolder:
                    DB_path = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);
                    break;
                case DB_ConstructorMode.OFD:
                    OpenFileDialog OFD = new OpenFileDialog();
                    OFD.Filter = "MS SQL Database|*.mdf";
                    if(OFD.ShowDialog() == DialogResult.OK)
                    {
                        DB_path = OFD.FileName;
                    }
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
        /// Method to insert 1 row of data in table of database.
        /// </summary>
        /// <param name="Table">Table to insert data in.</param>
        /// <param name="ParamNames">Names of columns.</param>
        /// <param name="ParamValues">Values corresponding to the parameters.</param>
        public void InsertInto(string Table, string[] ParamNames, object[] ParamValues)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            int N = ParamNames.Length;
            SqlCommand cmdInsertIn = new SqlCommand();
            cmdInsertIn.Connection = conn;
            StringBuilder CommandSB = new StringBuilder();//for cmdInsertIn
            CommandSB.Append("INSERT INTO ");
            CommandSB.AppendFormat("{0} VALUES(", Table);
            for (int i = 0; i < N; i++)
            {
                CommandSB.AppendFormat("@{0},",ParamNames[i]);
                cmdInsertIn.Parameters.AddWithValue(ParamNames[i], ParamValues[i]);
            }

            cmdInsertIn.CommandText = CommandSB.ToString().TrimEnd(',')+')';
            using (conn)
            {
                conn.Open();
                try {
                cmdInsertIn.ExecuteNonQuery();
                }
                catch(SqlException exc)
                {
                    if(exc.Number == 2627)//2627 - primary key violation code
                    MessageBox.Show("Cannot execute writing!\nPrimary key violation!", "Data error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
        }

        /// <summary>
        /// Method to delete rows in database table.
        /// SqlCommand: "DELETE FROM {Table} WHERE {WhereParam} = {ParamValue}".
        /// </summary>
        /// <param name="Table">Table in database to delete from.</param>
        /// <param name="WhereParam">Column parameter.</param>
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
