import { CarsService } from './../../../services/cars.service';
import { CarModel } from './../../../models/car.model';
import { Router } from '@angular/router';
import { CarDataModel } from './../../../models/car-data.model';
import { CarTypeModel } from './../../../models/car-type.models';
import { Component, OnInit } from '@angular/core';
import { Unsubscribe } from 'redux';
import { store } from 'src/app/redux/store';
import { CarsDataService } from 'src/app/services/cars-data.service';
import { CarsTypeService } from 'src/app/services/cars-type.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-manage-cars',
    templateUrl: './manage-cars.component.html',
    styleUrls: ['./manage-cars.component.css']
})
export class ManageCarsComponent implements OnInit {

    public closeResult: string;
    public unsubscribe: Unsubscribe;
    public cars: CarModel[];
    public carsToShow: CarModel[];
    public carsTypes: CarTypeModel[];
    public carsTypesToShow: CarTypeModel[];
    public carsData: CarDataModel[];
    public carsDataToShow: CarDataModel[];
    public changeStr: string = "";
    public newCarData = new CarDataModel();
    public newCarType = new CarTypeModel();
    public carData: CarDataModel;
    public carType: CarTypeModel;


    constructor(
        private carDataService: CarsDataService,
        private carsTypesService: CarsTypeService,
        private carsService: CarsService,
        private router: Router,
        private modalService: NgbModal
    ) { }

    ngOnInit(): void {
        this.loadAllCarsTypes();
        this.loadAllCarsData();
        this.loadAllCars();
    }
    public loadAllCarsData() {
        this.unsubscribe = store.subscribe(() => {
            this.carsData = store.getState().carsData;
            this.carsDataToShow = [...this.carsData]
        });

        if (store.getState().carsData.length > 0) {
            this.carsData = store.getState().carsData;
            this.carsDataToShow = [...this.carsData]
        }
        else {
            setTimeout(async () => {
                try {
                    await this.carDataService.loadAllCarsDataAsync();
                }
                catch (err) {
                    console.log("error: " + err.massage);
                }
            }, 1000);
        }
    }
    public loadAllCars() {
        this.unsubscribe = store.subscribe(() => {
            this.cars = store.getState().cars;
            this.carsToShow = [...this.cars]
        });

        if (store.getState().cars.length > 0) {
            this.cars = store.getState().cars;
            this.carsToShow = [...this.cars]
        }
        else {
            setTimeout(async () => {
                try {
                    await this.carsService.loadAllCarsAsync();
                    // for (const car of cars) {
                    //     car.carType.imageFileName.imageFileName = `${environment.CarsTypeImagesBaseUrl}/${carType.imageFileName}`;
                    // }
                }
                catch (err) {
                    console.log("error: " + err.massage);
                }
            }, 1000);
        }
    }
    public loadAllCarsTypes() {
        this.unsubscribe = store.subscribe(() => {
            this.carsTypes = store.getState().carsTypes;
            this.carsTypesToShow = [...this.carsTypes]
        });

        if (store.getState().carsTypes.length > 0) {
            this.carsTypes = store.getState().carsTypes;
            this.carsTypesToShow = [...this.carsTypes]
        }
        else {
            setTimeout(async () => {
                try {
                    await this.carsTypesService.loadAllCarsTypesAsync();
                    console.log("carsTypes " + this.carsTypes);
                }
                catch (err) {
                    console.log("error: " + err.massage);
                }
            }, 1000);
        }
    }
    public async AddCarData() {
        try {
            let addedCarData: CarDataModel = this.newCarData;
            await this.carDataService.addCarData(addedCarData);
            alert("New car has been added");
            this.router.navigateByUrl("/home");
        }
        catch (err) { console.log(err.message) };
    }
    public async addCarType() {
        try {
            let addedCarType: CarTypeModel = this.newCarType;
            await this.carsTypesService.addCarType(addedCarType);
            alert("Car Type has been added.")
            this.router.navigateByUrl('home');
        }
        catch (err) { console.log(err.message) };
    }
    public async DeleteCarData(id: number) {
        try {
            await this.carDataService.DeleteCarData(id);
            this.carsDataToShow = [...this.carsData]
            this.router.navigateByUrl("/home");
        }
        catch (err) { console.log(err.message) }
    }
    public async DeleteCarType(id: number) {
        try {
            await this.carsTypesService.DeleteCarType(id);
            this.carsTypesToShow = [...this.carsTypes]
            this.router.navigateByUrl('home');
        }
        catch (err) { console.log(err.message) };
    }
    public async UpdateCarData() {
        try {
            await this.carDataService.UpdateCarData(this.carData);
            alert("Car has been updated.")
            this.router.navigateByUrl("/home");
        }
        catch (err) { console.log(err.message) };
    }
    public async UpdateCarType() {
        try {
            await this.carsTypesService.UpdateCarType(this.carType);
            alert("Car type has been updated.")
            this.router.navigateByUrl("/home");
        }
        catch (err) { console.log(err.message) };
    }
    public searchCars() {
        this.carsToShow = this.cars.filter(c =>
            c.carType.manufacturer
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
            ||
            c.carType.model
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
            ||
            c.carData.gear
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
            ||
            c.carData.notes
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
        );
    }
   
    public openLg(content) {
        this.modalService.open(content, { size: 'lg' });
    }
    public getSingleCarTypeAndCarDataByID(carTypeId: number, carDataId: number) {
        this.carType = this.cars.find(c => c.carType.id === carTypeId).carType;
        this.carData = this.cars.find(c => c.carData.id === carDataId).carData;
    }
}