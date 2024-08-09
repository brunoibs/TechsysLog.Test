import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroPedidoComponent } from './cadastro-pedido.component';

describe('CadastroPedidoComponent', () => {
  let component: CadastroPedidoComponent;
  let fixture: ComponentFixture<CadastroPedidoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CadastroPedidoComponent]
    });
    fixture = TestBed.createComponent(CadastroPedidoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
