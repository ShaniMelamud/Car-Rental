import { BranchModel } from './../../../models/branch.model';
import { Router } from '@angular/router';
import { BranchesService } from './../../../services/branches.service';
import { Component, OnInit } from '@angular/core';
import { Unsubscribe } from 'redux';
import { store } from 'src/app/redux/store';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-manage-branches',
    templateUrl: './manage-branches.component.html',
    styleUrls: ['./manage-branches.component.css']
})
export class ManageBranchesComponent implements OnInit {

    public unsubscribe: Unsubscribe;
    public branches: BranchModel[];
    public branchesToShow: BranchModel[];
    public changeStr: string = "";
    public newBranch: BranchModel = new BranchModel();
    public branch: BranchModel;

    constructor(private branchesService: BranchesService, private router: Router, private modalService: NgbModal) { }

    ngOnInit(): void {
        this.loadAllBranches();
    }


    public loadAllBranches() {
        this.unsubscribe = store.subscribe(() => {
            this.branches = store.getState().branches;
            this.branchesToShow = [...this.branches]
        });

        if (store.getState().branches.length > 0) {
            this.branches = store.getState().branches;
            this.branchesToShow = [...this.branches]
        }
        else {
            setTimeout(async () => {
                try {
                    await this.branchesService.loadAllBranchesAsync();
                }
                catch (err) {
                    console.log("error: " + err.massage);
                }
            }, 1000);
        }
    }
    public async AddBranch() {
        try {
            let addedBranch: BranchModel = this.newBranch;
            await this.branchesService.addBranch(addedBranch)
            alert('New branch has been added!');
            this.router.navigateByUrl('/home');
        }
        catch (err) { console.log(err.message) }
    }
    public async UpdateBranch() {
        try {
            await this.branchesService.UpdateBranch(this.branch);
            alert("Branch has been updated");
            this.router.navigateByUrl('/home')
        }
        catch (err) { console.log(err.message) }
    }
    public async DeleteBranch(id: number) {
        try {
            await this.branchesService.DeleteBranch(id);
            this.branchesToShow = [...this.branches]
            this.router.navigateByUrl('/home');
        }
        catch (err) { console.log(err.message) }

    }
    public openLg(content) {
        this.modalService.open(content, { size: 'lg' });
    }
    public getSingleBranchByID(id: number) {
        this.branch = this.branches.find(b => b.id === id);
    }
    public search() {
        this.branchesToShow = this.branches.filter(b =>
            b.city
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
            ||
            b.country
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
            ||
            b.name
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
            ||
            b.email
                .toLocaleLowerCase()
                .includes(this.changeStr.toLocaleLowerCase())
        );
    }
}
