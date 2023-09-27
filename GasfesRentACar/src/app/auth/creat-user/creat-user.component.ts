import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalController } from '@ionic/angular';
import { User } from 'src/app/models/user-model';
import { AccountService } from 'src/app/services/Account.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-creat-user',
  templateUrl: './creat-user.component.html',
  styleUrls: ['./creat-user.component.scss'],
})
export class CreatUserComponent  implements OnInit {

  
  constructor(
    private modalCtr: ModalController,
    private fb: FormBuilder,
    private userService: UserService,
    private accountService: AccountService) { }

  cadForm = this.fb.group({
    nomeCompleto: ['', Validators.required],
    cpf: ['', Validators.required],
    login: ['', Validators.required],    
    senha: ['',Validators.required]
  });  

  ngOnInit() {
    if(this.accountService.usuarioLogado()) {
      const userId = this.accountService.ObterAccessTokenLogado().dados.userId
      this.userService.getById(userId)
      
      .subscribe( {
        next: (result) => {
          this.cadForm.patchValue(result); 
        },
        error : (erro) => {
          alert('Erro ao recuperar dados do usuário');
          console.debug(erro);
        }
      });
    }
  }

  confirm(){
    let user: User =  {... this.cadForm.value} as User
    if(!this.accountService.usuarioLogado()) {
      this.userService.insertUser(user)
      .subscribe( {
        next: (result) => {
          alert('Usuário cadastrado com sucesso!');                   
          
        },
        error : (erro) => {
          alert('Erro ao cadastrar usuário');
          console.debug(erro);
        }
      });
    } else {
      const userId = this.accountService.ObterAccessTokenLogado().dados.userId
      this.userService.updatetUser(user,userId)
      .subscribe( {
        next: (result) => {
          alert('Dados alterados com sucesso!');                   
          
        },
        error : (erro) => {
          alert('Erro ao alterar dados do usuário!');
          console.debug(erro);
        }
      });
    }

    this.modalCtr.dismiss({message:'Book confirmed'},'confirm');
  }
  cancel(){
    this.modalCtr.dismiss(null,'cancel');
  }

  showDeleteButton():boolean {
    return this.accountService.usuarioLogado();
  }

  delete() {
    const userId = this.accountService.ObterAccessTokenLogado().dados.userId
      this.userService.deleteUser(userId)
      .subscribe( {
        next: (result) => {
          alert('Perfil deletado com sucesso'); 
          this.modalCtr.dismiss(null, "delete");
          this.accountService.logout();
        },
        error : (erro) => {
          alert('Erro ao deletado perfil do usuário!');
          console.debug(erro);
        }
      });
  } 

}
