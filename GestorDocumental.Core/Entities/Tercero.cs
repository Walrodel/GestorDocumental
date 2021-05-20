namespace GestorDocumental.Core.Entities
{
    public class Tercero: BaseEntity
    {
        public string Identificaion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
