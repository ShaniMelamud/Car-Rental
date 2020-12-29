import { Component, OnDestroy, OnInit } from '@angular/core';
import { Unsubscribe } from 'redux';
import { store } from 'src/app/redux/store';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit, OnDestroy {

  public user = store.getState().user;
  public greetings = this.getGreetings();
  private unsubscribe: Unsubscribe;

  ngOnInit(): void {
      this.unsubscribe = store.subscribe(()=>{
          this.user = store.getState().user;
          this.greetings = this.getGreetings();
      });
  }

  private getGreetings(): string{
      return `Hello, ${this.user ? this.user.firstName : "Guest"}`;
  }

  public ngOnDestroy():void{
      this.unsubscribe();
  }

  
}
