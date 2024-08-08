namespace Api.PL.DTOs
{
    public class ProductoDTO
    {
        public int Idproducto { get; set; }

        public int? Idmarca { get; set; }

        public int? Idcategoria { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Precio { get; set; }

        public virtual CategoriaDTO? Categoria { get; set; }

        public virtual MarcaDTO? Marca { get; set; }
    }
}
