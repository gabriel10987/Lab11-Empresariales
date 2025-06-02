﻿using System;
using System.Collections.Generic;
using Lab11_GabrielCcama.Domain.Entities;

namespace Lab11_GabrielCcama.Infrastructure.Scaffold;

public partial class Response
{
    public int ResponseId { get; set; }

    public int TicketId { get; set; }

    public int ResponderId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual User Responder { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;
}
