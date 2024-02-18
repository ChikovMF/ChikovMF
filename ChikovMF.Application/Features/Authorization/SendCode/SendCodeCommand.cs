using MediatR;

namespace ChikovMF.Application.Features.Authorization.SendCode;

public class SendCodeCommand : IRequest<bool>
{
    public string Token { get; set; } = null!;
}
