import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router) { }

  canActivate(): boolean {

    // Recuperar a string JSON do localStorage
    const userString = localStorage.getItem('user');

    if (userString) {
      // Converter a string JSON de volta para um objeto
      const user = JSON.parse(userString);

      console.log(user);
      console.log('ID:', user.id);
      console.log('Nome:', user.nome);
      console.log('Email:', user.email);
      return true;
    } else {
      console.error('Nenhum usuário encontrado no localStorage');
      this.router.navigate(['/login']);
      return false;
    }
  }
}
