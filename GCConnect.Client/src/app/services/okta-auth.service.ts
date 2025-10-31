import { Inject, Injectable } from '@angular/core';
import { OKTA_AUTH } from '@okta/okta-angular';
import OktaAuth from '@okta/okta-auth-js';

@Injectable({
  providedIn: 'root'
})
export class OktaAuthService {

  private readonly oktaAuth: OktaAuth
  constructor(@Inject(OKTA_AUTH) public authService: OktaAuth) {
    this.oktaAuth = authService;
  }

  async signInWithRedirect(returnUrl?: string) {
    try {
      await this.oktaAuth.token.getWithRedirect({
        redirectUri: returnUrl || this.oktaAuth.options.redirectUri,
        scopes: this.oktaAuth.options.scopes
      });
    } catch (e) {
      console.error('Error initiating a login redirect', e);
    }
  }
  async signOut() {
    try {
      await this.oktaAuth.signOut();
    } catch (e) {
      console.error('Error during sign out', e);
    }
  }
}
