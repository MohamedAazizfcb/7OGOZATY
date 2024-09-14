import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationFacade } from '../../application/authentication.facade';

@Injectable()
export class LoginPresenter {
  constructor(private facade: AuthenticationFacade) {}

  login(username: string, password: string): Observable<any> {
    return this.facade.login(username, password);
  }
}