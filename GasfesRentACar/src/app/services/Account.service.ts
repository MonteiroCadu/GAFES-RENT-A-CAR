import { EventEmitter, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { User } from '../models/user-model';
import { AutenticacaoUsuario } from '../models/Autenticacao-model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { LoginUsuario } from '../models/login-model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private baseURL: string = environment.apiURL;
    private url : string = `${this.baseURL}/Autenticar`;

      public get chaveBuscaLocalStorage() : string {
      return 'usuarioLogado';
    }
    public eventMenuVisuvel = new EventEmitter<boolean>();

    constructor(
      private http : HttpClient,
      private router: Router ) {

    }

    public Logar(login:LoginUsuario) : Observable<AutenticacaoUsuario> {
      return this.http.post<AutenticacaoUsuario>(this.url,login);
    }

    public usuarioLogado() : boolean {
      let autenticacaoUsuario : AutenticacaoUsuario = this.ObterAccessTokenLogado();
      return autenticacaoUsuario !== null;
    }

    public ObterAccessTokenLogado() : AutenticacaoUsuario {
      let autenticacaoUsuario = sessionStorage.getItem(this.chaveBuscaLocalStorage);
      return autenticacaoUsuario != null ? JSON.parse(autenticacaoUsuario) : null;
    }

    public logout(){
      sessionStorage.removeItem(this.chaveBuscaLocalStorage);
      this.eventMenuVisuvel.emit(false);
      this.router.navigate(['/auth']);
    }
}