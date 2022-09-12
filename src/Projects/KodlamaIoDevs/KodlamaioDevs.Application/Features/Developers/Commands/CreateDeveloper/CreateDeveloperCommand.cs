using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using KodlamaioDevs.Application.Features.Developers.Dtos;
using KodlamaioDevs.Application.Features.Developers.Rules;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using MediatR;

namespace KodlamaioDevs.Application.Features.Developers.Commands.CreateDeveloper
{
    public class CreateDeveloperCommand : UserForRegisterDto,IRequest<TokenDto>
    {
        public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand,
            TokenDto>
        {
            private readonly IDeveloperRepository _developerRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IMapper _mapper;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            public CreateDeveloperCommandHandler(IDeveloperRepository developerRepository, ITokenHelper tokenHelper, IMapper mapper, DeveloperBusinessRules developerBusinessRules)
            {
                _developerRepository = developerRepository;
                _tokenHelper = tokenHelper;
                _mapper = mapper;
                _developerBusinessRules = developerBusinessRules;
            }


            public async Task<TokenDto> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
            {
                //Aynı email ismi kayıtlı ise geri döndürür.
                await _developerBusinessRules.EmailCanNotBeDuplicatedWhenInserted(request.Email);

                //Requesti veritabanına kaydetmek için şifrelemek gerekir.Bunun için Core.Security.Hashing daki HashingHelper kullanılacak. Request ile developer class ı maplenip passwordhash ile
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                Developer mappedDeveloper = _mapper.Map<Developer>(request);

                mappedDeveloper.PasswordHash = passwordHash;
                mappedDeveloper.PasswordSalt = passwordSalt;

                Developer createdDeveloper = await _developerRepository.AddAsync(mappedDeveloper);
                var token = _tokenHelper.CreateToken(mappedDeveloper, new List<OperationClaim>());
                TokenDto createdToken = new TokenDto() {Token = token.Token, Expiration = token.Expiration };

                return createdToken;
            }
        }
    }
}
