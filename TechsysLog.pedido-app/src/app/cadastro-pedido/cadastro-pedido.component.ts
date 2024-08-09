import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-cadastro-pedido',
  templateUrl: './cadastro-pedido.component.html',
  styleUrls: ['./cadastro-pedido.component.css']
})

export class CadastroPedidoComponent implements OnInit {


  pedidoForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    this.pedidoForm = this.fb.group({
      id: 0,
      descricao: ['', Validators.required],
      valor: ['', [Validators.required, Validators.min(0)]],
      cep: ['', Validators.required],
      rua: ['', Validators.required],
      numero: ['', Validators.required],
      bairro: ['', Validators.required],
      cidade: ['', Validators.required],
      estado: ['', Validators.required],
      idUserPedido : 0
    });
  }
  ngOnInit(): void {}

  buscarCep() {
    const cep = this.pedidoForm.get('cep')?.value;
    this.authService.buscarPeloCep(cep).subscribe(
      response => {
        if (response.status === 200) {
          this.pedidoForm.patchValue({
            rua: response.body.logradouro,
            bairro: response.body.bairro,
            cidade: response.body.localidade,
            estado: response.body.uf
          });
        } else {
          console.error('Erro consultar Cep', response);
        }
      },
      error => {
        console.error('Erro no cep', error);
      }
    );
  }

  onSubmit() {

    if (this.pedidoForm.valid) {
      console.log('Formulário enviado com sucesso', this.pedidoForm.value);
      const userString = localStorage.getItem('user');
      if (userString) {
        const user = JSON.parse(userString);
        this.pedidoForm.patchValue({
          idUserPedido: user.id
        });

        if(user.id == 0 ){
          alert("Usuário Invalido");
        }
        this.authService.cadastrarPedido(this.pedidoForm.value).subscribe(
          response => {
            if (response.status === 201) {
              this.router.navigate(['/painel-pedidos']);
            } else {
              console.error('Erro cadastrar Pedido', response);
            }
          },
          error => {
            console.error('Erro no Pedido', error);
          }
        );
      }else{
        alert("Usuário Invalido");
      }
    } else {
      console.log('Formulário inválido');
      this.pedidoForm.markAllAsTouched();
    }
  }
}
