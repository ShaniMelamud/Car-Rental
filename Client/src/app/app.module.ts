import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './components/home/home.component';
import { LayoutComponent } from './components/layout/layout.component';
import { HeaderComponent } from './components/header/header.component';
import { MenuComponent } from './components/menu/menu.component';
import { FooterComponent } from './components/footer/footer.component';
import { AboutComponent } from './components/about/about.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { ContactUsComponent } from './components/contact-us/contact-us.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { CarsComponent } from './components/cars/cars.component';

@NgModule({
  declarations: [
    HomeComponent,
    LayoutComponent,
    HeaderComponent,
    MenuComponent,
    FooterComponent,
    AboutComponent,
    PageNotFoundComponent,
    ContactUsComponent,
    SignUpComponent,
    LoginComponent,
    LogoutComponent,
    CarsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [LayoutComponent]
})
export class AppModule { }
