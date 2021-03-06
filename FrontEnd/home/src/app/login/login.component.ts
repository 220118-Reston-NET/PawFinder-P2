import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { User } from '../models/users.model';
import { NavbarService } from '../services/navbar.service';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { GlobalComponent } from '../global/global.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  show:boolean = false;
  passwordVisibility: string ="visibility";
  trySubmit:String = "";
  isloginConflict: boolean;
  responseMsg:string = "";

  loginGroup = new FormGroup({
    userName: new FormControl(""),
    userPassword:new FormControl(""),
    userDOB: new FormControl(""),
    userBio:new FormControl(""),
    userBreed:new FormControl(""),
    userSize:new FormControl("")
  });

  constructor(private router: Router, public nav: NavbarService, private loginService: LoginService) { this.isloginConflict = false; }

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

  login(p_loginGroup:FormGroup)
  {
    
    let loginGroup:User =
    {
      UserID: 0,
      UserName:p_loginGroup.get("userName")?.value,
      UserPassword:p_loginGroup.get("userPassword")?.value,
      UserDOB: new Date,
      UserBio: "",
      UserBreed: "",
      UserSize: "",
      pictureURL:""
    }
   
      this.loginService.verifyUser(loginGroup.UserName, loginGroup.UserPassword).subscribe(result => {if(result) {this.router.navigate(["/Profile"]); GlobalComponent.loggedInUserName = loginGroup.UserName;}}, error => {this.isloginConflict = true;});

  }

}
