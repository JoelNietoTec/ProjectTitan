import { Component, OnInit } from '@angular/core';

import { Individual } from '../../shared/models/individuals.model';
import { IndividualService } from '../../shared/services/individuals.service';

@Component({
  selector: 'app-individuals-list',
  templateUrl: './individuals-list.component.html',
  styleUrls: ['./individuals-list.component.css']
})
export class IndividualsListComponent implements OnInit {

  individuals: Individual[];

  constructor(private _indService: IndividualService) { }

  ngOnInit() {
    this._indService.getIndividuals()
      .subscribe(data => {
        this.individuals = data;
      });
  }

}
