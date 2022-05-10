namespace KaijuApp.Domain
{
    public class Kaiju
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Ability> Abilities { get; set; } = new List<Ability>();
    }
}