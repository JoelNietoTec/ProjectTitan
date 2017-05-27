import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { IndividualsComponent } from './individuals.component';
import { IndividualsListComponent } from './individuals-list/individuals-list.component';
import { IndividualsFormComponent } from './individuals-form/individuals-form.component';
import { IndividualDetailsComponent } from './individual-details/individual-details.component';

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
      },
      {
        path: ':id', component: IndividualDetailsComponent
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
  IndividualsFormComponent,
  IndividualDetailsComponent
];
