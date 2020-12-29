import { AuthService } from './../../services/auth.service';
import { UserModel } from './../../models/user.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-sign-up',
    templateUrl: './sign-up.component.html',
    styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit{

    public radio_button_value = null;

    public box_options = [
        {
            "name": "Male",
            "value": "male",
        },
        {
            "name": "Female",
            "value": "female"
        },
        {
            "name": "Other",
            "value": "other"
        }
    ]

    public user = new UserModel();
    public todaysdate;

    constructor(private auth: AuthService, private router: Router) { }
    ngOnInit(): void {
        this.todaysdate = new Date()
    }

    public async register() {
         this.user.registerDate = this.todaysdate;
        const succes = await this.auth.register(this.user);
        if (succes) {
            this.router.navigateByUrl("/home");
        }
    }
}
