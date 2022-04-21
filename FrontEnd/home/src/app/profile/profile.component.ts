import { Component, OnInit } from '@angular/core';
import { PawfinderService } from './../services/pawfinder.service';
import { User } from './../models/users.model';
import { ActivatedRoute} from '@angular/router';
import { NavbarService } from '../services/navbar.service';
import { UserService } from '../services/user.service';
import { FormControl, FormGroup } from '@angular/forms';
import { GlobalComponent } from '../global/global.component';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  userID:number = 0;
  userName:string= "no user selected";
  userDOB:Date = new Date;
  userBio:string = "no user selected";
  userSize:string = "no user selected";
  userBreed:string = "no user selected";
  pictureURL: string = "no user selected";

  show:boolean = true;
  isEditingProfile:boolean = false;
  dropdownSize:string = "Edit size";

 userGroup= new FormGroup({
  userName: new FormControl(""),
  userPassword:new FormControl(""),
  userDOB: new FormControl(""),
  userBio:new FormControl(""),
  userBreed:new FormControl(""),
  userSize:new FormControl("")    
});

// Users:PawfinderApi;
  sizeOfUsersList:number = 0;

  constructor(private router:ActivatedRoute, private PawService:PawfinderService, public nav: NavbarService, private userService: UserService) {
  
  //   this.Users={ sprites: {
  //     back_default:"",
  //     back_shiny:"",
  //     front_default:"",
  //     front_shiny:""
  //   }};
  
  //       this.filteredListOfUser = [];
}

  ngOnInit(): void {
    this.nav.show();

    this.loadUser();
    
    // this.userName = this.router.snapshot.paramMap.get("userName");
    // this.service.getAllUsers().subscribe(result=>{
    //   this.Users=result;
    // });
    //   this.service.getAllUsers().subscribe(result => {
    //         console.log(result);
    //         this.listOfUsers = result;
    //         this.filteredListOfUser = result;
    //          // result.forEach(Users=>Users.userName);
    //     });
    
  }

  updateUserInfo(p_userGroup:FormGroup){

    let user:User=
    {
      UserID: this.userID,
      UserName:this.userName,
      UserPassword:"",
      UserDOB: new Date,
      UserBio:p_userGroup.get("userBio")?.value,
      UserBreed:"",
      UserSize:this.userSize,
      pictureURL:""
    }
    
    if(user.UserBio === "")
    {
      user.UserBio = this.userBio;
    }

    if(user.UserSize === "")
    {
      user.UserSize = this.userSize;
    }

    this.userService.updateUser(user).subscribe( () => { this.loadUser(); });

    this.userGroup.reset({userBio:"", userSize:""});

    this.isEditingProfile = false;

  }

  editProfile()
  {
    this.isEditingProfile = true;
  }

  goBack()
  {
    this.isEditingProfile = false;
    this.dropdownSize = "Edit size";
  }

  chooseSize(p_size:string)
  {
    this.userSize = p_size;
    this.dropdownSize = p_size;
  }

  loadUser()
  {
    this.userService.getUserByUserName(GlobalComponent.loggedInUserName).subscribe(result => 

      {GlobalComponent.loggedInUserID = result.UserID;
  
        let user:User=
        {
          UserID: result.UserID,
          UserName:result.UserName,
          UserPassword:"",
          UserDOB: result.UserDOB,
          UserBio:result.UserBio,
          UserBreed:result.UserBreed,
          UserSize:result.UserSize,
          pictureURL:result.pictureURL
        }
        
        this.userID = user.UserID;
        this.userName = user.UserName;
        this.userDOB = user.UserDOB;
        this.userBio= user.UserBio;
        this.userSize = user.UserSize;
        this.userBreed = user.UserBreed;
        this.pictureURL = user.pictureURL;
      });

  }

}
