import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexModule } from '@angular/flex-layout';
import { HomeComponent } from './views/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { MaterialModule } from './material.module';
import { SigninComponent } from './views/auth/signin/signin.component';
import { SignupComponent } from './views/auth/signup/signup.component';
import { ReactiveFormsModule } from '@angular/forms';
import { OverlayModule } from '@angular/cdk/overlay';
import { FetchingComponent } from './components/fetching/fetching.component';
import { HeaderComponent } from './components/header/header.component';
import { DashboardComponent } from './views/dashboard/dashboard.component';
import { CookieService } from 'ngx-cookie-service';
import { ProgressBarComponent } from './components/progress-bar/progress-bar.component';
import { RankingComponent } from './views/dashboard/ranking/ranking.component';
import { CardScrollComponent } from './components/card-scroll/card-scroll.component';

@NgModule({
  declarations: [
    AppComponent,
    CardScrollComponent,
    DashboardComponent,
    FetchingComponent,
    HeaderComponent,
    HomeComponent,
    ProgressBarComponent,
    RankingComponent,
    SigninComponent,
    SignupComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    FlexModule,
    HttpClientModule,
    MaterialModule,
    OverlayModule,
    ReactiveFormsModule,
  ],
  exports: [
    HeaderComponent
  ],
  providers: [CookieService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
