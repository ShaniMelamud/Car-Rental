import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Notyf } from 'notyf';
import { store } from '../redux/store';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {

    public constructor(private router: Router) { }

    public canActivate(): boolean {

        if (store.getState().user?.role === "Admin")
            return true;

        const notify = new Notyf({ duration: 4000, ripple: false });
        notify.error("You are not admin!")

        // this.router.navigateByUrl("/login");

        return false;
    }
}
