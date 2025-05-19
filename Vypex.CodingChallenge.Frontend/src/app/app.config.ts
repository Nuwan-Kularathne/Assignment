import { registerLocaleData } from '@angular/common';
import { provideHttpClient } from '@angular/common/http';
import enAU from '@angular/common/locales/en-AU';
import { ApplicationConfig, provideExperimentalZonelessChangeDetection } from '@angular/core';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideRouter } from '@angular/router';
import { en_GB, provideNzI18n } from 'ng-zorro-antd/i18n';
import { NzModalService } from 'ng-zorro-antd/modal';
import { routes } from './app.routes';

registerLocaleData(enAU);

export const appConfig: ApplicationConfig = {
  providers: [
    provideExperimentalZonelessChangeDetection(),
    provideHttpClient(),
    provideRouter(routes),
    provideAnimations(),
    provideNzI18n(en_GB),
    NzModalService
  ]
};
