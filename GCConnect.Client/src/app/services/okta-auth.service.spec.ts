import { TestBed } from '@angular/core/testing';
import { OKTA_AUTH } from '@okta/okta-angular';
import OktaAuth from '@okta/okta-auth-js';
import { OktaAuthService } from './okta-auth.service';

describe('OktaAuthService', () => {
  let service: OktaAuthService;
  let oktaAuthMock: any;

  beforeEach(() => {
    oktaAuthMock = {
      token: {
        getWithRedirect: jasmine.createSpy('getWithRedirect').and.returnValue(Promise.resolve())
      },
      signOut: jasmine.createSpy('signOut').and.returnValue(Promise.resolve()),
      options: {
        redirectUri: 'http://localhost/redirect',
        scopes: ['openid', 'profile', 'email']
      }
    };

    TestBed.configureTestingModule({
      providers: [
        OktaAuthService,
        { provide: OKTA_AUTH, useValue: oktaAuthMock }
      ]
    });
    service = TestBed.inject(OktaAuthService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should call oktaAuth.token.getWithRedirect with default options', async () => {
    await service.signInWithRedirect();
    expect(oktaAuthMock.token.getWithRedirect).toHaveBeenCalledWith({
      redirectUri: oktaAuthMock.options.redirectUri,
      scopes: oktaAuthMock.options.scopes
    });
  });

  it('should call oktaAuth.token.getWithRedirect with custom returnUrl', async () => {
    await service.signInWithRedirect('http://custom/return');
    expect(oktaAuthMock.token.getWithRedirect).toHaveBeenCalledWith({
      redirectUri: 'http://custom/return',
      scopes: oktaAuthMock.options.scopes
    });
  });

  it('should call oktaAuth.signOut', async () => {
    await service.signOut();
    expect(oktaAuthMock.signOut).toHaveBeenCalled();
  });

  it('should handle errors in signInWithRedirect', async () => {
    const error = new Error('redirect error');
    oktaAuthMock.token.getWithRedirect.and.returnValue(Promise.reject(error));
    spyOn(console, 'error');
    await service.signInWithRedirect();
    expect(console.error).toHaveBeenCalledWith('Error initiating a login redirect', error);
  });

  it('should handle errors in signOut', async () => {
    const error = new Error('signout error');
    oktaAuthMock.signOut.and.returnValue(Promise.reject(error));
    spyOn(console, 'error');
    await service.signOut();
    expect(console.error).toHaveBeenCalledWith('Error during sign out', error);
  });
});
