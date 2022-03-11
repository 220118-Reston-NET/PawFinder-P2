import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Users } from '../models/users.model';
import { throwError } from 'rxjs';
import { NavbarService } from '../services/navbar.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  show:boolean = false;
  trySubmit:String = "";

  userGroup = new FormGroup({ })

  constructor(public nav: NavbarService) { }

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
      //userID: 0,
      userName: p_userGroup.get("userName")?.value,
      userPassword: p_userGroup.get("password")?.value,
      userDBO: new Date,
      userBio: "",
      userBreed: "",
      userSize: ""
    }

  }


}
