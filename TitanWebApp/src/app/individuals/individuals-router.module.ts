import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { IndividualsComponent } from './individuals.component';
import { IndividualsListComponent } from './individuals-list/individuals-list.component';
import { IndividualsFormComponent } from './individuals-form/individuals-form.component';

const routes: Routes = [
  {
    path: 'Individuals',
    component: IndividualsComponent,
    children: [
      {
        path: '', component: IndividualsListComponent
      },
      {
        path: 'New', component: IndividualsFormComponent
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class IndividualsRoutingModule { }

export const routedComponents = [
  IndividualsComponent,
  IndividualsListComponent,
  IndividualsFormComponent
];