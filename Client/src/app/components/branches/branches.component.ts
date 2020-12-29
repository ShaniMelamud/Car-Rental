import { BranchModel } from './../../models/branch.model';
import { Unsubscribe } from 'redux';
import { Component, OnInit } from '@angular/core';
import { store } from 'src/app/redux/store';
import { BranchesService } from 'src/app/services/branches.service';

@Component({
    selector: 'app-branches',
    templateUrl: './branches.component.html',
    styleUrls: ['./branches.component.css']
})
export class BranchesComponent implements OnInit {

    public unsubscribe: Unsubscribe;
    public branches: BranchModel[];
    public branchesToShow: BranchModel[];
    public changeStr: string = "";

    displayedColumns: string[] = ['id', 'name', 'country', 'city', 'email', 'phone', 'latitude', 'longitude'];
    dataSource;

    constructor(private branchesService: BranchesService) { }

    ngOnInit(): void {
        
        this.loadAllBranches()
        this.dataSource =  this.branches;
        
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
    public search(){}
}
