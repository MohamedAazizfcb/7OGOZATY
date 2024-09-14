import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EnvironmentService {

  getAppId = (): string => {
    return environment.appId;
  }

  isProduction = (): boolean => {
    return environment.production;
  }

  getApiUrl = (): string => {
    return environment.apiUrl;
  }

  canPerformLogging = (): boolean => {
    return environment.logging;
  }

  getFeatureFlag = (): boolean => {
    return environment.featureFlag;
  }
}
