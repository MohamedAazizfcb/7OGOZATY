import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationFacade } from '../../application/authentication.facade';

@Injectable()
export class ForgetPasswordPresenter {
  constructor(private facade: AuthenticationFacade) {}

  forgetPassword(email: string): Observable<any> {
    return this.facade.forgetPassword(email);
  }
}