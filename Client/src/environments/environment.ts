// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
const BaseUrl = "https://localhost:44384/api/"

export const environment = {
  production: false,
  CarsTypeBaseUrl: `${BaseUrl}CarsType`,
  CarsTypeImagesBaseUrl: `${BaseUrl}CarsType/images`,
  CarsBaseUrl: `${BaseUrl}Cars`,
  ActivityCarsTypeBaseUrl: `${BaseUrl}CarsType/activity_cars`,
  CarsDataBaseUrl: `${BaseUrl}CarsData`,
  UsersBaseUrl: `${BaseUrl}Users`,
  BranchesBaseUrl: `${BaseUrl}Branches`,
  RentalsBaseUrl: `${BaseUrl}Rentals`,
  AuthBaseUrl: `${BaseUrl}Auth`,
  rentalsForUsersBaseUrl: `${BaseUrl}Rentals/userRentals`
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
