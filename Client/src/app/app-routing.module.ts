import { AddUserComponent } from './components/admin/add-user/add-user.component';
import { EmployeeGuard } from './services/employee.guard';
import { AdminGuard } from './services/admin.guard';
import { ProfileComponent } from './components/profile/profile.component';
import { LoginGuard } from './services/login.guard';
import { CarsComponent } from './components/cars/cars.component';
import { LogoutComponent } from './components/logout/logout.component';
import { LoginComponent } from './components/login/login.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { ContactUsComponent } from './components/contact-us/contact-us.component';
import { AboutComponent } from './components/about/about.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { RentalsComponent } from './components/rentals/rentals.component';
import { BranchesComponent } from './components/branches/branches.component';
import { BackOfficeComponent } from './components/admin/back-office/back-office.component';
import { ManageBranchesComponent } from './components/admin/manage-branches/manage-branches.component';
import { AddBranchComponent } from './components/admin/add-branch/add-branch.component';
import { ManageCarsComponent } from './components/admin/manage-cars/manage-cars.component';
import { ManageUsersComponent } from './components/admin/manage-users/manage-users.component';
import { ManageRentalsComponent } from './components/admin/manage-rentals/manage-rentals.component';
import { AddRentalComponent } from './components/admin/add-rental/add-rental.component';
import { EmployeeDashboardComponent } from './components/admin/employee-dashboard/employee-dashboard.component';
import { AddCarTypeComponent } from './components/admin/add-car-type/add-car-type.component';
import { AddCarDataComponent } from './components/admin/add-car-data/add-car-data.component';


const routes: Routes = [
    { path: "home", component: HomeComponent },
    { path: "about", component: AboutComponent },
    { path: "contact-us", component: ContactUsComponent },
    { path: "sign-up", component: SignUpComponent },
    { path: "login", component: LoginComponent },
    { path: "logout", canActivate: [LoginGuard], component: LogoutComponent },
    { path: "cars", component: CarsComponent },
    { path: "profile", canActivate: [LoginGuard], component: ProfileComponent },
    { path: "rentals", canActivate: [LoginGuard], component: RentalsComponent },
    { path: "branches", component: BranchesComponent },
    {
        path: "admin/back-office", canActivate: [EmployeeGuard], component: BackOfficeComponent, children: [
            { path: "manage-branches", component: ManageBranchesComponent },
            { path: "manage-branches/add-branch", component: AddBranchComponent },
            { path: "manage-cars", component: ManageCarsComponent },
            { path: "manage-users", component: ManageUsersComponent },
            { path: "manage-users/add-user", component: AddUserComponent },
            { path: "manage-rentals", component: ManageRentalsComponent },
            { path: "manage-rentals/add-rental", component: AddRentalComponent },
            { path: "employee-dashboard", component: EmployeeDashboardComponent },
            { path: "manage-cars/add-car-type", component: AddCarTypeComponent },
            { path: "manage-cars/add-car-data", component: AddCarDataComponent }
        ]
    },
    { path: "", redirectTo: "/home", pathMatch: "full" },
    { path: "**", component: PageNotFoundComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
