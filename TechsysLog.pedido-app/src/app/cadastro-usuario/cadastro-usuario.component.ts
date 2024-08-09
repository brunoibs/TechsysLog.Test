import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-cadastro-usuario',
  templateUrl: './cadastro-usuario.component.html',
  styleUrls: ['./cadastro-usuario.component.css']
})
export class CadastroUsuarioComponent {
  user = {
    nome: '',
    email: '',
    senha: ''
  };

  constructor(private authService: AuthService, private router: Router) {}

  onSubmit() {
    let validar = true;
    if(this.user.nome == ''){
      validar = false;
    }
    if(this.user.email == ''){
      validar = false;
    }
    if(this.user.senha == ''){
      validar = false;
    }

    if(validar == false){
      alert("Favor preencher os campos Obrigatorios.");
    }else{
      this.authService.cadastrarUsuario(this.user).subscribe(
        response => {
          if (response.status === 201) {
            console.log('Usuário cadastrado com sucesso');
            this.router.navigate(['/login']);
          } else {
            console.error('Erro no cadastro do usuário', response);
          }
        },
        error => {
          console.error('Erro no cadastro do usuário', error);
        }
      );
    }


  }
}
