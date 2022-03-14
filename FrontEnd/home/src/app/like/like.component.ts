import { Component, Input, OnInit } from '@angular/core';
import { Users } from '../models/users.model';
import { NavbarService } from '../services/navbar.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-like',
  templateUrl: './like.component.html',
  styleUrls: ['./like.component.css']
})
export class LikeComponent implements OnInit {
 @Input()Like:number | undefined;

 listOfUsers:Users[];
 sizeOfUsersList:number = 0;

  constructor(public nav: NavbarService, private userService: UserService) { this.listOfUsers = []; }

  ngOnInit(): void {
    
    this.nav.show();

    this.userService.getAllUsers().subscribe(result => {console.log(result); this.listOfUsers = result});

    this.sizeOfUsersList = this.listOfUsers.length;

  }

  

}
