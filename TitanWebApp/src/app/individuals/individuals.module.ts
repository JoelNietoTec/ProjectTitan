import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { IndividualsComponent } from './individuals.component';
import { IndividualsFormComponent } from './individuals-form/individuals-form.component';
import { IndividualsListComponent } from './individuals-list/individuals-list.component';

@NgModule({
  imports: [
    CommonModule, 
    FormsModule,
    NgbModule
  ],
  declarations: [IndividualsComponent, IndividualsFormComponent, IndividualsListComponent]
})
export class IndividualsModule { }
