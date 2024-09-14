import { Injectable } from '@angular/core';
import { AuthenticationRepository } from '../../../infrastructure/repositories/authentication.repository';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SignupService {

  constructor(private authRepo: AuthenticationRepository) {}

  execute(username: string, password: string, email: string): Observable<any> {
    return this.authRepo.signup(username, password, email);
  }
}
