import { Component} from '@angular/core';
import { FormGroup,FormControl, Validators } from '@angular/forms';
import { Router } from "@angular/router";    

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})


export class LoginComponent {
 

  loginSignUpHeading:String = "Login:"
  newOrExistingUser:String = "Don't have an account?"
  loginOrRegister:String = "Create an Account"

  show:boolean = false;

  constructor() { }


 
    public input: any;


    constructor( private router: Router) {
        this.input = {
            "email": "",
            "password": ""
        };
    }

    Login()
    {
      this.router.navigate(["/login"]);
    }

  showPassword()
  {
    this.show = !this.show;
  } 

  switchBetweenLoginAndSignUp()
  {
    if(this.loginSignUpHeading === "Login:")
    {
      this.loginSignUpHeading = "Sign Up:";
      this.newOrExistingUser = "Already have an account?";
      this.loginOrRegister = "Back to Login Page";
    }
    else
    {
      this.loginSignUpHeading = "Login:";
      this.newOrExistingUser = "Don't have an account?";
      this.loginOrRegister = "Create an Account";
    }
  }

}

