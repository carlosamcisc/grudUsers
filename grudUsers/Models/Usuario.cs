using System;
using System.Collections.Generic;

namespace grudUsers.Models;

public partial class Usuario
{
    public int IdUser { get; set; }

    public string? Nombre { get; set; }

    public string? Rol { get; set; }
}
