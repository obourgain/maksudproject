using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MovieBrowser.Model;

namespace MovieBrowser.Forms
{
    public partial class UserListForm : Form
    {

        MovieDbEntities _entities = new MovieDbEntities();
        private User _user;
        public UserListForm(User user)
        {
            _user = user;
            InitializeComponent();


            var data = _entities.UserLists.Where(o => o.User.Id == _user.Id);
            objectListView1.SetObjects(data);
        }
    }
}
