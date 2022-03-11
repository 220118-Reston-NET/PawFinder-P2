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
  
  userGroup= new FormGroup({
    userID:new FormControl(""),
    userName: new FormControl(),
    uesrPassword:new FormControl(),
    userDBO: new FormControl(),
    userBio:new FormControl(),
    userBreed:new FormControl(),
    userSize:new FormControl()
    
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
    // if(p_userGroup.valid){

    // }
    let user:Users=
    {
      //userID:p_userGroup.get("userID")?.value,
      userName:p_userGroup.get("userName")?.value,
      userPassword:p_userGroup.get("password")?.value,
      userDBO:p_userGroup.get("userDBO")?.value,
      userBio:p_userGroup.get("userBio")?.value,
      userBreed:p_userGroup.get("userBreed")?.value,
      userSize:p_userGroup.get("userSize")?.value,
    }
    
    this.userService.addUser(user).subscribe();

  }

  Registor() 
  {
    this.router.navigate(["/registor"]);
  }

}
