import { Notyf } from 'notyf';
import { environment } from 'src/environments/environment';
import { Action } from './action';
import { ActionType } from './action-type';
import { AppState } from './app-state';

const notify = new Notyf({ duration: 4000, ripple: false });

export function reducer(currentState: AppState, action: Action): AppState {
    const newState: AppState = { ...currentState };
    switch (action.type) {
      
        case ActionType.GetAllCars: {
            for (const car of action.payload) {
                car.carType.imageFileName = `${environment.CarsTypeImagesBaseUrl}/${car.carType.imageFileName}`;
            }
            newState.cars = action.payload;
            break;
        }
        case ActionType.GetAllCarsTypes: {
            for (const carType of action.payload) {
                carType.imageFileName = `${environment.CarsTypeImagesBaseUrl}/${carType.imageFileName}`;
            }
            newState.carsTypes = action.payload;
            break;
        }
        case ActionType.AddCarType: {
            action.payload.imageFileName = `${environment.CarsTypeImagesBaseUrl}/${action.payload.imageFileName}`;
            newState.carsTypes.push(action.payload);
            break
        }
        case ActionType.UpdateCarType: {
            const index = newState.carsTypes.findIndex(c => c.id === action.payload.id);
            newState.carsTypes[index] = action.payload;
        }
        case ActionType.DeleteCarType: {
            const index = newState.carsTypes.findIndex(c => c.id === action.payload)
            newState.carsTypes.splice(index, 1);
            break;
        }
        case ActionType.GetAllCarsData: {
            newState.carsData = action.payload;
            break;
        }
        case ActionType.AddCarData: {
            newState.carsData.push(action.payload);
            break
        }
        case ActionType.UpdateCarData: {
            const index = newState.carsData.findIndex(c => c.id === action.payload.id);
            newState.carsData[index] = action.payload;
        }
        case ActionType.DeleteCarData: {
            const index = newState.carsData.findIndex(c => c.id === action.payload)
            newState.carsData.splice(index, 1);
            break;
        }
        case ActionType.GetAllRentals: {
            newState.rentals = action.payload;
            break;
        }
        case ActionType.GetAllFullRentals: {
            newState.fullRentals = action.payload;
            break;
        }
        case ActionType.AddRental: {
            newState.rentals.push(action.payload);
            break
        }
        case ActionType.UpdateRental: {
            const index = newState.rentals.findIndex(r => r.id === action.payload.id);
            newState.rentals[index] = action.payload;
        }
        case ActionType.DeleteRental: {
            const index = newState.rentals.findIndex(r => r.id === action.payload)
            newState.rentals.splice(index, 1);
            break;
        }
        case ActionType.GetAllBranches: {
            newState.branches = action.payload;
            break;
        }
        case ActionType.AddBranch: {
            newState.branches.push(action.payload);
            break
        }
        case ActionType.UpdateBranch: {
            const index = newState.branches.findIndex(b => b.id === action.payload.id);
            newState.branches[index] = action.payload;
        }
        case ActionType.DeleteBranch: {
            const index = newState.branches.findIndex(b => b.id === action.payload)
            newState.branches.splice(index, 1);
            break;
        }
        case ActionType.GetAllUsers: {
            newState.users = action.payload;
            break;
        }
        case ActionType.AddUser: {
            newState.users.push(action.payload);
            break
        }
        case ActionType.UpdateUser: {
            const index = newState.users.findIndex(u => u.id === action.payload.id);
            newState.users[index] = action.payload;
        }
        case ActionType.DeleteUser: {
            const index = newState.users.findIndex(u => u.id === action.payload)
            newState.users.splice(index, 1);
            break;
        }
        case ActionType.Register:
        case ActionType.Login: {
            newState.user = action.payload;
            sessionStorage.setItem("user", JSON.stringify(newState.user));
            break;
        }
        case ActionType.Logout: {
            newState.user = null;
            sessionStorage.removeItem("user");
            break;
        }
    };
    return newState;
}