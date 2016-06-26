using System.Windows;
using System.Data.SqlClient;
using System.Data;


namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\v12.0;AttachDbFilename=|DataDirectory|App_Data\events.mdf;Integrated Security=True";
            }
        }

private void BaseLoaded(object sender, RoutedEventArgs e)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                // Komenda otwierająca połączenie między bazą danych a moim programem
                conn.Open();
                // Nowe polecenie sql'a. Jest to odpowiednik "New Querty" w MS SQLu, składa się z polecenia
                // oraz informacji z jakie połączenie mam użyć.
                SqlCommand cmd = new SqlCommand("SELECT * FROM event", conn);
                // To polecenie jest odpowiedzialne za wykonanie powyższej komendy
                SqlDataReader dr = cmd.ExecuteReader();


                //Tworze nową tabele
                DataTable dt = new DataTable();
                //Uzupełniam tą tabele za pomocą polecenia którze wcześniej stworzyłem
                dt.Load(dr);
                //Ustawiam źródło danych mojego EvendGreedView na tabele którą stworzyłem i uzupełniłem
                dataGrid1.ItemsSource = dt.AsDataView();
            }
        }
    }
}
