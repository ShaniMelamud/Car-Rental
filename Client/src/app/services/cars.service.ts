import { CarModel } from './../models/car.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Action } from '../redux/action';
import { ActionType } from '../redux/action-type';
import { store } from '../redux/store';

@Injectable({
  providedIn: 'root'
})
export class CarsService {

  constructor(private http: HttpClient) {}
  public async loadAllCarsAsync(): Promise<boolean> {
    try {
        const cars = await this.http
            .get<CarModel[]>(environment.CarsBaseUrl)
            .toPromise();
        const action: Action = { type: ActionType.GetAllCars, payload: cars }
        store.dispatch(action);
        return true
    }
    catch (err) {
        console.log(err)
        return false;
    }
}
}
