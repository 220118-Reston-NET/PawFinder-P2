import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Users } from '../models/users.model';
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
  } 

  checkUser(p_loginGroup:FormGroup)
  {
    
    let loginGroup:Users =
    {
      userID: 0,
      userName:p_loginGroup.get("userName")?.value,
      userPassword:p_loginGroup.get("userPassword")?.value,
      userDOB: new Date,
      userBio: "",
      userBreed: "",
      userSize: "",
      userImg:""
    }
   
      this.loginService.verifyUser(loginGroup.userName, loginGroup.userPassword).subscribe(result => {if(result) {this.router.navigate(["/HomePage"]); GlobalComponent.loggedInUserName = loginGroup.userName;}}, error => {this.isloginConflict = true;});

  }

}
