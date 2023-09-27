import { Injectable } from '@angular/core';
import { CanLoad, Route, UrlSegment, Router } from '@angular/router';
import { Observable } from 'rxjs';

import { AuthService } from './auth.service';
import { AccountService } from './Account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanLoad {
  constructor(
    private accountService: AccountService, 
    private router: Router) {}

  canLoad(
    route: Route    
  ):  boolean {
    let loged = this.accountService.usuarioLogado();
    if (!loged) {
      this.router.navigateByUrl('/auth');
    }
    return loged;
  }
}