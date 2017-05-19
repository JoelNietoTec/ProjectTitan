import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IndividualsComponent } from './individuals.component';
import { IndividualsFormComponent } from './individuals-form/individuals-form.component';

@NgModule({
  imports: [
    CommonModule, 
    FormsModule
  ],
  declarations: [IndividualsComponent, IndividualsFormComponent]
})
export class IndividualsModule { }
