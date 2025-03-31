using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.UserService
{
    public class UsersBlock
    {
        public List<UserProfile> Users { get; private set; }
        public bool ExistMoreUsers { get; private set; }

        public UsersBlock(List<UserProfile> users, bool existMoreUsers)
        {
            this.Users = users;
            this.ExistMoreUsers = existMoreUsers;
        }

    }
}