import { CarDataModel } from './../models/car-data.model';
import { observable, Observable } from 'rxjs';
import { Action } from './../redux/action';
import { CarTypeModel } from './../models/car-type.models';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ActionType } from '../redux/action-type';
import { store } from '../redux/store';

@Injectable({
    providedIn: 'root'
})
export class CarsTypeService {

    constructor(private http: HttpClient) { }

    public async loadAllCarsTypesAsync(): Promise<boolean> {
        try {
            const carsTypes = await this.http
                .get<CarTypeModel[]>(environment.CarsTypeBaseUrl)
                .toPromise();
            const action: Action = { type: ActionType.GetAllCarsTypes, payload: carsTypes }
            store.dispatch(action);
            return true
        }
        catch (err) {
            console.log(err)
            return false;
        }
    }
    public async loadAllActivityCarsDatasAsync(start: Date, end: Date): Promise<CarDataModel[]> {
        
        const observable = this.http.get<CarDataModel[]>(environment.ActivityCarsTypeBaseUrl + `/${start}/${end}`);
        
        return observable.toPromise();

    }
    public addCarType(carTypeModel: CarTypeModel): Promise<undefined> {

        const formData = new FormData();
        formData.append('manufacturer', carTypeModel.manufacturer);
        formData.append('model', carTypeModel.model);
        formData.append('pricePerDay', carTypeModel.pricePerDay.toString());
        formData.append('image', carTypeModel.image, carTypeModel.image.name);

        return new Promise<undefined>((resolve, reject) => {
            this.http
                .post<CarTypeModel>(environment.CarsTypeBaseUrl, formData)
                .subscribe(addedCarType => {
                    const action: Action = { type: ActionType.AddCarType, payload: addedCarType };
                    store.dispatch(action);
                    return true;
                }, err => {
                    reject(err);
                });
        });
    }
    public UpdateCarType(carTypeModel: CarTypeModel): Promise<undefined> {

        return new Promise<undefined>((resolve, reject) => {
            this.http.put<CarTypeModel>(environment.CarsTypeBaseUrl + "/" + carTypeModel.id, carTypeModel)
                .subscribe(carType => {
                    const action: Action = { type: ActionType.UpdateCarType, payload: carType };
                    store.dispatch(action);
                    return true;
                }, err => {
                    reject(err);
                });
        });
    }

    public DeleteCarType(id: number): Promise<undefined> {
        return new Promise<undefined>((resolve, reject) => {
            this.http.delete<CarTypeModel>(environment.CarsTypeBaseUrl + "/" + id)
                .subscribe(() => {
                    const action: Action = { type: ActionType.DeleteCarType, payload: id };
                    store.dispatch(action);
                    return true;
                }, err => {
                    reject(err);
                });
        });
    }
}
