namespace SOVD
{
    public class Livro
    {
        string file, title, subtitle, authors, publisher, gender, sinopse, year;
        int edicao, id, type;
        double price;

        #region Encapsuladas
        public string File
        {
            get
            {
                return file;
            }

            set
            {
                file = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Subtitle
        {
            get
            {
                return subtitle;
            }

            set
            {
                subtitle = value;
            }
        }

        public string Authors
        {
            get
            {
                return authors;
            }

            set
            {
                authors = value;
            }
        }

        public string Publisher
        {
            get
            {
                return publisher;
            }

            set
            {
                publisher = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public string Sinopse
        {
            get
            {
                return sinopse;
            }

            set
            {
                sinopse = value;
            }
        }

        public string Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public int Edicao
        {
            get
            {
                return edicao;
            }

            set
            {
                edicao = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
        #endregion
    }
}