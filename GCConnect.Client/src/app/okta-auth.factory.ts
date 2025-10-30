import { Injectable } from '@angular/core';
import { OktaAuth } from '@okta/okta-auth-js';
import { environment } from '../environments/environment';

@Injectable({ providedIn: 'root' })
export class OktaAuthFactory {
    static createOktaAuth() {
        return new OktaAuth({
            clientId: environment.okta.clientId,
            issuer: environment.okta.issuer,
            redirectUri: window.location.origin + '/login/callback',
            scopes: environment.okta.scopes
        });
    }
}
