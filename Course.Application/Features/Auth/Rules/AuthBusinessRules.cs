using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Course.Application.Service.Repositories;


namespace Course.Application.Features.Auth.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepoistory;

        public AuthBusinessRules(IUserRepository userRepoistory)
        {
            _userRepoistory = userRepoistory;
        }

        public async Task EmailCanNotBeDuplicateWhenRegistered(string email)
        {
            User? user = await _userRepoistory.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Email already exists.");
        }
    }
}
