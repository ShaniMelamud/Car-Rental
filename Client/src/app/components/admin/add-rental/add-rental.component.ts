import { RentalsService } from './../../../services/rentals.service';
import { Component, OnInit } from '@angular/core';
import { RentalModel } from 'src/app/models/rental.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-rental',
  templateUrl: './add-rental.component.html',
  styleUrls: ['./add-rental.component.css']
})
export class AddRentalComponent implements OnInit {

    public newRental: RentalModel = new RentalModel();

    constructor(private rentalsService: RentalsService, private router: Router) { }

    ngOnInit(): void { }

    public async AddRental() {
        try {
            let addedRental: RentalModel = this.newRental;
            await this.rentalsService.addRental(addedRental);
            alert("Rental has been added.")
            this.router.navigateByUrl('/home');
        } catch (err) { console.log(err.message) };
    }

}
