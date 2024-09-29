using peryautWebApi.Models;

namespace peryautWebApi.Dtos
{
    public class AutoDto
    {
        public Guid id_auto { get; set; }
        public string nombredto { get; set; } = null!;
        public string aniodto { get; set; } = null!;
        public string colordto { get; set; } = null!;
        public string marcanamedto { get; set; } = null!;
    }
}
