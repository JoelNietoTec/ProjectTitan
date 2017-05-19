import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IndividualsFormComponent } from './individuals-form.component';

describe('IndividualsFormComponent', () => {
  let component: IndividualsFormComponent;
  let fixture: ComponentFixture<IndividualsFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IndividualsFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IndividualsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
