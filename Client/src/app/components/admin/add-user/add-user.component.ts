import { Router } from '@angular/router';
import { UsersService } from './../../../services/users.service';
import { UserModel } from './../../../models/user.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

    public newUser: UserModel = new UserModel();

  constructor(private userService: UsersService, private router: Router) { }

  ngOnInit(): void {
  }

  public async AddUser() {
    try {
        let addedUser: UserModel = this.newUser;
        await this.userService.addUser(addedUser);
        alert("User has been added.")
        this.router.navigateByUrl('/home');
    } catch (err) { console.log(err.message) };
}
}
