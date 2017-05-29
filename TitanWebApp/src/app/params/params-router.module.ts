import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ParamsComponent } from './params.component';
import { ParamMatricesComponent } from './param-matrices/param-matrices.component';
import { ParamMatrixComponent } from './param-matrix/param-matrix.component';


const routes: Routes = [
  {
    path: 'Params', component: ParamsComponent,
    children:
    [
      {
        path: '', component: ParamMatricesComponent
      },
      {
        path: 'Matrix/:id', component: ParamMatrixComponent
      },
      {
        path: '**', pathMatch: 'full', redirectTo: ''
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ParamsRoutingModule { }

export const routedComponents = [ParamsComponent, ParamMatrixComponent, ParamMatricesComponent];
