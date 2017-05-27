import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Individual } from '../../shared/models/individuals.model';
import { Gender } from '../../shared/models/genders.model';
import { IndividualService } from '../../shared/services/individuals.service';

@Component({
  moduleId: module.id,
  selector: 'individual-details',
  templateUrl: './individual-details.component.html',
  styleUrls: ['./individual-details.component.css']
})

export class IndividualDetailsComponent implements OnInit {

  _individual: Individual;

  constructor(
    private _route: ActivatedRoute,
    private _indService: IndividualService) { }

  ngOnInit() {
    this._route.params.subscribe(params => {
      this._indService.getIndividual(params['id'])
        .subscribe(data => {
          this._individual = data;
          console.log(this._individual);
        });
    });
  }
}
