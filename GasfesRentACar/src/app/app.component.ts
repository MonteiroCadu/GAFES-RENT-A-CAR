import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './services/auth.service';
import { AccountService } from './services/Account.service';
import { ModalController } from '@ionic/angular';
import { CreatUserComponent } from './auth/creat-user/creat-user.component';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  constructor(
    private accountService: AccountService,
    private modalCtrl: ModalController) {}
  logout() {
    this.accountService.logout();
  }

  async onPerfilUser() {
    const user = this.accountService.ObterAccessTokenLogado();
    const modal = await this.modalCtrl.create({
      component: CreatUserComponent,
      componentProps: {userId:user.dados.userId}
    });

    modal.present();

    const { data, role } = await modal.onWillDismiss();

    if (role === 'confirm') {
      //this.message = `Hello, ${data}!`;
      
    }
  }
}
