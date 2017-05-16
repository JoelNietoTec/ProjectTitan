import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ParamsCategoriesComponent } from './params-categories.component';

describe('ParamsCategoriesComponent', () => {
  let component: ParamsCategoriesComponent;
  let fixture: ComponentFixture<ParamsCategoriesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ParamsCategoriesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ParamsCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
