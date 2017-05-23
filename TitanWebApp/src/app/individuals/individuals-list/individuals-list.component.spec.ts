import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IndividualsListComponent } from './individuals-list.component';

describe('IndividualsListComponent', () => {
  let component: IndividualsListComponent;
  let fixture: ComponentFixture<IndividualsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IndividualsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IndividualsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
