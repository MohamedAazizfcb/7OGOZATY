import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/base/app-component/app.component';
import { config } from './app/base/configure/app.config.server';

const bootstrap = () => bootstrapApplication(AppComponent, config);

export default bootstrap;
