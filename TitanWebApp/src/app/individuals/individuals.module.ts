import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { IndividualsRoutingModule } from './individuals-router.module';

import { IndividualsComponent } from './individuals.component';
import { IndividualsFormComponent } from './individuals-form/individuals-form.component';
import { IndividualsListComponent } from './individuals-list/individuals-list.component';
import { IndividualDetailsComponent } from './individual-details/individual-details.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgbModule,
    IndividualsRoutingModule
  ],
  declarations: [
    IndividualsComponent,
    IndividualsFormComponent,
    IndividualsListComponent,
    IndividualDetailsComponent]
})
export class IndividualsModule { }
