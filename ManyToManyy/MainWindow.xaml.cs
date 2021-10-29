using Dapper;
using ManyToManyy.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ManyToManyy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            using (var connection=new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                var sql = @"select A.AuthorId,A.Firstname,A.Lastname,B.BookId,
                        B.Title,B.Price
                        from Authors as A
                        inner join AuthorsAndBooks as AB on AB.AuthorId=A.AuthorId
                        inner join Books as B on B.BookId=AB.BookId";

                var authors = connection.Query<Author, Book, Author>(sql,
                    (a, b) => { a.Books.Add(b);b.Authors.Add(a); return a; },splitOn:"BookId").ToList();
                mydatagrid.ItemsSource = authors;
            }
        }
    }
}
