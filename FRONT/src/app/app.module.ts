import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.modules';
import { AlunoCadastrarComponent } from './pages/aluno/aluno-cadastrar/aluno-cadastrar.component';
import { ImcCadastrarComponent } from './pages/imc/imc-cadastrar/imc-cadastrar.component';
import { ImcListarComponent } from './pages/imc/imc-listar/imc-listar.component';

@NgModule({
  declarations: [
    AppComponent,
    AlunoCadastrarComponent,
    ImcCadastrarComponent,
    ImcListarComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
