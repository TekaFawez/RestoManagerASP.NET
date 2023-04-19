using System.ComponentModel.DataAnnotations;

namespace RestoManager.Models.RestosModel
{
    public class Avis
    {
        public int CodeAvis { get; set; }
        public string NomPresonne { get; set; } = null!;
        [Range(1,5)]
        public int Note { get; set; } 
        public string Commentaire { get; set; } = null!;
        public int NumResto { get; set; }

        public virtual Restaurant? LeResto { get; set; } 

    }
}
