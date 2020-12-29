import { CarTypeModel } from './car-type.models';
export class CarDataModel  {
    public constructor(
        public id?: number,
        public carTypeId?: number,
        public kilometer?: number,
        public createAt?: Date,
        public gear?: string,
        public notes?: string,
        public image?: string,
        public branchId?: number,
        public carType?: CarTypeModel
    ){}
}