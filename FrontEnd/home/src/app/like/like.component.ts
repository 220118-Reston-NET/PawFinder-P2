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
  sizeOfUsersList:number = 0;

  userID:number = 0;
  userName:string = "";
  userDOB:Date = new Date;
  userBio:string = "";
  userSize:string = "";
  userBreed:string = "";
  userImg:string = "";

  i:number = 0;

  constructor(public nav: NavbarService, private likeService: LikeService, private userService: UserService, private matchservice: MatchService) { 
    this.listOfUsers = []; }

  ngOnInit(): void {
    
    this.nav.show();

    this.userService.getPotentialMatch(GlobalComponent.loggedInUserID).subscribe(result => {console.log(result); this.listOfUsers = result;
      this.userID = result[0].userID;
      this.userName = result[0].userName;
      this.userDOB = result[0].userDOB;
      this.userBio= result[0].userBio;
      this.userSize = result[0].userSize;
      this.userBreed = result[0].userBreed;
      this.userImg = result[0].userImg;
    });

    this.sizeOfUsersList = this.listOfUsers.length;
  
  }

  likeUser(p_likeeID:number, p_likerID:number)
  {
    this.likeService.likeAUser(p_likeeID, p_likerID).subscribe();
    
    this.i = this.i + 1;

    let currentUser:Users=
    {
      userID: this.listOfUsers[this.i].userID,
      userName:this.listOfUsers[this.i].userName,
      userPassword:"",
      userDOB: this.listOfUsers[this.i].userDOB,
      userBio:this.listOfUsers[this.i].userBio,
      userBreed:this.listOfUsers[this.i].userBreed,
      userSize:this.listOfUsers[this.i].userSize,
      userImg:""
    }

    this.userID = currentUser.userID;
    this.userName = currentUser.userName;
    this.userDOB = currentUser.userDOB;
    this.userBio= currentUser.userBio;
    this.userSize = currentUser.userSize;
    this.userBreed = currentUser.userBreed;
    this.userImg = currentUser.userImg;
    
  }

  dislikeUser(p_passeeID:number, p_passerID:number)
  {
    this.likeService.DislikeAUser(p_passeeID, p_passerID).subscribe();

    this.i = this.i + 1;

    let currentUser:Users=
    {
      userID: this.listOfUsers[this.i].userID,
      userName:this.listOfUsers[this.i].userName,
      userPassword:"",
      userDOB: this.listOfUsers[this.i].userDOB,
      userBio:this.listOfUsers[this.i].userBio,
      userBreed:this.listOfUsers[this.i].userBreed,
      userSize:this.listOfUsers[this.i].userSize,
      userImg:""
    }

    this.userID = currentUser.userID;
    this.userName = currentUser.userName;
    this.userDOB = currentUser.userDOB;
    this.userBio= currentUser.userBio;
    this.userSize = currentUser.userSize;
    this.userBreed = currentUser.userBreed;
    this.userImg = currentUser.userImg;

  }

}


