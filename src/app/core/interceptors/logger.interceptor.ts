import { HttpHandlerFn, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { inject } from '@angular/core';
import { tap } from 'rxjs';
import { LoggerService } from '../services/logger.service';

export const LoggerInterceptor: HttpInterceptorFn = (req: HttpRequest<unknown>, next: HttpHandlerFn) => {
  const logService = inject(LoggerService);
  const start = Date.now();
  logService.info("New Http Request: " ,req);

  return next(req).pipe(
    tap(event => {
        if (event.type === 0) { // `0` means an `HttpResponse` has started.
            logService.info(`Response for ${req.url} took ${Date.now() - start} ms`);
        }
    }),
  );
};