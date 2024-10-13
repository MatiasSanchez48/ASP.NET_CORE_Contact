namespace NetCore.ContactsApi.Models
{
    public class Contact
    {
        public string Id { get; set; } // Identificador único del contacto
        public string FirstName { get; set; } // Nombre
        public string LastName { get; set; } // Apellido
        public string Email { get; set; } // Correo electrónico
        public string PhoneNumber { get; set; } // Número de teléfono
        public DateTime CreatedAt { get; set; } // Fecha de creación
        public DateTime UpdatedAt { get; set; } // Fecha de última modificación
    }
}
