import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { NgbDateParserFormatter, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';


import { Individual } from '../../shared/models/individuals.model';
import { IndividualService } from '../../shared/services/individuals.service';
import { GendersService } from '../../shared/services/genders.service';
import { Gender } from '../../shared/models/genders.model';

interface FormIndividual extends Individual {
  formBirthDate?: NgbDateStruct;
};

@Component({
  selector: 'individuals-form',
  templateUrl: './individuals-form.component.html',
  styleUrls: ['./individuals-form.component.css']
})
export class IndividualsFormComponent implements OnInit {

  private individual: FormIndividual;
  private birthdate: string;

  private genders: Gender[];

  constructor(
    private _gendersService: GendersService,
    private _individualsService: IndividualService,
    private _dateFormatter: NgbDateParserFormatter,
    private _router: Router, 
    private _route: ActivatedRoute
  ) {
    const id: string = _route.snapshot.params.id;
    const url: string = _route.snapshot.url.toString();
    const parent: string =_route.snapshot.parent.url.toString();
    const user = _route.snapshot.data.user;

    console.log(url);
    console.log(parent);

   }

  ngOnInit() {

    this.individual = {};

    this._gendersService.getGenders()
      .subscribe(data => {
        this.genders = data;
      });
  };

  saveIndividual() {
    // console.log(this.individual);
    this.individual.BirthDate = new Date(this._dateFormatter.format(this.individual.formBirthDate));
    // this.birthdate = this._dateFormatter.format(this.individual.formBirthDate);
    console.log(this.individual);
    this._individualsService.createIndividual(this.individual)
      .subscribe(data => {
        this._router.navigate(['/individuals']);
      });
  };

};
