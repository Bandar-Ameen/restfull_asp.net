using AstoolTechRestFullAPI.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AstoolTechRestFullAPI.customclass
{
    public class AuthenticationRepository : IDisposable
    {
        Models.orderapiEntities1 context = new Models.orderapiEntities1();
        //Add the Refresh token
        public async Task<bool> AddRefreshToken(RefreshTokenRf token)
        {
            var existingToken = context.RefreshTokenRf.FirstOrDefault(r => r.UserName == token.UserName
                            && r.ClientID == token.ClientID);
            if (existingToken != null)
            {
                var result = await RemoveRefreshToken(existingToken);
            }
            context.RefreshTokenRf.Add(token);
            return await context.SaveChangesAsync() > 0;
        }
        //Remove the Refesh Token by id
        public async Task<bool> RemoveRefreshTokenByID(string refreshTokenId)
        {
            var refreshToken = await context.RefreshTokenRf.FindAsync(refreshTokenId);
            if (refreshToken != null)
            {
                context.RefreshTokenRf.Remove(refreshToken);
                return await context.SaveChangesAsync() > 0;
            }
            return false;
        }
        //Remove the Refresh Token
        public async Task<bool> RemoveRefreshToken(RefreshTokenRf refreshToken)
        {
            context.RefreshTokenRf.Remove(refreshToken);
            return await context.SaveChangesAsync() > 0;
        }
        //Find the Refresh Token by token ID
        public async Task<RefreshTokenRf> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await context.RefreshTokenRf.FindAsync(refreshTokenId);
            return refreshToken;
        }
        //Get All Refresh Tokens
        public List<RefreshTokenRf> GetAllRefreshTokens()
        {
            return context.RefreshTokenRf.ToList();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}