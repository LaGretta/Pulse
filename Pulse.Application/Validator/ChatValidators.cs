using FluentValidation;
using Pulse.Application.DTO;

namespace Pulse.Application.Validator;

public class SendMessageDtoValidator : AbstractValidator<SendMessageDto>
{
    public SendMessageDtoValidator()
    {
        RuleFor(x => x.ChatRoomId).GreaterThan(0);
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Message cannot be empty")
            .MaximumLength(4000).WithMessage("Message too long");
    }
}

public class EditMessageDtoValidator : AbstractValidator<EditMessageDto>
{
    public EditMessageDtoValidator()
    {
        RuleFor(x => x.MessageId).GreaterThan(0);
        RuleFor(x => x.Content).NotEmpty().MaximumLength(4000);
    }
}

public class AddReactionDtoValidator : AbstractValidator<AddReactionDto>
{
    public AddReactionDtoValidator()
    {
        RuleFor(x => x.MessageId).GreaterThan(0);
        RuleFor(x => x.Emoji).NotEmpty().MaximumLength(10);
    }
}