using APICore.Repos.Data;
using APICore.Service;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace APICore.Container
{
    public class RefreshHandler : IRefreshHandler
    {
        private readonly ApplicationDbcontext context;
        public RefreshHandler(ApplicationDbcontext context) { 
            this.context = context;
        }
        public async Task<string> GenerateToken(string username)
        {
            var randomnumber = new byte[32];
            using(var randomnumbergenerator= RandomNumberGenerator.Create())
            {
                randomnumbergenerator.GetBytes(randomnumber);
                string refreshtoken=Convert.ToBase64String(randomnumber);
                var Existtoken = this.context.tblRefreshtokens.FirstOrDefaultAsync(item=>item.Userid==username).Result;
                if (Existtoken != null)
                {
                    Existtoken.Refreshtoken = refreshtoken;
                }
                else
                {
                   await this.context.tblRefreshtokens.AddAsync(new Repos.Models.TblRefreshtoken
                    {
                       Userid=username,
                       Tokenid= new Random().Next().ToString(),
                       Refreshtoken=refreshtoken
                   });
                }
                await this.context.SaveChangesAsync();

                return refreshtoken;

            }
        }
    }
}
