import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ParamMatricesComponent } from './param-matrices.component';

describe('ParamMatricesComponent', () => {
  let component: ParamMatricesComponent;
  let fixture: ComponentFixture<ParamMatricesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ParamMatricesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ParamMatricesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
