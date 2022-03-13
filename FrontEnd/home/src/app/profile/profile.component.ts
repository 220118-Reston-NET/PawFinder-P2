import { Component, OnInit } from '@angular/core';
import { PawfinderService } from './../services/pawfinder.service';
import { Users } from './../models/users.model';
import { ActivatedRoute} from '@angular/router';
import { NavbarService } from '../services/navbar.service';
import { UserService } from '../services/user.service';
import { FormControl, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
 userName:string | null = "No users Selected";

 show:boolean = true;

 userGroup= new FormGroup({
  userName: new FormControl(""),
  userPassword:new FormControl(""),
  userDBO: new FormControl(""),
  userBio:new FormControl(""),
  userBreed:new FormControl(""),
  userSize:new FormControl("")    
});

// Users:PawfinderApi;
 Users: any;
  constructor(private router:ActivatedRoute, private PawService:PawfinderService, public nav: NavbarService, private userService: UserService) {
    this.Users={ sprites: {
      back_default:"",
      back_shiny:"",
      front_default:"",
      front_shiny:""
    }};
   }

  ngOnInit(): void {
    // this.userName = this.router.snapshot.paramMap.get("userName");
    // this.PawService.getAllUsers(this.userName).subscribe(result=>{
    //   this.Users=result;
    // });
    this.nav.show();
  }

  updateUserInfo(p_userGroup:FormGroup){

    let user:Users=
    {
      userName:p_userGroup.get("userName")?.value,
      userPassword:p_userGroup.get("userPassword")?.value,
      userDBO:p_userGroup.get("userDBO")?.value,
      userBio:p_userGroup.get("userBio")?.value,
      userBreed:p_userGroup.get("userBreed")?.value,
      userSize:p_userGroup.get("userSize")?.value,
    }
    
    this.userService.updateUser(user).subscribe();

  }

  matchColorPinck()
  {
    return 
  }

}
