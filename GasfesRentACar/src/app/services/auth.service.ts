import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _loged: boolean = false;

  constructor(private router: Router) { }

  login() {
    this._loged = true;
    this.router.navigateByUrl("");
  }

  

  get loged() : boolean {
    return this._loged;
  }
}
