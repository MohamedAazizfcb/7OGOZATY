import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  private _accessTokenKey = 'accessToken';

  saveAccessToken = (token: string): void => {
    localStorage.setItem(this._accessTokenKey, token);
  }

  getAccessToken = (): string | null => {
    return localStorage.getItem(this._accessTokenKey);
  }

  clearAccessToken = (): void => {
    localStorage.removeItem(this._accessTokenKey);
  }

  isTokenValid = (): boolean => {
    return !!this.getAccessToken();
  }
}
