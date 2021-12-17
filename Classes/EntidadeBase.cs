namespace DIO.Series
{
    // A classe será abstract pois não definirá nenhum método, somente uma base para a criação de 
    // classes.
    public abstract class EntidadeBase
    {
        // Define um atributo Id que todos herdeiros dessa classe terão
        public int Id {get; protected set;}
    }
}
