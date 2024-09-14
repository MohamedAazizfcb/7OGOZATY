import { HttpHandlerFn, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { inject } from '@angular/core';
import { EnvironmentService } from '../services/environment.service'; // Update path as needed

export const appIdInterceptor: HttpInterceptorFn = (req: HttpRequest<unknown>, next: HttpHandlerFn) => {
  const envService = inject(EnvironmentService);
  const appId = envService.getAppId();

  // Clone the request and add the APPID header
  const clonedReq = req.clone({
    headers: req.headers.set('APPID', appId)
  });

  return next(clonedReq);
};