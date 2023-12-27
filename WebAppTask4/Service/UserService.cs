using Microsoft.AspNetCore.Mvc;
using WebAppTask4.Data;
using WebAppTask4.Models;

namespace WebAppTask4.Service
{
    enum Status
    {
        Block, 
        UnBlock, 
        Delete
    }

    public class UserService
    {
        private readonly AppDbContext context;

        public UserService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task DeleteUser(string[] guids)
        {
            await ExecuteUserAction(Status.Delete, guids);
            await context.SaveChangesAsync();
        }

        public async Task UnBlockUser(string[] guids)
        {
            await ExecuteUserAction(Status.UnBlock, guids);
            await context.SaveChangesAsync();
        }

        public async Task BlockUser(string[] guids)
        {
            await ExecuteUserAction(Status.Block, guids);
            await context.SaveChangesAsync();
        }

        private async Task ExecuteUserAction(Status status, string[] guids)
        {
            foreach (var guid in guids)
            {
                var user = await context.Users.FindAsync(guid);

                if (user is not null)
                {
                    switch(status)
                    {
                        case Status.Delete: context.Users.Remove(user); break;
                        case Status.Block: user.IsActive = false; break;
                        case Status.UnBlock: user.IsActive = true; break;
                    }
                }
            }
        }
    }
}
