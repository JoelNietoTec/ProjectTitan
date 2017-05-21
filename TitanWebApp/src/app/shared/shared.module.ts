import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConnectionsComponent } from './connections/connections.component';
import { GendersService } from './services/genders.service';
import { IndividualService } from './services/individuals.service'

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [GendersService, IndividualService ],
  declarations: [ConnectionsComponent]
})
export class SharedModule { }
