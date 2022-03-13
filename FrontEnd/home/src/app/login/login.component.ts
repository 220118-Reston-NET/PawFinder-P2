import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
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

  p_userName:String = "";
  p_userPW:String = "";

  loginGroup = new FormGroup({ })

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
