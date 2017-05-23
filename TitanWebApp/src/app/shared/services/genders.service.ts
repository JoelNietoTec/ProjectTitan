import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';

import { Gender } from '../models/genders.model';

@Injectable()
export class GendersService {

    private gendersURL = "http://localhost:53212/api/genders";

    private genders: Gender[];

    constructor(private http: Http) { }

    getGenders() {
        return this.http.get(this.gendersURL)
            .map(response => {
                this.genders = response.json();
                return this.genders
            });
    };
    

}
