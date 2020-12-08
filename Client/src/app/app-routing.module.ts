import { CarsComponent } from './components/cars/cars.component';
import { LogoutComponent } from './components/logout/logout.component';
import { LoginComponent } from './components/login/login.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { ContactUsComponent } from './components/contact-us/contact-us.component';
import { AboutComponent } from './components/about/about.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';


const routes: Routes = [
    { path: "home", component: HomeComponent},
    { path: "about", component: AboutComponent},
    { path: "contact-us", component: ContactUsComponent},
    { path: "sign-up", component: SignUpComponent},
    { path: "login", component: LoginComponent},
    { path: "logout", component: LogoutComponent},
    { path: "cars", component: CarsComponent},
    { path: "", redirectTo: "/home", pathMatch: "full" },
    { path: "**", component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
