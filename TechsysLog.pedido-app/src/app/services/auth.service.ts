import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) {}

  cadastrarUsuario(usuario: any): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<any>("https://localhost:7165/api/Usuarios", usuario, { headers, observe: 'response' });
  }

  cadastrarPedido(pedido: any): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<any>("https://localhost:7165/api/Pedido/RegistrarPedido", pedido, { headers, observe: 'response' });
  }

  buscarPedidosPeloIdUser(id: any, status: any): Observable<any> {
    const url = `https://localhost:7165/api/Pedido/ListarPedidosPeloIdUser?id=${id}&status=${status}`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.get<any>(url, { headers, observe: 'response' });
  }

  buscarPeloCep(cep: any): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<any>("https://localhost:7165/api/Pedido/GetAddressByCep?cep="+cep, null, { headers, observe: 'response' });
  }

  registrarEntrega(id: any): Observable<any> {
    const url = `https://localhost:7165/api/Pedido/RegistrarEngrega?id=${id}`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<any>(url, null, { headers, observe: 'response' });
  }

  cancelarPedido(id: any): Observable<any> {
    const url = `https://localhost:7165/api/Pedido/CancelarEntrega?id=${id}`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<any>(url, null, { headers, observe: 'response' });
  }

}
