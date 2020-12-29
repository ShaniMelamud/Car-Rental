import { BranchesService } from './../../../services/branches.service';
import { BranchModel } from './../../../models/branch.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-branch',
  templateUrl: './add-branch.component.html',
  styleUrls: ['./add-branch.component.css']
})
export class AddBranchComponent implements OnInit {

    public newBranch: BranchModel = new BranchModel();

    constructor(private branchesService: BranchesService, private router: Router) { }

    ngOnInit(): void { }

    public async AddBranch() {
        try {
            let addedBranch: BranchModel = this.newBranch;
            await this.branchesService.addBranch(addedBranch);
            alert("Branch has been added.")
            this.router.navigateByUrl('/home');
        } catch (err) { console.log(err.message) };
    }

}
