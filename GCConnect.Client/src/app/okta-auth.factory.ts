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
                // Directly call signInWithRedirect to avoid circular dependency
                oktaAuth.signInWithRedirect();
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
