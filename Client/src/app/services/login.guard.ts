import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Notyf } from 'notyf';
import { store } from '../redux/store';

@Injectable({
    providedIn: 'root'
})
export class LoginGuard implements CanActivate {

    public constructor(private router: Router) { }

    public canActivate(): boolean {

        if (store.getState().user)
            return true;

        const notify = new Notyf({ duration: 4000, ripple: false });
        notify.error("Please login!")

        // this.router.navigateByUrl("/login");

        return false;
    }

}
