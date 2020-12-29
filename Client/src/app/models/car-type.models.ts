export class CarTypeModel {
    public constructor(
        public id?: number,
        public manufacturer?: string,
        public model?: string,
        public pricePerDay?: number,
        public image?: File,
        public imageFileName?: string
    ){}
}