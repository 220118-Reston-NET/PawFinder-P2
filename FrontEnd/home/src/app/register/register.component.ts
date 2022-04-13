import { PawfinderService } from '../services/pawfinder.service';
import { Users } from '../models/users.model';
import { FormGroup, FormControl } from '@angular/forms';
import { Component, OnInit} from '@angular/core';
import { Router } from "@angular/router";
import { NavbarService } from '../services/navbar.service';
import { UserService } from '../services/user.service';
import { GlobalComponent } from '../global/global.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{
  
  myResult:any;
  isRegisterConflict:boolean;

  userGroup= new FormGroup({
    userName: new FormControl(""),
    userPassword:new FormControl(""),
    userDOB: new FormControl(""),
    userBio:new FormControl(""),
    userBreed:new FormControl(""),
    userSize:new FormControl("")    
  });

  show:boolean = false;
  passwordVisibility: string = "visibility";

  constructor(private router: Router, private userService: UserService, public nav: NavbarService, public service:PawfinderService) { this.isRegisterConflict = false; }

  ngOnInit(): void {
    this.nav.hide();
  }

  showPassword()
  {
    this.show = !this.show;

    if(this.passwordVisibility === "visibility")
    {
      this.passwordVisibility = "visibility_off";
    }
    else
    {
      this.passwordVisibility = "visibility";
    }
  }

  Register(p_userGroup:FormGroup){

    let user:Users=
    {
      userID:0,
      userName:p_userGroup.get("userName")?.value,
      userPassword:p_userGroup.get("userPassword")?.value,
      userDOB:p_userGroup.get("userDOB")?.value,
      userBio:p_userGroup.get("userBio")?.value,
      userBreed:p_userGroup.get("userBreed")?.value,
      userSize:p_userGroup.get("userSize")?.value,
      userImg:""
    }
    
    this.userService.addUser(user).subscribe(result => {if(result) { GlobalComponent.loggedInUserID = result.userID;
      GlobalComponent.loggedInUserName = result.userName; this.router.navigate(["/HomePage"]);}}, error => {this.isRegisterConflict = true;});

  }
   onFilechange(event: any)
    {
  //  console.log(event.target.files[0])
  //  this.file = event.target.files[0]
   }
 
 upload() 
 {
      // if (this.file) {
      //   this.service.uploadfile(this.file).subscribe(resp => {
      //     alert("Uploaded")
      //   })
      // } 
      // else {
      //   alert("Please select a file first")
      // }
      // userImg:""
  }

  Registor() 
  {
    this.router.navigate(["/Register"]);
  }

}
