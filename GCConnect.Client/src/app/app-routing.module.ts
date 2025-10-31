import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OktaAuthGuard, OktaCallbackComponent } from '@okta/okta-angular';
import { HomeComponent } from './components/home/home.component';
import { ROUTES } from './common/constants/routes.constants';

const routes: Routes = [
  {
    path: ROUTES.root,
    component: HomeComponent,
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
