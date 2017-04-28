using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blip.Models
{
    public class BlipRepo
    {
        static List<BlipUser> _users = null;
        static List<int> _winners = null;
        static int _claims = 0;

        static BlipRepo _repo = null;
        static List<String> _avatars = null;

        Random _r;
        private BlipRepo()
        {
            Clear();
            _r = new Random(Guid.NewGuid().GetHashCode());
        }

        public void Clear()
        {
            _users = new List<BlipUser>();
            _avatars = new List<string>();
            _winners = new List<int>();

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
            _avatars.Add("av11.PNG");
            _avatars.Add("av12.PNG");
            _avatars.Add("av13.PNG");
            _avatars.Add("av14.PNG");
            _avatars.Add("av15.PNG");

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
            _users.Add(user);

            return user;
        }
        
        public List<BlipUser> GetAll()
        {
            return _users;
        }      
        
        public void CreateWinner()
        {
            int winner = -1;

            if (_users.Count < 1)
                return;

            //If everyone has won reset the winners list
            if(_users.Count <= _winners.Count)
            {
                _winners.Clear();
                _claims = 0;
            }

            do
            {
                winner = _r.Next() % _users.Count;
            }while(_winners.Contains(winner));

            _winners.Add(winner);
        }
        
        public BlipUser GetWinner()
        {
            if(_winners.Count > _claims)
            {
                return _users[_winners.Last()];
            }

            return null;
        }  

        public void SetWinnerClaimed()
        {
            _claims = _winners.Count;
        }
    }
}