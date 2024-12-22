using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetExample
{
    public class ProductDal
    {
        // Dal : Data  Access Layer . İsimlendirmede  Dal veya Dao kullanılır. Dao : Data Access Object.

        SqlConnection _connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; initial catalog=AdoNet; integrated security = true");
           
        // Burada connection  ı _ connection a çeviriyor. Sınıfın içerisinde methodların dışında olunca önüne alt çizgi konulması gerekiyormuş.
            
        // BU KODDA KONTROLLER YOK YANİ ADAM EKSİK VERİ GİRMESİ GİBİ MEVZU OLURSA BİR KONTROL YOK PROGRAM CRASHLAYABİLİR.

    public List<Product> GetAll()
        {
            // Burada @ arkasından gelen verinin tamamını string olarak ele almasını sağlıyor. '\' başka anlamlara geldiğinden hata vermsin diye konuldu. 
            // initial catalog : Hangi veri tabanına bağlanılacağını belirlemeye yarar.
            // integrated security : Veri tabanına Windows doğrulamasıyla bağlanıp bağlanamayacağını belirler. True olunca Bilgisayarı açmak yeterli Veritabanına bakmak için.
            // new SqlConnection(@"server=(localdb)\MSSQLLocalDB; initial catalog=AdoNet; integrated security = false; uid = engin pwd =134;"); gibi
            //

            ConnectionControl();

            SqlCommand getData = new SqlCommand("SELECT * FROM Products", _connection);

            //
            SqlDataReader reader = getData.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["Name"].ToString(),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };

                products.Add(product);

            }

            reader.Close();
            _connection.Close();
            return products;


        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public DataTable GetAll2()
        {
            // Burada @ arkasından gelen verinin tamamını string olarak ele almasını sağlıyor. '\' başka anlamlara geldiğinden hata vermsin diye konuldu. 
            // initial catalog : Hangi veri tabanına bağlanılacağını belirlemeye yarar.
            // integrated security : Veri tabanına Windows doğrulamasıyla bağlanıp bağlanamayacağını belirler. True olunca Bilgisayarı açmak yeterli Veritabanına bakmak için.
            // new SqlConnection(@"server=(localdb)\MSSQLLocalDB; initial catalog=AdoNet; integrated security = false; uid = engin pwd =134;"); gibi
            //

            ConnectionControl();

            SqlCommand getData = new SqlCommand("SELECT * FROM Products", _connection);

            //
            SqlDataReader reader = getData.ExecuteReader();


            // DataTable kullanılmadığını vede kullanılmaması gerektiğini , Hafıza bakımından pahallı ve serileştirme yapılmadığını olduğunu belirtti.
            // Yani nadiren kullanılıyor.
            //Serileştirme özelliği nedir?

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            _connection.Close();
            return dataTable;

        }

        public void Add(Product product)
        {
            ConnectionControl();

            SqlCommand addCommand =
                new SqlCommand("INSERT into Products values(@Name,@UnitPrice,@StockAmount)", _connection);

            addCommand.Parameters.AddWithValue("@Name",product.Name);
            addCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            addCommand.Parameters.AddWithValue("@StockAmount", product.StockAmount);
            addCommand.ExecuteNonQuery();
            _connection.Close();

        }

        public void Update(Product product)
        {
            ConnectionControl();

            SqlCommand addCommand =
                new SqlCommand("UPDATE Products set Name = @Name, UnitPrice = @UnitPrice , StockAmount = @StockAmount WHERE id = @Id )", _connection);

            addCommand.Parameters.AddWithValue("@Name", product.Name);
            addCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            addCommand.Parameters.AddWithValue("@StockAmount", product.StockAmount);
            addCommand.Parameters.AddWithValue("@Id", product.Id);
            addCommand.ExecuteNonQuery();
            _connection.Close();

        }

        public void Delete(int id)
        {
            ConnectionControl();

            SqlCommand addCommand =
                new SqlCommand("DELETE FROM Products WHERE Id = @Id", _connection);
            addCommand.Parameters.AddWithValue("@Id", id);
            addCommand.ExecuteNonQuery();
            _connection.Close();

        }



    }
}
