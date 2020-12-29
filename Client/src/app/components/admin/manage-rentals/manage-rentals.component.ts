import { FullRentalModel } from './../../../models/full-rental.model';
import { Unsubscribe } from 'redux';
import { RentalsService } from './../../../services/rentals.service';
import { Component, OnInit } from '@angular/core';
import { store } from 'src/app/redux/store';
import { RentalModel } from 'src/app/models/rental.model';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-manage-rentals',
    templateUrl: './manage-rentals.component.html',
    styleUrls: ['./manage-rentals.component.css']
})
export class ManageRentalsComponent implements OnInit {


    public unsubscribe: Unsubscribe;
    public fullRentals: FullRentalModel[];
    public rentalsToShow: FullRentalModel[];
    public changeStr: string = "";
    public newRental: RentalModel = new RentalModel();
    public fullRental: FullRentalModel;


    constructor(private rentalService: RentalsService, private router: Router, private modalService: NgbModal) { }

    ngOnInit(): void {
        this.loadAllRentals();
    }


    public loadAllRentals() {
        this.unsubscribe = store.subscribe(() => {
            this.fullRentals = store.getState().fullRentals;
            this.rentalsToShow = [...this.fullRentals]
        });

        if (store.getState().fullRentals.length > 0) {
            this.fullRentals = store.getState().fullRentals;
            this.rentalsToShow = [...this.fullRentals]
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
    public async AddRental() {


        try {
            let addedRental: RentalModel = this.newRental;
            await this.rentalService.addRental(addedRental);
            alert("Rental has been added");
            this.router.navigateByUrl("/home");
        }
        catch (err) { console.log(err.message) };

    }
    public async UpdateRental() {
        try {
            await this.rentalService.UpdateRental(this.fullRental.rentalModel);
            alert('Rental has been updated')
            this.router.navigateByUrl('/home');
        }
        catch (err) { console.log(err) };
    }
    public async DeleteRental(id: number) {
        try {
            await this.rentalService.DeleteRental(id);
            this.rentalsToShow = [...this.fullRentals];
            this.router.navigateByUrl('/home')
        }
        catch (err) { console.log(err.message) }

    }
    public openLg(content) {

        this.modalService.open(content, { size: 'lg' });
    }
    public GetSingleFullRentalById(id: number) {
        this.fullRental = this.fullRentals.find(r => r.rentalModel?.id === id);
    }
    public searchRentals() {
        this.rentalsToShow = this.fullRentals.filter(u =>
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
