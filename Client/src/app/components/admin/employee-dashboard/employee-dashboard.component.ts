import { UserModel } from './../../../models/user.model';
import { Unsubscribe } from 'redux';
import { FullRentalModel } from './../../../models/full-rental.model';
import { Component, OnInit } from '@angular/core';
import { store } from 'src/app/redux/store';
import { RentalsService } from 'src/app/services/rentals.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-employee-dashboard',
    templateUrl: './employee-dashboard.component.html',
    styleUrls: ['./employee-dashboard.component.css']
})
export class EmployeeDashboardComponent implements OnInit {

    public fullRentals: FullRentalModel[];
    public fullRentalsToShow: FullRentalModel[];
    public fullRental: FullRentalModel;
    public unsubscribe: Unsubscribe;
    public changeStr: string = "";


    constructor(private rentalService: RentalsService, private router: Router) { 

    }

    ngOnInit(): void {
        this.loadAllRentals();
    }
    public loadAllRentals() {
        this.unsubscribe = store.subscribe(() => {
            this.fullRentals = store.getState().fullRentals;
            this.fullRentalsToShow = [...this.fullRentals]
        });

        if (store.getState().fullRentals.length > 0) {
            this.fullRentals = store.getState().fullRentals;
            this.fullRentalsToShow = [...this.fullRentals]
        }
        else {
            setTimeout(async () => {
                try {
                    await this.rentalService.loadAllFullRentalsAsync();
                }
                catch (err) { console.log("error: " + err.massage); }
            }, 1000);
        }
    }

    public async ReportCarReturn() {
        try {
            // this.fullRental.rentalModel.finalReturnTime = new Date();
            // this.fullRental.rentalModel.finalPrice = this.fullRental.rentalModel.finalReturnTime >
            //  this.fullRental.rentalModel.returnTime ?
            //     this.fullRental.rentalModel.expectedPrice +
            //     (this.fullRental.carModel.carType.pricePerDay *
            //         (this.fullRental.rentalModel.finalReturnTime.getDay() -
            //             this.fullRental.rentalModel.returnTime.getDay())) : this.fullRental.rentalModel.expectedPrice
            await this.rentalService.UpdateRental(this.fullRental.rentalModel);
            alert('Rental has been updated')
            this.router.navigateByUrl('/home');
        }
        catch (err) { console.log(err.message) };
    }
    public GetSingleFullRentalById(id: number) {
        this.fullRental = this.fullRentals.find(r => r.rentalModel?.id === id);
    }
    public search(){
        this.fullRentalsToShow = this.fullRentals.filter(u =>
            u.userModel.userName
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
            ||
            u.branchModelPickUp.name
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
            ||
            u.branchModelReturn.name
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
        );
    }
}
