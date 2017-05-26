import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { ParamsComponent } from './params/params.component';
import { IndividualsComponent } from './individuals/individuals.component'; 

const routes: Routes = [
  { path: 'Home', component: HomeComponent },
  { path: 'Params', component: ParamsComponent },
  { path: 'Individuals', component: IndividualsComponent},
  { path: '**', pathMatch: 'full', redirectTo: 'Home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }

export const routedComponents = [HomeComponent, ParamsComponent, IndividualsComponent];