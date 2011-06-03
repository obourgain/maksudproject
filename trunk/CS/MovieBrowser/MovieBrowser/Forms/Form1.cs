using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MovieBrowser.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Configuration c = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var section = (ConnectionStringsSection)c.GetSection("connectionStrings");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string datasource = string.Format(@"metadata=res://*/Model.MoviesDb.csdl|res://*/Model.MoviesDb.ssdl|res://*/Model.MoviesDb.msl;provider=System.Data.SQLite;provider connection string='data source={0}\MaxInc\Db\MovieDb.sqlite';", path);
            section.ConnectionStrings["MovieDbEntities"].ConnectionString = datasource;
            c.Save();

        }
    }
}
