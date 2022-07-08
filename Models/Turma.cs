namespace Escola.Models
{
    public class Turma
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public bool? Ativo { get; set; }

       // #region Navigation Properties

      // public virtual List<Aluno>? Alunos { get; }
      // #endregion
    }
}
