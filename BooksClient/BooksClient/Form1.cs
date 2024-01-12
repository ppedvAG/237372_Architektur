namespace BooksClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var url = "https://www.googleapis.com/books/v1/volumes?q=pizza";

            var http = new HttpClient();
            var json = http.GetStringAsync(url).Result;

            var books = System.Text.Json.JsonSerializer.Deserialize<Books>(json);

            dataGridView1.DataSource = books.items.Select(x=>x.volumeInfo).ToList();

        }
    }
}
