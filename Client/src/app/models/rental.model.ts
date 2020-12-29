import { UserModel } from './user.model';
import { CarDataModel } from './car-data.model';
import { BranchModel } from './branch.model';
export class RentalModel {
    public constructor(
        public id?: number,
        public carDataId?: number,
        public userId?: number,
        public branchStartId?: number,
        public branchEndId?: number,
        public pickUpTime?: Date,
        public returnTime?: Date,
        public finalReturnTime?: Date,
        public expectedPrice?: number,
        public finalPrice?: number,
    ){}
}