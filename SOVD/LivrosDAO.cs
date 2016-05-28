using System;
using System.Data;

namespace SOVD
{
    public class LivrosDAO : DAO
    {
        public DataTable selectAll()
        {
            return Load_Table("SELECT "
                + "idProd, title, subtitle, autors,"
                + " publisher, genders, price, year,"
                + " edition, type, abstract, fileLocation"
                + " FROM prod");
        }

        public DataTable SelectForSearch()
        {
            return Load_Table("SELECT "
                + "idProd, title, subtitle, autors,"
                + " publisher, genders, price, year,"
                + " edition, type"
                + " FROM prod");
        }

        public void Search(Livro livro)
        {
            DataTable table = Load_Table("SELECT idProd, title, subtitle, autors, publisher, genders, price, year, edition, type, abstract, fileLocation"
                + " FROM prod WHERE idProd = '" + livro.Id + "'");

            if (table.Rows.Count > 0)
            {
                int i; double d;
                DataRow row = table.Rows[0];
                livro.Authors = row["autors"].ToString();
                if (int.TryParse(row["edition"].ToString(), out i))
                {
                    livro.Edicao = i; 
                }
                livro.File = row["fileLocation"].ToString();
                livro.Gender = row["genders"].ToString();
                if (double.TryParse(row["price"].ToString(), out d))
                {
                    livro.Price = d; 
                }
                livro.Publisher = row["publisher"].ToString();
                livro.Sinopse = row["abstract"].ToString();
                livro.Subtitle = row["subtitle"].ToString();
                livro.Title = row["title"].ToString();
                if (int.TryParse(row["type"].ToString(), out i))
                {
                    livro.Type = i; 
                }//ATENTION
                livro.Year = row["year"].ToString();
            }
        }

        public void alterar(Livro book)
        {
            Load_Table("update prod set title='" + book.Title + "', subtitle='" + book.Subtitle
                + "', autors='" + book.Authors + "', genders='" + book.Gender
                + "', fileLocation='" + book.File + "', publisher='" + book.Publisher + "', price='" + book.Price
                + "', year='" + book.Year + "', edition='" + book.Edicao + "', abstract='" + book.Sinopse + "', type='" + book.Type
                + "' where idProd='" + book.Id + "'");
        }

        public void excluir(int idProd)
        {
            Load_Table("delete from prod where idProd ='" + idProd + "'");
        }
    }
}