import { Action } from './../redux/action';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CarDataModel } from '../models/car-data.model';
import { ActionType } from '../redux/action-type';
import { store } from '../redux/store';

@Injectable({
    providedIn: 'root'
})
export class CarsDataService {

    constructor(private http: HttpClient) { }

    public async loadAllCarsDataAsync(): Promise<boolean> {
        try {
            const carsData = await this.http
                .get<CarDataModel[]>(environment.CarsDataBaseUrl)
                .toPromise();
            const action: Action = { type: ActionType.GetAllCarsData, payload: carsData };
            store.dispatch(action);
            return true;
        }
        catch (err) {
            console.log(err)
            return false;
        }
    }
    public addCarData(carDataModel: CarDataModel): Promise<undefined> {

        return new Promise<undefined>((resolve, reject) => {
            this.http
                .post<CarDataModel>(environment.CarsDataBaseUrl, carDataModel)
                .subscribe(addedCarData => {
                    const action: Action = { type: ActionType.AddCarData, payload: addedCarData };
                    store.dispatch(action);
                    return true;
                }, err => {
                    reject(err);
                });
        });
    }
    public UpdateCarData(carDataModel: CarDataModel): Promise<undefined> {
        return new Promise<undefined>((resolve, reject) => {
            this.http.patch<CarDataModel>(
                environment.CarsDataBaseUrl + "/" + carDataModel.id, carDataModel)
                .subscribe(carData => {
                    const action: Action = { type: ActionType.UpdateCarData, payload: carData };
                    store.dispatch(action);
                   return true;
                }, err => {
                    reject(err);
                });
        });
    }

    public DeleteCarData(id: number): Promise<undefined> {
        return new Promise<undefined>((resolve, reject) => {
            this.http.delete<CarDataModel>(environment.CarsDataBaseUrl + "/" + id)
                .subscribe(() => {
                    const action: Action = { type: ActionType.DeleteCarData, payload: id };
                    store.dispatch(action);
                    return true;
                }, err => {
                    reject(err);
                });
        });
    }
}
