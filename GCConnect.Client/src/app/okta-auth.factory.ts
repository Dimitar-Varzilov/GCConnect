import { Injectable, Injector } from '@angular/core';
import { OktaAuth } from '@okta/okta-auth-js';
import { environment } from '../environments/environment';
import { OktaConfig } from '@okta/okta-angular';
import { OktaAuthService } from './services/okta-auth.service';

@Injectable({ providedIn: 'root' })
export class OktaAuthFactory {
    static createOktaAuth(): OktaConfig {
        return {
            onAuthRequired: (oktaAuth: OktaAuth, injector: Injector) => {
                // Use injector to access services
                const authService = injector.get(OktaAuthService);
                authService.signInWithRedirect();
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
