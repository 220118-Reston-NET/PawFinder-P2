import { Component, Input, OnInit } from '@angular/core';
import { GlobalComponent } from '../global/global.component';
import { User } from '../models/users.model';
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
  
  listOfUsers:User[];
  sizeOfUsersList:number = 0;

  userID:number = 0;
  userName:string = "";
  userDOB:Date = new Date;
  userBio:string = "";
  userSize:string = "";
  userBreed:string = "";
  userImg:string = "";
  
  showNextProfile: boolean = true;
  i:number = 0;

  constructor(public nav: NavbarService, private likeService: LikeService, private userService: UserService, private matchservice: MatchService) { 
    this.listOfUsers = []; }

  ngOnInit(): void {
    
    this.nav.show();

    this.userService.getPotentialMatch(GlobalComponent.loggedInUserID).subscribe(result => {console.log(result); this.listOfUsers = result;
      if(this.listOfUsers.length === 0)
      {
        this.showNextProfile = false;
      }
      else
      {
        this.userID = result[0].UserID;
        this.userName = result[0].UserName;
        this.userDOB = result[0].UserDOB;
        this.userBio= result[0].UserBio;
        this.userSize = result[0].UserSize;
        this.userBreed = result[0].UserBreed;
        this.userImg = result[0].pictureURL;
      }

    });

    this.sizeOfUsersList = this.listOfUsers.length;
  
  }

  likeUser(p_likeeID:number, p_likerID:number)
  {
    this.likeService.likeAUser(p_likeeID, p_likerID).subscribe();
    
    this.i = this.i + 1;
    if(this.i > this.sizeOfUsersList)
    {
      this.showNextProfile = false;
    }
    else
    {
      let currentUser:User=
      {
        UserID: this.listOfUsers[this.i].UserID,
        UserName:this.listOfUsers[this.i].UserName,
        UserPassword:"",
        UserDOB: this.listOfUsers[this.i].UserDOB,
        UserBio:this.listOfUsers[this.i].UserBio,
        UserBreed:this.listOfUsers[this.i].UserBreed,
        UserSize:this.listOfUsers[this.i].UserSize,
        pictureURL:this.listOfUsers[this.i].pictureURL
      }
      
      this.userID = currentUser.UserID;
      this.userName = currentUser.UserName;
      this.userDOB = currentUser.UserDOB;
      this.userBio= currentUser.UserBio;
      this.userSize = currentUser.UserSize;
      this.userBreed = currentUser.UserBreed;
      this.userImg = currentUser.pictureURL;
    }

    
  }

  dislikeUser(p_passeeID:number, p_passerID:number)
  {
    this.likeService.DislikeAUser(p_passeeID, p_passerID).subscribe();

    this.i = this.i + 1;
    if(this.i > this.sizeOfUsersList)
    {
      this.showNextProfile = false;
    }
    else
    {
      let currentUser:User=
      {
        UserID: this.listOfUsers[this.i].UserID,
        UserName:this.listOfUsers[this.i].UserName,
        UserPassword:"",
        UserDOB: this.listOfUsers[this.i].UserDOB,
        UserBio:this.listOfUsers[this.i].UserBio,
        UserBreed:this.listOfUsers[this.i].UserBreed,
        UserSize:this.listOfUsers[this.i].UserSize,
        pictureURL:this.listOfUsers[this.i].pictureURL
      }
    
      this.userID = currentUser.UserID;
      this.userName = currentUser.UserName;
      this.userDOB = currentUser.UserDOB;
      this.userBio= currentUser.UserBio;
      this.userSize = currentUser.UserSize;
      this.userBreed = currentUser.UserBreed;
      this.userImg = currentUser.pictureURL;
    }

  }

}


