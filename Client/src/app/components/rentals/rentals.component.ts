import { RentalsService } from './../../services/rentals.service';
import { RentalModel } from './../../models/rental.model';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-rentals',
    templateUrl: './rentals.component.html',
    styleUrls: ['./rentals.component.css']
})

export class RentalsComponent implements OnInit {

    public rentals: RentalModel[];

    constructor(private rentalsService: RentalsService) { }

    ngOnInit(): void {
        this.getRentalsForUser();
    }


    public async getRentalsForUser() {
        try {
            this.rentals = await this.rentalsService.loadAllRentalsForUserAsync();
        }
        catch (err) { console.log(err) };
    }
}
