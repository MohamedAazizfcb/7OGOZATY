import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginService } from './services/login/login.service';
import { SignupService } from './services/signup/signup.service';
import { ForgetPasswordService } from './services/forget-password/forget-password.service';
import { LoggerService } from '../../../core/services/logger.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationFacade {
  constructor(
    private loginService: LoginService,
    private signUpService: SignupService,
    private forgetPasswordService: ForgetPasswordService,
  ) {}

  login(username: string, password: string): Observable<any> {
    return this.loginService.execute(username, password);
  }

  signup(username: string, password: string, email: string): Observable<any> {
    return this.signUpService.execute(username, password, email);
  }

  forgetPassword(email: string): Observable<any> {
    return this.forgetPasswordService.execute(email);
  }
}
