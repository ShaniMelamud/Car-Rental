import { FullRentalModel } from './../models/full-rental.model';
import { RentalModel } from './../models/rental.model';
import { HttpClient } from '@angular/common/http';
import { Injectable, PipeTransform } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Action } from '../redux/action';
import { ActionType } from '../redux/action-type';
import { store } from '../redux/store';


@Injectable({
    providedIn: 'root'
})
export class RentalsService {

    constructor(private http: HttpClient) { }

    public async loadAllRentalsAsync(): Promise<boolean> {
        try {
            const rentals = await this.http
                .get<RentalModel[]>(environment.RentalsBaseUrl)
                .toPromise();
            const action: Action = { type: ActionType.GetAllRentals, payload: rentals };
            store.dispatch(action);
            return true;
        }
        catch (err) {
            console.log(err)
            return false;
        }
    }
    public async loadAllFullRentalsAsync(): Promise<boolean> {
        try {
            const fullRentals = await this.http
                .get<FullRentalModel[]>(environment.RentalsBaseUrl + "/full-rentals")
                .toPromise();
            const action: Action = { type: ActionType.GetAllFullRentals, payload: fullRentals };
            store.dispatch(action);
            return true;
        }
        catch (err) {
            console.log(err)
            return false;
        }
    }

    private user = JSON.parse(sessionStorage.getItem("user"))

    public async loadAllRentalsForUserAsync(): Promise<RentalModel[]> {
        console.log("user " + this.user.id)
        const observable = this.http.get<RentalModel[]>(environment.rentalsForUsersBaseUrl + `/${this.user.id}`);
        return observable.toPromise();

    }
    public addRental(rentalModel: RentalModel): Promise<undefined> {

        return new Promise<undefined>((resolve, reject) => {
            this.http
                .post<RentalModel>(environment.RentalsBaseUrl, rentalModel)
                .subscribe(addedRental => {
                    const action: Action = { type: ActionType.AddRental, payload: addedRental };
                    store.dispatch(action);
                    return true;
                }, err => {
                    reject(err);
                });
        });
    }
    public UpdateRental(rentalModel: RentalModel): Promise<undefined> {
        return new Promise<undefined>((resolve, reject) => {
            this.http.patch<RentalModel>(environment.RentalsBaseUrl + "/" + rentalModel.id, rentalModel)
                .subscribe(rental => {
                    const action: Action = { type: ActionType.UpdateRental, payload: rental };
                    store.dispatch(action);
                    return true;
                }, err => {
                    reject(err);
                });
        });
    }

    public DeleteRental(id: number): Promise<undefined> {
        return new Promise<undefined>((resolve, reject) => {
            this.http.delete<RentalModel>(environment.RentalsBaseUrl + "/" + id)
                .subscribe(() => {
                    const action: Action = { type: ActionType.DeleteRental, payload: id };
                    store.dispatch(action);
                    return true;
                }, err => {
                    reject(err);
                });
        });
    }
}