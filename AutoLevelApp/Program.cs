using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLevelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet("books");
            dataSet.ExtendedProperties.Add("OwnerCompany", "ITStep");
            dataSet.ExtendedProperties.Add("CreationDate", DateTime.Now);

            #region Books Table
            DataTable booksTable = new DataTable("books");
            booksTable.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "id",
                DataType = typeof(int),
                Unique = true
            });
            booksTable.PrimaryKey = new DataColumn[] { booksTable.Columns["id"] };

            booksTable.Columns.Add("Name", typeof(string));
            booksTable.Columns.Add("Price", typeof(int));
            booksTable.Columns.Add("AuthorId", typeof(int));

            dataSet.Tables.Add(booksTable);
            #endregion

            #region Authors Table
            DataTable authorsTable = new DataTable("books");
            authorsTable.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "id",
                DataType = typeof(int),
                Unique = true
            });
            authorsTable.PrimaryKey = new DataColumn[] { authorsTable.Columns["id"] };

            authorsTable.Columns.Add("Name", typeof(string));

            dataSet.Tables.Add(booksTable);
            #endregion

            authorsTable.Rows.Add(new object[] { "Пушкин А.С" });

            DataRow row = booksTable.NewRow();
            row.BeginEdit();
            row.ItemArray = new object[] { "Сказки", 1000, 1 };
            row.EndEdit();
            row.SetAdded();
            booksTable.Rows.Add(row);

            DataRelation dataRelation = new DataRelation("authors_book_fk", "authors", "books", new string[] { "id" }, new string[] { "authorId" }, false);
            dataSet.Relations.Add(dataRelation);
        }
    }
}
