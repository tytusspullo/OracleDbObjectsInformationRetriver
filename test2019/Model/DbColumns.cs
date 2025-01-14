using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devart.Data;
using Devart.Data.Oracle;

namespace test2019
{
    public class DbColumns:List<DbColumn>
    {
        ConnectionData cnData = null;
        public DbColumns(ConnectionData cnData)
        {
            this.CnData = cnData;
        }
        public ConnectionData CnData
        {
            get { return cnData; }
            set { cnData = value; }
        }
        public bool TestConnection()
        {
            bool isOpen = false;

            using (OracleConnection conn = new OracleConnection(CnData.CnString))
            {
                try
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                        isOpen = true;                    
                }
                catch (OracleException ex) {
                    throw ex;
                }
            } 
            return isOpen;
        }
        public void LoadData()
        {
            string cmdText = @"SELECT column_name
                                FROM all_tab_cols
                                WHERE data_type = 'NUMBER'
                                AND TABLE_NAME in (SELECT table_name FROM user_tables)";
            try
            {
                this.Clear();
                using (OracleConnection conn = new OracleConnection(CnData.CnString))
                {
                    conn.Open();
                    using (OracleCommand command = conn.CreateCommand())
                    {
                        command.CommandText = cmdText;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                for (int i = 0; i < reader.FieldCount; i++)
                                    this.Add(new DbColumn(reader[0].ToString())
                                              );
                        }
                    }
                }// try > finally  Close && Dispose 
            }
            catch (OracleException ex) {
                throw ex; }
        }
        public void LoadData2()
        {
            string cmdText = @"SELECT column_name
                                FROM all_tab_cols
                                WHERE data_type = 'NUMBER'
                                AND TABLE_NAME in (SELECT table_name FROM user_tables)";
            try
            {
                this.Clear();
                using (OracleConnection conn = new OracleConnection(CnData.CnString))
                {
                    conn.Open();
                    using (OracleCommand command = conn.CreateCommand())
                    {
                        command.CommandText = cmdText;
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                for (int i = 0; i < reader.FieldCount; i++)
                                    this.Add(new DbColumn(reader[0].ToString())
                                              );
                        }
                    }
                }// try > finally  Close && Dispose 
            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }
    }
}
