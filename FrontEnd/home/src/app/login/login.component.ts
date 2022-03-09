import { Component} from '@angular/core';
import { FormGroup,FormControl, Validators } from '@angular/forms';
import { Router } from "@angular/router";    

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent {
 

 
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

}