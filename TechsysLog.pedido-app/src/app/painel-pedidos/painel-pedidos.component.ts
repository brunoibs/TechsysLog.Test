import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { SignalRService } from '../services/signalR.service ';
//import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

@Component({
  selector: 'app-painel-pedidos',
  templateUrl: './painel-pedidos.component.html',
  styleUrls: ['./painel-pedidos.component.css']
})
export class PainelPedidosComponent implements OnInit {
  pedidos: any[] = [];
  idUser: number = 0;
  status: string = '';
  //private hubConnection: HubConnection;

  constructor(private authService: AuthService, private router: Router, private signalRService: SignalRService) {}

  ngOnInit() {
    const userString = localStorage.getItem('user');

    if (userString) {
      const user = JSON.parse(userString);
      this.idUser = user.id;
    }

    this.signalRService.startConnection();
    this.signalRService.updateListener((message) => {
      console.log('Mensagem recebida: ', message);
      this.status = '';
      this.loadPedidos();
    });
    this.loadPedidos();
  }

  statusList = [
    { value: '0', label: 'Cancelado' },
    { value: '1', label: 'Recebido' },
    { value: '2', label: 'Em Preparação' },
    { value: '3', label: 'Saiu para Entrega' },
    { value: '4', label: 'Entregue' }
  ];

  atualizarLista(event: any): void {
    this.status = event.target.value;
    console.log('Valor selecionado:', this.status);
    this.loadPedidos();
  }

  marcarEntregue(id: any){

    this.authService.registrarEntrega(id).subscribe(
      response => {
        if (response.status === 201) {
          this.loadPedidos();
        } else {
          console.error('Erro ao registrar Entrega', response);
        }
      },
      error => {
        console.error('Erro ao registrar Entrega', error);
      }
    );
  }

  cancelarEntrega(id: any){

    this.authService.cancelarPedido(id).subscribe(
      response => {
        if (response.status === 201) {
          this.loadPedidos();
        } else {
          console.error('Erro ao cancelar Pedido', response);
        }
      },
      error => {
        console.error('Erro ao cancelar Pedido', error);
      }
    );
  }

  loadPedidos() {

    this.authService.buscarPedidosPeloIdUser(this.idUser,this.status).subscribe(
      response => {
        if (response.status === 200) {
          this.pedidos = response.body;
          console.log("lista de pedidos: ", this.pedidos);
        } else {
          console.error('Erro ao listar pedidos', response);
        }
      },
      error => {
        console.error('Erro ao listar pedidos', error);
      }
    );
  }

  setupSignalR() {
    // this.hubConnection = new HubConnectionBuilder()
    //   .withUrl('https://api-url/hub')
    //   .build();

    // this.hubConnection.on('ReceivePedidoUpdate', (pedido) => {
    //   const index = this.pedidos.findIndex(p => p.numero === pedido.numero);
    //   if (index !== -1) {
    //     this.pedidos[index] = pedido;
    //   } else {
    //     this.pedidos.push(pedido);
    //   }
    // });

    // this.hubConnection.start().catch(err => console.error(err));
  }
}
