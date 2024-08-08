using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public int? Idmarca { get; set; }

    public int? Idcategoria { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public virtual Categoria? CategoriaNavigation { get; set; }

    public virtual Marca? MarcaNavigation { get; set; }
}
