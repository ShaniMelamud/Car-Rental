import { FullRentalModel } from './../models/full-rental.model';
import { CarModel } from './../models/car.model';
import { BranchModel } from './../models/branch.model';
import { RentalModel } from './../models/rental.model';
import { CarDataModel } from '../models/car-data.model';
import { CarTypeModel } from './../models/car-type.models';
import { UserModel } from '../models/user.model';
export class AppState {
    public cars: CarModel[] = [];
    public carsTypes: CarTypeModel[] = [];
    public carsData: CarDataModel[] = [];
    public rentals: RentalModel[] = [];
    public fullRentals: FullRentalModel[] = [];
    public branches: BranchModel[] = [];
    public users: UserModel[] = [];
    public user: UserModel = null;
    public constructor() {
        this.user = JSON.parse(sessionStorage.getItem("user"));
     }
}