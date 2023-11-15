import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LancamentosComponent } from './lancamentos/lancamentos.component';
import { IncluirComponent } from './lancamentos/incluir/incluir.component';
import { EditarComponent } from './lancamentos/editar/editar.component';

const routes: Routes = [
  { path: '', redirectTo: 'Lancamentos', pathMatch: 'full' },
  { path: 'Lancamentos', component: LancamentosComponent },
  { path: 'Lancamentos/Incluir', component: IncluirComponent },
  { path: 'Lancamentos/Editar/:id', component: EditarComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
