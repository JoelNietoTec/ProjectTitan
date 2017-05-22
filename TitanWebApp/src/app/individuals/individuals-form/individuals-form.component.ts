import { Component, OnInit } from '@angular/core';

import { NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';


import { Individual } from '../../shared/models/individuals.model';
import { IndividualService } from '../../shared/services/individuals.service';
import { GendersService } from '../../shared/services/genders.service';
import { Gender } from '../../shared/models/genders.model';

@Component({
  selector: 'individuals-form',
  templateUrl: './individuals-form.component.html',
  styleUrls: ['./individuals-form.component.css']
})
export class IndividualsFormComponent implements OnInit {

  private individual = new Individual();

  private genders: Gender[];

  constructor(
    private _gendersService: GendersService,
    private _individualsService: IndividualService,
    private _dateFormatter: NgbDateParserFormatter) { }

  ngOnInit() {
    this._gendersService.getGenders()
      .subscribe(data => {
        this.genders = data;
      });
  };

  saveIndividual() {
    console.log(this.individual);
    this._individualsService.createIndividual(this.individual)
      .subscribe();
  }

}
