import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ParamsComponent } from './params.component';
import { ParamsCategoriesComponent } from './params-categories/params-categories.component';
import { ParamMatricesComponent } from './param-matrices/param-matrices.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  providers: [
  ],
  declarations: [ParamsComponent, ParamsCategoriesComponent, ParamMatricesComponent]
})
export class ParamsModule { }
