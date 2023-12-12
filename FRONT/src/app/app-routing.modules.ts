import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AlunoCadastrarComponent } from "./pages/aluno/aluno-cadastrar/aluno-cadastrar.component";
import { ImcCadastrarComponent } from "./pages/imc/imc-cadastrar/imc-cadastrar.component";
import { ImcListarComponent } from "./pages/imc/imc-listar/imc-listar.component";


const routes: Routes =[
    {
        path: "",
        component : AlunoCadastrarComponent
    },
    {
        path: "pages/imc/cadastro",
        component: ImcCadastrarComponent
    },
    {
        path: "pages/imc/listar",
        component: ImcListarComponent
    }

];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule{ }