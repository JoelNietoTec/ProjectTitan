import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ParamsComponent } from './params.component';
import { ParamsCategoriesComponent } from './params-categories/params-categories.component';

import { ParamsService } from './params.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    ParamsService
  ],
  declarations: [ParamsComponent, ParamsCategoriesComponent]
})
export class ParamsModule { }
