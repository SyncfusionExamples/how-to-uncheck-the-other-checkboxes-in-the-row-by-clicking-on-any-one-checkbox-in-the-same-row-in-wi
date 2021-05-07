using Syncfusion.Data;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SfDataGridDemo
{
    public partial class Form1 : Form
    {
        DataTable employeeCollection;
        public Form1()
        {
            InitializeComponent();

            sfDataGrid1.AutoGenerateColumns = true;
            sfDataGrid1.ShowGroupDropArea = false;
            var table = this.GetDataTable();           
            sfDataGrid1.DataSource = table;           
            sfDataGrid1.CellCheckBoxClick += SfDataGrid1_CellCheckBoxClick;           
        }

        private void SfDataGrid1_CellCheckBoxClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellCheckBoxClickEventArgs e)
        {
            //Get the clicked data row
            var rowData = (e.Record as DataRowView).Row;

            //get the changed state of clicked column
            var checkState = e.NewValue;

            //get the clicked current column
            string currentColumnName = e.Column.MappingName;

            // make sure all other columns that are data Type of Boolean are not checked except for this one which we will check
            if (checkState == CheckState.Checked) 
            {
                //Get the column in datatable collection
                foreach (DataColumn dc in employeeCollection.Columns)
                {
                    if (dc.ColumnName != currentColumnName && dc.DataType == typeof(Boolean))
                    {
                        rowData[dc.ColumnName] = false;
                    }
                    else if (dc.ColumnName == currentColumnName)
                    {
                        rowData[dc.ColumnName] = true;
                    }
                }
            }           
        }        

        public DataTable GetDataTable()
        {
            employeeCollection = new DataTable();

            employeeCollection.Columns.Add("OrderID", typeof(int));
            employeeCollection.Columns[0].ColumnName = "Order ID";
            employeeCollection.Columns.Add("CustomerID", typeof(string));
            employeeCollection.Columns[1].ColumnName = "Customer ID";
            employeeCollection.Columns.Add("CustomerName", typeof(string));
            employeeCollection.Columns[2].ColumnName = "Customer Name";
            employeeCollection.Columns.Add("Country", typeof(string));
            employeeCollection.Columns[3].ColumnName = "Country";
            employeeCollection.Columns.Add("ShipCity", typeof(string));
            employeeCollection.Columns[4].ColumnName = "Ship City";
            employeeCollection.Columns.Add("1", typeof(bool));
            employeeCollection.Columns.Add("2", typeof(bool));
            employeeCollection.Columns.Add("3", typeof(bool));


            employeeCollection.Rows.Add(1001, "ALFKI", "Maria Anders", "Germany", "Berlin",false, false, false);
            employeeCollection.Rows.Add(1002, "ANATR", "Ana Trujilo", "Mexico", "Mexico D.F.", false, false, false);
            employeeCollection.Rows.Add(1003, "ANTON", "Antonio Moreno", "Mexico", "Mexico D.F.", false, false, false);
            employeeCollection.Rows.Add(1004, "AROUT", "Thomas Hardy", "UK",  "London", false, false, false);
            employeeCollection.Rows.Add(1005, "BERGS", "Christina Berglund", "Sweden",  "Lula", false, false, false);
            employeeCollection.Rows.Add(1006, "BLAUS", "Hanna Moos", "Germany",  "Mannheim", false, false, false);
            employeeCollection.Rows.Add(1007, "BLONP", "Frederique Citeaux", "France","Strasbourg", false, false, false);
            employeeCollection.Rows.Add(1008, "BOLID", "Martin Sommer", "Spain",  "Madrid", false, false, false);
            employeeCollection.Rows.Add(1009, "BONAP", "Laurence Lebihan", "France",  "Marseille", false, false, false);
            employeeCollection.Rows.Add(1010, "BOTTM", "Elizabeth Lincoln", "Canada", "Tsawassen", false, false, false);

            return employeeCollection;

        }        
    }
}
