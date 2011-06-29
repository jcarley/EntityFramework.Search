using System;
using System.Linq;
using System.Windows.Forms;
using EntityFramework.Search.Data;
using System.IO;
using Lucene.Net.Search;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Documents;
using Lucene.Net.QueryParsers;
using Lucene.Net.Analysis.Standard;


namespace EntityFramework.Search
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Search()
        {

            var indexPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Index");

            var analyzer = new StandardAnalyzer();

            string fieldName = "Firstname".ToLower();

            QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_29, fieldName, analyzer);
            Query query = parser.Parse("+Jeff");

            var directory = FSDirectory.GetDirectory(indexPath);

            IndexSearcher searcher = new IndexSearcher(indexPath, true);

            Hits hits = searcher.Search(query);

            for (int i = 0; i < hits.Length(); i++)
            {
                Document document = hits.Doc(i);

                float score = hits.Score(i);

                string name = document.Get(fieldName);

                System.Diagnostics.Debug.WriteLine("Score: " + score);
                System.Diagnostics.Debug.WriteLine("Name: " + name);
            }

            searcher.Close();
            directory.Close();

        }

        private void Process()
        {
            using (var context = new WatercoolerEntities())
            {
                var user = context.Users.FirstOrDefault(u => u.Email == "jeff.carley@finishfirstsoftware.com");

                user.Firstname = "Jeff";

                user = context.Users.FirstOrDefault(u => u.Email == "kbarton@gmail.com");

                context.DeleteObject(user);

                user = User.CreateUser(Guid.NewGuid(), "Fred", "Flintstone", "fflint@gmail.com", "password", true, null);

                context.Users.AddObject(user);

                context.SaveChanges();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}
