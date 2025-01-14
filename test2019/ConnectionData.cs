using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Devart.Data.Oracle;

namespace test2019
{
    public class ConnectionData
    {
        private string dataSource = "";
        private string user = "";
        private string password = "";
        private string cnString = "";

        public ConnectionData(string user, string password)
        {
            this.dataSource = GetDataSource();
            this.user = user;
            this.password = password;
            this.cnString = BuildConnectionString();
        }
        public ConnectionData(): this("","")
        { }
        public bool ValidateConnectionString => ValidateUser() && ValidatePassword();
        public string CnString
        {
            get { return cnString;}
        }
        public bool ValidateUser()
        {
            return (user.Length > 0 && user.Length <= 30 ? true : false);
        }
        public bool ValidatePassword()
        {
            return (password.Length > 0 && password.Length <= 30 ? true : false);
        }
        private string BuildConnectionString()
        {
            OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();
            ocsb.Direct = true;
            ocsb.Port = 1521;
            ocsb.Server = dataSource;
            ocsb.Sid = "OracleSid";
            ocsb.UserId = user;
            ocsb.Password = password;
            ocsb.MaxPoolSize = 150;
            ocsb.ConnectionTimeout = 30;
            return ocsb.ConnectionString;
        }
        private string GetDataSource()
        {
            string datasource;

            XmlDocument doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + "\\config.xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/configuration/datasource");
            datasource = node.InnerText;

            return datasource;
        }

    }
}
