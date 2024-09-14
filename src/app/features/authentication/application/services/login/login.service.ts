import { Injectable } from '@angular/core';
import { AuthenticationRepository } from '../../../infrastructure/repositories/authentication.repository';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private authRepo: AuthenticationRepository) {}

  execute(username: string, password: string): Observable<any> 
  {
    return this.authRepo.login(username, password);
  }
}
