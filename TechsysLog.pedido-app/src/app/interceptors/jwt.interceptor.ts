import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // Obter o token do localStorage
      const userString = localStorage.getItem('user');
      let token = '';
      if (userString) {
        const user = JSON.parse(userString);
        console.log("User Token", user);
        token = user.token;
      }

        // Se o token existir, clona a requisição e adiciona o cabeçalho Authorization
        if (token) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${token}`
                }
            });
        }

        // Passa a requisição para o próximo handler na cadeia
        return next.handle(request);
    }
}
