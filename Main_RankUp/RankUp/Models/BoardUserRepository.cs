using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class BoardUserRepository : IBoardUserRepository
    {

        AppDBContext context;
        private readonly UserManager<User> userManager;

        public BoardUserRepository(AppDBContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public BoardUsers Add(BoardUsers newBoardUser)
        {
            var boardUser = context.boardUsers.Add(newBoardUser);
            // boardUser.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return newBoardUser;
        }
        public List<BoardUsers> GetAllBoardUsers()
        {
            return context.boardUsers.Include(c => c.user).ToList();
        }

        public BoardUsers GetBoardUserById(int id)
        {
            return context.boardUsers.Include(c => c.user).FirstOrDefault(c => c.id == id);

        }
        public BoardUsers Update(BoardUsers UpdatedBoardUser)
        {
            var boardUser = context.boardUsers.Attach(UpdatedBoardUser);
            boardUser.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            // a3ml update f table el users kman ?????? YESSSSSS
            var userId = UpdatedBoardUser.user.Id;
            var user = context.Users.Find(userId);
            var updatedUser = context.Users.Attach(user);
            //var updatedUser = context.Users.Attach(UpdatedBoardUser.user);
            updatedUser.State = EntityState.Modified;
            context.SaveChanges();


            return UpdatedBoardUser;
        }

        public int GetActiveHR()
        {
            return context.boardUsers.Where(c => c.isAvailable).Count();
        }

        public bool DeleteBoardUser(int deletedBoardUserId)
        {
            try
            {
                context.boardUsers.Remove(context.boardUsers.Find(deletedBoardUserId));
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> ResetBoardUserPasswordAsync(int boardUserId)
        {
            // msh rady yb3t el boardUser.user.Id directly fl View ??????
            //BoardUsers boardUser = context.boardUsers.Include(c => c.user).Find(boardUserId);
            BoardUsers boardUser = context.boardUsers.Where(c => c.id == boardUserId).Include(c => c.user).First();

            User user = context.Users.Find(boardUser.user.Id);

            string passwordToken = await userManager.GeneratePasswordResetTokenAsync(user);

            //if(passwordToken.IsCompletedSuccessfully)
            //{
                var result = await userManager.ResetPasswordAsync(user, passwordToken, "RankUp@1234");
                if(result.Succeeded)
                {
                    return true;
                }
                return false;
            //}
            return false;
        }

        public List<BoardUsers> FilterBoardUsers(string userName, bool isAdmin, bool isAvailable)
        {
            char[] separator = { ' ' };
            List<string> separatedName = new List<string>(userName.Split(separator));

            List<string> namesList = separatedName.Select(name => name.ToLower()).ToList();

            // and wala or ???
            return context.boardUsers.Where(c => (c.isAvailable == isAvailable && c.isAdmin == isAdmin) ||
            (separatedName.Contains(c.user.firstName.ToLower()) || separatedName.Contains(c.user.lastName.ToLower()))).Include(c=>c.user).ToList();
        }

    }
}
