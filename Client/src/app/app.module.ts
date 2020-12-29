import { EmployeeDashboardComponent } from './components/admin/employee-dashboard/employee-dashboard.component';
import { JwtInterceptorService } from './services/jwt-interceptor.service';
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
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { ProfileComponent } from './components/profile/profile.component';
import {MatCard, MatCardActions, MatCardContent, MatCardFooter, MatCardModule, MatCardSubtitle, MatCardTitle} from '@angular/material/card'
import {  MatButtonModule } from '@angular/material/button';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RentalsComponent } from './components/rentals/rentals.component';
import { CarPhotoComponent } from './components/car-photo/car-photo.component';
import { BranchesComponent } from './components/branches/branches.component';
import { BackOfficeComponent } from './components/admin/back-office/back-office.component';
import { ManageBranchesComponent } from './components/admin/manage-branches/manage-branches.component';
import { ManageUsersComponent } from './components/admin/manage-users/manage-users.component';
import { ManageCarsComponent } from './components/admin/manage-cars/manage-cars.component';
import { ManageRentalsComponent } from './components/admin/manage-rentals/manage-rentals.component';
import { AddCarTypeComponent } from './components/admin/add-car-type/add-car-type.component';
import { AddCarDataComponent } from './components/admin/add-car-data/add-car-data.component';
import { AddBranchComponent } from './components/admin/add-branch/add-branch.component';
import { AddRentalComponent } from './components/admin/add-rental/add-rental.component';
import { AddUserComponent } from './components/admin/add-user/add-user.component';
import { LogoComponent } from './components/logo/logo.component';

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
        CarsComponent,
        ProfileComponent,
        RentalsComponent,
        CarPhotoComponent,
        BranchesComponent,
        BackOfficeComponent,
         ManageBranchesComponent,
          ManageUsersComponent,
           ManageCarsComponent, 
           ManageRentalsComponent, 
           AddCarTypeComponent,
            AddCarDataComponent,
             EmployeeDashboardComponent, 
             AddBranchComponent, 
             AddRentalComponent,
              AddUserComponent,
              LogoComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        FormsModule,
        HttpClientModule,
        BrowserAnimationsModule,
        MatTableModule,
        MatCardModule,
        NgbModule,
        MatButtonModule,
        MatTableModule
        
        // MatCard,
        // MatCardTitle,
        // MatCardSubtitle,
        // MatCardContent,
        // MatCardActions,
        // MatCardFooter,
        // MatButton,
          
    ],
    providers: [{
        provide: HTTP_INTERCEPTORS,
        useClass: JwtInterceptorService,
        multi: true
    }],
    bootstrap: [LayoutComponent]
})
export class AppModule { }
