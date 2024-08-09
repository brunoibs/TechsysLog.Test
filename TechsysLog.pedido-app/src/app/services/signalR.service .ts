import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: signalR.HubConnection = null!; // Inicializando como null!

  constructor() { }

  public startConnection(): void {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7165/notificationHub') // URL do seu hub SignalR no backend
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));
  }

  public updateListener(callback: (message: string) => void): void {
    this.hubConnection.on('ReceiveUpdate', (message) => {
      callback(message);
    });
  }
}
