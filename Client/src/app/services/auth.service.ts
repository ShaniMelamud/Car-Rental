import { CredentialsModel } from './../models/credentials-model';
import { Action } from './../redux/action';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { UserModel } from '../models/user.model';
import { store } from '../redux/store';
import { ActionType } from '../redux/action-type';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor(private http: HttpClient, private router: Router) { }

    public async register(userModel: UserModel): Promise<boolean> {
        try {
            const registeredUser =
                await this.http
                    .post<UserModel>
                    (environment.AuthBaseUrl + "/register", userModel)
                    .toPromise();

            const action: Action = { type: ActionType.Register, payload: registeredUser };
            store.dispatch(action);
            return true
        }
        catch (httpErrorRespons) {
            const action: Action = { type: ActionType.GotError, payload: httpErrorRespons }
            store.dispatch(action);
            return false;
        }
    }
    public async login(credentials: CredentialsModel): Promise<boolean> {
        try {
            const loggedInUser =
                await this.http
                    .post<UserModel>
                    (environment.AuthBaseUrl + "/login", credentials)
                    .toPromise();

            const action: Action = { type: ActionType.Login, payload: loggedInUser };
            store.dispatch(action);
            return true
        }
        catch (httpErrorRespons) {
            const action: Action = { type: ActionType.GotError, payload: httpErrorRespons }
            store.dispatch(action);
            return false;
        }
    }
    public logout(): void {
        const action: Action = { type: ActionType.Logout };
        store.dispatch(action);
    }
}
