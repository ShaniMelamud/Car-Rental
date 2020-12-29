import { BranchesService } from './../../services/branches.service';
import { BranchModel } from './../../models/branch.model';
import { HttpClient } from '@angular/common/http';
import { CarDataModel } from './../../models/car-data.model';
import { RentalsService } from './../../services/rentals.service';
import { RentalModel } from './../../models/rental.model';
import { CarsTypeService } from './../../services/cars-type.service';
import { CarTypeModel } from './../../models/car-type.models';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Unsubscribe } from 'redux';
import { store } from 'src/app/redux/store';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
    selector: 'app-cars',
    templateUrl: './cars.component.html',
    styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {

    // public images = [944, 1011, 984].map((n) => `https://picsum.photos/id/${n}/900/500`);



    public endDate: Date;
    public startDate: Date;
    public activityCarsData: CarDataModel[];
    public activityCarsDatatoShow: CarDataModel[];
    public carDataId: number;
    public carType: CarTypeModel;
    public newRental = new RentalModel();
    public user = store.getState().user;
    public pricePerDay: number;
    public changeStr: string = "";



    public dateSent;
    public dateReceived;
    public todaysdate;


    @ViewChild('startDate') myStartDate: ElementRef;
    @ViewChild('endDate') myEndDate: ElementRef;

    constructor(
        private router: Router,
        private carTypesService: CarsTypeService,
        private modalService: NgbModal,
        private rentalService: RentalsService,
    ) { }

     ngOnInit() {
        this.todaysdate = new Date()
    }
    public getSingleCarTypeByID(id: number) {
        console.log(this.activityCarsData[0])
        this.carType = this.activityCarsData.find(c => c.carTypeId === id).carType;
    }
    public search() {
        this.activityCarsDatatoShow = this.activityCarsData.filter(c =>
            c.carType.manufacturer
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
            ||
            c.carType.model
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
            ||
            c.gear
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
        );
    }
    public setEndDate(event) {
        this.endDate = event.target.value;
    }
    public setStartDate(event) {
        this.startDate = event.target.value;
    }
    public SetPricePerDate(event) {
        this.pricePerDay = event.target.value;
    }
    public SetCarDataId(id: number) {
        console.log("set " + id)
        this.carDataId = id;
    }
    public async getActivityCarsData() {
        try {

            this.activityCarsData = await this.carTypesService.loadAllActivityCarsDatasAsync(this.startDate, this.endDate);
            if (this.activityCarsData.length < 1) {
                alert('There is no available cars in this dates.')
            }
            for (const item of this.activityCarsData) {
                item.carType.imageFileName = `${environment.CarsTypeImagesBaseUrl}/${item.carType.imageFileName}`;
            }
            this.activityCarsDatatoShow = [...this.activityCarsData];

        }
        catch (err) { console.log(err) };
    }
    public calculatePriceWithDays(pricePerDay: number,): number {
        const days: any = this.calculateDays(this.startDate, this.endDate);
        let results = days * (pricePerDay);
        if (days === 0)
            results += pricePerDay;
        return results;
    }
    public calculateDays(start: Date, end: Date) {

        start = new Date(start);
        end = new Date(end);
        if (start < new Date() || end < start) {

            return 0;
        }
        return Math.floor((Date.UTC(end.getFullYear(), end.getMonth(), end.getDate()) -
            Date.UTC(start.getFullYear(), start.getMonth(), start.getDate())) / (1000 * 60 * 60 * 24));
    }
    // this function open dialog - car invite
    public openLg(content) {

        this.modalService.open(content, { size: 'lg' });
    }

    public async AddRental() {
        try {
            console.log(this.carDataId)
            this.newRental.carDataId = this.GetCarDataIdForRent(this.carDataId);
            this.newRental.pickUpTime = this.startDate;
            this.newRental.returnTime = this.endDate;
            this.newRental.expectedPrice = this.calculatePriceWithDays(this.carType?.pricePerDay)
            this.newRental.userId = this.user?.id;
            const success = await this.rentalService.addRental(this.newRental);
            if (success)
                this.router.navigateByUrl('/home');
        }
        catch (err) { console.log("Error: " + err) }
    }
    public GetCarDataIdForRent(id: number): number {
        const carDataId = this.activityCarsData.find(c => c.id == id).id;
        return carDataId;
    }


}
