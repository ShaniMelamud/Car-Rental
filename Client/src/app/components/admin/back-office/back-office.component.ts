import { Component, OnDestroy, OnInit } from '@angular/core';
import { Unsubscribe } from 'redux';
import { store } from 'src/app/redux/store';

@Component({
    selector: 'app-back-office',
    templateUrl: './back-office.component.html',
    styleUrls: ['./back-office.component.css']
})
export class BackOfficeComponent implements OnInit, OnDestroy {

    public user = store.getState().user;
    private unsubscribe: Unsubscribe;
  
    ngOnInit(): void {
        this.unsubscribe = store.subscribe(()=>{
            this.user = store.getState().user;
        });
    }

    public ngOnDestroy():void{
        this.unsubscribe();
    }


}
