import { PawfinderService } from '../services/pawfinder.service';
import { User } from '../models/users.model';
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
  dropdownSize: string = "Choose size";
  dropdownBreed: string = "Choose breed";

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
  userSize: string = "";
  UserBreed: string = "";

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

    let user:User=
    {
      UserID:0,
      UserName:p_userGroup.get("userName")?.value,
      UserPassword:p_userGroup.get("userPassword")?.value,
      UserDOB:p_userGroup.get("userDOB")?.value,
      UserBio:p_userGroup.get("userBio")?.value,
      UserBreed:this.UserBreed,
      UserSize:this.userSize,
      pictureURL:""
    }
    
    this.userService.addUser(user).subscribe(result => {if(result) { GlobalComponent.loggedInUserID = result.UserID;
      GlobalComponent.loggedInUserName = result.UserName; this.router.navigate(["/Profile"]);}}, error => {this.isRegisterConflict = true;});

  }
   onFilechange(event: any)
    {
  //  console.log(event.target.files[0])
  //  this.file = event.target.files[0]
   }
 
  chooseBreed(p_breed:string)
  {
    this.UserBreed = p_breed;
    this.dropdownBreed = p_breed;
  }

  chooseSize(p_size:string)
  {
    this.userSize = p_size;
    this.dropdownSize = p_size;
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
