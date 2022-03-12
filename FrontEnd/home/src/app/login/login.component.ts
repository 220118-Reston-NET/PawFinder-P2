import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Users } from '../models/users.model';
import { throwError } from 'rxjs';
import { NavbarService } from '../services/navbar.service';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  show:boolean = false;
  trySubmit:String = "";

  userGroup = new FormGroup({ })

  constructor(private router: Router, public nav: NavbarService, private userService: UserService) { }

  ngOnInit(): void {
    this.nav.hide();
  }

  showPassword()
  {
    this.show = !this.show;
  } 

  checkUser(p_userGroup:FormGroup)
  {
    
    let user:Users = 
    {
      userName: p_userGroup.get("userName")?.value,
      userPassword: p_userGroup.get("userPassword")?.value,
      userDBO: new Date,
      userBio: "",
      userBreed: "",
      userSize: ""
    }

    this.userService.verifyUser(user).subscribe(result => {if(result) {this.router.navigate(["/Profile"])}});

  }


}
