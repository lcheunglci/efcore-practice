namespace KaijuApp.Domain
{
    public class Ability
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public Kaiju Kaiju { get; set; }
        public int KaijuId { get; set; }


    }
}