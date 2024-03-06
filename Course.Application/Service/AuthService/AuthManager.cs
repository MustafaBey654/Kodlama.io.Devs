using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Course.Application.Service.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Course.Application.Service.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepoistory;

        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepoistory;

        public AuthManager(IUserOperationClaimRepository userOperationClaimRepoistory, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepoistory)
        {
            _userOperationClaimRepoistory = userOperationClaimRepoistory;
            _tokenHelper = tokenHelper;
            _refreshTokenRepoistory = refreshTokenRepoistory;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken addRefreshToken = await _refreshTokenRepoistory.AddAsync(refreshToken);
            return addRefreshToken;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims =
                 await _userOperationClaimRepoistory.GetListAsync(u => u.UserId == user.Id,
                 include: u => u.Include(u => u.OperationClaim));

            IList<OperationClaim> operationClaims =
                userOperationClaims.Items.Select(u => new OperationClaim
                { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name, }).ToList();

            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }

        public async Task<RefreshToken> CreatRefreshToken(User user, string ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return await Task.FromResult(refreshToken);
        }
    }
}
