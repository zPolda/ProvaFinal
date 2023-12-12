import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { error } from 'console';
import { Aluno } from 'src/app/models/aluno.models';
import { Imc } from 'src/app/models/imc.models';

@Component({
  selector: 'app-imc-cadastrar',
  templateUrl: './imc-cadastrar.component.html',
  styleUrls: ['./imc-cadastrar.component.css']
})
export class ImcCadastrarComponent implements OnInit {
  altura: string =  "";
  peso: string = "";
  ValorIMC: string = "";
  classificacao: string = "";
  dataDecriacao: string = "";
  alunoId: number = 0;
  alunos: Aluno[] = [];




  constructor(private client: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.client
    .get<Aluno[]>("https://localhost:7227/api/aluno/listar")
    .subscribe({
      next:(alunos) =>{
        console.table(alunos);
        this.alunos = alunos;
      },
      error: (erro) => {
        console.log(erro);
      },
    });
    
  }
  cadastrar(): void{
    let imc: Imc = {
      altura: this.altura,
      peso: this.peso,
      alunoId: this.alunoId
    };
    this.client
    .post<Imc>("https://localhost:7227/api/imc/cadastrar", imc)
    .subscribe({
      next: (imc) => {
        this.router.navigate([""])
      },
      error: (erro)=>{
        console.log(erro);
      },
      });
  }

}
