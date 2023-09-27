import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { CreatUserComponent } from './creat-user/creat-user.component';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalController } from '@ionic/angular';
import { AccountService } from '../services/Account.service';
import { LoginUsuario } from '../models/login-model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.page.html',
  styleUrls: ['./auth.page.scss'],
})
export class AuthPage implements OnInit {
  loginForm = this.fb.group({
    
    login: ['', Validators.required],    
    senha: ['',Validators.required]
  });  

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private modalCtrl: ModalController,
    private accountService: AccountService,
    private router: Router) { }

  ngOnInit() {
   
  }  

  login() {
    
    if(this.loginForm.valid) {
      let login: LoginUsuario =  {... this.loginForm.value} as LoginUsuario
      this.accountService.Logar(login)
      .subscribe( {
        next: (result) => {
          
          sessionStorage.setItem(this.accountService.chaveBuscaLocalStorage,JSON.stringify(result));
          this.accountService.eventMenuVisuvel.emit(true); 
          this.router.navigateByUrl("");
        },
        error : (erro) => {
          alert('Usuário não autorizado, verifique login e senha!');
          console.debug(erro);
        }
      });
     
      //this.authService.login();
    } else {
      alert('Informe login e senha');
    }
  }

  async onCreateUser() {
    const modal = await this.modalCtrl.create({
      component: CreatUserComponent
    });

    modal.present();

    const { data, role } = await modal.onWillDismiss();

    if (role === 'confirm') {
      //this.message = `Hello, ${data}!`;
      
    }
  }


}
