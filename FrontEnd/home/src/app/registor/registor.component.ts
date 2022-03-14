import { Users } from './../models/users.model';
import { FormGroup, FormControl } from '@angular/forms';
import { Component, OnInit} from '@angular/core';
import { Router } from "@angular/router";
import { NavbarService } from '../services/navbar.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-registor',
  templateUrl: './registor.component.html',
  styleUrls: ['./registor.component.css']
})
export class RegistorComponent implements OnInit{
  
  myResult:any;

  userGroup= new FormGroup({
    userName: new FormControl(""),
    userPassword:new FormControl(""),
    userDBO: new FormControl(""),
    userBio:new FormControl(""),
    userBreed:new FormControl(""),
    userSize:new FormControl("")    
  });

  show:boolean = false;
  
  constructor(private router: Router, private userService: UserService, public nav: NavbarService) {
  }

  ngOnInit(): void {
    this.nav.hide();
  }

  showPassword()
  {
    this.show = !this.show;
  }

  addUser(p_userGroup:FormGroup){

    let user:Users=
    {
      userID:0,
      userName:p_userGroup.get("userName")?.value,
      userPassword:p_userGroup.get("userPassword")?.value,
      userDBO:p_userGroup.get("userDBO")?.value,
      userBio:p_userGroup.get("userBio")?.value,
      userBreed:p_userGroup.get("userBreed")?.value,
      userSize:p_userGroup.get("userSize")?.value,
      userImg:""
    }
  
    this.userService.addUser(user).subscribe(result => {if(result) {this.router.navigate(["/Profile"])}});

  }

  Registor() 
  {
    this.router.navigate(["/Registor"]);
  }

}
