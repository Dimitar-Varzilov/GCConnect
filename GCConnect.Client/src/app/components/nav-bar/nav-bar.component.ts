import { Component, OnInit } from '@angular/core';
import { OktaAuthStateService } from '@okta/okta-angular';
import { ROUTES_PATHS } from 'src/app/common/constants/routes.constants';
import { OktaAuthService } from 'src/app/services/okta-auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  isAuthenticated: boolean = false;

  readonly ROUTES_PATHS = ROUTES_PATHS

  constructor(public authService: OktaAuthService, private oktaStateService: OktaAuthStateService) { }

  ngOnInit(): void {
    this.oktaStateService.authState$.subscribe(authState => {
      this.isAuthenticated = authState.isAuthenticated ?? false;
    });
  }

}
