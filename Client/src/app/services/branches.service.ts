import { BranchModel } from './../models/branch.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Action } from '../redux/action';
import { ActionType } from '../redux/action-type';
import { store } from '../redux/store';

@Injectable({
    providedIn: 'root'
})
export class BranchesService {

    constructor(private http: HttpClient) { }

    public async loadAllBranchesAsync(): Promise<boolean> {
        try {
            const branches = await this.http
                .get<BranchModel[]>(environment.BranchesBaseUrl)
                .toPromise();
            const action: Action = { type: ActionType.GetAllBranches, payload: branches };
            store.dispatch(action);
            return true;
        }
        catch (err) {
            console.log(err)
            return false;
        }
    }
    public addBranch(branchModel: BranchModel): Promise<undefined> {

        return new Promise<undefined>((resolve, reject) => {
            this.http
                .post<BranchModel>(environment.BranchesBaseUrl, branchModel)
                .subscribe(addedBranch => {
                    const action: Action = { type: ActionType.AddBranch, payload: addedBranch };
                    store.dispatch(action);
                    return true;
                }, err => {
                    reject(err);
                });
        });
    }
    public UpdateBranch(branchModel: BranchModel): Promise<undefined> {
        return new Promise<undefined>((resolve, reject) => {
            this.http.put<BranchModel>(
                environment.BranchesBaseUrl + "/" + branchModel.id, branchModel)
                .subscribe(branch => {
                    const action: Action = { type: ActionType.UpdateBranch, payload: branch };
                    store.dispatch(action);
                    return true;
                }, err => {
                    reject(err);
                });
        });
    }

    public DeleteBranch(id: number): Promise<undefined> {
        return new Promise<undefined>((resolve, reject) => {
            this.http.delete<BranchModel>(environment.BranchesBaseUrl + "/" + id)
                .subscribe(() => {
                    const action: Action = { type: ActionType.DeleteBranch, payload: id };
                    store.dispatch(action);
                    return true;
                }, err => {
                    reject(err);
                });
        });
    }
}