import { Injectable } from '@angular/core';

@Injectable()
export class ConnectionService {

  public APIUrl: string;

  constructor() {
    this.APIUrl = 'http://localhost:53212/api/';
  }
}
