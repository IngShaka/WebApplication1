using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class DocumentType
{
    public Guid Id { get; set; }

    public short TypeDocuments { get; set; }

    public string Nombre { get; set; } = null!;

    public short CodigoAddenda { get; set; }

    public DateTime FechaCreacion { get; set; }
}
