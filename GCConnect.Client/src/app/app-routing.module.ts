import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OktaAuthGuard, OktaCallbackComponent } from '@okta/okta-angular';
import { AppComponent } from './app.component';
import { ROUTES } from './common/constants/routes.constants';

const routes: Routes = [
  {
    path: ROUTES.root,
    component: AppComponent,
  },
  {
    path: ROUTES.loginCallback,
    component: OktaCallbackComponent,
  },
  {
    path: ROUTES.profile,
    loadChildren: () => import('./modules/profile.module').then(m => m.ProfileModule),
    canActivate: [OktaAuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
