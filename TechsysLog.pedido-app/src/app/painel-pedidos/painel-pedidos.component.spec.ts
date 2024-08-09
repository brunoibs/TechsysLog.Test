import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PainelPedidosComponent } from './painel-pedidos.component';

describe('PainelPedidosComponent', () => {
  let component: PainelPedidosComponent;
  let fixture: ComponentFixture<PainelPedidosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PainelPedidosComponent]
    });
    fixture = TestBed.createComponent(PainelPedidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
