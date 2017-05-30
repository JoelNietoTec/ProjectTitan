import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { ParamsRoutingModule } from './params-router.module';

import { ParamsComponent } from './params.component';
import { ParamMatricesComponent } from './param-matrices/param-matrices.component';
import { ParamMatrixComponent } from './param-matrix/param-matrix.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgbModule,
    ParamsRoutingModule
  ],
  providers: [
  ],
  declarations: [
    ParamsComponent,
    ParamMatricesComponent,
    ParamMatrixComponent
  ]
})
export class ParamsModule { }
