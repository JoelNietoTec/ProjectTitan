import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { GendersService } from './services/genders.service';
import { IndividualService } from './services/individuals.service';
import { ParamMatricesService } from './services/param-matrices.service';
import { ConnectionService } from './services/connection.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    GendersService,
    IndividualService,
    ParamMatricesService,
    ConnectionService
  ],
  declarations: []
})
export class SharedModule { }
