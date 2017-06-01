import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';

import { ParamMatrix } from '../../shared/models/param-matrices.model';
import { ParamMatricesService } from '../../shared/services/param-matrices.service';

@Component({
  selector: 'app-param-matrices',
  templateUrl: './param-matrices.component.html',
  styleUrls: ['./param-matrices.component.css']
})
export class ParamMatricesComponent implements OnInit {

  matrices: ParamMatrix[];
  newMatrix: ParamMatrix = {};

  constructor(private _matrixService: ParamMatricesService) { }

  ngOnInit() {
    this._matrixService.getMatrices()
      .subscribe(data => {
        this.matrices = data;
      });
  }

  onSubmit() {
    this._matrixService.createMatrix(this.newMatrix)
      .subscribe(data => {
        console.log(data);
        this.matrices.push(data);
        console.log(this.matrices);
        this.newMatrix = {};
      });
  }
}
