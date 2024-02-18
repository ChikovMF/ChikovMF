using ChikovMF.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ChikovMF.Application.Features.Authorization.SendCode;

public class SendCodeCommandHandler : IRequestHandler<SendCodeCommand, bool>
{
    public async Task<bool> Handle(SendCodeCommand request, CancellationToken cancellationToken)
    {
        var currentTokens = await _context.AccessTokens.Where(t => DateTime.UtcNow - t.DateOfReceiving < new TimeSpan(0, 10, 0)).ToArrayAsync();

        foreach (var currentToken in currentTokens)
        {
            if (BCryptNet.Verify(request.Token, currentToken.HashToken))
            {
                return true;
            }
        }

        return false;
    }

    private readonly IChikovMFContext _context;

    public SendCodeCommandHandler(IChikovMFContext context)
    {
        _context = context;
    }
}
