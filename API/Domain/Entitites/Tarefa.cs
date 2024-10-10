namespace API.Domain.Entitites
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public bool IsCompleta { get; set; }
    }
}
