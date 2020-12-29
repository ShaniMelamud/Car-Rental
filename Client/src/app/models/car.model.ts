import { CarTypeModel } from './car-type.models';
import { CarDataModel } from './car-data.model';
export class CarModel{
    public constructor(
        public carData?: CarDataModel,
        public carType?: CarTypeModel
    ){}
}