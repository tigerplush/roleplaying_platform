import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { AutoRefreshTokenService, createInterceptorCondition, INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG, IncludeBearerTokenCondition, includeBearerTokenInterceptor, provideKeycloak, UserActivityService } from 'keycloak-angular';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { environment } from '../environments/environment';
import { provideHttpClient, withInterceptors } from '@angular/common/http';

const localhostCondition = createInterceptorCondition<IncludeBearerTokenCondition>({
  urlPattern: /^(http:\/\/localhost:8181)(\/.*)?$/i
});

export const appConfig: ApplicationConfig = {
  providers: [
    provideKeycloak({
      config: {
        url: environment.keycloakUrl,
        realm: environment.keycloakRealm,
        clientId: environment.keycloakClientId
      },
      initOptions: {
        onLoad: 'check-sso',
        silentCheckSsoRedirectUri: window.location.origin + '/silent-check-sso.html',
        enableLogging: true,
        redirectUri: window.location.origin + '/after-login'
      },
      providers: [
        AutoRefreshTokenService,
        UserActivityService,
        {
          provide: INCLUDE_BEARER_TOKEN_INTERCEPTOR_CONFIG,
          useValue: [localhostCondition]
        }
      ]
    }),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideClientHydration(withEventReplay()),
    provideAnimationsAsync(),
    provideHttpClient(withInterceptors([includeBearerTokenInterceptor]))
  ]
};
