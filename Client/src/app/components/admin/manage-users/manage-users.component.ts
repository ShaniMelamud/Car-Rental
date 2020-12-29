import { Router } from '@angular/router';
import { UsersService } from './../../../services/users.service';
import { UserModel } from './../../../models/user.model';
import { Unsubscribe } from 'redux';
import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { store } from 'src/app/redux/store';

@Component({
    selector: 'app-manage-users',
    templateUrl: './manage-users.component.html',
    styleUrls: ['./manage-users.component.css']
})
export class ManageUsersComponent implements OnInit {

    public unsubscribe: Unsubscribe;
    public users: UserModel[];
    public usersToShow: UserModel[];
    public changeStr: string = '';
    public newUser: UserModel = new UserModel();
    public user: UserModel;

    constructor(private usersService: UsersService, private router: Router, private modalService: NgbModal) { }

    ngOnInit(): void {
        this.loadAllUsers();
    }
    public loadAllUsers() {
        this.unsubscribe = store.subscribe(() => {
            this.users = store.getState().users;
            this.usersToShow = [...this.users];
        });
        if (store.getState().users.length > 0) {
            this.users = store.getState().users;
            this.usersToShow = [...this.users];
        }
        else {
            setTimeout(async () => {
                try {
                    await this.usersService.loadAllUsersAsync();
                }
                catch (err) {
                    console.log("error: " + err.massage);
                }
            }, 1000)
        }
    }
    public async updateUser() {
        try {
            await this.usersService.UpdateUser(this.user);
            alert("User has been updated");
            this.router.navigateByUrl('/home');
        }
        catch (err) { console.log(err.message) }
    }
    public async deleteUser(id: number) {
        try {
            await this.usersService.DeleteUser(id);
            this.usersToShow = [...this.users];
            this.router.navigateByUrl('/home');
        }
        catch (err) { console.log(err.message) }

    }
    public openLg(content) {
        this.modalService.open(content, { size: 'lg' });
    }
    public getSingleUserByID(id: number) {
        this.user = this.users.find(b => b.id === id);
    }
    public search() {
        this.usersToShow = this.users.filter(u =>
            u.email
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
            ||
            u.firstName
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
            ||
            u.lastName
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
            ||
            u.userName
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
                ||
            u.gender
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
                ||
            u.role
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
                ||
            u.licenseType
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
        );
    }
}
