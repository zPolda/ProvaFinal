import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Aluno } from './../../../models/aluno.models';

@Component({
  selector: 'app-aluno-cadastrar',
  templateUrl: './aluno-cadastrar.component.html',
  styleUrls: ['./aluno-cadastrar.component.css']
})
export class AlunoCadastrarComponent implements OnInit {
    nome : string = "";
    dataDeNascimento : string = "";

  constructor(private client: HttpClient, private router: Router) { }
  ngOnInit(): void {
  }
  cadastrar() : void{
    let aluno : Aluno = {
      nome: this.nome,
      dataDeNascimento : this.dataDeNascimento
    };
    this.client
      .post<Aluno>("https://localhost:7227/api/aluno/cadastrar", aluno)
      .subscribe({
        next: (aluno) => {
          this.router.navigate(["pages/imc/cadastro"])
        },
        error: (erro) =>
        {
            console.log(erro);
        }
      })
  }

}
