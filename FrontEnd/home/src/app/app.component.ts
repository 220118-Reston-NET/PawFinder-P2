// import { DOCUMENT } from '@angular/common';
// import { Component, Inject, OnInit } from '@angular/core';
// import { User } from './models/User';
// import { AccountService } from './services/account.service';

// @Component({
//   selector: 'app-root',
//   templateUrl: './app.component.html',
//   styleUrls: ['./app.component.css']
// })
// export class AppComponent implements OnInit{

//   constructor(
//     private accountService: AccountService,
//     @Inject(DOCUMENT) private doc: Document) {}
//   title = 'home';
//   users: any;

//   ngOnInit() {
//     this.setCurrentUser();
//   }

//   setCurrentUser(){
//     const user: User = JSON.parse(localStorage.getItem('user'));
//     if (user) {
//       this.accountService.setCurrentUser(user);
//     }
//   }
// }

import { Component, Inject, OnInit } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { User } from './models/User';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit{

  constructor(
    private accountService: AccountService,
    @Inject(DOCUMENT) private doc: Document) {}
  title = 'My-2-Cents-UI';
  users: any;

  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser(){
    const user: User = JSON.parse(localStorage.getItem('user') || '{}');
    if (user) {
      this.accountService.setCurrentUser(user);
    }
  }
}
