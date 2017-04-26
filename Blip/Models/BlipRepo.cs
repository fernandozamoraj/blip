using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blip.Models
{
    public class BlipRepo
    {
        static List<BlipUser> _users = null;

        static BlipRepo _repo = null;
        static List<String> _avatars = null;
        static int _nextAvatar = 0;

        Random _r;
        private BlipRepo()
        {
            _users = new List<BlipUser>();
            _avatars = new List<string>();

            _avatars.Add("av0.PNG");
            _avatars.Add("av1.PNG");
            _avatars.Add("av2.PNG");
            _avatars.Add("av3.PNG");
            _avatars.Add("av4.PNG");
            _avatars.Add("av5.PNG");
            _avatars.Add("av6.PNG");
            _avatars.Add("av7.PNG");
            _avatars.Add("av8.PNG");
            _avatars.Add("av9.PNG");
            _avatars.Add("av10.PNG");
            _r = new Random();
        }

        public List<string> GetAvatars()
        {
            return _avatars;
        }

        public static BlipRepo Current {
            get {
                if(_repo == null)
                {
                    _repo = new BlipRepo();
                }
                return _repo;
            }
        }

        public BlipUser AddUser(BlipUser user)
        {
            user.UserId = _users.Count();

            //Set avatar
            //_nextAvatar = _r.Next() % _avatars.Count();
            //user.Avatar = _avatars[_nextAvatar];

            _users.Add(user);

            return user;
        }
        
        public List<BlipUser> GetAll()
        {
            return _users;
        }        
    }
}