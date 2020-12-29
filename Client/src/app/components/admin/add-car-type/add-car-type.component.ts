import { CarsTypeService } from 'src/app/services/cars-type.service';
import { CarTypeModel } from './../../../models/car-type.models';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-add-car-type',
    templateUrl: './add-car-type.component.html',
    styleUrls: ['./add-car-type.component.css']
})
export class AddCarTypeComponent implements OnInit {
    
    public preview: string;
    public newCarType: CarTypeModel = new CarTypeModel();

    constructor(private carsTypesService: CarsTypeService, private router: Router) { }

    ngOnInit(): void {
    }

    public displayPreview(image: File): void {
        this.newCarType.image = image;
        const fileReader = new FileReader();
        fileReader.onload = args => this.preview = args.target.result.toString();
        fileReader.readAsDataURL(image);
    }
    public async AddCarType() {
        if (!this.preview) {
            alert("Please select image");
            return;
        }
        try {
            let addedCarType: CarTypeModel = this.newCarType;
            await this.carsTypesService.addCarType(addedCarType);
            alert("Car Type has been added.")
            this.router.navigateByUrl('home');
        } catch (err) { console.log(err.message) };

    }
    
}
