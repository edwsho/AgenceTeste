import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaTarjetasCreditoComponent } from './lista-tarjetas-credito.component';

describe('ListaTarjetasCreditoComponent', () => {
  let component: ListaTarjetasCreditoComponent;
  let fixture: ComponentFixture<ListaTarjetasCreditoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaTarjetasCreditoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaTarjetasCreditoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
