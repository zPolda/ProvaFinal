import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Imc } from 'src/app/models/imc.models';

@Component({
  selector: 'app-imc-listar',
  templateUrl: './imc-listar.component.html',
  styleUrls: ['./imc-listar.component.css']
})
export class ImcListarComponent implements OnInit {
  imcs : Imc [] = [];

  constructor(private client: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.client
    .get<Imc[]>("https://localhost:7227/api/imc/listar")
    .subscribe({
      next: (imcs) =>{
        console.table(imcs);
        this.imcs = imcs;
      },
      error: (erro) => {
        console.log()
      }
    })
  }

}
