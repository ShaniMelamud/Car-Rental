export class UserModel {
    public constructor(
        public id?: number,
        public firstName?: string,
        public lastName?: string,
        public idCard?: string,
        public licenseNumber?: string,
        public licenseType?: string,
        public birthDate?: Date,
        public gender?: string,
        public email?: string,
        public phone?: string,
        public role?: string,
        public userName?: string,
        public password?: string,
        public jwtToken?: string,
        public registerDate?: Date
    ){}
}