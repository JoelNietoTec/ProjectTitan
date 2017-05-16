import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { ParamsComponent } from './params/params.component';
import { IndividualsComponent } from './individuals/individuals.component'; 

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'params', component: ParamsComponent },
  { path: 'individuals', component: IndividualsComponent},
  { path: '**', pathMatch: 'full', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }

export const routedComponents = [HomeComponent, ParamsComponent, IndividualsComponent];