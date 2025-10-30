import { Component } from '@angular/core';
import { OktaAuthWrapperService } from './okta-auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'GCConnect.Client';
  isAuthenticated = false;

  constructor(private oktaService: OktaAuthWrapperService) {
    this.oktaService.authState$.subscribe(state => {
      this.isAuthenticated = !!state.isAuthenticated;
    });
  }

  login() {
    window.location.assign('/login');
  }

  logout() {
    window.location.assign('/logout');
  }
}
