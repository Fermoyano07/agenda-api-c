using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestordeContactosApi.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Numero { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
    }
}
