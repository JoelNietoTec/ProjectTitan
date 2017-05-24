import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { GendersService } from './services/genders.service';
import { IndividualService } from './services/individuals.service';
import { ConnectionService } from './services/connection.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [GendersService, IndividualService, ConnectionService],
  declarations: []
})
export class SharedModule { }
