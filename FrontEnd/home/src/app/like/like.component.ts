import { Component, Input, OnInit } from '@angular/core';
import { GlobalComponent } from '../global/global.component';
import { Users } from '../models/users.model';
import { LikeService } from '../services/like.service';
import { MatchService } from '../services/match.service';
import { NavbarService } from '../services/navbar.service';
import { UserService } from '../services/user.service';


@Component({
  selector: 'app-like',
  templateUrl: './like.component.html',
  styleUrls: ['./like.component.css']
})

export class LikeComponent implements OnInit {
  @Input()Like:number | undefined;
  
  myUserID:number = GlobalComponent.loggedInUserID;
  
  listOfUsers:Users[];
  listOfMatchedUsers:Users[];
  filteredListOfUsers:Users[];
  sizeOfUsersList:number = 0;

  constructor(public nav: NavbarService, private likeService: LikeService, private userService: UserService, private matchservice: MatchService) { 
    this.listOfUsers = []; this.listOfMatchedUsers= []; this.filteredListOfUsers = []; }

  ngOnInit(): void {
    
    this.nav.show();

    this.userService.getAllUsers().subscribe(result => {console.log(result); this.listOfUsers = result});

    this.matchservice.getMatches(GlobalComponent.loggedInUserID).subscribe(result => {console.log(result); this.listOfMatchedUsers = result;});

    this.filteredListOfUsers = this.listOfUsers.filter( x => !this.listOfMatchedUsers.includes(x) );

    this.sizeOfUsersList = this.listOfUsers.length;



  }

  likeUser(p_likeeID:number, p_likerID:number)
  {
    this.likeService.likeAUser(p_likeeID, p_likerID).subscribe();
  }

  dislikeUser(p_passeeID:number, p_passerID:number)
  {
    this.likeService.DislikeAUser(p_passeeID, p_passerID).subscribe();

  }

}


