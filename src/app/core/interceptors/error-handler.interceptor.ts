import { HttpErrorResponse, HttpHandlerFn, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { LoggerService } from '../services/logger.service';
import { ToastrService } from '../services/toastr.service';

export const errorHandlerInterceptor: HttpInterceptorFn = (req: HttpRequest<unknown>, next: HttpHandlerFn) => {
  const logService = inject(LoggerService);
  const toastrService = inject(ToastrService);

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      // Log the error
      logService.error(`Error of status=(${ error.status }) is intercepted with the message: ${ error.message }`);

      // Show user-friendly message
      toastrService.showError(error.message);

      // Return an observable with the error to use if needed
      return throwError(() => error);
    })
  );
};