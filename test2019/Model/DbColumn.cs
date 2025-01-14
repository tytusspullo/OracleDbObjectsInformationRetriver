using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2019
{
    public class DbColumn
    {
        string columnName = "";

        public DbColumn(string columnName)
        {
            this.columnName = columnName;
        }

        public string ColumnName 
        {
            get { return columnName; }
            set { columnName = value;} 
        }


    }
}
