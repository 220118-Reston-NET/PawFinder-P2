import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GlobalComponent } from '../global/global.component';
import { User } from '../models/users.model';
import { MatchService } from '../services/match.service';
import { NavbarService } from '../services/navbar.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-match',
  templateUrl: './match.component.html',
  styleUrls: ['./match.component.css']
})
export class MatchComponent implements OnInit {
  
  listOfUsers:User[];
  sizeOfUsersList:number = 0;
  myUserID = GlobalComponent.loggedInUserID;
  chattingWithUserID = 0;

  constructor(private router: Router, public nav: NavbarService, private userService: UserService, private matchservice: MatchService) { this.listOfUsers = []; }

  ngOnInit(): void {
    
    this.nav.show();

    this.matchservice.getMatches(this.myUserID).subscribe(result => {console.log(result); this.listOfUsers = result});

    this.sizeOfUsersList = this.listOfUsers.length;

  }

  chatwithUser(p_userID:number)
  {
    GlobalComponent.chattingUserID = p_userID;
    this.router.navigate(["/Chat"]);
  }

}
