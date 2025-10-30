import { Injectable } from '@angular/core';
import { OktaAuth } from '@okta/okta-auth-js';
import { OktaAuthStateService } from '@okta/okta-angular';
import { environment } from '../environments/environment';

@Injectable({ providedIn: 'root' })
export class OktaAuthWrapperService {
    constructor(private oktaAuth: OktaAuthStateService) { }

    // OktaAuthStateService does not provide direct login/logout methods.
    // These should be handled via OktaAuth instance (in factory) or router guards.
    // Here, we expose authState$ observable and recommend using OktaAuthModule's built-in methods for login/logout.
    authState$ = this.oktaAuth.authState$;
}
