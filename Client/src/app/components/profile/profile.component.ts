import { UsersService } from './../../services/users.service';
import { Component, OnInit } from '@angular/core';
import { Unsubscribe } from 'redux';
import { store } from 'src/app/redux/store';
import { Router } from '@angular/router';

@Component({
    selector: 'app-profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

    public user = store.getState().user;
    public unsubscribe: Unsubscribe;

    constructor(private userService: UsersService, private router: Router) { }

    ngOnInit(): void {
        this.unsubscribe = store.subscribe(() => {
            this.user = store.getState().user;
        })
    }

    public async updateUser(){
        try{
            const updatedUser = await this.userService.UpdateUser(this.user);
            alert('Profile has been updated: ' + this.user.id);
            this.router.navigateByUrl('/home');
        }
        catch(err){console.log(err.message)}
    }
    
}
