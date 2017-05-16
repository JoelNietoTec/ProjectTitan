import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise'

import { ParamMaster, ParamCategory } from './params.models'

@Injectable()
export class ParamsService {

  private paramMasterUrl = 'http://localhost:53212/api/ParamMasters'
  private CategoryUrl = 'http://localhost:53212/api/ParamCategories'

  constructor(private http: Http) { }

}