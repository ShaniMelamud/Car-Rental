import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Notyf } from 'notyf';
import { Observable } from 'rxjs';
import { store } from '../redux/store';

@Injectable({
    providedIn: 'root'
})
export class EmployeeGuard implements CanActivate {

    public constructor(private router: Router) { }

    public canActivate(): boolean {

        if (store.getState().user?.role === "Employee" || store.getState().user?.role === "Admin")
            return true;

        const notify = new Notyf({ duration: 4000, ripple: false });
        notify.error("This page is only for employees!")

        this.router.navigateByUrl("/login");

        return false;
    }

}
