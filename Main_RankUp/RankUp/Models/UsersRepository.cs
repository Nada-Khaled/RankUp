using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class UsersRepository : IUserRepository
    {
        private readonly AppDBContext context;

        public UsersRepository(AppDBContext context)
        {
            this.context = context;
        }
        public User Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User Delete(string id)
        {
            User user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return null;

        }

        public List<User> GetAllUsers()
        {
            List<User> users = context.Users.Where(u => !context.boardUsers.Select(bu => bu.user.Id).Contains(u.Id)).ToList();
            return users;
        }

        public User GetUser(string id)
        {
            return context.Users.Find(id);
        }

        public User Update(User UserChanges)
        {
            var user = context.Users.Attach(UserChanges);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return UserChanges;
        }
        public bool updateCV(User user, string newPath)
        {
            try
            {
                user.CV = newPath;
                var updateUser = context.Users.Attach(user);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<(string, string, string)> GetCVRequests(string id)
        {
            var cvRequests = context.reviewRequests.Where(c => c.user.Id == id && c.status == "submitted" && c.requestType == "CV").ToList();
            List<(string, string, string)> result = new List<(string, string, string)>();

            foreach (var request in cvRequests)
            {
                result.Add((request.id.ToString(), request.requestType, request.status));
            }

            return result;
        }

        public List<(string, string, string)> GetInterviewRequests(string id)
        {
            var interviewRequests = context.reviewRequests.Where(c => c.user.Id == id && c.status == "submitted" && c.requestType == "interview").ToList();
            List<(string, string, string)> result = new List<(string, string, string)>();

            foreach (var request in interviewRequests)
            {
                result.Add((request.id.ToString(), request.requestType, request.status));
            }

            return result;
        }

        public List<(string, string, string)> GetLinkedInRequests(string id)
        {
            var linkedInRequests = context.reviewRequests.Where(c => c.user.Id == id && c.status == "submitted" && c.requestType == "linkedin").ToList();
            List<(string, string, string)> result = new List<(string, string, string)>();

            foreach (var request in linkedInRequests)
            {
                result.Add((request.id.ToString(), request.requestType, request.status));
            }

            return result;
        }

        public List<ReviewRequests> GetPendingRequests(string id)
        {

            return context.reviewRequests.Where(c => c.user.Id == id && c.status == "pending").OrderBy(c => c.requestType).ToList();

        }

        public List<(string, int)> GetUsersCountries()
        {
            var x = context.Users.GroupBy(c => c.country).Select(c=> new { key = c.Key, val = c.Count() } ).ToList();
            List<(string, int)> result = new List<(string, int)>();
            
            foreach (var item in x)
            {
                if(item.key != null)
                    result.Add((item.key, item.val));
            }
            return result;
        }
    }
}
