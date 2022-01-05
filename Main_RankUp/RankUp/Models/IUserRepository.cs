using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public interface IUserRepository
    {
        public User Add(User user);
        public User Delete(string id);
        public User Update(User UserChanges);
        //public IEnumerable<User> GetAllUsers();
        public List<User> GetAllUsers();
        public User GetUser(string id);
        public bool updateCV(User user, string newPath);

        public List<(string, string, string)> GetCVRequests(string id);
        public List<(string, string, string)> GetInterviewRequests(string id);
        public List<(string, string, string)> GetLinkedInRequests(string id);
        public List<ReviewRequests> GetPendingRequests(string id);

        //public bool GetUsersCountries();
        //public List<(string, User)> GetUsersCountries();
        public List<(string, int)> GetUsersCountries();

    }
}
