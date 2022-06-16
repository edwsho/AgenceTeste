import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultorsAgenceTesteComponent } from './consultors-agence-teste.component';

describe('ConsultorsAgenceTesteComponent', () => {
  let component: ConsultorsAgenceTesteComponent;
  let fixture: ComponentFixture<ConsultorsAgenceTesteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsultorsAgenceTesteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultorsAgenceTesteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
