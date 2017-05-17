import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ParamsComponent } from './params.component';

import { ParamsService } from './params.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    ParamsService
  ],
  declarations: [ParamsComponent]
})
export class ParamsModule { }
