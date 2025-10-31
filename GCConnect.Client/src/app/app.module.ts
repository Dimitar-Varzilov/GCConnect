import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { OktaAuthModule, OKTA_CONFIG } from '@okta/okta-angular';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OktaAuthFactory } from './okta-auth.factory';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    OktaAuthModule
  ],
  providers: [
    {
      provide: OKTA_CONFIG,
      useValue: OktaAuthFactory.createOktaAuth()
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
