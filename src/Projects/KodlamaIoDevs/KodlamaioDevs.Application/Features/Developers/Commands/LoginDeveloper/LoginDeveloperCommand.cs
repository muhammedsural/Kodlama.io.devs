using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using KodlamaioDevs.Application.Features.Developers.Dtos;
using KodlamaioDevs.Application.Features.Developers.Rules;
using KodlamaioDevs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KodlamaioDevs.Application.Features.Developers.Commands.LoginDeveloper
{
    public class LoginDeveloperCommand : UserForLoginDto,IRequest<TokenDto>
    {
        class LoginDeveloperCommandHandler : IRequestHandler<LoginDeveloperCommand,TokenDto>
        {private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IMapper _mapper;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            public LoginDeveloperCommandHandler(ITokenHelper tokenHelper, IMapper mapper, DeveloperBusinessRules developerBusinessRules, IUserRepository userRepository)
            {
                _tokenHelper = tokenHelper;
                _mapper = mapper;
                _developerBusinessRules = developerBusinessRules;
                _userRepository = userRepository;
            }

            public async Task<TokenDto> Handle(LoginDeveloperCommand request, CancellationToken cancellationToken)
            {
                //Gelen email ile veritabanındaki email kontrol ediliyor ve User sınıfındaki ICollection<UserOperationClaim> türünde User OperationClaim property değerlerini almak için UserOperationClaim sınıfı ile joinlememiz gerekiyor.
                var user = await _userRepository.GetAsync(e => e.Email.ToLower() == request.Email.ToLower(),
                         include:j => j
                        .Include(m => m.UserOperationClaims)
                        .ThenInclude(e => e.OperationClaim));

                //Veritabanından aldığımız User a ait OperationClaimleri operationClaims içerisine atıyoruz.
                //List<OperationClaim> operationClaims = new List<OperationClaim>() { };

                //foreach (var userOperationClaim in user.UserOperationClaims)
                //{
                //    operationClaims.Add(userOperationClaim.OperationClaim);
                //}

                var operationClaims = user.UserOperationClaims.Select(x => x.OperationClaim).ToList();

                // İş kurallarını uyguluyoruz.
                _developerBusinessRules.DeveloperShouldExistWhenRequest(user);

                _developerBusinessRules.UserCredentialsShouldMatch(request.Password, user.PasswordHash, user.PasswordSalt);

                // CreateToken fonksiyonuna User nesnesini ve operationClaimlerini gönderip token alıyoruz
                AccessToken token = _tokenHelper.CreateToken(user, operationClaims);

                //tokenDto ile token maplenip response olarak döndürülüyor.
                TokenDto tokenDto = _mapper.Map<TokenDto>(token);

                return tokenDto;

            }
        }
    }
}
