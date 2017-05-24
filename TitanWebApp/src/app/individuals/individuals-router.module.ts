import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { IndividualsComponent } from './individuals.component';
import { IndividualsListComponent } from './individuals-list/individuals-list.component';

const routes: Routes = [
  { path: 'individuals', component: IndividualsComponent,
children: [ {
    path: ''
}

] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class IndividualsRoutingModule { }

export const routedComponents = [IndividualsComponent];