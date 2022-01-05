using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public interface IBoardUserRepository
    {
        public BoardUsers Add(BoardUsers newBoardUser);
        public List<BoardUsers> GetAllBoardUsers();
        public BoardUsers GetBoardUserById(int id);
        public BoardUsers Update(BoardUsers UpdatedBoardUser);

        public int GetActiveHR();

        public bool DeleteBoardUser(int deletedBoardUserId);
        public Task<bool> ResetBoardUserPasswordAsync(int boardUserId);

        public List<BoardUsers> FilterBoardUsers(string userName, bool isAdmin, bool isAvailable);

    }
}
