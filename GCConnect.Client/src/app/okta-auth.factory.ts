import { Injectable, Injector } from '@angular/core';
import { OktaAuth } from '@okta/okta-auth-js';
import { environment } from '../environments/environment';
import { Router } from '@angular/router';
import { OktaConfig } from '@okta/okta-angular';
import { ROUTES_PATHS } from './common/constants/routes.constants';

@Injectable({ providedIn: 'root' })
export class OktaAuthFactory {
    static createOktaAuth(): OktaConfig {
        return {
            onAuthRequired: (oktaAuth: OktaAuth, injector: Injector) => {
                // Use injector to access services
                const router = injector.get(Router);
                // Redirect the user to your custom login page
                router.navigate([ROUTES_PATHS.auth]);
            },
            oktaAuth: new OktaAuth({
                issuer: environment.okta.issuer,
                clientId: environment.okta.clientId,
                redirectUri: environment.okta.redirectUrl,
                scopes: environment.okta.scopes,
            })
        };
    }
}
