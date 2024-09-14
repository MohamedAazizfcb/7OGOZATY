import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from '../routes/app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { appIdInterceptor } from '../../core/interceptors/app-id.interceptor';
import { errorHandlerInterceptor } from '../../core/interceptors/error-handler.interceptor';
import { LoggerInterceptor } from '../../core/interceptors/logger.interceptor';
import { AuthenticationInterceptor } from '../../core/interceptors/authentication.interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideRouter(routes), 
    provideClientHydration(),
    provideHttpClient(
      withInterceptors([
        appIdInterceptor,
        errorHandlerInterceptor,
        LoggerInterceptor,
        AuthenticationInterceptor
      ])
    ), 
    provideAnimationsAsync(),
  ]
};
