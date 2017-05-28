import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { Individual } from '../models/individuals.model';
import { ConnectionService } from './connection.service';

@Injectable()
export class IndividualService {

  private headers = new Headers({ 'Content-Type': 'application/json' });

  private individualURL: string;

  private individual: Individual;

  private individuals: Individual[];

  private newIndividual: Individual;

  constructor(private http: Http, private _conn: ConnectionService) {
    this.individualURL = _conn.APIUrl + 'individuals';
  };

  getIndividuals() {
    return this.http
      .get(this.individualURL)
      .map(response => {
        this.individuals = response.json();
        return this.individuals;
      });
  };

  getIndividual(_id: number) {
    return this.http
      .get(this.individualURL + '/' + _id)
      .map(response => {
        console.log(this.individualURL + '/' + _id);
        this.individual = response.json();
        return this.individual;
      });
  };

  createIndividual(ind: any): Observable<Individual> {
    return this.http
      .post(this.individualURL, JSON.stringify(ind), { headers: this.headers })
      .map(response => {
        this.newIndividual = response.json();
        return this.newIndividual;
      });
  };

}
