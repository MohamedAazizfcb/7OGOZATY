import { HttpHandlerFn, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';
import { TokenService } from '../services/token.service';
import { inject } from '@angular/core';

export const AuthenticationInterceptor: HttpInterceptorFn = (req: HttpRequest<unknown>, next: HttpHandlerFn) => {
    const tokenService = inject(TokenService);
    const accessToken = tokenService.getAccessToken()?? '';

    // Clone the request to add the Access Token Bearer header.
    const authReq = req.clone({
        setHeaders: {
        Authorization: `Bearer ${accessToken}`
        }
    });

    return next(authReq).pipe(
        catchError(error => {
            // Handle authentication error here (redirect to login)
            if (true) 
            {
                // this.authService.redirectToLogin(); // Method to handle redirection
            }
            return throwError(() => error); // Re-throw the error
        })
    );
};