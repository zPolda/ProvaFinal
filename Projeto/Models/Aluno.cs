using System.ComponentModel.DataAnnotations;


namespace Projeto.Models;
public class Aluno
{
    [Key]
    [Required]
    public int AlunoId {get; set;}
    public string Nome {get; set;}
    public string DataDeNascimento {get; set;}

}
