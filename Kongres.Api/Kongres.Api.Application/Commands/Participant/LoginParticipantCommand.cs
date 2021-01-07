﻿using MediatR;

namespace Kongres.Api.Application.Commands.Participant
{
    public class LoginParticipantCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}