import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Users } from '../models/users.model';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginSignUpHeading:String = "Login:"
  newOrExistingUser:String = "Don't have an account?"
  loginOrRegister:String = "Create an Account"

  show:boolean = false;

  userGroup = new FormGroup({

  })

  constructor() { }

  ngOnInit(): void {
  }

  showPassword()
  {
    this.show = !this.show;
  } 

  checkUser(p_userGroup:FormGroup)
  {
    if(this.loginOrRegister === "Login:")
    {
      
      // let user:Users =
      // {
      //   userID: 0,
      //   userName: p_userGroup.get("userName")?.value,
      //   userPassword: p_userGroup.get("password")?.value,
      //   userBio: "",
      //   userBreed: "",
      //   userSize: 0
      // }

    }
    else if(this.loginOrRegister === "Sign Up:")
    {
      console.log("User is signing up!");
    }
    else
    {
      //something is wrong and for some reason loginOrRegister does not have correct value.
      throwError;
    }
  }


}
