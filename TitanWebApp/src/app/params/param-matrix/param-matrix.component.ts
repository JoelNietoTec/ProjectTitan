import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ParamMatrix } from '../../shared/models/param-matrices.model';
import { ParamMatricesService } from '../../shared/services/param-matrices.service';

@Component({
  moduleId: module.id,
  selector: 'app-param-matrix',
  templateUrl: './param-matrix.component.html',
  styleUrls: ['./param-matrix.component.css']
})

export class ParamMatrixComponent implements OnInit {

  _matrix: ParamMatrix;

  constructor(
    private _route: ActivatedRoute,
    private _matrixService: ParamMatricesService
  ) { }

  ngOnInit() {
    this._route.params.subscribe(params => {
      this._matrixService.getMatrix(params['id'])
        .subscribe(data => {
          this._matrix = data;
        });
    });
  }
}
