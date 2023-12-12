import { Aluno } from "./aluno.models";

export interface Imc{
    imcId? : number;
    altura : string;
    peso : string;
    valorIMC?: string;
    classificacao?: string;
    dataDeCriacao?: string;
    aluno? : Aluno;
    alunoId : number;
}