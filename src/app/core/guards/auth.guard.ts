import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { TokenService } from '../services/token.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private _tokenService: TokenService, 
    private _router: Router
  ) {}

  canActivate = (): boolean => {
    if (this._tokenService.isTokenValid()) // if there is a token Go on and the interceptor will kick you out if the token is expired
    {
      return true;
    } 
    else 
    {
      this._router.navigate(['/login']);
      return false;
    }
  }
}
