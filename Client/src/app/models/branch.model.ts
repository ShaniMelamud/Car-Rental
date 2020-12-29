export class BranchModel {
    public constructor(
        public id?: number,
        public name?: string,
        public country?: string,
        public city?: string,
        public longitude?: number,
        public latitude?: number,
        public phone?: string,
        public email?: string,
    ){}
}