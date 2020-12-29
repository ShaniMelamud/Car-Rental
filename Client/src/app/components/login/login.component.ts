import { AuthService } from './../../services/auth.service';
import { CredentialsModel } from './../../models/credentials-model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent {

    public credentials = new CredentialsModel();

    constructor(private auth: AuthService, private router: Router) { }

    public async login() {
        const success = await this.auth.login(this.credentials);
        if (success) {
            this.router.navigateByUrl("/home");
        }
    }

}
