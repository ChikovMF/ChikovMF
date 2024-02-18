using ChikovMF.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ChikovMF.Application.Features.Authorization.GetToken;

public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery>
{
    public async Task Handle(GetTokenQuery request, CancellationToken cancellationToken)
    {
        var currentTokens = await _context.AccessTokens.Where(t => DateTime.UtcNow - t.DateOfReceiving < new TimeSpan(0, 10, 0)).ToArrayAsync(cancellationToken);

        if (currentTokens.Length > 0)
        {
            return;
        }

        Guid token = Guid.NewGuid();

        var accessToken = new Entities.AccessToken
        {
            DateOfReceiving = DateTime.UtcNow,
            HashToken = BCryptNet.HashPassword(token.ToString())
        };

        await _context.AccessTokens.AddAsync(accessToken, cancellationToken);

        var adminId = new ChatId(_configuration.AdminId);
        var message = await _bot.SendTextMessageAsync(
            chatId: adminId,
            text: $"Токен доступа: {token}.",
            cancellationToken: cancellationToken
            );

        await _context.SaveChangesAsync(cancellationToken);
    }

    private readonly TelegramBotClient _bot;
    private readonly AuthConfiguration _configuration;
    private readonly IChikovMFContext _context;

    public GetTokenQueryHandler(TelegramBotClient bot, AuthConfiguration configuration, IChikovMFContext context)
    {
        _bot = bot;
        _configuration = configuration;
        _context = context;
    }
}
