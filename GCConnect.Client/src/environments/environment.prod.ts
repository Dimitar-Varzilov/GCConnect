import { ROUTES_PATHS } from "src/app/common/constants/routes.constants";

export const environment = {
  production: true,
  okta: {
    clientId: '0oawp7ttyirnoMful697', // TODO: Replace with your Okta clientId
    issuer: 'https://integrator-1333019.okta.com/oauth2/default', // TODO: Replace with your Okta domain,
    redirectUrl: window.location.origin + ROUTES_PATHS.loginCallback,
    scopes: ['openid', 'profile', 'email']
  }
};
