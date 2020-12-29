import { CarDataModel } from './../../../models/car-data.model';
import { CarsDataService } from './../../../services/cars-data.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-add-car-data',
    templateUrl: './add-car-data.component.html',
    styleUrls: ['./add-car-data.component.css']
})
export class AddCarDataComponent implements OnInit {

    public newCarData: CarDataModel = new CarDataModel();

    constructor(private carDataService: CarsDataService, private router: Router) { }

    ngOnInit(): void { }

    public async AddCarData() {
        try {
            let addedCarData: CarDataModel = this.newCarData;
            await this.carDataService.addCarData(addedCarData);
            alert("Car data has been added.")
            this.router.navigateByUrl('home');
        } catch (err) { console.log(err.message) };
    }
}
