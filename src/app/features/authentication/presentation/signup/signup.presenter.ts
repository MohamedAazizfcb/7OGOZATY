import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationFacade } from '../../application/authentication.facade';

@Injectable()
export class SignUpPresenter {
  constructor(private facade: AuthenticationFacade) {}

  signup(username: string, password: string, email: string): Observable<any> {
    return this.facade.signup(username, password, email);
  }
}