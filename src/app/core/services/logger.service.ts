import { Injectable } from '@angular/core';
import { EnvironmentService } from './environment.service';
import { LogLevel } from '../../shared/enums/log-level.enum';


@Injectable({
  providedIn: 'root'
})
export class LoggerService {
  constructor(
    private _envService: EnvironmentService,
  ) 
  {}

  // General log method
  private log= (level: LogLevel, message: string, ...optionalParams: any[]) => {
    if(!this._envService.canPerformLogging())
    {
        return;
    }

    if (!this._envService.isProduction()) 
    {
      console.log(`[${level}] ${message}`, ...optionalParams); // Print to console
    }
    // send logs to a remote server
    this.sendToServer(level, message, optionalParams);
  }

  info = (message: string, ...optionalParams: any[]) => {
    this.log(LogLevel.INFO, message, ...optionalParams);
  }

  warn = (message: string, ...optionalParams: any[]) => {
    this.log(LogLevel.WARN, message, ...optionalParams);
  }

  error = (message: string, ...optionalParams: any[]) => {
    this.log(LogLevel.ERROR, message, ...optionalParams);
  }

  debug = (message: string, ...optionalParams: any[]) => {
    this.log(LogLevel.DEBUG, message, ...optionalParams);
  }

  private sendToServer = (level: LogLevel, message: string, optionalParams: any[]) => {
    if (this._envService.isProduction()) {
      // Post Request
    }
  }
}
