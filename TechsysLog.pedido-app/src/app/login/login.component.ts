import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  login = {
    email: '',
    senha: ''
  };

  constructor(private http: HttpClient, private router: Router) { }

  onSubmit() {

    this.http.post('https://localhost:7165/api/Usuarios/login', this.login).subscribe((response: any) => {
      if (response && response.token) {
        const user = {
          id: response.id,
          nome: response.nome,
          email: response.email,
          token: response.token
        };
        console.log("User:", JSON.stringify(response));
        // Converter o objeto para uma string JSON
        const userString = JSON.stringify(user);

        // Armazenar a string JSON no localStorage
        localStorage.setItem('user', userString);
        localStorage.setItem('authToken', userString);
        this.router.navigate(['/painel-pedidos']);
      } else {
        alert('Login falhou!');
      }
    }, error => {
      console.error('Erro no login', error);
      alert('Erro no login!');
    });
  }
}
