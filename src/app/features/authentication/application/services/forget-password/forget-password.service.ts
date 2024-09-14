import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationRepository } from '../../../infrastructure/repositories/authentication.repository';

@Injectable({
  providedIn: 'root'
})
export class ForgetPasswordService {
  constructor(private authRepo: AuthenticationRepository) {}

  execute(email: string): Observable<any> {
    return this.authRepo.forgetPassword(email);
  }
}
