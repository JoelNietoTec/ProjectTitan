import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ParamMatrix } from '../../shared/models/param-matrices.model';
import { ParamCategory, ParamMaster, ParamValue } from '../../shared/models/params.models';
import { ParamMatricesService } from '../../shared/services/param-matrices.service';

@Component({
  moduleId: module.id,
  selector: 'app-param-matrix',
  templateUrl: './param-matrix.component.html',
  styleUrls: ['./param-matrix.component.css']
})

export class ParamMatrixComponent implements OnInit {

  _matrix: ParamMatrix;
  _newCategory: ParamCategory;

  constructor(
    private _route: ActivatedRoute,
    private _matrixService: ParamMatricesService
  ) { }

  ngOnInit() {
    this._route.params.subscribe(params => {
      this._matrixService.getMatrix(params['id'])
        .subscribe(data => {
          this._matrix = data;
          console.log(this._matrix);
        });
    });
    this._newCategory = {};
  }

  addCategory() {
    this._matrix.ParamCategories.push(this._newCategory);
    console.log(this._matrix);
    this._newCategory = {};
  }
}
