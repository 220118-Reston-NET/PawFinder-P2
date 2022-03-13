import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Users } from '../models/users.model';
import { throwError } from 'rxjs';
import { NavbarService } from '../services/navbar.service';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  show:boolean = false;
  trySubmit:String = "";

  loginGroup= new FormGroup({
    userName: new FormControl(""),
    userPassword:new FormControl(""),
    userDBO: new FormControl(""),
    userBio:new FormControl(""),
    userBreed:new FormControl(""),
    userSize:new FormControl("")
  });

  constructor(private router: Router, public nav: NavbarService, private loginService: LoginService) { }

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
      userName:p_loginGroup.get("userName")?.value,
      userPassword:p_loginGroup.get("userPassword")?.value,
      userDBO: new Date,
      userBio:"",
      userBreed:"",
      userSize: "",
    }

    this.loginService.verifyUser(loginGroup.userName, loginGroup.userPassword).subscribe(result => {if(result) {this.router.navigate(["/Profile"])}});

  }

}
