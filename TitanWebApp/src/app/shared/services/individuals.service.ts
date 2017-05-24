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

    private individuals: Individual[];

    private newIndividual: Individual;

    constructor(private http: Http, private _conn: ConnectionService) {
        this.individualURL = _conn.APIUrl + "individuals"
    };

    getIndividuals() {
        return this.http
            .get(this.individualURL)
            .map(response => {
                this.individuals = response.json();
                return this.individuals;
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