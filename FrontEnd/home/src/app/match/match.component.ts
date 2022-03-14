import { Component, OnInit } from '@angular/core';
import { Users } from '../models/users.model';
import { MatchService } from '../services/match.service';
import { NavbarService } from '../services/navbar.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-match',
  templateUrl: './match.component.html',
  styleUrls: ['./match.component.css']
})
export class MatchComponent implements OnInit {

  myUserID:number = 1;
  
  listOfUsers:Users[];
  sizeOfUsersList:number = 0;
 

  constructor(public nav: NavbarService, private userService: UserService, private matchservice: MatchService) { this.listOfUsers = []; }

  ngOnInit(): void {
    
    this.nav.show();

    this.matchservice.getMatches(this.myUserID).subscribe(result => {console.log(result); this.listOfUsers = result});

    this.sizeOfUsersList = this.listOfUsers.length;

  }

}
