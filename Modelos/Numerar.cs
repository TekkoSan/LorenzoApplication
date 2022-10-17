namespace LorenzoApplication.Modelos
{
    public class Numerar
    {
        public int Id { get; set; }
        public string Numerador { get; set; }
        public int Valor { get; set;}

        public Numerar()
        {
            Id = 0;
            Numerador = string.Empty;
            Valor = 0;
        }
    }
}
