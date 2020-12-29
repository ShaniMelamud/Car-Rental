import { CarModel } from './car.model';
import { BranchModel } from './branch.model';
import { UserModel } from './user.model';
import { RentalModel } from "./rental.model";

export class FullRentalModel {
    constructor(
        public rentalModel?: RentalModel,
        public userModel?: UserModel,
        public branchModelPickUp?: BranchModel,
        public branchModelReturn?: BranchModel,
        public carModel?: CarModel
    ){}
}