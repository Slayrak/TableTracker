using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Interfaces;

namespace TableTracker.Application.CQRS.Notifications.Commands.SendFAQEmail
{
    public class SendFAQEmailCommandHandler : IRequestHandler<SendFAQEmailCommand, CommandResponse<EmailDTO>>
    {
        private readonly IEmailHandler _emailHandler;

        public SendFAQEmailCommandHandler(IEmailHandler email)
        {
            _emailHandler = email;
        }

        public async Task<CommandResponse<EmailDTO>> Handle(SendFAQEmailCommand request, CancellationToken cancellationToken)
        {
            request.Email.Subject = "FAQ Question";
            request.Email.To = new List<string> { "placeholder" };

            _emailHandler.SendEmail(request.Email);
        }
    }
}
