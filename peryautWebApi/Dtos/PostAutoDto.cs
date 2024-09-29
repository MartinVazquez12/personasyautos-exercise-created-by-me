using peryautWebApi.Models;

namespace peryautWebApi.Dtos
{
    public class PostAutoDto
    {
        public Guid idpost { get; set; }

        public string nombrepost { get; set; } = null!;

        public string aniopost { get; set; } = null!;

        public string colorpost { get; set; } = null!;

        public bool activopost { get; set; }

        public Guid id_marcapost { get; set; }

    }
}
