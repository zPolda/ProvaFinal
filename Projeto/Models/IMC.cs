using System.ComponentModel.DataAnnotations;
namespace Projeto.Models;
public class IMC
{
    public IMC(double peso, double altura){
        Peso = peso;
        Altura = altura;
        calculoDeIMC();
        classificacaoDeIMC();
        DataCriacao = DateTime.Now;

    }
    [Key]
    [Required]
    public int? ImcId {get; set;}
    public double Altura {get; set;}
    public double Peso {get; set;}
    public double? ValorIMC {get; set;}
    public string? Classificacao {get; set;} 
    public DateTime? DataCriacao {get; set;}

    public Aluno? Aluno {get; set;}
    public int AlunoId {get; set;}

    public void calculoDeIMC(){
        ValorIMC = Peso / (Altura*Altura);
    }
    public void classificacaoDeIMC(){
        if(ValorIMC> 40){
            Classificacao = "Obesidade Grave";
        }
        if(ValorIMC<= 40 && ValorIMC > 30){
            Classificacao = "Obesidade";
        }
        if(ValorIMC <= 29.9 && ValorIMC > 25){
            Classificacao = "Sobrepeso";
        }
        if(ValorIMC <= 24.9 && ValorIMC > 18.5){
            Classificacao = "Normal";
        }
        if(ValorIMC< 18.5){
            Classificacao = "Magreza";
        }
    }
}
