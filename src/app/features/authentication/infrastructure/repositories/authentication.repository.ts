import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EnvironmentService } from '../../../../core/services/environment.service';
import { LoggerService } from '../../../../core/services/logger.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationRepository {

  constructor(
    private http: HttpClient,
    private envService: EnvironmentService,
  ) {}

  login(username: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.envService.getApiUrl()}/login`, { username, password });
  }

  signup(username: string, password: string, email: string): Observable<any> {
    return this.http.post<any>(`${this.envService.getApiUrl()}/signup`, { username, password, email });
  }

  forgetPassword(email: string): Observable<any> {
    return this.http.post<any>(`${this.envService.getApiUrl()}/forget-password`, { email });
  }
}
