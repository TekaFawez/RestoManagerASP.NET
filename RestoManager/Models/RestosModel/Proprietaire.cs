namespace RestoManager.Models.RestosModel
{
    public class Proprietaire
    {
        public int Numero { get; set; }
        public string Name { get; set; }=  null!;
        public string Email { get; set; } = null!;
        public string Gsm { get; set; } = null!;

        public virtual ICollection<Restaurant>? LesResto { get; set; }
    }
}
