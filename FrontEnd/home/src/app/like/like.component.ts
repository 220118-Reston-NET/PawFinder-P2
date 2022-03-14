import { Component, Input, OnInit } from '@angular/core';
import { Users } from '../models/users.model';
import { LikeService } from '../services/like.service';
import { NavbarService } from '../services/navbar.service';
import { UserService } from '../services/user.service';


@Component({
  selector: 'app-like',
  templateUrl: './like.component.html',
  styleUrls: ['./like.component.css']
})

export class LikeComponent implements OnInit {
  @Input()Like:number | undefined;
  
  myUserID:number = 2;
  
  listOfUsers:Users[];
  sizeOfUsersList:number = 0;
 

  constructor(public nav: NavbarService, private likeService: LikeService, private userService: UserService) { this.listOfUsers = []; }

  ngOnInit(): void {
    
    this.nav.show();

    this.userService.getAllUsers().subscribe(result => {console.log(result); this.listOfUsers = result});

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


