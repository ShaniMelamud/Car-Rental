import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserModel } from '../models/user.model';
import { Action } from '../redux/action';
import { ActionType } from '../redux/action-type';
import { store } from '../redux/store';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

    constructor(private http: HttpClient) { }

    public async loadAllUsersAsync(): Promise<boolean> {
        try {
            const users = await this.http
                .get<UserModel[]>(environment.UsersBaseUrl)
                .toPromise();
            const action: Action = { type: ActionType.GetAllUsers, payload: users };
            store.dispatch(action);
            return true;
        }
        catch (err) {
            console.log(err)
            return false;
        }
    }
    public addUser(userModel: UserModel): Promise<undefined> {

        return new Promise<undefined>((resolve, reject) => {
            this.http
                .post<UserModel>(environment.UsersBaseUrl, userModel)
                .subscribe(addedUser => {
                    const action: Action = { type: ActionType.AddUser, payload: addedUser };
                    store.dispatch(action);
                    return true;
                }, err => {
                    reject(err);
                });
        });
    }
    public UpdateUser(userModel: UserModel): Promise<undefined> {
        return new Promise<undefined>((resolve, reject) => {
            this.http.put<UserModel>(
                environment.UsersBaseUrl + "/" + userModel.id, userModel)
                .subscribe(user => {
                    const action: Action = { type: ActionType.UpdateUser, payload: user };
                    store.dispatch(action);
                    return true;
                }, err => {
                    reject(err);
                });
        });
    }

    public DeleteUser(id: number): Promise<undefined> {
        return new Promise<undefined>((resolve, reject) => {
            this.http.delete<UserModel>(environment.UsersBaseUrl + "/" + id)
                .subscribe(() => {
                    const action: Action = { type: ActionType.DeleteUser, payload: id };
                    store.dispatch(action);
                    return true;
                }, err => {
                    reject(err);
                });
        });
    }
}